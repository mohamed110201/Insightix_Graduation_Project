
namespace Graduation_Project.Data.Config
{
    public class ResourceConsumptionDataConfigurations : IEntityTypeConfiguration<ResourceConsumptionData>
    {
        public void Configure(EntityTypeBuilder<ResourceConsumptionData> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TimeStamp).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Value).HasColumnType("int").IsRequired();

            builder.HasOne(x => x.Machine)
                .WithMany(x => x.ResourceConsumptionData)
                .HasForeignKey(x => x.MachineId)
                .IsRequired();

            builder.HasOne(x => x.MachineTypeResourceConsumptionAttribute)
                .WithMany(x => x.ResourceConsumptionData)
                .HasForeignKey(x => x.MachineTypeResourceConsumptionAttributeId)
                .IsRequired();

            builder.ToTable("ResourceConsumptionData");
        }
    }
}
