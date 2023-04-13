using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutionManagement.DML.Dtos.UserAccountManagement
{
    public class ChangePasswordDto
    {
        [Required]
        [MaxLength(50)]
        public string OldPassword { get; set; }=string.Empty;

        [Required]
        [MaxLength(50)]
        public string NewPassword { get; set; }=string.Empty;

        [Required]
        [MaxLength(50)]
        public string ConfirmNewPassword { get; set; } = string.Empty;
    }
}
