using Base.Modules.Users.Domain.DTO.User;
using Base.Modules.Users.Domain.DTO.UserSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.Domain.IServices
{
    public interface IUserSettingsService
    {
        Task<string> LoginUsingUserName(LoginUsingUserNameRequestDto dto);
        Task<string> LoginUsingEmail(LoginUsingEmailRequestDto dto);
        Task<GetUserDetailsResponseDto> GetUserInfo(Guid id, Guid businessId);
        Task ChangePassword(ChangePasswordRequestDto dto);
        Task ChangeEmail(Guid id, Guid businessId, string email);
        Task VerifyEmail(Guid id, Guid businessId, string code);
        Task SendVerifyCodeToEmail(Guid id, Guid businessId);
        Task ChangePasswordAndSendUsingEmail(Guid businessId, string email);
    }
}
