using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutionManagement.DML.Dtos.UserAccountManagement
{
    public class UserInfoDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public bool IsEmailVerified { get; set; }
        public string? PhonNumber { get; set; } = string.Empty;
        public string Tocken { get; set; } = string.Empty;

    }
}
