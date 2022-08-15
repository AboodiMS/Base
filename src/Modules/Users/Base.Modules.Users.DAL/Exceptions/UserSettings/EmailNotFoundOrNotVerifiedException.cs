using Base.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.DAL.Exceptions.UserSettings
{
    internal class EmailNotFoundOrNotVerifiedException:BaseException
    {
        public string Email { get; }

        public EmailNotFoundOrNotVerifiedException(string email) : base($"User with Email: '{email}' was not found or not verified.")
        {
            Email = email;
        }
    }
}
