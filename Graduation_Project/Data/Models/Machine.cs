namespace Graduation_Project.Data.Models
{
    public class Machine
    {
        public int Id { get; set; }
        public int SystemId { get; set; }
        public System System { get; set; }
        public int MachineTypeId { get; set; }
        public MachineType MachineType { get; set; }
        public string SerialNumber { get; set; }

        public List<MonitoringData>? MonitoringData { get; set; }
        public List<ResourceConsumptionData>? ResourceConsumptionData { get; set; }

    }
}
