//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xarial.XCad.Utils.Reflection
{
    internal static class EnumerableExtension
    {
        internal static IEnumerable<T> ValueOrEmpty<T>(this IEnumerable<T> enumer) 
        {
            if (enumer != null)
            {
                return enumer;
            }
            else 
            {
                return Enumerable.Empty<T>();
            }
        }
    }
}
