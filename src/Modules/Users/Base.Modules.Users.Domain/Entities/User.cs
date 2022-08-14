using Base.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.Domain.Entities
{
    public class User: DeletableEntity
    {
        public string UserName { get; set; }=string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool IsAdmin { get; set; } 
        public string HashPassword { get; set; } = string.Empty;
        public string HashCode { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string VerifyEmailCode { get; set; } = string.Empty;
        public DateTime? VerifyEmailDate { get; set; } = null;
        public string PhonNum { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public string[]? Powers { get; set; }=null;
        public bool IsActive { get; set; }=true;
        public DateTime? SignOutExpirationDate { get; set; } = null;
    }
}
