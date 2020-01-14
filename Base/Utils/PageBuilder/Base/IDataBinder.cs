//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;

namespace Xarial.XCad.Utils.PageBuilder.Base
{
    public delegate IControl CreateBindingControlDelegate(Type dataType, IAttributeSet atts, IGroup parent, out int idRange);
    public delegate IPage CreateBindingPageDelegate(IAttributeSet atts);

    public interface IDataModelBinder
    {
        void Bind<TDataModel>(TDataModel model, CreateBindingPageDelegate pageCreator,
            CreateBindingControlDelegate ctrlCreator,
            out IEnumerable<IBinding> bindings, out IRawDependencyGroup dependencies);
    }
}
