using Graduation_Project.Controllers.Repository;
using Graduation_Project.Core.JSend;
using Graduation_Project.Data.Dtos.Machine;
using Graduation_Project.Modules.Failures.DTOs;
using Graduation_Project.Services.Implementation;
using Graduation_Project.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers
{
    [Route("api/machines/{machineId:int}/failures")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class MachineFailuresController(IMachineFailuresService machineFailuresService) : ControllerBase
    {
        
        [HttpGet]
        public async Task<IActionResult> GetAll([FromRoute] int machineId)
        {
            var failures = await machineFailuresService.GetAll(machineId);
            return JSend.Success(data:failures);
        }
        
        
        [HttpPost]
        public async Task<IActionResult> Add([FromRoute] int machineId,[FromBody] FailureAddDTO failureAddDto)
        {
            await machineFailuresService.Add(machineId,failureAddDto);
            return JSend.Created(message:"Failure Added To Machine Successfully");
        }

        
    }
}