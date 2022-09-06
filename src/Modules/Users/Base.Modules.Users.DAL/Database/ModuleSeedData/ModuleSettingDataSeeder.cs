using Base.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.DAL.Database.ModuleSeedData
{
    public static class ModuleSettingDataSeeder
    {
        public static void ModuleSettingDataSeed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ModuleSetting>()
               .HasData(
                new ModuleSetting
                {
                    CodeName="users-modules",
                    Name="Users Managament",
                    
                }

                );

        }

    }
}
