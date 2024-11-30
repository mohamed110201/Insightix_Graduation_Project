namespace Graduation_Project.Data.Models
{
    public class MonitoringAttribute
    {
        public int Id {  get; set; }
        public string? Name { get; set; }
        public string? Unit {  get; set; }

        public List<MachineType> MachineTypes { get; set;}
    }
}
