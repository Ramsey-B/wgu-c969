using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CustomerManagement.Core.Interfaces;
using CustomerManagement.Core.Models;
using System.Data;
using MySql.Data.MySqlClient;

namespace CustomerManagement.Data.Util
{
    /// <summary>
    /// This is a wrapper for Dapper (the ORM of choice).
    /// It exists to make it easier to manage connections 
    /// and allows for swapping ORMs easier.
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
            using (var connnection = GetConnection())
            {
                return await connnection.ExecuteAsync(sqlStatement, parameters);
            }
        }

        public async Task<T> QueryAsync<T>(string sqlStatement, object parameters = null)
        {
            using (var connnection = GetConnection())
            {
                return await connnection.QueryFirstOrDefaultAsync<T>(sqlStatement, parameters);
            }
        }

        public async Task<List<T>> QueryListAsync<T>(string sqlStatement, object parameters = null)
        {
            using (var connnection = GetConnection())
            {
                var results = await connnection.QueryAsync<T>(sqlStatement, parameters);
                return results.ToList();
            }
        }

        public async Task<T> QueryAsync<T>(string sqlStatement, string tableName, int id)
        {
            return await QueryAsync<T>(sqlStatement + $" WHERE {tableName + "Id"} = @Id;", new { Id = id });
        }

        public async Task<int> CreateEntityAsync(string tableName, string sql, EntityBase entity, object parameters)
        {
            if (entity.Id != null) return (int)entity.Id;

            // Appends the Last inserted id mysql func so that the Id is returned instead of the row count. 
            sql = sql.EndsWith(";") ? sql : sql + ";";
            sql += " SELECT LAST_INSERT_ID();";
            return await QueryAsync<int>(sql, parameters);
        }

        public async Task<int> DeleteAsync(int id, string tableName)
        {
            return await ExecuteAsync($"DELETE FROM {tableName} WHERE {tableName + "Id"} = @Id", new { Id = id });
        }

        private IDbConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}
