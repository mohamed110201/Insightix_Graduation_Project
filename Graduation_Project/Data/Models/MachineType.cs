namespace Graduation_Project.Data.Models
{
    public class MachineType
    {
        public int Id { get; set; }
        public string Name { get; set; } =null!;
        public string Model { get; set; } = null!;
        public List<Machine> Machines { get; set; } = [];
        public List<MonitoringAttribute> MonitoringAttributes { get; set; } = [];
        public List<MachineTypeMonitoringAttribute> MachineTypeMonitoringAttributes {  get; set; } = [];
        public List<ResourceConsumptionAttribute> ResourceConsumptionAttributes { get; set; } = [];
        public List<MachineTypeResourceConsumptionAttribute> MachineTypeResourceConsumptionAttributes { get; set; } = [];

    }
}
