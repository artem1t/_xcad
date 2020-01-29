//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using Xarial.XCad.Utils.PageBuilder.Base.Attributes;

namespace Xarial.XCad.Attributes
{
    public class DependentOnAttribute : Attribute, IDependentOnAttribute
    {
        public object[] Dependencies { get; private set; }

        public Type DependencyHandler { get; private set; }

        public DependentOnAttribute(Type dependencyHandler, params object[] dependencies)
        {
            DependencyHandler = dependencyHandler;
            Dependencies = dependencies;
        }
    }
}
