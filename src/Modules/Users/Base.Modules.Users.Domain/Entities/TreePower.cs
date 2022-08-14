using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.Domain.Entities
{
    public class TreePower
    {
        public string CodeName { get; set; } 
        public int Num { get; set; }
        public string Name { get; set; } 
        public bool IsEndPoint { get; set; }
        public string[]? DependsOn { get; set; } = null;
        public TreePower Parent { get; set; } 
        public string? ParentCodeName { get; set; } 
        public List<TreePower> SubTreePowers { get; } = new List<TreePower>();

    }
}
