using Base.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.Domain.Entities
{
    public class CustomPower: ModelEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        [Column(TypeName = "jsonb")]
        public string[]? Powers { get; set; } = null;
    }
}
