using Base.Modules.ErrorsLogger.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.ErrorsLogger.DAL.Database
{
    public class ErrorsLoggerDbContext: DbContext
    {
        public DbSet<ErrorLogger> ErrorLogger { get; set; }

        public ErrorsLoggerDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("errors-logger");
        }


    }
}
