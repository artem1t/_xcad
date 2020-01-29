//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using Xarial.XCad.Sketch;

namespace Xarial.XCad.Features
{
    public interface IXSketchBase : IXFeature 
    {
        bool IsEditing { get; set; }
        IXSketchEntityCollection Entities { get; }
    }
}
