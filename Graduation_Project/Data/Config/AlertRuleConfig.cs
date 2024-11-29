using Graduation_Project.Data.Enums;
using Graduation_Project.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Graduation_Project.Data.Config;

public class AlertRuleConfig:IEntityTypeConfiguration<AlertRule>
{
    public void Configure(EntityTypeBuilder<AlertRule> builder)
    { 
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Value);
        
        builder.Property(x => x.Severity).HasConversion(new EnumToStringConverter<AlertSeverity>());
        
        builder.Property(x => x.Condition).HasConversion(new EnumToStringConverter<AlertCondition>());
        
        builder.UseTpcMappingStrategy();
        
    }
}