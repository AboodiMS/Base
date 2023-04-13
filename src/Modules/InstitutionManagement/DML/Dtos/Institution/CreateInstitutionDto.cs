using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutionManagement.DML.Dtos.Institution
{
    public class CreateInstitutionDto
    {
        [Required]
        [MaxLength(50)]
        public string InstitutionName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string FullName { get; set; } = string.Empty;
    }
}
