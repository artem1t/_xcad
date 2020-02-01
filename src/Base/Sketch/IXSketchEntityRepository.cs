//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System.Collections.Generic;
using Xarial.XCad.Base;

namespace Xarial.XCad.Sketch
{
    public interface IXSketchEntityRepository : IXRepository<IXSketchEntity>
    {
        IXSketchLine NewLine();
        IXSketchPoint NewPoint();
    }
}
