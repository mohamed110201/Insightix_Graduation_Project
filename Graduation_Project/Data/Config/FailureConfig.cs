
using Graduation_Project.Data.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Graduation_Project.Data.Config
{
    public class FailureConfig : IEntityTypeConfiguration<Failure>
    {
        public void Configure(EntityTypeBuilder<Failure> builder)
        {
            builder.ToTable("Failure");

            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.StartDateTimeOffset);
            
            builder.Property(x=>x.EndDateTimeOffset);
            
            builder.Property(x=>x.Status).HasConversion(new EnumToStringConverter<FailureStatus>());;

            builder.HasOne(x => x.Machine)
                .WithMany(x => x.Failures)
                .HasForeignKey(x => x.MachineId)
                .IsRequired();
            
        }
    }
}
