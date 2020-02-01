//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Text;

namespace Xarial.XCad.Features.CustomFeature.Delegates
{
    public delegate TOut DataConverterDelegate<TIn, TOut>(TIn data)
        where TIn : class, new()
        where TOut : class, new();
}
