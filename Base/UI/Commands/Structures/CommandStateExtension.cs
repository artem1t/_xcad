//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using Xarial.XCad.Enums;

namespace Xarial.XCad.Structures
{
    public static class CommandStateExtension 
    {
        public static void ResolveState(this CommandState state, WorkspaceTypes_e ws, IXApplication app) 
        {
            var curSpace = WorkspaceTypes_e.NoDocuments;

            var activeDoc = app.Documents.Active;

            if (activeDoc == null)
            {
                curSpace = WorkspaceTypes_e.NoDocuments;
            }
            else
            {
                if (activeDoc is IXPart)
                {
                    curSpace = WorkspaceTypes_e.Part;
                }
                else if (activeDoc is IXAssembly)
                {
                    curSpace = WorkspaceTypes_e.Assembly;
                }
                else if (activeDoc is IXDrawing)
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
