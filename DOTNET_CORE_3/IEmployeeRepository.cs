using System.Collections.Generic;
using System.Threading.Tasks;

namespace DOTNET_CORE_3
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> Find(int fetchSize, int minId);
    }
}
