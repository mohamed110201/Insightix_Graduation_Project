using Graduation_Project.Core.JSend;
using Graduation_Project.Data.Dtos.Machine;
using Graduation_Project.Services.Implementation;
using Graduation_Project.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers
{
    [Route("api/machines")]
    [ApiController]
    public class MachinesController(IMachinesService machinesService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var machines = await machinesService.GetAll();
            return JSend.Success(data:machines);
        }

        [HttpGet("{machineId:int}")]
        public async Task<IActionResult> GetById([FromRoute] int machineId)
        {
            var machine = await machinesService.GetById(machineId);
            return JSend.Success(data:machine);
        }

        


    }
}