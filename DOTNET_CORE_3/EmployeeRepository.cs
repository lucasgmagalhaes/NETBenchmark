using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DOTNET_CORE_3
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnection _connection;

        public EmployeeRepository(IDbConnection con)
        {
            _connection = con;
        }

        public Task<IEnumerable<Employee>> Find(int fetchSize, int minId)
        {
            return _connection.QueryAsync<Employee>("select * from humanresources.employee where businessentityid > @minId limit @fetchSize", new { fetchSize, minId });
        }
    }
}
