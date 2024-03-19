using GlucoCare.source.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlucoCareApi.source.Domain.Entities
{
    public class InsulinEntityConfiguration : IEntityTypeConfiguration<InsulinEntity>
    {
        public void Configure(EntityTypeBuilder<InsulinEntity> builder)
        {
            // Define the primary key for the 'Insulin' table
            builder.HasKey(t => t.Id);

            // Configure properties with their constraints:
            builder.Property(p => p.NameInsulin)
                .HasMaxLength(100) // Maximum length of 100 characters
                .IsRequired();     // Not nullable

            builder.Property(p => p.IndividualApplication)
                .IsRequired();      // Not nullable

            // Validate typesInsulin array (assuming it should not be null or empty)
            builder.Property(p => p.TypesInsulin)
                .IsRequired();     // Not nullable

            builder.Property(p => p.IdUser)
                .IsRequired();      // Not nullable
        }
    }
}
