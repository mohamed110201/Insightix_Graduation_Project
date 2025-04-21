namespace Graduation_Project.Modules.Machines.DTOs;

public class MachineForSimulationMonitoringAttribute
{
    public int MonitoringAttributeId{ get; set; }
    public int MinNormalRange{ get; set; }
    public int MaxNormalRange{ get; set; }
}

public class MachineForSimulation
{
    public int MachineId{ get; set; } 
    public List<MachineForSimulationMonitoringAttribute> MonitoringAttributes { get; set; }
}