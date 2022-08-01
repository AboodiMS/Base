using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.Domain.DTO.UserSettings
{
    public class VerifyEmailRequestDto
    {
        public Guid Id { get; set; }
        public string VerifyEmailCode { get; set; } = string.Empty;

    }
}
