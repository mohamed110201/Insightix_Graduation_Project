
namespace Graduation_Project.Data.Config
{
    public class MonitoringAttributeConfigurations : IEntityTypeConfiguration<MonitoringAttribute>
    {
        public void Configure(EntityTypeBuilder<MonitoringAttribute> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasColumnType("nvarchar")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(e => e.Unit).HasColumnType("nvarchar")
                .HasMaxLength(25)
                .IsRequired();

            builder.ToTable("MonitoringAttributes");




        }
    }
}
