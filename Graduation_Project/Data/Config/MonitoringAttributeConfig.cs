
namespace Graduation_Project.Data.Config
{
    public class MonitoringAttributeConfig : IEntityTypeConfiguration<MonitoringAttribute>
    {
        public void Configure(EntityTypeBuilder<MonitoringAttribute> builder)
        {
            builder.ToTable("MonitoringAttributes");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasColumnType("nvarchar")
                .HasMaxLength(25);

            builder.Property(e => e.Unit).HasColumnType("nvarchar")
                .HasMaxLength(25);
                

        }
    }
}
