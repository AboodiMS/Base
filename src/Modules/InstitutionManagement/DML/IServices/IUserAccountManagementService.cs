using InstitutionManagement.DML.Dtos.UserAccountManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutionManagement.DML.IServices
{
    public interface IUserAccountManagementService
    {
        Task<string> Registration(RegistrationDto dto);
        Task<string> Login(LoginDto dto);
        Task<UserInfoDto> GetUserInfo();
        Task Edit(EditUserAccountDto dto);
        Task ChangePassword(ChangePasswordDto dto); 

        Task SendVerifyCodeToEmail();
        Task VerifyEmail(string code);

        Task SendVerifyCodeToPhonNumber();
        Task VerifyPhonNumber(string code);

        Task ChangePasswordAndSendUsingEmail(Guid businessId, string email);
    }
}
