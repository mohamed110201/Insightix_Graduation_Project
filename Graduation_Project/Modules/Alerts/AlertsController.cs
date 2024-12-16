using Graduation_Project.Core.JSend;
using Graduation_Project.Modules.Alerts.Service;
using Graduation_Project.Modules.Machines.Service;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Modules.Alerts
{
    [Route("api/Alerts")]
    [ApiController]
    public class AlertsController(IAlertsService alertService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var alerts = await alertService.GetAll();
            return JSend.Success(data:alerts);
        }

        [HttpGet("{alertId:int}")]
        public async Task<IActionResult> GetById([FromRoute] int alertId)
        {
            var alert = await alertService.GetById(alertId);
            return JSend.Success(data:alert);
        }

        [HttpPost("{alertId:int}")]
        public async Task<IActionResult> ChangeStaus([FromRoute]int alertId, [FromBody]string status)
        {
            await alertService.ChangeStatus(alertId, status);
            return JSend.Edited("Status Changed Successfully");
        }


    }
}