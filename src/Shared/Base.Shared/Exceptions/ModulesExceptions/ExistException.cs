using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Base.Shared.Exceptions.ModulesExceptions
{
    public class ExistException:BaseException
    {
        public ExistException(ExceptionData existExceptionData) : base(JsonSerializer.Serialize(existExceptionData))
        {
        }
    }
}
