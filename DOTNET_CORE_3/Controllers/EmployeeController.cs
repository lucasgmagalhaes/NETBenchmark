using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOTNET_CORE_3.Controllers
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
