using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Shared.Extensions
{
    public static class StringExtension
    {
        public static Guid ToGuid(this string value)
        {
            Guid result;
            if (!Guid.TryParse(value, out result)) return Guid.Empty;
            return result;
        }
    }
}
