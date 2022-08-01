using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.Domain.DTO.UserSettings
{
    public class ChangeEmailRequestDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }=string.Empty;
    }
}
