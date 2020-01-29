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
using Xarial.XCad.UI.PropertyPage.Base;
using Xarial.XCad.UI.PropertyPage.Enums;

namespace Xarial.XCad.UI.PropertyPage.Attributes
{
    /// <summary>
    /// Additional options for text box control
    /// </summary>
    /// <remarks>Applied to property of type <see cref="string"/></remarks>
    public class TextBoxOptionsAttribute : Attribute, IAttribute
    {
        public TextBoxStyle_e Style { get; private set; }

        /// <summary>
        /// Constructor for text box options
        /// </summary>
        /// <param name="style">Text box control style</param>
        public TextBoxOptionsAttribute(TextBoxStyle_e style = TextBoxStyle_e.None)
        {
            Style = style;
        }
    }
}
