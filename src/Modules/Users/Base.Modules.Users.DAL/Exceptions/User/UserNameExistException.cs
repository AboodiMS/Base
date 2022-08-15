using Base.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.DAL.Exceptions.User
{
    internal class UserNameExistException : BaseException
    {
        public string UserName { get; }

        public UserNameExistException(string username) : base($"User Exist with UserName: '{username}'.")
        {
            UserName = username;
        }
    }
}
