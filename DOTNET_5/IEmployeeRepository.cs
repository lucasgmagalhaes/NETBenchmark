namespace DOTNET_5
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> Find(int fetchSize, int minId);
    }
}
