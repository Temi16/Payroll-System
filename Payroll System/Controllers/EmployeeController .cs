using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payroll_System.DTO_s.EmployeesDto;
using Payroll_System.Interface.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService) => (_employeeService) = (employeeService);
        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> Create([FromForm] CreateEmployeeRequestModel model, CancellationToken cancellationToken)
        {
            var response = await _employeeService.CreateEmployee(model, cancellationToken);
            return (response.Status) ? Ok(response) : BadRequest(response);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _employeeService.ViewAllEmployees();
            return (response.Status) ? Ok(response) : NotFound(response);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _employeeService.GetById(id);
            return (response.Status) ? Ok(response) : NotFound(response);
        }

        [HttpGet("GetByCadreLevel/{cadreLevelId}")]
        public async Task<IActionResult> GetByCadreLevel(Guid cadreLevelId)
        {
            var response = await _employeeService.ViewAllEmployeesByCadreLevel(cadreLevelId);
            return (response.Status) ? Ok(response) : NotFound(response);
        }
    }
}
