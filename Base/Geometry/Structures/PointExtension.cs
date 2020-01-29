//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Xarial.XCad
{
    public static class VectorExtension
    {
        public static Vector3 ToVector3(this Structures.Point pt) 
        {
            return new Vector3((float)pt.X, (float)pt.Y, (float)pt.Z);
        }
    }
}
