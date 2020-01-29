//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System.Collections.Generic;

namespace Xarial.XCad
{
    public interface IXSketchEntityCollection : IEnumerable<IXSketchEntity>
    {
        int Count { get; }

        void AddRange(IEnumerable<IXSketchEntity> segments);

        IXSketchLine NewLine();
        IXSketchPoint NewPoint();
    }
}
