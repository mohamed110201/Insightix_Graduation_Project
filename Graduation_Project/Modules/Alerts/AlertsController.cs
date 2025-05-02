using Graduation_Project.Core.JSend;
using Graduation_Project.Data;
using Graduation_Project.Modules.Alerts.Service;
using Graduation_Project.Modules.MachinesMonitoringData.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Modules.Alerts
{
    [Route("api/Alerts")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AlertsController(IAlertsService alertService , 
        ICreateAlertsService createAlertsService,
        AppDbContext _context) : ControllerBase
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
        [HttpPost("/test")]
        public async Task<IActionResult> Test([FromQuery]int machineId ,
            [FromQuery]DateTimeOffset startTime,
           [FromQuery] DateTimeOffset endTime)
        {
            var result = await _context.GetMachineMonitoringData(machineId,startTime, endTime);
            return JSend.Success(data:result);
        }

        
    }
}