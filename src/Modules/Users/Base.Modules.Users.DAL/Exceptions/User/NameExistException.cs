using Base.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.DAL.Exceptions.User
{
    internal class NameExistException : BaseException
    {
        public string Name { get; }

        public NameExistException(string name) : base($"User Exist with Name: '{name}'.")
        {
            Name = name;
        }
    }
}
