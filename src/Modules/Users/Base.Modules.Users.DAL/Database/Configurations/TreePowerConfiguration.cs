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
    internal sealed class TreePowerConfiguration : IEntityTypeConfiguration<TreePower>
    {
        public void Configure(EntityTypeBuilder<TreePower> builder)
        {
            builder.HasKey(x => x.CodeName);
            builder.Property(x => x.Name);
            builder.Property(x => x.Num);
            builder.Property(x => x.IsEndPoint);
            builder.HasOne(x => x.Parent)
                   .WithMany(x => x.SubTreePowers)
                   .HasForeignKey(x => x.ParentCodeName)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
