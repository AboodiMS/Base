using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.Services
{
    public interface IDeletableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid BusinessId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public Guid? LastUpdateUserId { get; set; }
        public bool IsDeleted { get; set; }
        void Delete(Guid userid);
    }
}
