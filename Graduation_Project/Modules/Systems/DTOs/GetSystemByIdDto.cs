using Graduation_Project.Data.Dtos.Machine;

namespace Graduation_Project.Data.Dtos.SystemDto
{
    public class GetSystemByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<GetMachinesBySystemIdDto> Machines { get; set; } = [];
    }
}
