using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Base.Modules.Users.Domain.DTO.User
{
    public class CreateUserRequestDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [JsonIgnore]
        public Guid UserId { get; set; }
        [JsonIgnore]
        public Guid BusinessId { get; set; }
        [Required]
        [MaxLength(50)]     
        public string UserName { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public bool IsAdmin { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; } = string.Empty;
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;
        [MaxLength(20)]
        [Phone]
        public string PhonNum { get; set; } = string.Empty;
        [MaxLength(500)]
        public string Note { get; set; } = string.Empty;
        public string[]? Powers { get; set; } = new string[0];
        [Required]
        public bool IsActive { get; set; }
    }
}
