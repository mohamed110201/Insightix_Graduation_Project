using Graduation_Project.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation_Project.Data.Config;

public class MonitoringAlertConfig:IEntityTypeConfiguration<MonitoringAlert>
{
    public void Configure(EntityTypeBuilder<MonitoringAlert> builder)
    {
        builder.Property(x => x.MonitorAttributeAlertRuleId);
        
        builder.HasOne<MonitorAttributeAlertRule>(x=>x.MonitorAttributeAlertRule)
            .WithMany(x => x.Alerts)
            .HasForeignKey(x => x.MonitorAttributeAlertRuleId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}