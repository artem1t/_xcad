//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Text;

namespace Xarial.XCad.Services
{
    public class XObjectEqualityComparer<TObj> : IEqualityComparer<TObj>
        where TObj : IXObject
    {
        public bool Equals(TObj x, TObj y)
        {
            if (object.ReferenceEquals(x, y)) 
            {
                return true;
            }

            if (x == null || y == null) 
            {
                return false;
            }

            return x.IsSame(y);
        }

        public int GetHashCode(TObj obj)
        {
            return 0;
        }
    }
}
