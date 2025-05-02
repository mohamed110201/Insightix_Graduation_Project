using Graduation_Project.Data.Enums;

namespace Graduation_Project.Data.Models
{
    public class Failure
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public Machine Machine { get; set; } = null!;
        
        public DateTimeOffset StartDateTimeOffset { get; set;}
        public DateTimeOffset? EndDateTimeOffset { get; set; }
        
        public FailureStatus Status { get; set;}
    }
}
