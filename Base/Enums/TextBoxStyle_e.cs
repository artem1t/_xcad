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
    [Flags]
    public enum TextBoxStyle_e
    {
        None = 0,
        NotifyOnlyWhenFocusLost = 1,
        ReadOnly = 2,
        NoBorder = 4,
        Multiline = 8
    }
}
