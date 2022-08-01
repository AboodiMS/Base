using Base.Modules.Companies.Domain.Entities;
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







        //private readonly CompaniesDbContext companyDbContext;

        //public CompanyDataSeeder(CompaniesDbContext companyDbContext)
        //{
        //    this.companyDbContext = companyDbContext;
        //}

        public static void CompanySeed(this ModelBuilder modelBuilder )
        {

            modelBuilder.Entity<Company>().HasData
                (
                        new Company()
                        {
                            Id = Guid.NewGuid(),
                            Name = "اسم الشركة",
                            CompanyWork = string.Empty,
                            ActiveSections = new string[] { "Accounting" },
                        }
                );


            ////if (!companyDbContext.Companies.Any())
            ////{
            //var companies = new List<Company>()
            //    {
            //            new Company()
            //            {
            //                Id=Guid.NewGuid(),
            //                Name = "اسم الشركة",
            //                CompanyWork=string.Empty,
            //                ActiveSections= new List<string> { "Accounting"},
            //            }
            //    };
            //companyDbContext.Companies.AddRange(companies);
            //companyDbContext.SaveChanges();
            ////}
        }
    }
}
