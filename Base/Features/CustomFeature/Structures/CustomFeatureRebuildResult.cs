//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Text;

namespace Xarial.XCad.Structures
{
    public class CustomFeatureRebuildResult
    {
        public bool Result { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class CustomFeatureBodyRebuildResult : CustomFeatureRebuildResult 
    {
        public IXBody[] Bodies { get; set; }
    }
}
