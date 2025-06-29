﻿
namespace Graduation_Project.Data.Config
{
    public class MonitoringDataConfig : IEntityTypeConfiguration<MonitoringData>
    {
        public void Configure(EntityTypeBuilder<MonitoringData> builder)
        {
            builder.ToTable("MonitoringData");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.TimeStamp);
            builder.Property(x=>x.Value);

            builder.HasOne(x => x.Machine)
                .WithMany(x => x.MonitoringData)
                .HasForeignKey(x => x.MachineId)
                .IsRequired();

            builder.HasOne(x => x.MonitoringAttribute)
                .WithMany(x => x.MonitoringData)
                .HasForeignKey(x => x.MonitoringAttributeId)
                .IsRequired();
        }
    }
}
