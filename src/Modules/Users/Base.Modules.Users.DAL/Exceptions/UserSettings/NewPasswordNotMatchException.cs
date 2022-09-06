using Base.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.DAL.Exceptions.UserSettings
{
    internal class NewPasswordNotMatchException : BaseException
    {

        public NewPasswordNotMatchException() : base($"The new password does not match.")
        {
        }
    }
}
