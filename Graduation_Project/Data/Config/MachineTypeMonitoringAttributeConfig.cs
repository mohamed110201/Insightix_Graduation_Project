
namespace Graduation_Project.Data.Config
{
    public class MachineTypeMonitoringAttributeConfig : IEntityTypeConfiguration<MachineTypeMonitoringAttribute>
    {
        public void Configure(EntityTypeBuilder<MachineTypeMonitoringAttribute> builder)
        {
            builder.ToTable("MachineTypeMonitoringAttributes");
        }
    }
}
