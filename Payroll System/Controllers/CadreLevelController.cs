using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payroll_System.DTO_s.CadreLevelDto;
using Payroll_System.Interface.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadreLevelController : ControllerBase
    {
        private readonly ICadreLevelService _cadreLevelService;
        public CadreLevelController(ICadreLevelService cadreLevelService) => (_cadreLevelService) = (cadreLevelService);
        [HttpPost("CreateCadreLevel")]
        public async Task<IActionResult> Create([FromForm] CreateCadreLevelRequestModel model)
        {
            var response = await _cadreLevelService.CreateCadreLevel(model);
            return (response.Status) ? Ok(response) : BadRequest(response);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _cadreLevelService.ViewAllCadreLevels();
            return (response.Status) ? Ok(response) : NotFound(response);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _cadreLevelService.GetById(id);
            return (response.Status) ? Ok(response) : NotFound(response);
        }
       
    }
}
