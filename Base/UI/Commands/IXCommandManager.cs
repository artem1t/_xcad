//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Text;
using Xarial.XCad.UI.Commands.Structures;

namespace Xarial.XCad.UI.Commands
{
    public interface IXCommandManager
    {
        IEnumerable<IXCommandBar> CommandBars { get; }
        IXCommandBar AddCommandBar(CommandBarSpec cmdBar);
    }
}
