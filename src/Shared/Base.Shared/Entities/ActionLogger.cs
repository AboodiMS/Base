using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.Entities
{
    public class ActionLogger
    {
        [Key]
        public Guid Id { get; set; }
        public Guid BusinessId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UserId { get; set; }
        public string Table { get; set; }
        public string Action { get; set; }
        public Guid ObjectId { get; set; }
        [Column(TypeName = "jsonb")]
        public object ObjectData { get; set; }
    }
}
