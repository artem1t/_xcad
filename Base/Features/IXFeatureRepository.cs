//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Text;
using Xarial.XCad.Base;
using Xarial.XCad.Features.CustomFeature;

namespace Xarial.XCad.Features
{
    public interface IXFeatureRepository : IXRepository<IXFeature>
    {
        IXCustomFeature<TParams> NewCustomFeature<TParams>()
            where TParams : class, new();

        IXSketch2D New2DSketch();
        IXSketch3D New3DSketch();
    }
}
