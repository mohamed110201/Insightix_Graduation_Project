namespace Graduation_Project.Data.Dtos.Machine
{
    public class GetMachinesBySystemIdDto
    {
        public int Id { get; set; }
        public string MachineTypeName { get; set; } = null!;
        public int MachineTypeId { get; set; }
        public string SerialNumber { get; set; } = null!;
    }
}
