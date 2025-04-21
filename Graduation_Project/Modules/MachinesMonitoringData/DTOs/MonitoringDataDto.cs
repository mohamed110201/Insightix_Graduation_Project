namespace Graduation_Project.Modules.MachinesMonitoringData.DTOs;

public class MonitoringDataDto
{
    public int MachineId { get; set; }
    public int MonitoringAttributeId { get; set; }
    public double Value { get; set; }
    
    public DateTime TimeStamp { get; set; }
}


