using Base.Shared.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Companies.Domain.Events.Company
{
    public record CompanyUpdated(Guid Id, string Name, string CompanyWork) : IEvent;
    
}
