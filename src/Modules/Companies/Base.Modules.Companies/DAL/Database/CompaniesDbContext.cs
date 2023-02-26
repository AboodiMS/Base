using Base.Modules.Companies.DAL.Database.ModuleSeedData;
using Base.Modules.Companies.Domain.Entities;
using Base.Shared.Database;
using Microsoft.EntityFrameworkCore;

namespace Base.Modules.Companies.DAL.Database
{
    public class CompaniesDbContext : BaseDbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Section> Sections { get; set; }

        public CompaniesDbContext(DbContextOptions<CompaniesDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("companies");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            modelBuilder.CompanySeed();
            modelBuilder.ModuleSettingDataSeed();
            modelBuilder.TreeDataSeed();
        }
    }
}
