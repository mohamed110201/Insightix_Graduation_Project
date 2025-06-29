﻿namespace Graduation_Project.Data.Config
{
    public class MachineConfig : IEntityTypeConfiguration<Machine>
    {
        public void Configure(EntityTypeBuilder<Machine> builder)
        {
            builder.ToTable("Machines");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.SerialNumber);
            builder.Property(x => x.FailurePredictionCheckPoint);
            builder.HasOne(x => x.System)
                .WithMany(x => x.Machines)
                .HasForeignKey(x => x.SystemId)
                .IsRequired();

            builder.HasOne(x => x.MachineType)
                .WithMany(x => x.Machines)
                .HasForeignKey(x => x.MachineTypeId)
                .IsRequired();
            
        }
    }
}
