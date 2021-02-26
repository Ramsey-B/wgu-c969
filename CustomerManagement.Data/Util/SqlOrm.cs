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

        public async Task<T> QueryAsync<T>(string sqlStatement, string tableName, int id) where T : new()
        {
            return await QueryAsync<T>(sqlStatement + $" WHERE {tableName + "Id"} = @Id;", new { Id = id });
        }

        public async Task<int> CreateEntityAsync(string sql, object parameters)
        {
            // Appends the Last inserted id mysql func so that the Id is returned instead of the row count. 
            sql = sql.EndsWith(";") ? sql : sql + ";";
            sql += " SELECT LAST_INSERT_ID();";
            return await ExecuteAsync(sql, parameters);
        }

        public async Task<int> DeleteAsync(int id, string tableName)
        {
            return await ExecuteAsync($"DELETE FROM {tableName} WHERE {tableName + "Id"} = @Id@", new { Id = id });
        }

        private IDbConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        private async Task<string> ExecuteScalarAsync(string sql, object parameters = null)
        {
            using (var connection = GetConnection() as MySqlConnection)
            {
                try
                {
                    connection.Open();
                    sql = AddParametersToSql(sql, parameters);
                    var cmd = new MySqlCommand(sql, connection);

                    var result = await cmd.ExecuteReaderAsync();

                    if (!result.HasRows) return default;

                    result.Read();
                    return result[0].ToString();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private async Task<List<T>> ExecuteAsync<T>(string sql, object parameters = null) where T : new()
        {
            using(var connection = GetConnection() as MySqlConnection)
            {
                try
                {
                    connection.Open();
                    sql = AddParametersToSql(sql, parameters);
                    var cmd = new MySqlCommand(sql, connection);

                    var result = await cmd.ExecuteReaderAsync();

                    if (!result.HasRows) return null;

                    var items = new List<T>();

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
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private string AddParametersToSql(string sql, object paramaters = null)
        {
            if (paramaters == null) return sql;

            var props = paramaters.GetType().GetProperties().ToList();

            foreach (var prop in props)
            {
                var value = prop.GetValue(paramaters);

                if (value is string)
                {
                    sql = sql.Replace($"@{prop.Name}@", $"'{value}'");
                }
                else if (value is DateTime date)
                {
                    var dateStr = date.ToString("yyyy-MM-dd hh:mm:ss");
                    sql = sql.Replace($"@{prop.Name}@", $"'{dateStr}'");
                }
                else
                {
                    sql = sql.Replace($"@{prop.Name}@", value?.ToString());
                }
            }

            return sql;
        }

        private T MapColumns<T>(DbDataReader result) where T : new()
        {
            var instance = new T();
            var props = instance.GetType().GetProperties().ToList();

            for (int i = 0; i < result.FieldCount; i++)
            {
                try
                {
                    var prop = props.Find(p => p.GetCustomAttribute<ColumnAttribute>()?.ColumnName?.ToLower() == result.GetName(i).ToLower());
                    if (prop == null)
                    {
                        prop = props.Find(p => p.Name.ToLower() == result.GetName(i).ToLower());
                    }
                    if (prop == null) continue;

                    prop.SetValue(instance, result[i], null);
                }
                catch (Exception ex)
                {
                    throw new SqlException($"Unable to map column '{result.GetName(i)}' with value {result[i]}");
                }
            }

            return instance;
        }
    }
}
