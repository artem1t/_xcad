//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.XCad.Utils.PageBuilder.Base.Attributes;

namespace Xarial.XCad.Attributes
{
    public interface ITabConstructor 
    {
    }

    /// <summary>
    /// Attribute indicates that current property or class should be rendered as tab box
    /// </summary>
    /// <remarks>This attribute is only applicable for complex types which contain nested properties</remarks>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class TabAttribute : Attribute, ISpecificConstructorAttribute
    {
        public Type ConstructorType { get; }

        /// <summary>
        /// Sets the current property as tab container
        /// </summary>
        public TabAttribute()
        {
            ConstructorType = typeof(ITabConstructor);
        }
    }
}
