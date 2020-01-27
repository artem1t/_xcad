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
    public static class IXFeatureManagerExtension
    {
        public static IXCustomFeature CreateCustomFeature<TDef, TParams>(this IXFeatureManager featMgr, TParams param)
            where TDef : class, IXCustomFeatureDefinition, new()
            where TParams : class, new()
        {
            return featMgr.CreateCustomFeature<TParams>(typeof(TDef), param);
        }
    }
}
