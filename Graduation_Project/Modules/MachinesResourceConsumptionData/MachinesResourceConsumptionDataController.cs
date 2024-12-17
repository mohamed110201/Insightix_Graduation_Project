using Graduation_Project.Core.JSend;
using Graduation_Project.Data;
using Graduation_Project.Modules.Machines.Service;
using Graduation_Project.Modules.MachinesResourceConsumptionData.Service;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Modules.MachinesResourceConsumptionData
{
    [Route("api/machines/{machineId:int}/resource-consumption-data")]
    [ApiController]
    public class MachinesResourceConsumptionDataController(IMachinesResourceConsumptionDataService machinesResourceConsumptionDataService) : ControllerBase
    {
        [HttpGet("resource-consumption-attribute/{resourceConsumptionAttributeId:int}/line-chart")]
        public async Task<IActionResult> GetAll([FromRoute]int machineId
            ,[FromRoute]int resourceConsumptionAttributeId
            , [FromQuery]int? lastSeconds)
        {
            var ResourceConsumptionData = await machinesResourceConsumptionDataService.GetAll(machineId, resourceConsumptionAttributeId, lastSeconds);
            return JSend.Success(data: ResourceConsumptionData);
        }

        [HttpGet("resource-consumption-attribute/{resourceConsumptionAttributeId:int}/summary")]
        public async Task<IActionResult> GetSummary([FromRoute] int machineId
            , [FromRoute] int resourceConsumptionAttributeId
            , [FromQuery] int? lastSeconds)

        {
            var summary = await machinesResourceConsumptionDataService.GetSummary(machineId, resourceConsumptionAttributeId, lastSeconds);
            return JSend.Success(data: summary);
        }



    }
}