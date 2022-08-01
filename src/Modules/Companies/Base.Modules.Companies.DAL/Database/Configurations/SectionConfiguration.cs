
using Base.Modules.Companies.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.Modules.Companies.DAL.Database.Configurations
{
    internal sealed class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasKey(x => x.CodeName);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.HasIndex(e => new { e.Name }, "IX_Section_Name").IsUnique();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        }
    }
}
