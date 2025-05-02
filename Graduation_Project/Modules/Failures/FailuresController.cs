using Graduation_Project.Core.JSend;
using Graduation_Project.Modules.Failures.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers
{
    [Route("api/failures")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class FailuresController(IFailuresService failuresService) : ControllerBase
    {
        
        [HttpGet]
        public async Task<IActionResult> GetAll([FromRoute] int machineId)
        {
            var failures = await failuresService.GetAll();
            return JSend.Success(data:failures);
        }
        
        [HttpGet("{failureId:int}")]
        public async Task<IActionResult> GetById([FromRoute] int failureId)
        {
              var failure = await failuresService.GetById(failureId);
              return JSend.Success(data:failure);
        }
        
        [HttpPost("{failureId:int}/resolve")]
        public async Task<IActionResult> Add([FromRoute] int failureId,[FromBody] DateTimeOffset? endDateTimeOffset)
        {
            await failuresService.Resolve(failureId,endDateTimeOffset);
            return JSend.Created(message:"Failure Resolved Successfully");
        }

        
    }
}