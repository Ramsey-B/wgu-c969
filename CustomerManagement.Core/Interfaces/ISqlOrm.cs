using CustomerManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Core.Interfaces
{
    public interface ISqlOrm
    {
        Task<int> ExecuteAsync(string sqlStatement, object parameters = null);
        Task<T> QueryAsync<T>(string sqlStatement, object parameters = null);
        Task<List<T>> QueryListAsync<T>(string sqlStatement, object parameters = null);
        Task<T> QueryAsync<T>(string sqlStatement, string tableName, int id);
        Task<int> CreateEntityAsync(string tableName, string sql, EntityBase entity, object parameters);
        Task<int> DeleteAsync(int id, string tableName);
    }
}
