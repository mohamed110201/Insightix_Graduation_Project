using Graduation_Project.Data.Config;
using Graduation_Project.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;
using Graduation_Project.Data.FunctionsData;
using Machine = Graduation_Project.Data.Models.Machine;

namespace Graduation_Project.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {

        public DbSet<Models.System> Systems { get; set; }
        public DbSet<MachineType>  MachineTypes { get; set; }
        public DbSet<Machine>  Machines { get; set; }
        public DbSet<MonitoringAttribute>  MonitoringAttributes  { get; set; }
        public DbSet<ResourceConsumptionAttribute>  ResourceConsumptionAttributes  { get; set; }
        public DbSet<MachineTypeMonitoringAttribute>  MachineTypeMonitoringAttributes  { get; set; }
        public DbSet<MachineTypeResourceConsumptionAttribute>  MachineTypeResourceConsumptionAttributes  { get; set; }
        public DbSet<MonitoringData>  MonitoringData  { get; set; }
        public DbSet<Alert>  Alerts  { get; set; }
        public DbSet<MonitorAttributeAlertRule>  MonitorAttributeAlertRules   { get; set; }
        public DbSet<ResourceConsumptionAttributeAlertRule>  ResourceConsumptionAttributeAlertRules   { get; set; }
        public DbSet<ResourceConsumptionData> ResourceConsumptionData { get; set; }
        public DbSet<Failure> Failures { get; set; }

        public DbSet<AlertChangeLog> AlertChangeLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            
            modelBuilder.Entity<MachineMonitoringData>().HasNoKey(); 
            modelBuilder.Entity<CurrentMonitoringAttributesValues>().HasNoKey();
            modelBuilder.Entity<MachineResourceConsumptionData>().HasNoKey();


            modelBuilder
                .HasDbFunction(() => DownSamplingMonitoringData(default, default, default, default, default))
                .HasName("DownSamplingMonitoringData")
                .HasSchema("dbo");

            modelBuilder
                .HasDbFunction(() => DownSamplingResourceConsumptionData(default, default, default, default, default))
                .HasName("DownSamplingResourceConsumptionData")
                .HasSchema("dbo");

            modelBuilder
                .HasDbFunction(() => GetCurrentMonitoringAttributesForMachine(default))
                .HasName("GetCurrentMonitoringAttributesForMachine")
                .HasSchema("dbo");
        }
        
        public IQueryable<MachineMonitoringData> DownSamplingMonitoringData(
            int machineId,
            int monitoringAttributeId,
            int windowSize,
            DateTime startDate,
            DateTime endDate)
        {
            return FromExpression(() => DownSamplingMonitoringData(machineId, monitoringAttributeId, windowSize, startDate, endDate));
        }

        public IQueryable<MachineResourceConsumptionData> DownSamplingResourceConsumptionData(
            int machineId,
            int ResourceConsumptionAttributeId,
            int windowSize,
            DateTime startDate,
            DateTime endDate)
        {
            return FromExpression(() => DownSamplingResourceConsumptionData(machineId, ResourceConsumptionAttributeId, windowSize, startDate, endDate));
        }

        public IQueryable<CurrentMonitoringAttributesValues> GetCurrentMonitoringAttributesForMachine(int machineId)
        {
            return FromExpression(() => GetCurrentMonitoringAttributesForMachine(machineId));
        }
    }
}
