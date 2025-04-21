using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Graduation_Project.Data.Config
{
    public class SystemConfig : IEntityTypeConfiguration<Models.System>
    {
        public void Configure(EntityTypeBuilder<Models.System> builder)
        {
            builder.ToTable("Systems");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);

        }
    }
}
