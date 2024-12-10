namespace Graduation_Project.Data.Dtos.Machine
{
    public class GetMachineByIdDto
    {
        //Will Be Adjusted Later
        public int Id { get; set; }
        public string SystemName { get; set; } = null!;
        public string MachineTypeName { get; set; } = null!;
        public string SerialNumber { get; set; } = null!;
    }
}
