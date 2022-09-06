using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.Entities
{
    public class ModuleSetting
    {
        [Key]
        public string CodeName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "jsonb")]
        public object Setting { get; set; }
    }
}
