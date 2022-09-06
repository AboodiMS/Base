using Base.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.Database.Configurations
{
    public class ModuleSettingConfiguration : IEntityTypeConfiguration<ModuleSetting>
    {
        public void Configure(EntityTypeBuilder<ModuleSetting> builder)
        {
            builder.HasKey(x => x.CodeName);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Setting);
        }
    }
}
