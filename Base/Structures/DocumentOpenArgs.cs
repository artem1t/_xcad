﻿//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Text;

namespace Xarial.XCad.Structures
{
    public class DocumentOpenArgs
    {
        public string Path { get; set; }
        public bool ReadOnly { get; set; }
        public bool ViewOnly { get; set; }
    }
}
