using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Modules.Companies.Domain.Entities
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string CompanyWork { get; set; }=string.Empty;
        [Column(TypeName = "jsonb")]
        public string[]? ActiveSections { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; } = null;
        public Guid? LastUpdateUserId { get; set; } = null;
        public bool IsDeleted { get; set; }
        public uint xmin { get; set; }
    }
}
