using Base.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.DAL.Exceptions.User
{
    internal class UserNotFoundException : BaseException
    {
        public Guid Id { get; }

        public UserNotFoundException(Guid id) : base($"User with ID: '{id}' was not found.")
        {
            Id = id;
        }
    }
}
