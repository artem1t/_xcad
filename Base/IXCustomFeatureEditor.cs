//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Text;
using Xarial.XCad.Delegates;

namespace Xarial.XCad
{
    public interface IXCustomFeatureEditor<TData, TPage>
        where TData : class, new()
        where TPage : class, new()
    {
        void Insert(IXDocument model);
        void Edit(IXDocument model, IXCustomFeature<TData> feature);
        IXBody[] CreateGeometry(IXCustomFeatureDefinition def, TData data, bool isPreview, out AlignDimensionDelegate<TData> alignDim);
    }
}
