//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Text;
using Xarial.XCad.Delegates;
using Xarial.XCad.Structures;

namespace Xarial.XCad
{
    public interface IXCommandBar
    {
        event CommandClickDelegate CommandClick;
        event CommandStateDelegate CommandStateResolve;

        CommandBarSpec Spec { get; }
    }
}
