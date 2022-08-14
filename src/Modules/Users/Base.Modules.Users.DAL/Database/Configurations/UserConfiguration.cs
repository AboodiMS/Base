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
            builder.HasKey(x => x.Id);
            builder.Property(x => x.BusinessId);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.CreatedUserId);
            builder.Property(x => x.LastUpdateDate);
            builder.Property(x => x.LastUpdateUserId);
            builder.Property(x => x.IsDeleted);
            builder.Property(x => x.IsRowVersion).IsRowVersion();

            builder.HasIndex(e => new { e.Name,e.BusinessId }  , "IX_User_Name").IsUnique().HasFilter("[IsDeleted] = 1");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.HasIndex(e => new { e.UserName,e.BusinessId }  , "IX_User_UserName").IsUnique().HasFilter("[IsDeleted] = 1");
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.IsAdmin);
            builder.Property(x => x.HashPassword);
            builder.Property(x => x.HashCode);
            builder.Property(x => x.Email);
            builder.Property(x => x.VerifyEmailCode);
            builder.Property(x => x.VerifyEmailDate);
            builder.Property(x => x.PhonNum);
            builder.Property(x => x.Note);
            builder.Property(x => x.Powers);

        }
    }
}
