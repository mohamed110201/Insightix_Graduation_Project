namespace Graduation_Project.Data.Config
{
    public class MachineConfigurations : IEntityTypeConfiguration<Machine>
    {
        public void Configure(EntityTypeBuilder<Machine> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SerialNumber)
                .HasColumnType("nvarchar")
                .IsRequired();

            builder.HasOne(x => x.System)
                .WithMany(x=>x.Machines)
                .HasForeignKey(x=>x.SystemId)
                .IsRequired();

            builder.HasOne(x => x.MachineType)
                .WithMany(x => x.Machines)
                .HasForeignKey(x => x.MachineTypeId)
                .IsRequired();

            builder.ToTable("Machines");

        }
    }
}
