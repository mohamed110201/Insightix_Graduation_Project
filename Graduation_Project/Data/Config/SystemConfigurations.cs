using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Graduation_Project.Data.Config
{
    public class SystemConfigurations : IEntityTypeConfiguration<Models.System>
    {
        public void Configure(EntityTypeBuilder<Models.System> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("nvarchar")
                .HasMaxLength(25)
                .IsRequired();

            builder.ToTable("Systems");

        }
    }
}
