using Dapper;
using System.Data;

namespace DOTNET_6
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
