//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Xarial.XCad.Enums;
using Xarial.XCad.Utils.PageBuilder.Base;

namespace Xarial.XCad.Attributes
{
    /// <summary>
    /// Additional options for option box control
    /// </summary>
    public class OptionBoxOptionsAttribute : Attribute, IAttribute
    {
        public OptionBoxStyle_e Style { get; private set; }
        
        /// <summary>
        /// Assigns additional options (such as style) for this option box control
        /// </summary>
        /// <param name="style"></param>
        public OptionBoxOptionsAttribute(
            OptionBoxStyle_e style = 0)
        {
            Style = style;
        }
    }
}
