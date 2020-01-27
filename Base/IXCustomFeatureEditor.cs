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
    public interface IXCustomFeatureEditor<TCustomFeatureDef, TData, TPage>
        where TCustomFeatureDef : class, IXCustomFeatureDefinition<TData>, new()
        where TData : class, new()
        where TPage : class, new()
    {
        void Insert(IXDocument model);
        void Edit(IXDocument model, IXCustomFeature<TData> feature);
        IXBody[] CreateGeometry(TData data);
    }
}
