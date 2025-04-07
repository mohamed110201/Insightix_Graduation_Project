
namespace Graduation_Project.Data.Config
{
    public class MonitoringAttributeConfig : IEntityTypeConfiguration<MonitoringAttribute>
    {
        public void Configure(EntityTypeBuilder<MonitoringAttribute> builder)
        {
            builder.ToTable("MonitoringAttributes");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name);

            builder.Property(e => e.Unit);
            builder.HasData(
                new MonitoringAttribute { Id = 1001, Name = "Flag roping", Unit = "None" },
                new MonitoringAttribute { Id = 1002, Name = "Platform Position", Unit = "degree" },
                new MonitoringAttribute { Id = 1003, Name = "Platform Motor frequency", Unit = "HZ" },
                new MonitoringAttribute { Id = 1004, Name = "Temperature platform drive", Unit = "degree" },
                new MonitoringAttribute { Id = 1005, Name = "Temperature slave drive", Unit = "degree" },
                new MonitoringAttribute { Id = 1006, Name = "Temperature hoist drive", Unit = "degree" },
                new MonitoringAttribute { Id = 1007, Name = "Tensione totale film", Unit = "%" },
                new MonitoringAttribute { Id = 1008, Name = "Current speed cart", Unit = "%" },
                new MonitoringAttribute { Id = 1009, Name = "Platform motor speed", Unit = "%" },
                new MonitoringAttribute { Id = 1010, Name = "Lifting motor speed", Unit = "RPM" },
                new MonitoringAttribute { Id = 1011, Name = "Platform rotation speed", Unit = "RPM" },
                new MonitoringAttribute { Id = 1012, Name = "Slave rotation speed", Unit = "M/MIN" },
                new MonitoringAttribute { Id = 1013, Name = "Lifting speed rotation", Unit = "M/MIN" }
            );


        }
    }
}
