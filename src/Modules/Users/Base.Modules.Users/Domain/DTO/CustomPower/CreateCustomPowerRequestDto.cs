using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Base.Modules.Users.Domain.DTO.CustomPower
{
    public class CreateCustomPowerRequestDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [JsonIgnore]
        public Guid BusinessId { get; set; }
        [JsonIgnore]
        public Guid UserId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(1000)]
        public string Note { get; set; } = string.Empty;
        public string[] Powers { get; set; } = new string[0];
    }
}
