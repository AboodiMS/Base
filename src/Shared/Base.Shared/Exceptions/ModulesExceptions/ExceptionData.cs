using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.Exceptions.ModulesExceptions
{
    public class ExceptionData
    {
        public string TableName { get; set; }
        public string PropertieName { get; set; }
        public string PropertieValue { get; set; }
    }
}