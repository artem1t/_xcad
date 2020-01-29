//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Text;
using Xarial.XCad.Structures;

namespace Xarial.XCad
{
    public interface IXGeometryBuilder
    {
        IXBody CreateBox(Point center, Vector dir, Vector refDir,
            double width, double length, double height);

        IXBody CreateCylinder(Point center, Vector axis, Vector refDir, 
            double radius, double height);

        IXBody CreateCone(Point center, Vector axis, Vector refDir,
            double baseRadius, double topRadius, double height);
    }
}
