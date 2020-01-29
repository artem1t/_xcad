//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Text;

namespace Xarial.XCad
{
    public interface IXBody : IXSelObject
    {
        bool Visible { get; set; }
        
        IXBody Add(IXBody other);
        IXBody[] Substract(IXBody other);
        IXBody[] Common(IXBody other);
    }
}
