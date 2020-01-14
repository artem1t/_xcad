//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Text;
using Xarial.XCad.Enums;

namespace Xarial.XCad.Structures
{
    public class CommandState
    {
        public bool Enabled { get; set; }
        public bool Checked { get; set; }
    }

    public static class CommandStateExtension 
    {
        public static void ResolveState(this CommandState state, WorkspaceTypes_e ws, IXApplication app) 
        {
            var curSpace = WorkspaceTypes_e.NoDocuments;

            if (app.ActiveDocument == null)
            {
                curSpace = WorkspaceTypes_e.NoDocuments;
            }
            else
            {
                if (app.ActiveDocument is IXPart)
                {
                    curSpace = WorkspaceTypes_e.Part;
                }
                else if (app.ActiveDocument is IXAssembly)
                {
                    curSpace = WorkspaceTypes_e.Assembly;
                }
                else if (app.ActiveDocument is IXDrawing)
                {
                    curSpace = WorkspaceTypes_e.Drawing;
                }
                else
                {
                    throw new NotSupportedException();
                }
            }

            state.Enabled = ws.HasFlag(curSpace);
        }
    }
}
