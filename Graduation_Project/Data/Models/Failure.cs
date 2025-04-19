using Graduation_Project.Data.Enums;

namespace Graduation_Project.Data.Models
{
    public class Failure
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public Machine Machine { get; set; } = null!;
        
        public DateTime StartDateTime { get; set;}
        public DateTime? EndDateTime { get; set; }
        
        public FailureStatus Status { get; set;}
    }
}
