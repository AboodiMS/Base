using Base.Shared.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutionManagement.DML.Entities
{
    public class Institution : ModelEntity1
    {
        public string InstitutionName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        [Column(TypeName = "jsonb")]
        public string[]? Permission { get; set; } = null;
        public Guid OwnerId { get; set; }
        public User Owner { get; set; } = new User();
        public DateTimeOffset ActivationExpires { get; set; }
        public bool Demo { get; set; } = true;
    }
}
