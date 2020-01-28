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
    public interface IXSketchEntitiesCollection : IEnumerable<IXSketchEntity>
    {
        int Count { get; }

        void AddRange(IEnumerable<IXSketchEntity> segments);
    }

    public interface IXSketchEntity : IXEntity 
    {
    }

    public interface IXSketchSegment : IXSketchEntity
    {
        IXSketchPoint StartPoint { get; }
        IXSketchPoint EndPoint { get; }
    }

    public interface IXSketchLine : IXSketchSegment 
    {
    }

    public interface IXSketchPoint  : IXSketchEntity
    {
        Point Coordinate { get; set; }
    }

    public interface IXSketch : IXFeature
    {
        IXSketchEntitiesCollection Entities { get; }
        bool IsEditing { get; set; }
    }
}
