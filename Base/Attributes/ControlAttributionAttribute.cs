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
    /// Provides additional attribution options (i.e. icons, labels, tooltips etc.) for all controls
    /// </summary>
    /// <remarks>Can be applied to any property which is bound to the property manager page control</remarks>
    public class ControlAttributionAttribute : Attribute, IAttribute
    {
        public BitmapLabelType_e StandardIcon { get; private set; } = 0;
        
        /// <summary>Constructor allowing specify the standard icon</summary>
        /// <param name="standardIcon">Control label</param>
        public ControlAttributionAttribute(BitmapLabelType_e standardIcon)
        {
            StandardIcon = standardIcon;
        }
    }
}
