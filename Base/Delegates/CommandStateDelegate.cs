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

namespace Xarial.XCad.Delegates
{
    public delegate void CommandStateDelegate(CommandSpec spec, ref CommandState state);

    public delegate void CommandEnumStateDelegate<TCmdEnum>(TCmdEnum spec, ref CommandState state)
        where TCmdEnum : Enum;
}
