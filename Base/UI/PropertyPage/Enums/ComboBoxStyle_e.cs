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
    public enum ComboBoxStyle_e
    {
        Sorted = 1,
        EditableText = 2,
        EditBoxReadOnly = 4,
        AvoidSelectionText = 8
    }
}
