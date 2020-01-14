//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using Xarial.XCad.Utils.PageBuilder.Base;

namespace Xarial.XCad.Utils.PageBuilder.Attributes
{
    public class SupportsAttributesAttribute : Attribute, IAttribute
    {
        public Type[] Types { get; private set; }

        public SupportsAttributesAttribute(params Type[] types)
        {
            Types = types;
        }
    }
}
