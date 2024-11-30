

namespace Graduation_Project.Data.Config
{
    public class MachineTypeConfigurations : IEntityTypeConfiguration<MachineType>
    {
        public void Configure(EntityTypeBuilder<MachineType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("nvarchar")
                .HasMaxLength(25)
                .IsRequired();


            builder.HasMany(x=>x.MonitoringAttributes)
                .WithMany(x=>x.MachineTypes)
                .UsingEntity<MachineTypeMonitoringAttribute>();

            builder.HasMany(x => x.ResourceConsumptionAttributes)
                .WithMany(x => x.MachineTypes)
                .UsingEntity<MachineTypeResourceConsumptionAttribute>();

            builder.ToTable("MachineTypes");

        }
    }
}
