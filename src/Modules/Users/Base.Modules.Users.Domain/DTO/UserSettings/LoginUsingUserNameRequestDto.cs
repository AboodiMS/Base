using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.Domain.DTO.UserSettings
{
    public class LoginUsingUserNameRequestDto
    {
        [DefaultValue("11111111-1111-1111-1111-111111111111")]
        [Required]
        public Guid BusinessId { get; set; }
        [DefaultValue("1")]
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; } = string.Empty;
        [DefaultValue("1")]
        [Required]
        [MaxLength(50)]
        public string Password { get; set; } = string.Empty;
    }
}
