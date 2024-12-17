using Graduation_Project.Core.JSend;
using Graduation_Project.Data;
using Graduation_Project.Modules.Machines.Service;
using Graduation_Project.Modules.MachinesMonitoringData.Service;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Modules.MachinesMonitoringData
{
    [Route("api/machines/{machineId:int}/monitoring-data")]
    [ApiController]
    public class MachinesMonitoringDataController(IMachinesMonitoringDataService machinesMonitoringDataService) : ControllerBase
    {
        [HttpGet("monitoring-attribute/{monitoringAttributeId:int}/line-chart")]
        public async Task<IActionResult> GetAll([FromRoute]int machineId
            ,[FromRoute]int monitoringAttributeId
            ,[FromQuery]int? lastSeconds)
        {
            var monitoringData = await machinesMonitoringDataService.GetAll(machineId, monitoringAttributeId, lastSeconds);
            return JSend.Success(data:monitoringData);
        }
        
        [HttpGet("monitoring-attribute/{monitoringAttributeId:int}/summary")]
        public async Task<IActionResult> GetSummary([FromRoute]int machineId
            ,[FromRoute]int monitoringAttributeId
            ,[FromQuery]int? lastSeconds)
           
        {
            var summary = await machinesMonitoringDataService.GetSummary(machineId, monitoringAttributeId, lastSeconds);
            return JSend.Success(data:summary);
        }


        [HttpGet("current")]
        public async Task<IActionResult> GetCurrent([FromRoute] int machineId)
        {
            var current = await machinesMonitoringDataService.GetCurrent(machineId);
            return JSend.Success(data:current);
        }
    }
}