
namespace Graduation_Project.Data.Config
{
    public class MonitoringDataConfigurations : IEntityTypeConfiguration<MonitoringData>
    {
        public void Configure(EntityTypeBuilder<MonitoringData> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TimeStamp).HasColumnType("datetime").IsRequired();
            builder.Property(x=>x.Value).HasColumnType("int").IsRequired();

            builder.HasOne(x => x.Machine)
                .WithMany(x => x.MonitoringData)
                .HasForeignKey(x => x.MachineId)
                .IsRequired();

            builder.HasOne(x => x.MachineTypeMonitoringAttribute)
                .WithMany(x => x.MonitoringData)
                .HasForeignKey(x => x.MachineTypeMonitoringAttributeId)
                .IsRequired();
            builder.ToTable("MonitoringData");
        }
    }
}
