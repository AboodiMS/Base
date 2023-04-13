using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;



namespace Base.Modules.Companies.Domain.DTO.Company
{
    public class UpdateActiveSectionsCompanyRequestDto
    {
        [Required]
        public Guid Id { get; set; }
        [JsonIgnore]
        public Guid CompanyId { get; set; }
        [Required]
        public string[] ActiveSections { get; set; }=new string[0];

    }
}
