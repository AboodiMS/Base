


using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Base.Modules.Companies.Domain.DTO.Company
{
    public class UpdateCompanyRequestDto
    {
        public Guid Id { get; set; }
        [JsonIgnore]
        public Guid CompanyId { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(100)]
        public string CompanyWork { get; set; } = string.Empty;
    }
}
