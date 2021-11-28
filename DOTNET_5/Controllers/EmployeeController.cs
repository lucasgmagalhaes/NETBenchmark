using Microsoft.AspNetCore.Mvc;

namespace DOTNET_5.Controllers
{
    public class Params
    {
        public int FetchSize { get; set; }
        public int MinId { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> Get([FromQuery] Params param)
        {
            return await _employeeRepository.Find(param.FetchSize, param.MinId);
        }
    }
}