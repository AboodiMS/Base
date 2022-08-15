using Base.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.DAL.Exceptions.User
{
    internal class DeleteAdminException : BaseException
    {
        public DeleteAdminException() : base($"Can't delete first admin.")
        {
        }
    }
}
