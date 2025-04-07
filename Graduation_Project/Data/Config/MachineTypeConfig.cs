

namespace Graduation_Project.Data.Config
{
    public class MachineTypeConfig : IEntityTypeConfiguration<MachineType>
    {
        public void Configure(EntityTypeBuilder<MachineType> builder)
        {
            builder.ToTable("MachineTypes");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.AIModelName);

            builder.Property(x => x.Model);

            builder.HasMany(x => x.MonitoringAttributes)
                .WithMany(x => x.MachineTypes)
                .UsingEntity<MachineTypeMonitoringAttribute>();
                 

            builder.HasMany(x => x.ResourceConsumptionAttributes)
                .WithMany(x => x.MachineTypes)
                .UsingEntity<MachineTypeResourceConsumptionAttribute>();
            builder.HasData(
                new MachineType {Id = 1001 , Name = "Wrapper Machine" , Model = "Wr001" , AIModelName = "best_model_overall.h5"}
            );


        }
    }
}
