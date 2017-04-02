using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    static public class StringExtensions
    {
        static public bool IsNullOrEmpty(this string r )
        {
            return string.IsNullOrEmpty(r);
        }
    }
}
