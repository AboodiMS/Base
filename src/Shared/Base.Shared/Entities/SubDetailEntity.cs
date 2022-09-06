using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.Entities
{
    public class SubDetailEntity
    {
        [Key]
        public long Id { get; set; }
        public Guid BusinessId { get; set; }
        public Guid HeaderId { get; set; }
    }
}
