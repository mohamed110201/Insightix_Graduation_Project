using Graduation_Project.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation_Project.Data.Config;

public class MonitorAttributeAlertRuleConfig:IEntityTypeConfiguration<MonitorAttributeAlertRule>
{
    public void Configure(EntityTypeBuilder<MonitorAttributeAlertRule> builder)
    {
        builder.ToTable("MonitorAttributeAlertRules");

        builder.Property(x => x.MachineTypeMonitoringAttributeId);
        
        builder.HasOne<MachineTypeMonitoringAttribute>(x => x.MachineTypeMonitoringAttribute)
            .WithMany(x => x.AlertRules)
            .HasForeignKey(x => x.MachineTypeMonitoringAttributeId)
            .IsRequired();

    }
}