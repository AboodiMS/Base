using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.DTO.Logger
{
    public class AddErrorLoggerDto
    {
        public Guid BusinessId { get; set; }
        public string Action { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public Exception Exception { get; set; } = null;
        public object InputData { get; set; } = null;
    }
}
