//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System.Collections.Generic;

namespace Xarial.XCad.Utils.PageBuilder.Base
{
    public interface IBindingManager
    {
        IEnumerable<IBinding> Bindings { get; }
        IDependencyManager Dependency { get; }

        void Load(IEnumerable<IBinding> bindings, IRawDependencyGroup dependencies);
    }
}
