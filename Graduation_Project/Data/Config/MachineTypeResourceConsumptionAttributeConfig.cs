
namespace Graduation_Project.Data.Config
{
    public class MachineTypeResourceConsumptionAttributeConfig : IEntityTypeConfiguration<MachineTypeResourceConsumptionAttribute>
    {
        public void Configure(EntityTypeBuilder<MachineTypeResourceConsumptionAttribute> builder)
        {
            builder.ToTable("MachineTypeResourceConsumptionAttributes");
        }
    }
}
