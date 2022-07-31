


namespace Base.Modules.Companies.Domain.DTO.Company
{
    public class UpdateCompanyRequestDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CompanyWork { get; set; } = string.Empty;
    }
}
