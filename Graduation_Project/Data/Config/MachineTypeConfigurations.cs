

namespace Graduation_Project.Data.Config
{
    public class MachineTypeConfigurations : IEntityTypeConfiguration<MachineType>
    {
        public void Configure(EntityTypeBuilder<MachineType> builder)
        {
            builder.ToTable("MachineTypes");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("nvarchar")
                .HasMaxLength(25);
                

            builder.Property(x => x.Model).HasColumnType("nvarchar")
                .HasMaxLength(25);

            builder.HasMany(x => x.MonitoringAttributes)
                .WithMany(x => x.MachineTypes)
                .UsingEntity<MachineTypeMonitoringAttribute>();
                 

            builder.HasMany(x => x.ResourceConsumptionAttributes)
                .WithMany(x => x.MachineTypes)
                .UsingEntity<MachineTypeResourceConsumptionAttribute>();


        }
    }
}
