


using Base.Modules.Companies.Domain.Entities;

namespace Base.Modules.Companies.Domain.DTO.Company
{
    public class GetCompanyDetailsResponseDto: GetCompanyResponseDto
    {
        public List<Section> ActiveSections { get; set; }=new List<Section>();
    }
}
