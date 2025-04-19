
namespace Graduation_Project.Data.Config
{
    public class MachineTypeMonitoringAttributeConfig : IEntityTypeConfiguration<MachineTypeMonitoringAttribute>
    {
        public void Configure(EntityTypeBuilder<MachineTypeMonitoringAttribute> builder)
        {
            builder.ToTable("MachineTypeMonitoringAttributes");
            builder.HasData(
                new MachineTypeMonitoringAttribute { Id = 1, MachineTypeId = 1001, MonitoringAttributeId = 1001 },
                new MachineTypeMonitoringAttribute { Id = 2, MachineTypeId = 1001, MonitoringAttributeId = 1002 },
                new MachineTypeMonitoringAttribute { Id = 3, MachineTypeId = 1001, MonitoringAttributeId = 1003 },
                new MachineTypeMonitoringAttribute { Id = 4, MachineTypeId = 1001, MonitoringAttributeId = 1004 },
                new MachineTypeMonitoringAttribute { Id = 5, MachineTypeId = 1001, MonitoringAttributeId = 1005 },
                new MachineTypeMonitoringAttribute { Id = 6, MachineTypeId = 1001, MonitoringAttributeId = 1006 },
                new MachineTypeMonitoringAttribute { Id = 7, MachineTypeId = 1001, MonitoringAttributeId = 1007 },
                new MachineTypeMonitoringAttribute { Id = 8, MachineTypeId = 1001, MonitoringAttributeId = 1008 },
                new MachineTypeMonitoringAttribute { Id = 9, MachineTypeId = 1001, MonitoringAttributeId = 1009 },
                new MachineTypeMonitoringAttribute { Id = 10, MachineTypeId = 1001, MonitoringAttributeId = 1010 },
                new MachineTypeMonitoringAttribute { Id = 11, MachineTypeId = 1001, MonitoringAttributeId = 1011 },
                new MachineTypeMonitoringAttribute { Id = 12, MachineTypeId = 1001, MonitoringAttributeId = 1012 },
                new MachineTypeMonitoringAttribute { Id = 13, MachineTypeId = 1001, MonitoringAttributeId = 1013 }
            );

        }
    }
}
