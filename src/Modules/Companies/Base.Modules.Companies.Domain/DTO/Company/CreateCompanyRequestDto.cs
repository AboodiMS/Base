using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Companies.Domain.DTO.Company
{
    public class CreateCompanyRequestDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [JsonIgnore]
        public Guid UserId { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(100)]
        public string CompanyWork { get; set; } = string.Empty;
        public string[]? ActiveSections { get; set; }
    }
}
