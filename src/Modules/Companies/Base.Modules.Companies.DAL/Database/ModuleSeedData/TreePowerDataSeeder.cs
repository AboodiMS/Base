
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
                            CodeName = "companies-module",
                            ParentCodeName = null,
                            Name = "قسم الشركة",
                            Num = 01,
                            IsEndPoint = false,
                        },
                        new TreePower()
                        {
                            CodeName = "companies-module/Companies",
                            ParentCodeName = "companies-module",
                            Name = "معلومات الشركة",
                            Num = 0101,
                            IsEndPoint = false,
                        },
                        new TreePower()
                        {
                            CodeName = "companies-module/Companies/GetById",
                            ParentCodeName = "companies-module/Companies",
                            Name = "عرض",
                            Num = 010101,
                            IsEndPoint = true,
                        },
                        new TreePower()
                        {
                            CodeName = "companies-module/Companies/Update",
                            ParentCodeName = "companies-module/Companies",
                            Name = "تعديل",
                            Num = 010102,
                            IsEndPoint = true,
                            DependsOn = new string[1] { "companies-module/Companies/GetById" },
                        },
                        new TreePower()
                        {
                            CodeName = "companies-module/Companies/UpdateActiveSections",
                            ParentCodeName = "companies-module/Companies",
                            Name = "تعديل",
                            Num = 010103,
                            IsEndPoint = true,
                            DependsOn = new string[1] { "companies-module/Companies/GetById" },
                        }
                       
                ) ;
        }
    }
}
