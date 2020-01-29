//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Xarial.XCad.Structures;

namespace Xarial.XCad
{
    public interface IXView
    {
        void Freeze(bool freeze);
        TransformMatrix Transform { get; set; }
        TransformMatrix ScreenTransform { get; }
        Rectangle ScreenRect { get; }
        void Update();
    }
}
