using Graduation_Project.Data.Enums;
using Graduation_Project.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Graduation_Project.Data.Config;

public class AlertConfig:IEntityTypeConfiguration<Alert>
{
    public void Configure(EntityTypeBuilder<Alert> builder)
    {
        

        
        builder.ToTable("Alerts");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.TimeStamp);
        
        builder.Property(x=>x.Status).HasConversion(new EnumToStringConverter<AlertStatus>());
        
        builder.Property(x=>x.Type).HasConversion(new EnumToStringConverter<AlertType>());

        builder.Property(x => x.MachineId);

        builder.UseTphMappingStrategy();
        
        builder.HasDiscriminator<AlertType>(x=>x.Type)
            .HasValue<MonitoringAlert>(AlertType.Monitoring)
            .HasValue<ResourceConsumptionAlert>(AlertType.ResourceConsumption);

        
        builder.HasOne<Machine>(x=>x.Machine)
            .WithMany(x=>x.Alerts)
            .HasForeignKey(x=>x.MachineId)
            .IsRequired();
            

        builder.HasMany<AlertChangeLog>(x => x.ChangeLogs)
            .WithOne(x => x.Alert)
            .HasForeignKey(x => x.AlertId)
            .IsRequired();
        
    }
}