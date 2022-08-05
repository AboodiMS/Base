using Base.Modules.Users.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.DAL.Database.ModuleSeedData
{
    internal static class TreePowerDataSeeder
    {
        public static void TreeDataSeed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TreePower>().HasData
                (
                        //--mainroot
                        new TreePower()
                        {
                            CodeName = "mainroot",
                            ParentCodeName = null,
                            Name = "mainroot",
                            Num = 0,
                            IsEndPoint = false,
                        },
                        //--companies-module
                        new TreePower()
                        {
                            CodeName = "companies-module",
                            ParentCodeName = "mainroot",
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
                        },
                        //--users-module
                        new TreePower()
                        {
                            CodeName = "users-module",
                            ParentCodeName = "mainroot",
                            Name = "قسم المستخدمين",
                            Num = 02,
                            IsEndPoint = false,
                        },
                        new TreePower()
                        {
                            CodeName = "users-module/Users",
                            ParentCodeName = "users-module",
                            Name = "معلومات المستخدمين",
                            Num = 0201,
                            IsEndPoint = false,
                        },
                        new TreePower()
                        {
                            CodeName = "users-module/Users/GetAll",
                            ParentCodeName = "users-module/Users",
                            Name = "عرض الكل",
                            Num = 020101,
                            IsEndPoint = true,
                        },
                        new TreePower()
                        {
                            CodeName = "users-module/Users/GetById",
                            ParentCodeName = "users-module/Users",
                            Name = "عرض",
                            Num = 020102,
                            IsEndPoint = true,
                        },
                        new TreePower()
                        {
                            CodeName = "users-module/Users/Add",
                            ParentCodeName = "users-module/Users",
                            Name = "اضافة",
                            Num = 020103,
                            IsEndPoint = true,
                        },
                        new TreePower()
                        {
                            CodeName = "users-module/Users/Update",
                            ParentCodeName = "users-module/Users",
                            Name = "تعديل",
                            Num = 020104,
                            IsEndPoint = true,
                            DependsOn = new string[1] { "users-module/Users/GetById" },
                        },
                        new TreePower()
                        {
                            CodeName = "users-module/Users/Delete",
                            ParentCodeName = "users-module/Users",
                            Name = "حذف",
                            Num = 020105,
                            IsEndPoint = true,
                            DependsOn = new string[1] { "users-module/Users/GetById" },
                        },
                        new TreePower()
                        {
                            CodeName = "users-module/Users/ChangePowers",
                            ParentCodeName = "users-module/Users",
                            Name = "تعديل الصلاحيات",
                            Num = 020106,
                            IsEndPoint = true,
                            DependsOn = new string[1] { "users-module/Users/GetById" },
                        }
                ) ;
        }
    }
}
