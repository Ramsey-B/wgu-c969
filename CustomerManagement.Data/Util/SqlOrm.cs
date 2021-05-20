using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerManagement.Core.Interfaces;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Reflection;
using CustomerManagement.Core.Attributes;
using CustomerManagement.Core.Exceptions;

namespace CustomerManagement.Data.Util
{
    /// <summary>
    /// This is my custom ORM. Normally I would just use
    /// Dapper but this projects requirements specify no
    /// third party libraries so I built my own.
    /// </summary>
    public class SqlOrm : ISqlOrm
    {
        private readonly string _connectionString;
        public SqlOrm(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> ExecuteAsync(string sqlStatement, object parameters = null)
        {
            var result = await ExecuteScalarAsync(sqlStatement, parameters);
            return Convert.ToInt32(result);
        }

        public async Task<T> QueryAsync<T>(string sqlStatement, object parameters = null) where T : new()
        {
            var result = await QueryListAsync<T>(sqlStatement, parameters) ?? new List<T>();
            return result.FirstOrDefault();
        }

        public async Task<List<T>> QueryListAsync<T>(string sqlStatement, object parameters = null) where T : new()
        {
            return await ExecuteAsync<T>(sqlStatement, parameters) ?? new List<T>();
        }

        public async Task<T> QueryAsync<T>(string sqlStatement, int id) where T : new()
        {
            return await QueryAsync<T>(sqlStatement + $" WHERE id = @id;", new { id });
        }

        public async Task<int> CreateEntityAsync(string sql, object parameters)
        {
            // Appends the Last inserted id mysql func so that the Id is returned instead of the row count. 
            sql = sql.EndsWith(";") ? sql : sql + ";";
            sql += " SELECT LAST_INSERT_ID();"; // gets the last inserted id
            return await ExecuteAsync(sql, parameters);
        }

        public async Task<int> DeleteAsync(int id, string tableName)
        {
            return await ExecuteAsync($"DELETE FROM {tableName} WHERE id = @id", new { id });
        }

        private IDbConnection GetConnection()
        {
            return new MySqlConnection(_connectionString); // generates a new connection to the DB.
        }

        /// <summary>
        /// Used to get a single column in return. 
        /// </summary>
        private async Task<string> ExecuteScalarAsync(string sql, object parameters = null)
        {
            using (var connection = GetConnection() as MySqlConnection) // Dispose of the connection to prevent a memory leak
            {
                try
                {
                    connection.Open(); // start the connection to the DB
                    var cmd = new MySqlCommand(sql, connection); // creates a new command
                    AddParameters(ref cmd, parameters);

                    var result = await cmd.ExecuteReaderAsync(); // executes the command

                    if (!result.HasRows) return default;

                    result.Read();
                    return result[0].ToString();
                }
                catch (Exception ex)
                {
                    throw new SqlException(ex.Message, ex);
                }
                finally
                {
                    connection.Close(); // ensures that even if the request throws an exception, we still close the connection.
                }
            }
        }

        private async Task<List<T>> ExecuteAsync<T>(string sql, object parameters = null) where T : new()
        {
            using(var connection = GetConnection() as MySqlConnection) // Dispose of the connection to prevent a memory leak
            {
                try
                {
                    connection.Open(); // start the connection to the DB
                    var cmd = new MySqlCommand(sql, connection); // creates a new command
                    AddParameters(ref cmd, parameters);

                    var result = await cmd.ExecuteReaderAsync(); // executes the command

                    if (!result.HasRows) return null;

                    var items = new List<T>();

                    // map the results to the object types
                    while (result.Read())
                    {
                        var item = MapColumns<T>(result);

                        if (item != null)
                        {
                            items.Add(item);
                        }
                    }

                    return items;
                }
                catch (Exception ex)
                {
                    throw new SqlException(ex.Message, ex);
                }
                finally
                {
                    connection.Close(); // ensures that even if the request throws an exception, we still close the connection.
                }
            }
        }

        private void AddParameters(ref MySqlCommand command, object parameters = null)
        {
            if (parameters == null) return;

            var props = parameters.GetType().GetProperties().ToList(); // get the properties from the parameters with reflection

            foreach (var prop in props) // iterate properties
            {
                var value = prop.GetValue(parameters); // get the value of the property
                var name = prop.GetCustomAttribute<ColumnAttribute>()?.ColumnName ?? prop.Name;

                command.Parameters.AddWithValue(name, value);
            }
        }

        private T MapColumns<T>(DbDataReader result) where T : new()
        {
            var instance = new T(); // create a new instance of the generic type. This is why I use the type constraint of new(). This prevents things like interfaces from being used.
            var props = instance.GetType().GetProperties().ToList();  // get the properties from the parameters with reflection

            for (int i = 0; i < result.FieldCount; i++) // iternate over the columns in the row
            {
                try
                {
                    // Find the property that has a Column attribute that matches the column name
                    var prop = props.Find(p => p.GetCustomAttribute<ColumnAttribute>()?.ColumnName?.ToLower() == result.GetName(i).ToLower());
                    if (prop == null)
                    {
                        // if no property has the attribute that matches the column name, try the property name
                        prop = props.Find(p => p.Name.ToLower() == result.GetName(i).ToLower());
                    }
                    if (prop == null) continue; // if no property matches, then ignore this column.

                    prop.SetValue(instance, result[i], null); // set the column value on the object.
                }
                catch (Exception ex)
                {
                    throw new SqlException($"Unable to map column '{result.GetName(i)}' with value {result[i]}", ex);
                }
            }

            return instance;
        }
    }
}
