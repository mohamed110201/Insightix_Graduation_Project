
namespace Graduation_Project.Data.Config
{
    public class ResourceConsumptionDataConfig : IEntityTypeConfiguration<ResourceConsumptionData>
    {
        public void Configure(EntityTypeBuilder<ResourceConsumptionData> builder)
        {
            builder.ToTable("ResourceConsumptionData");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.TimeStamp).HasColumnType("datetime");
            builder.Property(x => x.Value).HasColumnType("int");

            builder.HasOne(x => x.Machine)
                .WithMany(x => x.ResourceConsumptionData)
                .HasForeignKey(x => x.MachineId)
                .IsRequired();

            builder.HasOne(x => x.ResourceConsumptionAttribute)
                .WithMany(x => x.ResourceConsumptionData)
                .HasForeignKey(x => x.ResourceConsumptionAttributeId)
                .IsRequired();

        }
    }
}
