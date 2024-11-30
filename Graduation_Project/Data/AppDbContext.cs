using Graduation_Project.Data.Config;
using Graduation_Project.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Project.Data
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions options): base(options)
        {
        }
        DbSet<Models.System> Systems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MachineConfigurations).Assembly);
          

        }
    }
}
