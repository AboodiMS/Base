﻿using Base.Shared.IServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.Entities
{
    public abstract class ModelEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid BusinessId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; } = null;
        public Guid? LastUpdateUserId { get; set; } = null;
        public bool IsDeleted { get; set; }
        public uint xmin { get; set; }

        public void Delete(Guid userid)
        {
            IsDeleted = true;
            LastUpdateDate = DateTime.Now;
            LastUpdateUserId = userid;
        }
    }
}
