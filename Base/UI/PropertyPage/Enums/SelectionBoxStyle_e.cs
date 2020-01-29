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
    public enum SelectionBoxStyle_e
    {
        None = 0,
        HorizontalScroll = 1,
        UpAndDownButtons = 2,
        MultipleItemSelect = 4,
        WantListboxSelectionChanged = 8
    }
}
