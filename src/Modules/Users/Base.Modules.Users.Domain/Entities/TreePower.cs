using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.Domain.Entities
{
    public class TreePower
    {
        public string CodeName { get; set; } = string.Empty;
        public int Num { get; set; }
        public string MainCodeName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool IsEndPoint { get; set; }
    }
}
