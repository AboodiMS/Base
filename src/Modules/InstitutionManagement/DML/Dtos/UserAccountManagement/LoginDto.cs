using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutionManagement.DML.Dtos.UserAccountManagement
{
    public class LoginDto
    {
        [DefaultValue("1")]
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; } = string.Empty;

        [MaxLength(20)]
        [Phone]
        public string PhonNummber { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Password { get; set; } = string.Empty;
    }
}
