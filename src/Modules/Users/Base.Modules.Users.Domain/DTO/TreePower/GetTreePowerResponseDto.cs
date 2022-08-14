using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.Domain.DTO.TreePower
{
    public class GetTreePowerResponseDto
    {
        public string CodeName { get; set; } = string.Empty;
        public int Num { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsEndPoint { get; set; }
        public bool HasAccess { get; set; }
        public List<GetTreePowerResponseDto> TreePowerNodes { get; set; } = null;
    }
}
