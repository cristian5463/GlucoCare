using GlucoCare.Domain.Entities;
using GlucoCare.source.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlucoCareApi.source.Domain.Entities
{
    public class InsulinDoseEntityConfiguration : IEntityTypeConfiguration<InsulinDoseEntity>
    {
        public void Configure(EntityTypeBuilder<InsulinDoseEntity> builder)
        {
            // Define the primary key for the 'Insulin' table
            builder.HasKey(t => t.Id);

            // Configure properties with their constraints:
            builder.Property(p => p.IdTypeInsulin)
                .IsRequired();      // Not nullable

            // Validate typesInsulin array (assuming it should not be null or empty)
            builder.Property(p => p.Amount)
                .IsRequired();     // Not nullable

            builder.Property(p => p.Correction)
                .IsRequired();      // Not nullable
        }
    }
}
