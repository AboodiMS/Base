using Base.Modules.Users.Domain.DTO.TreePower;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.Domain.DTO.User
{
    public class GetUserResponseDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
        public string? Email { get; set; } = string.Empty;
        public string? PhonNum { get; set; } = string.Empty;
    }

}
