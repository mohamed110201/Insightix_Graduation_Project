using Graduation_Project.Data.Dtos.MachineTypeDto;
using Graduation_Project.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MachineTypesController(IMachineTypeServices machineTypeServices) : Controller
{
    private readonly IMachineTypeServices _machineTypeServices = machineTypeServices;
    [HttpGet]
    public async Task<IActionResult> GetAllMachineTypes()
    {
        try
        {
            var machineTypes = await _machineTypeServices.GetAllMachineTypesAsync();
            return Ok(machineTypes);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetMachineTypeById(int id)
    {
        try
        {
            var machineType = await _machineTypeServices.GetMachineTypeByIdAsync(id);
            return Ok(machineType);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPost]

    public async Task<IActionResult> CreateMachineType(MachineTypeRequestDto machineTypeRequestDto)
    {
        
        try
        {
            var machineTypeCreated = await _machineTypeServices.AddMachineTypeAsync(machineTypeRequestDto);
            return Created(machineTypeCreated.Id.ToString(), machineTypeCreated);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
    
}