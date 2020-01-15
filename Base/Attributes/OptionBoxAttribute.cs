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
using Xarial.XCad.Utils.PageBuilder.Attributes;

namespace Xarial.XCad.Attributes
{
    public interface IOptionBoxConstructor 
    {
    }

    /// <summary>
    /// Attribute indicates that current property should be rendered as option box
    /// </summary>
    /// <remarks>This attribute is only applicable for <see cref="Enum">enum</see> types</remarks>
    public class OptionBoxAttribute : SpecificConstructorAttribute
    {
        /// <summary>
        /// Sets the current property as option box
        /// </summary>
        public OptionBoxAttribute() : base(typeof(IOptionBoxConstructor))
        {
        }
    }
}
