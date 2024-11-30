namespace Graduation_Project.Data.Models
{
    public class Machine
    {
        public int Id { get; set; }
        public int SystemId { get; set; }
        public System System { get; set; } = null!;
        public int MachineTypeId { get; set; }
        public MachineType MachineType { get; set; } = null!;
        public string SerialNumber { get; set; } = null!;
        public ICollection<Alert> Alerts { get; set; } = new List<Alert>();
        public List<MonitoringData> MonitoringData { get; set; } = [];
        public List<ResourceConsumptionData> ResourceConsumptionData { get; set; } = [];

    }
}
