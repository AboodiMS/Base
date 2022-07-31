


namespace Base.Modules.Companies.Domain.DTO.Company
{
    public class GetCompanyResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string CompanyWork { get; set; }=string.Empty;
        public string[]? ActiveSections { get; set; }
    }
}
