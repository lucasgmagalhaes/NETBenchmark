namespace DOTNET_6
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> Find(int fetchSize, int minId);
    }
}
