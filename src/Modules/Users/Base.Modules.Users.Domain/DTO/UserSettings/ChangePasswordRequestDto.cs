using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.Domain.DTO.UserSettings
{
    public class ChangePasswordRequestDto
    {
        public Guid Id { get; set; }
        public string OldPassword { get; set; }=string.Empty;
        public string NewPassword { get; set; }=string.Empty;
    }
}
