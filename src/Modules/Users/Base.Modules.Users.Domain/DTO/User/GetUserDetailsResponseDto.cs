using Base.Modules.Users.Domain.DTO.TreePower;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.Domain.DTO.User
{
    public class GetUserDetailsResponseDto: GetUserResponseDto
    {
        public string? Note { get; set; } = string.Empty;
        public GetTreePowerResponseDto Powers { get; set; } = new GetTreePowerResponseDto();
    }
}
