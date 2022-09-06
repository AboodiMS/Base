using Base.Modules.Users.Domain.DTO.TreePower;

namespace Base.Modules.Users.Domain.DTO.CustomPower
{
    public class GetCustomPowerDetailsResponseDto: GetCustomPowerResponseDto
    {
        public string Note { get; set; } = string.Empty;
        public List<GetTreePowerResponseDto> Powers { get; set; } = new List<GetTreePowerResponseDto>();
    }
}
