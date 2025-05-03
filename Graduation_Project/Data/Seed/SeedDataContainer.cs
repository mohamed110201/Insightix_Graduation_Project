namespace Graduation_Project.Data;

public class SeedDataContainer
{
    public List<Models.System> Systems {get; set;}
    public List<MachineType> MachineTypes {get; set;}
    public List<Machine> Machines {get; set;}
    public List<MonitoringAttribute> MonitoringAttributes {get; set;}
    public List<ResourceConsumptionAttribute> ResourceConsumptionAttributes {get; set;}
    public List<MachineTypeMonitoringAttribute> MachineTypeMonitoringAttributes {get; set;}
    public List<MachineTypeResourceConsumptionAttribute> MachineTypeResourceConsumptionAttributes {get; set;}
    public List<MonitoringData> MonitoringData {get; set;}
    public List<ResourceConsumptionData> ResourceConsumptionData { get; set; }
    
    public List<MonitoringData> WrapperMachineData { get; set; }
    public List<MonitorAttributeAlertRule> MonitorAttributeAlertRule { get; set; }
    public List<ResourceConsumptionAttributeAlertRule> ResourceConsumptionAttributeAlertRule { get; set; }
    public List<MonitoringAlert> MonitoringAlert { get; set; }
    public List<ResourceConsumptionAlert> ResourceConsumptionAlert { get; set; }

}