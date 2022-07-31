using System.ComponentModel.DataAnnotations;



namespace Base.Modules.Companies.Domain.DTO.Company
{
    public class UpdateActiveSectionsCompanyRequestDto
    {
        public Guid Id { get; set; }
        [Required]
        public string[]? ActiveSections { get; set; }

    }
}
