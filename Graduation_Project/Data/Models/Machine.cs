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
        public ICollection<Alert> Alerts { get; set; } = [];
        public ICollection<MonitoringData> MonitoringData { get; set; } = [];
        public ICollection<ResourceConsumptionData> ResourceConsumptionData { get; set; } = [];
        public ICollection<Failure> Failures { get; set; } = [];
        public DateTime? FailurePredictionCheckPoint { get; set; }

    }
}
