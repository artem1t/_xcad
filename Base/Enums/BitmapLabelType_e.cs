//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Text;

namespace Xarial.XCad.Enums
{
    public enum BitmapLabelType_e
    {
        LinearDistance = 1,
        AngularDistance,
        SelectEdgeFaceVertex,
        SelectFaceSurface,
        SelectVertex,
        SelectFace,
        SelectEdge,
        SelectFaceEdge,
        SelectComponent,
        Diameter,
        Radius,
        LinearDistance1,
        LinearDistance2,
        Thickness1,
        Thickness2,
        LinearPattern,
        CircularPattern,
        Width,
        Depth,
        KFactor,
        BendAllowance,
        BendDeduction,
        RipGap,
        SelectProfile,
        SelectBoundary
    }
}
