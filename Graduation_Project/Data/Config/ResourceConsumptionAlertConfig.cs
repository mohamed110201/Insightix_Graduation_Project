using Graduation_Project.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Graduation_Project.Data.Config;

public class ResourceConsumptionAlertConfig:IEntityTypeConfiguration<ResourceConsumptionAlert>
{
    public void Configure(EntityTypeBuilder<ResourceConsumptionAlert> builder)
    {
        
        builder.Property(x => x.ResourceConsumptionAttributeAlertRuleId);
        
        builder.HasOne<ResourceConsumptionAttributeAlertRule>(x=>x.ResourceConsumptionAttributeAlertRule)
            .WithMany(x => x.Alerts)
            .HasForeignKey(x => x.ResourceConsumptionAttributeAlertRuleId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}