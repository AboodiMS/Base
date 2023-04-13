using Base.Shared.IServices;
using InstitutionManagement.DML.Entities;
using InstitutionManagement.DML.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutionManagement.DML.IServices
{
    public interface IInstitutionService: ICRUDService<Institution, InstitutionFilter>
    {

    }
}
