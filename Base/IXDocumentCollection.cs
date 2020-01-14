//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System.Collections.Generic;
using Xarial.XCad.Delegates;
using Xarial.XCad.Structures;

namespace Xarial.XCad
{   
    public interface IXDocumentCollection : IEnumerable<IXDocument>
    {
        event DocumentCreateDelegate DocumentCreated;

        IXDocument Active { get; }
        IXDocument Open(DocumentOpenArgs args);
        int Count { get; }
    }
}
