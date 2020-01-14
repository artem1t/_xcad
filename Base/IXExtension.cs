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

namespace Xarial.XCad
{
    public interface IXExtension
    {
        bool OnConnect();
        bool OnDisconnect();

        IXApplication Application { get; }
        IXCommandManager CommandManager { get; }
    }

    public interface IXCommandManager 
    {
        IEnumerable<IXCommandBar> CommandBars { get; }
        IXCommandBar AddCommandBar(CommandBarSpec cmdBar);
    }
}
