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
using Xarial.XCad.Structures;

namespace Xarial.XCad
{
    public interface IXSketchEntityCollection : IEnumerable<IXSketchEntity>
    {
        int Count { get; }

        void AddRange(IEnumerable<IXSketchEntity> segments);

        IXSketchLine NewLine();
        IXSketchPoint NewPoint();
    }

    public interface IXSketchEntity : IXSelObject 
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

    public interface IXSketchBase : IXFeature 
    {
        bool IsEditing { get; set; }
        IXSketchEntityCollection Entities { get; }
    }

    public interface IXSketch2D : IXSketchBase
    {
    }

    public interface IXSketch3D : IXSketchBase
    {
    }
}
