using Base.Modules.Companies.Domain.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.Modules.Companies.DAL.Database.Configurations
{
    internal sealed class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(e => new { e.Name }, "IX_Company_Name").IsUnique();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CompanyWork).IsRequired().HasMaxLength(200);
            builder.Property(x => x.ActiveSections);
        }
    }
}
