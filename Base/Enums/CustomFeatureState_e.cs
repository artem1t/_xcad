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
    public enum CustomFeatureState_e
    {
        Default = 0,
        CannotBeDeleted = 1,
        NotEditable = 2,
        CannotBeSuppressed = 4,
        CannotBeReplaced = 8,
        EnableNote = 16,
        CannotBeRolledBack = 32
    }
}
