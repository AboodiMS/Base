using Base.Modules.Companies.Domain.Entities;
using Base.Shared.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Companies.DAL.Database.ModuleSeedData
{
    internal static class CompanyDataSeeder
    {
        public static void CompanySeed(this ModelBuilder modelBuilder )
        {

            modelBuilder.Entity<Company>().HasData
                (
                        new Company()
                        {                            
                            Id = BaseModulesData.SupperBusinessId,
                            CreatedDate = DateTimeOffset.Now,
                            CreatedUserId = BaseModulesData.SupperAdminId,
                            LastUpdateDate = null,
                            LastUpdateUserId = null,
                            IsDeleted = false,
                            Name = "اسم الشركة",
                            CompanyWork = string.Empty,
                            ActiveSections = new string[] { "Accounting" },
                        }
                );
        }
    }
}
