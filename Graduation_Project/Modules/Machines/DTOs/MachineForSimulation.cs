namespace Graduation_Project.Modules.Machines.DTOs;

public class MachineForSimulationMonitoringAttribute
{
    public int MonitoringAttributeId{ get; set; }
    public double MinNormalRange{ get; set; }
    public double MaxNormalRange{ get; set; }
}

public class MachineForSimulationResourceConsumptionAttribute
{
    public int ResourceConsumptionAttributeId{ get; set; }
    public double MinNormalRange{ get; set; }
    public double MaxNormalRange{ get; set; }
}

public class MachineForSimulation
{
    public int MachineId{ get; set; } 
    public List<MachineForSimulationMonitoringAttribute> MonitoringAttributes { get; set; }
    public List<MachineForSimulationResourceConsumptionAttribute> ResourceConsumptionAttributes { get; set; }

}