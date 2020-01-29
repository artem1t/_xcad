//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using Xarial.XCad.Documents.Drawings;
using Xarial.XCad.Geometry.Structures;

namespace Xarial.XCad.Documents
{
    public interface IXDocument3D : IXDocument
    {
        Box3D CalculateBoundingBox();
        IXView ActiveView { get; }
    }
}
