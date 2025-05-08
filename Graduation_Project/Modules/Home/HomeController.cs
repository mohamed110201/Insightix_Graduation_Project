using Graduation_Project.Core.JSend;
using Graduation_Project.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Modules.Home
{
    [Route("api/home")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class HomeController(AppDbContext dbContext) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var counts = new 
            {
                NoMachines = await dbContext.Machines.CountAsync(),
                NoSystems = await dbContext.Systems.CountAsync(),
                NoMachineTypes = await dbContext.MachineTypes.CountAsync()
            };

            var systemMachineCounts = await dbContext.Systems
                .Select(system => new 
                {
                    SystemId = system.Id,
                    SystemName = system.Name,
                    MachinesCount = system.Machines.Count()
                })
                .ToListAsync();

            return JSend.Success(data: new
            {
                Counts = counts,
                SystemMachineCounts = systemMachineCounts
            });
        }

    }
    
}