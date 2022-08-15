using Base.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.DAL.Exceptions.UserSettings
{
    internal class ErrorUserNameOrPasswordException : BaseException
    {
        public ErrorUserNameOrPasswordException() : base($"error username or password.")
        {
        }
    }
}
