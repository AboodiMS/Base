
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutionManagement.DML.Dtos.InstitutionManagement
{
    public class EditInstitutionPermitionsDto
    {
        [Required]
        public Guid Id { get; set; }
        public string[]? Permission { get; set; } = null;
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public DateTimeOffset ActivationExpires { get; set; }
        [Required]
        public bool Demo { get; set; } = true;
    }
}
