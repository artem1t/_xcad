//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using Xarial.XCad.Utils.PageBuilder.Base.Attributes;

namespace Xarial.XCad.Utils.PageBuilder.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SpecificConstructorAttribute : Attribute, ISpecificConstructorAttribute
    {
        public Type ConstructorType { get; private set; }

        public SpecificConstructorAttribute(Type constrType)
        {
            ConstructorType = constrType;
        }
    }
}
