using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.ErrorsLogger.Domain.Entities
{
    public class ErrorLogger
    {
        [Key]
        public Guid Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public Guid BusinessId { get; set; }
        public string InputData { get; set; }
        public string Class { get; set; }
        public string Action { get; set; }
        [Column(TypeName = "jsonb")]
        public string Exception { get; set; }
    }
}
