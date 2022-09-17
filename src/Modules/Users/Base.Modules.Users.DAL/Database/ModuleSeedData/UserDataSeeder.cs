using Base.Modules.Users.Domain.Entities;
using Base.Shared.Helper101;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.DAL.Database.ModuleSeedData
{
    public static class UserDataSeeder
    {
        public static void UserDataSeed(this ModelBuilder modelBuilder)
        {
            string hashCode = Guid.NewGuid().ToString();
            modelBuilder.Entity<User>()
                .HasData(
                   new User()
                   {
                       Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                       BusinessId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                       CreatedDate = DateTime.Now,
                       CreatedUserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                       LastUpdateDate = null,
                       LastUpdateUserId = null,
                       IsDeleted = false,

                       LoginName = "1",
                       Name = "admin",
                       IsAdmin = true,
                       HashPassword = "1".Encryption(hashCode),
                       HashCode = hashCode,
                       Email = null,
                       VerifyEmailCode = string.Empty,
                       VerifyEmailDate = null,
                       PhonNum = string.Empty,
                       Note = string.Empty,
                       Powers=null,
                       IsActive =true,
                       SignOutExpirationDate=null
                   }
                );
            
           
        }
    }
}
