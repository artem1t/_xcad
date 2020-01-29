//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System.ComponentModel;
using System.Drawing;

namespace Xarial.XCad.UI.Commands.Structures
{
    public class CommandBarSpec
    {
        public CommandBarSpec Parent { get; set; }
        public string Title { get; set; }
        public string Tooltip { get; set; }
        public Image Icon { get; set; }

        public int Id { get; set; }
        public CommandSpec[] Commands { get; set; }
    }
}
