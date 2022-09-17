using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.DTO.Logger
{
    public class AddActionLoggerDto
    {
        public Guid UserId { get; set; }
        public Guid BusinessId { get; set; }
        public string Action { get; set; } = string.Empty;
        public string Table { get; set; } = string.Empty;
        public Guid ObjectId { get; set; }
        public object ObjectData { get; set; } = null;
    }
}
