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
                            CodeName = "users-module",
                            ParentCodeName = null,
                            Name = "قسم المستخدمين",
                            Num = 1,
                            IsEndPoint = false,
                        },
                        new TreePower()
                        {
                            CodeName = "users-module/Users",
                            ParentCodeName = "users-module",
                            Name = "معلومات المستخدمين",
                            Num = 101,
                            IsEndPoint = false,
                        },
                        new TreePower()
                        {
                            CodeName = "users-module/Users/GetAll",
                            ParentCodeName = "users-module/Users",
                            Name = "عرض الكل",
                            Num = 10101,
                            IsEndPoint = true,
                        },
                        new TreePower()
                        {
                            CodeName = "users-module/Users/GetById",
                            ParentCodeName = "users-module/Users",
                            Name = "عرض",
                            Num = 10102,
                            IsEndPoint = true,
                        },
                        new TreePower()
                        {
                            CodeName = "users-module/Users/Add",
                            ParentCodeName = "users-module/Users",
                            Name = "اضافة",
                            Num = 10103,
                            IsEndPoint = true,
                        },
                        new TreePower()
                        {
                            CodeName = "users-module/Users/Update",
                            ParentCodeName = "users-module/Users",
                            Name = "تعديل",
                            Num = 10104,
                            IsEndPoint = true,
                            DependsOn = new string[1] { "users-module/Users/GetById" },
                        },
                        new TreePower()
                        {
                            CodeName = "users-module/Users/Delete",
                            ParentCodeName = "users-module/Users",
                            Name = "حذف",
                            Num = 10105,
                            IsEndPoint = true,
                            DependsOn = new string[1] { "users-module/Users/GetById" },
                        },
                        new TreePower()
                        {
                            CodeName = "users-module/Users/ChangePowers",
                            ParentCodeName = "users-module/Users",
                            Name = "تعديل الصلاحيات",
                            Num = 10106,
                            IsEndPoint = true,
                            DependsOn = new string[1] { "users-module/Users/GetById" },
                        }

                ) ;
        }
    }
}
