namespace Graduation_Project.Data.Models
{
    public class MachineType
    {
        public int Id { get; set; }
        public string Name { get; set; } =null!;
        public string Model { get; set; } = null!;
        public string? AIModelName { get; set; }
        public ICollection<Machine> Machines { get; set; } = [];
        public ICollection<MonitoringAttribute> MonitoringAttributes { get; set; } = [];
        public ICollection<MachineTypeMonitoringAttribute> MachineTypeMonitoringAttributes {  get; set; } = [];
        public ICollection<ResourceConsumptionAttribute> ResourceConsumptionAttributes { get; set; } = [];
        public ICollection<MachineTypeResourceConsumptionAttribute> MachineTypeResourceConsumptionAttributes { get; set; } = [];

    }
}
