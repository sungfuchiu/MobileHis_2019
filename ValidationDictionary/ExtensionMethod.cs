using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class ExtensionMethod
    {
        public static bool IsNullOrEmpty(this string item)
        {
            return string.IsNullOrEmpty(item);
        }
    }
}
