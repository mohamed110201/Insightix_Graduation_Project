
namespace Graduation_Project.Data.Config
{
    public class MachineTypeMonitoringAttributeConfigurations : IEntityTypeConfiguration<MachineTypeMonitoringAttribute>
    {
        public void Configure(EntityTypeBuilder<MachineTypeMonitoringAttribute> builder)
        {
            builder.ToTable("MachineTypeMonitoringAttributes");
        }
    }
}
