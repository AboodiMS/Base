using AutoMapper;
using Base.Modules.Companies.Domain.DTO.Company;
using Base.Modules.Companies.Domain.Entities;

namespace Base.Modules.Companies.Domain.Mapping
{
    public class CompanyProfile: Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, GetCompanyDetailsResponseDto>();
            CreateMap<Company, GetCompanyResponseDto>();
            CreateMap<UpdateCompanyRequestDto, Company>();
            CreateMap<CreateCompanyRequestDto, Company>();
            CreateMap<UpdateActiveSectionsCompanyRequestDto, Company>();
        }

    }
}
