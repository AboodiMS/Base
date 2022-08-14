using Base.Modules.Users.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.DAL.Database.Configurations
{
    internal sealed class CustomPowerConfiguration : IEntityTypeConfiguration<CustomPower>
    {
        public void Configure(EntityTypeBuilder<CustomPower> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(e => new { e.Name }, "IX_CustomPower_Name").IsUnique();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CodeName).HasMaxLength(100);
            builder.Property(x => x.Note).HasMaxLength(1000);
            builder.Property(x => x.Powers);
        }
    }
}
