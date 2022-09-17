
using Base.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.Database
{
    public class BaseDbContext: DbContext
    {
        public DbSet<ModuleSetting> ModuleSettings { get; set; }
        public DbSet<TreePower> TreePowers { get; set; }
        public DbSet<Properties> Properties { get; set; }

        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);


            modelBuilder.Entity<TreePower>().HasKey(x => x.Code);
            modelBuilder.Entity<TreePower>().Property(x => x.Name);
            modelBuilder.Entity<TreePower>().Property(x => x.Num);
            modelBuilder.Entity<TreePower>().Property(x => x.IsEndPoint);
            modelBuilder.Entity<TreePower>().HasOne(x => x.Parent)
                                            .WithMany(x => x.SubTreePowers)
                                            .HasForeignKey(x => x.ParentCode)
                                            .IsRequired(false)
                                            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
