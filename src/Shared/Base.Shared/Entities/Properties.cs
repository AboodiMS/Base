using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.Entities
{
    public class Properties
    {
        [Key]
        public string Code { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string TableName { get; set; }
        [Column(TypeName = "jsonb")]
        public string Data { get; set; }
        [Timestamp]
        public byte[] IsRowVersion { get; set; }
    }
}
