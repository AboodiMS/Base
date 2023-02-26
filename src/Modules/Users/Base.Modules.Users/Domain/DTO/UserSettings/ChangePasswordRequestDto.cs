using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.Domain.DTO.UserSettings
{
    public class ChangePasswordRequestDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [JsonIgnore]
        public Guid BusinessId { get; set; }
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
