using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.Entities
{
    public class ModelEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public Guid CreatedUserId { get; set; }
        public DateTimeOffset? LastUpdateDate { get; set; } = null;
        public Guid? LastUpdateUserId { get; set; } = null;
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeleteDate { get; set; } = null;
        public Guid? LastDeleteUserId { get; set; } = null;
        public DateTimeOffset? LastRestoreDate { get; set; } = null;
        public Guid? LastRestoreUserId { get; set; } = null;
        public uint xmin { get; set; }

        public void Delete(Guid userid)
        {
            IsDeleted = true;
            LastUpdateDate = DateTimeOffset.Now;
            LastDeleteUserId = userid;
        }
        public void Restore(Guid userid)
        {
            IsDeleted = false;
            LastRestoreDate = DateTimeOffset.Now;
            LastRestoreUserId = userid;
        }

    }
}
