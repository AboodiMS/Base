using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.Domain.IServices
{
    public interface IUserSettingsService
    {
        Task Login();
        Task Logout(Guid userid);
        Task ChangePassword();
        Task ChangeEmail();
        Task VerifyEmail();
    }
}
