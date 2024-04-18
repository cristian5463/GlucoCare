using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlucoCare.source.Domain.Entities
{
    public class ConfigEntityConfiguration : IEntityTypeConfiguration<ConfigEntity>
    {
        public void Configure(EntityTypeBuilder<ConfigEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.ApplyInsulinSnack)
                .IsRequired();

            builder.Property(c => c.UseCarbsCalc)
                .IsRequired();
        }
    }
}