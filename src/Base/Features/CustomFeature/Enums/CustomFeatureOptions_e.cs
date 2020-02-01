//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Text;

namespace Xarial.XCad.Features.CustomFeature.Enums
{
    [Flags]
    public enum CustomFeatureOptions_e
    {
        Default = 0,
        AlwaysAtEnd = 1,
        Patternable = 2,
        Dragable = 4,
        NoCachedBody = 8
    }
}
