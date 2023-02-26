using Base.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.DAL.Exceptions.UserSettings
{
    internal class OldPasswordNotMatchException : BaseException
    {

        public OldPasswordNotMatchException() : base($"The old password does not match.")
        {
        }
    }
}
