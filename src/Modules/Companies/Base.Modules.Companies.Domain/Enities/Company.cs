using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Modules.Companies.Domain.Enities
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string CompanyWork { get; set; }=string.Empty;
        [Column(TypeName = "jsonb")]
        public string[]? ActiveSections { get; set; }
    }
}
