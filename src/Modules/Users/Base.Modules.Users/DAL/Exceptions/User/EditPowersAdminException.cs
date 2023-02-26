using Base.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.DAL.Exceptions.User
{
    internal class EditPowersAdminException : BaseException
    {
        public EditPowersAdminException() : base($"Can't edit first admin powers.")
        {
        }
    }
}
