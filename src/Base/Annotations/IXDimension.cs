//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Text;

namespace Xarial.XCad.Annotations
{
    public interface IXDimension : IXSelObject
    {
        double GetValue(string confName = "");
        void SetValue(double val, string confName = "");
    }
}
