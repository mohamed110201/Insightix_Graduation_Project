using Graduation_Project.Core.JSend;
using Graduation_Project.Modules.FailuresPrediction.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Modules.FailuresPrediction
{
    [Route("api/failures-prediction")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class FailuresPredictionController(IFailuresPredictionService failuresPredictionService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var failurePredictions = await failuresPredictionService.GetAll();
            return JSend.Success(data:failurePredictions);
        }

    }
    
}