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
using Xarial.XCad.Structures;
using Xarial.XCad.Utils.CustomFeature;

namespace Xarial.XCad
{
    public interface IXExtension
    {
        bool OnConnect();
        bool OnDisconnect();

        IXApplication Application { get; }
        IXCommandManager CommandManager { get; }

        IXNativePage<TData> CreatePage<TData>();

        IXCustomFeatureEditor<TCustomFeatureDef, TData, TPage> CreateCustomFeatureEditor<TCustomFeatureDef, TData, TPage>(
            DataConverterDelegate<TPage, TData> pageToDataConv, DataConverterDelegate<TData, TPage> dataToPageConv,
            CreateGeometryDelegate<TData> geomCreator)
            where TCustomFeatureDef : class, IXCustomFeatureDefinition<TData>, new()
            where TData : class, new()
            where TPage : class, new();
    }
}
