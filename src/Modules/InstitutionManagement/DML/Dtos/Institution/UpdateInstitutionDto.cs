using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutionManagement.DML.Dtos.Institution
{
    public class UpdateInstitutionDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string InstitutionName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string FullName { get; set; } = string.Empty;
    }
}
