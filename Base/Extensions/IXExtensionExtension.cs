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
    public static class IXExtensionExtension
    {
        public static IXCustomFeatureEditor<TCustomFeatureDef, TData, TData> CreateCustomFeatureEditor<TCustomFeatureDef, TData>(
            this IXExtension ext, CreateGeometryDelegate<TData> geomCreator)
            where TCustomFeatureDef : class, IXCustomFeatureDefinition<TData>, new()
            where TData : class, new()
        {
            return ext.CreateCustomFeatureEditor<TCustomFeatureDef, TData, TData>(
                d => d,
                d => d,
                geomCreator);
        }
    }
}
