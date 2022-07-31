using Base.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Companies.DAL.Exceptions.Company
{
    internal class CompanyNotFoundException : BaseException
    {
        public Guid Id { get; }

        public CompanyNotFoundException(Guid id) : base($"Company with ID: '{id}' was not found.")
        {
            Id = id;
        }
    }
}
