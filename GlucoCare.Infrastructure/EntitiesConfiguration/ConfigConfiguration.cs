using GlucoCare.Domain.Entities;
using GlucoCare.source.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlucoCareApi.source.Domain.Entities
{
    public class ConfigEntityConfiguration : IEntityTypeConfiguration<ConfigEntity>
    {
        public void Configure(EntityTypeBuilder<ConfigEntity> builder)
        {

            builder.Property(c => c.ApplyInsulinSnack)
                .IsRequired();

            builder.Property(c => c.UseCarbsCalc)
                .IsRequired();
        }
    }
}
