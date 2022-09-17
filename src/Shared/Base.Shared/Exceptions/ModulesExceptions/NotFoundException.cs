using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Base.Shared.Exceptions.ModulesExceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(ExceptionData existExceptionData) : base(JsonSerializer.Serialize(existExceptionData))
        {
        }
    }
}
