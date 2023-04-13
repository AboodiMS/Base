using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.Filter
{
    public class AutoCompleteFilter
    {
        public string Value { get; set; } = string.Empty;
        public int PageNo { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
