namespace Graduation_Project.Data.Models
{
    public class System
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Machine> Machines { get; set; } = [];

    }
}
