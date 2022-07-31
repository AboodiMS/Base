using Base.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Companies.DAL.Exceptions.Company
{
    internal class CompanyNameAlreadyExistsException : BaseException
    {
        public string CompanyName { get; }
        public CompanyNameAlreadyExistsException(string companyName) : base($"User with company name: '{companyName}' already exists.")
        {
            CompanyName = companyName;
        }
    }
}
