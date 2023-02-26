using Base.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Companies.DAL.Exceptions.Company
{
    internal class InvalidCompanyActiveSectionsException : BaseException
    {

        public InvalidCompanyActiveSectionsException() : base($"ActiveSections is Invalid.")
        {
        }
    }
}
