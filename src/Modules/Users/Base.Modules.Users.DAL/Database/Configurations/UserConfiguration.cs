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
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(e => new { e.Name, e.BusinessId }, "IX_User_Name").IsUnique(true).HasFilter<User>("\"IsDeleted\" = false");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.HasIndex(e => new { e.LoginName, e.BusinessId }, "IX_User_UserName").IsUnique(true).HasFilter<User>("\"IsDeleted\" = false");
            builder.Property(x => x.LoginName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.IsAdmin);
            builder.Property(x => x.HashPassword);
            builder.Property(x => x.HashCode);
            builder.Property(x => x.Email);
            builder.HasIndex(e => new { e.Email, e.BusinessId }, "IX_User_Email").IsUnique(true).HasFilter<User>("\"IsDeleted\" = false");
            builder.Property(x => x.VerifyEmailCode);
            builder.Property(x => x.VerifyEmailDate);
            builder.Property(x => x.PhonNum);
            builder.Property(x => x.Note);
            builder.Property(x => x.Powers);
            builder.Property(x => x.IsActive);
            builder.UseXminAsConcurrencyToken();

        }
    }
}
