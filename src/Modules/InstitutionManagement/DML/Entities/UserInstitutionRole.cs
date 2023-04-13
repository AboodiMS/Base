using Base.Shared.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutionManagement.DML.Entities
{
    public class UserInstitutionRole: ModelEntity1
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = new User();
        public Guid InstitutionsId { get; set; }
        public Institution Institutions { get; set; } = new Institution();
        [Column(TypeName = "jsonb")]
        public string[]? Permission { get; set; } = null;
        public bool Admin { get; set; } = false;
        public bool Active { get; set; } = true;
        public bool InvitationAccepted { get; set; } = false;
        public DateTimeOffset? InvitationAcceptedDate { get; set; } = null;
    }
}
