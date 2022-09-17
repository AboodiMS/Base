
using Base.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Companies.DAL.Database.ModuleSeedData
{
    internal static class TreePowerDataSeeder
    {
        public static void TreeDataSeed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TreePower>().HasData
                (
                        //--companies-module
                        new TreePower()
                        {
                            Code = "companies-module",
                            ParentCode = null,
                            Name = "قسم الشركة",
                            Num = 01,
                            IsEndPoint = false,
                        },
                        new TreePower()
                        {
                            Code = "companies-module/Companies",
                            ParentCode = "companies-module",
                            Name = "معلومات الشركة",
                            Num = 0101,
                            IsEndPoint = false,
                        },
                        new TreePower()
                        {
                            Code = "companies-module/Companies/GetById",
                            ParentCode = "companies-module/Companies",
                            Name = "عرض",
                            Num = 010101,
                            IsEndPoint = true,
                        },
                        new TreePower()
                        {
                            Code = "companies-module/Companies/Update",
                            ParentCode = "companies-module/Companies",
                            Name = "تعديل",
                            Num = 010102,
                            IsEndPoint = true,
                            DependsOn = new string[1] { "companies-module/Companies/GetById" },
                        },
                        new TreePower()
                        {
                            Code = "companies-module/Companies/UpdateActiveSections",
                            ParentCode = "companies-module/Companies",
                            Name = "تعديل",
                            Num = 010103,
                            IsEndPoint = true,
                            DependsOn = new string[1] { "companies-module/Companies/GetById" },
                        }
                       
                ) ;
        }
    }
}
