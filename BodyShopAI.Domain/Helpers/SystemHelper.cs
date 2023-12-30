using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class SystemHelper
    {
        public static bool IsNullOrWhiteSpace(this string source) => string.IsNullOrWhiteSpace(source);
        
    }
}
