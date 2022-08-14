using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.Domain.DTO.UserSettings
{
    public class LoginUsingUserNameRequestDto
    {
        [Required]
        public Guid BusinessId { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Password { get; set; } = string.Empty;
    }
}
