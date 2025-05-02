using Graduation_Project.Data;
using Graduation_Project.Modules.Machines.DTOs;
using Graduation_Project.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Project.Repositories.Implementation
{
    public class MachinesRepository(AppDbContext dbContext) : IMachinesRepository
    {
        public async Task<List<Machine>> GetAll()
        {
            return await dbContext.Machines.Include(m => m.MachineType).Include(m => m.System).ToListAsync();
        }

        public async Task<Machine?> GetById(int id)
        {
            //Will Be Adjusted Later "Alerts,Monitoring....etc"
            return await dbContext.Machines.Include(m => m.MachineType).Include(m => m.System)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Machine>> GetMachinesByMachineTypeId(int machineTypeId)
        {
            return await dbContext.Machines
                .Where(m => m.MachineTypeId == machineTypeId)
                .ToListAsync();
        }

        public async Task AddMachineToSystem(int systemId, Machine machine)
        {
            machine.SystemId = systemId;
            dbContext.Machines.Add(machine);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Machine>> GetMachinesBySystemId(int systemId)
        {
            return await dbContext.Machines
                .Include(m => m.MachineType)
                .Where(m => m.SystemId == systemId)
                .ToListAsync();
        }

        public  Machine? SearchBySerialNumber(string serialNumber)
        {
           return  dbContext.Machines.FirstOrDefault(m => m.SerialNumber == serialNumber);
        }

        public async Task<List<MachineForSimulation>> GetMachinesForSimulation()
        {
         return await   dbContext.Machines.Include(m => m.MachineType)
                .ThenInclude(t => t.MachineTypeMonitoringAttributes)
                .Include(m => m.MachineType)
                .ThenInclude(t=>t.MachineTypeResourceConsumptionAttributes)
                
                .Select(m=>new MachineForSimulation()
                {
                    MachineId = m.Id,
                    MonitoringAttributes= m.MachineType.MachineTypeMonitoringAttributes.Select(a=>new MachineForSimulationMonitoringAttribute()
                    {
                        MonitoringAttributeId = a.MonitoringAttributeId,
                        MinNormalRange=a.LowerRange,
                        MaxNormalRange=a.UpperRange
                    }).ToList()
                    ,
                    ResourceConsumptionAttributes = m.MachineType.MachineTypeResourceConsumptionAttributes.Select(a=>new MachineForSimulationResourceConsumptionAttribute()
                    {
                        ResourceConsumptionAttributeId = a.ResourceConsumptionAttributeId,
                        MinNormalRange=a.LowerRange,
                        MaxNormalRange=a.UpperRange
                    }).ToList()
                }).ToListAsync();
        }
       
        
        public async Task<List<Machine>>GetMachinesForPrediction()
        {
            var machines = await dbContext.Machines.Where(x=>x.MachineType.AIModelName != null)
                .ToListAsync();
            return  machines;
        }

        public async Task<FailurePrediction> AddPrediction(int machineId, DateTime timestamp)
        {
            var prediction = new FailurePrediction(){MachineId = machineId, TimeStamp = timestamp};
            var failurePrediction = dbContext.FailurePredictions.Add(prediction);
            await dbContext.SaveChangesAsync();
            return failurePrediction.Entity;
        }
        
        public async Task UpdatePredictionCheckPoint(int machineId, DateTime checkPoint)
        {
            var machine = await dbContext.Machines.Where(m => m.Id == machineId)
                .ExecuteUpdateAsync(setters 
                    => setters.SetProperty(m => m.FailurePredictionCheckPoint,checkPoint));
                        await dbContext.SaveChangesAsync();
        }
        
    }
}

