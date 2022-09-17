using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.Entities
{
    public class TreePower
    {
        [Key]
        public string Code { get; set; } 
        public int Num { get; set; }
        public string Name { get; set; } 
        public bool IsEndPoint { get; set; }
        [Column(TypeName = "jsonb")]
        public string[] DependsOn { get; set; } = null;     
        public TreePower Parent { get; set; }
        [ForeignKey("Code")]
        public string ParentCode { get; set; } 
        public List<TreePower> SubTreePowers { get; } = new List<TreePower>();

    }
}
