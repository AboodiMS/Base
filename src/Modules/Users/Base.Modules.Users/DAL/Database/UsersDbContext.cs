using Base.Modules.Users.DAL.Database.ModuleSeedData;
using Base.Modules.Users.Domain.Entities;
using Base.Shared.Database;
using Microsoft.EntityFrameworkCore;

namespace Base.Modules.Users.DAL.Database
{
    public class UsersDbContext : BaseDbContext
    {
        public DbSet<CustomPower> CustomPowers { get; set; }
        public DbSet<User> Users { get; set; }

        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("users");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            modelBuilder.TreeDataSeed();
            modelBuilder.UserDataSeed();
            modelBuilder.ModuleSettingDataSeed();
        }
    }
}
