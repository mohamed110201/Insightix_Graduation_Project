using Graduation_Project.Data.Config;
using Graduation_Project.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;
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
        
        public DbSet<MonitorAttributeAlertRule>  MonitorAttributeAlertRules   { get; set; }
        public DbSet<ResourceConsumptionAttributeAlertRule>  ResourceConsumptionAttributeAlertRules   { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
