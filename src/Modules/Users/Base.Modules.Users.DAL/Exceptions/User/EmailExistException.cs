using Base.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.DAL.Exceptions.User
{
    internal class EmailExistException : BaseException
    {
        public string Email { get; }

        public EmailExistException(string email) : base($"User Exist with Email: '{email}'.")
        {
            Email = email;
        }
    }
}
