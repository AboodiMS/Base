using Base.Modules.Users.Domain.Entities;
using Base.Shared.Entities;
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
                        //--users-module
                        new TreePower()
                        {
                            Code = "users-module",
                            ParentCode = null,
                            Name = "قسم المستخدمين",
                            Num = 1,
                            IsEndPoint = false,
                        },
                        new TreePower()
                        {
                            Code = "users-module/Users",
                            ParentCode = "users-module",
                            Name = "معلومات المستخدمين",
                            Num = 101,
                            IsEndPoint = false,
                        },
                        new TreePower()
                        {
                            Code = "users-module/Users/GetAll",
                            ParentCode = "users-module/Users",
                            Name = "عرض الكل",
                            Num = 10101,
                            IsEndPoint = true,
                        },
                        new TreePower()
                        {
                            Code = "users-module/Users/GetById",
                            ParentCode = "users-module/Users",
                            Name = "عرض",
                            Num = 10102,
                            IsEndPoint = true,
                        },
                        new TreePower()
                        {
                            Code = "users-module/Users/Create",
                            ParentCode = "users-module/Users",
                            Name = "اضافة",
                            Num = 10103,
                            IsEndPoint = true,
                        },
                        new TreePower()
                        {
                            Code = "users-module/Users/Update",
                            ParentCode = "users-module/Users",
                            Name = "تعديل",
                            Num = 10104,
                            IsEndPoint = true,
                            DependsOn = new string[2] { "users-module/Users/GetById", "users-module/Users/GetAll" },
                        },
                        new TreePower()
                        {
                            Code = "users-module/Users/Delete",
                            ParentCode = "users-module/Users",
                            Name = "حذف",
                            Num = 10105,
                            IsEndPoint = true,
                            DependsOn = new string[2] { "users-module/Users/GetById", "users-module/Users/GetAll" },
                        },
                        new TreePower()
                        {
                            Code = "users-module/Users/ChangePowers",
                            ParentCode = "users-module/Users",
                            Name = "تعديل الصلاحيات",
                            Num = 10106,
                            IsEndPoint = true,
                            DependsOn = new string[2] { "users-module/Users/GetById", "users-module/Users/GetAll" },
                        }
                ) ;
        }
    }
}
