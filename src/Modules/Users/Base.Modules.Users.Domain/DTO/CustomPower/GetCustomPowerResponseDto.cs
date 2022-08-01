using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.Domain.DTO.CustomPower
{
    public class GetCustomPowerResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
