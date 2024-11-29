using Graduation_Project.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation_Project.Data.Config;

public class ResourceConsumptionAttributeAlertRuleConfig:IEntityTypeConfiguration<ResourceConsumptionAttributeAlertRule>
{
    public void Configure(EntityTypeBuilder<ResourceConsumptionAttributeAlertRule> builder)
    {
        
        builder.ToTable("ResourceConsumptionAttributeAlertRules");

        builder.Property(x => x.MachineTypeResourceConsumptionAttributeId);
        
        builder.HasOne<MachineTypeResourceConsumptionAttribute>(x => x.MachineTypeResourceConsumptionAttribute)
            .WithMany(x=>x.AlertRules)
            .HasForeignKey(x=>x.MachineTypeResourceConsumptionAttributeId)
            .IsRequired();

    }
}