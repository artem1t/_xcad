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
    public interface IXCustomFeature : IXFeature
    {
        IXConfiguration Configuration { get; }
    }

    public interface IXCustomFeature<TParams> : IXFeature
        where TParams : class, new()
    {
        TParams GetParameters();

        void SetParameters(TParams param);
    }
}
