using Base.Shared.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutionManagement.DML.Entities
{
    public class TreePermission
    {
        [Key]
        public string CodeName { get; set; } = string.Empty;
        public int Num { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsEndPoint { get; set; }
        public string EndpointAPI { get; set; }= string.Empty;
        [Column(TypeName = "jsonb")]
        public string[]? DependsOn { get; set; } = null;
        public TreePermission? Parent { get; set; } = null;
        [ForeignKey("CodeName")]
        public string ParentCodeName { get; set; }=string.Empty;
        public List<TreePermission> Children { get; set; } = new List<TreePermission>();
    }
}
