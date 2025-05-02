using Graduation_Project.Core.JSend;
using Graduation_Project.Data.Dtos.SystemDto;
using Graduation_Project.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers
{
    [Route("api/systems")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SystemsController(ISystemsService systemsService) : ControllerBase
    {
      
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var systems =await  systemsService.GetAll();
            return JSend.Success(data:systems);
        }

        [HttpGet("{systemId:int}")]
        public async Task<IActionResult> GetById([FromRoute]int systemId)
        {
            var system = await systemsService.GetById(systemId);
            return JSend.Success(data:system);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddSystemDto AddSystemDto)
        {
            await systemsService.Add(AddSystemDto);
            return JSend.Created("System Was Added Successfully");
        }
    }
}
