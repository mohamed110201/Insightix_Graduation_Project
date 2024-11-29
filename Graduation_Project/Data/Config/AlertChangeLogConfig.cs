using Graduation_Project.Data.Enums;
using Graduation_Project.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Graduation_Project.Data.Config;

public class AlertChangeLogConfig:IEntityTypeConfiguration<AlertChangeLog>
{
    public void Configure(EntityTypeBuilder<AlertChangeLog> builder)
    {
        
        builder.ToTable("AlertChangeLogs");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.TimeStamp);
        
        builder.Property(x=>x.Status).HasConversion(new EnumToStringConverter<AlertStatus>());
        
        builder.Property(x => x.AlertId);
        

    }
}