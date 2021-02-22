using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagement.Models.Interfaces
{
    public interface ISqlOrm
    {
        Task<int> ExecuteAsync(string sqlStatement, object parameters = null);
        Task<T> QueryAsync<T>(string sqlStatement, object parameters = null);
        Task<List<T>> QueryListAsync<T>(string sqlStatement, object parameters = null);
    }
}
