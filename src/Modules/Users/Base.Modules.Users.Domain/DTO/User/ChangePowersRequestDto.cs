using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Base.Modules.Users.Domain.DTO.User
{
    public class ChangePowersRequestDto
    {
        [Required]
        public Guid Id { get; set; }
        [JsonIgnore]
        public Guid UserId { get; set; }
        [JsonIgnore]
        public Guid BusinessId { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        public string[] Powers { get; set; } = new string[0];
    }
}
