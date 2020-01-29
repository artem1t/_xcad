//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Text;

namespace Xarial.XCad.UI.PropertyPage.Enums
{
    [Flags]
    public enum NumberBoxStyle_e
    {
        None = 0,
        ComboEditBox = 1,
        EditBoxReadOnly = 2,
        AvoidSelectionText = 4,
        NoScrollArrows = 8,
        Slider = 16,
        Thumbwheel = 32,
        SuppressNotifyWhileTracking = 64
    }
}
