﻿
namespace Graduation_Project.Data.Config
{
    public class ResourceConsumptionAttributeConfig : IEntityTypeConfiguration<ResourceConsumptionAttribute>
    {
        public void Configure(EntityTypeBuilder<ResourceConsumptionAttribute> builder)
        {
            builder.ToTable("ResourceConsumptionAttributes");
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.Name).IsRequired();
            builder.Property(x => x.Unit).IsRequired();
        }
    }
}
