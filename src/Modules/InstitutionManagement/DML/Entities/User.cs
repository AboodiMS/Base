using Base.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutionManagement.DML.Entities
{
    public class User : ModelEntity1
    {
        public string UserName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string HashPassword { get; set; } = string.Empty;
        public string HashCode { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string VerifyEmailCode { get; set; } = string.Empty;
        public DateTimeOffset? VerifyEmailDate { get; set; } = null;
        public string PhonNumber { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public bool SuperAdmin { get; set; } = false;
        public List<Institution> OwnedInstitutions { get; set; } = new List<Institution>();

    }
}
