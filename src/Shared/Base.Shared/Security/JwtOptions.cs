using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.Security
{
    internal sealed class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SymmetricKey { get; set; }
    }
}
