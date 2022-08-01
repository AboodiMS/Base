using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.Domain.Entities
{
    public class CustomPower
    {
        public Guid Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string CodeName { get; set; }=string.Empty;
        public string Note { get; set; }= string.Empty;
        public string[] Powers { get; set; }= new string[0];
    }
}
