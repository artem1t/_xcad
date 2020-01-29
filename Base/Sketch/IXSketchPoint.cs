//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using Xarial.XCad.Structures;

namespace Xarial.XCad
{
    public interface IXSketchPoint  : IXSketchEntity
    {
        Point Coordinate { get; set; }
    }
}
