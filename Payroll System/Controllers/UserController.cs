using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payroll_System.DTO_s.UserDtos;
using Payroll_System.Interface.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;
        public UserController(IUserService UserService) => (_UserService) = (UserService);
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] LoginRequestModel model, CancellationToken cancellationToken)
        {
            var response = await _UserService.Login(model, cancellationToken);
            return (response.Status) ? Ok(response) : BadRequest(response);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var response = _UserService.ViewAllUsers();
            return (response.Status) ? Ok(response) : NotFound(response);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var response = await _UserService.GetById(id, cancellationToken);
            return (response.Status) ? Ok(response) : NotFound(response);
        }
       
    }
}
