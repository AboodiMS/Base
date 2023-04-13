using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace InstitutionManagement.DML.Entities
{
    public class UserSession
    {
        public BigInteger Number { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set;}
    }
}
