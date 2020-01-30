﻿//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Text;

namespace Xarial.XCad.Base
{
    public interface IXRepository<TEnt> : IEnumerable<TEnt>
    {
        int Count { get; }
        void AddRange(IEnumerable<TEnt> ents);
        void RemoveRange(IEnumerable<TEnt> ents);
    }
}
