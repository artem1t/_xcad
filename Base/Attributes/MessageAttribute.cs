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
using Xarial.XCad.Enums;
using Xarial.XCad.Utils.PageBuilder.Base;

namespace Xarial.XCad.Attributes
{
    /// <summary>
    /// Attributes allows to specify the message to be displayed in the property manager page
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class MessageAttribute : Attribute, IAttribute
    {
        public string Text { get; private set; }
        public PageMessageVisibility Visibility { get; private set; }
        public PageMessageExpanded Expanded { get; private set; }
        public string Caption { get; private set; }

        /// <summary>
        /// Constructor to specify message and its parameters
        /// </summary>
        /// <param name="text">Text to be displayed in the message</param>
        /// <param name="caption">Message box caption</param>
        /// <param name="visibility">Visibility option</param>
        /// <param name="expanded">Expansion state</param>
        public MessageAttribute(string text, string caption,
            PageMessageVisibility visibility = PageMessageVisibility.Visible,
            PageMessageExpanded expanded = PageMessageExpanded.Expand)
        {
            Text = text;
            Caption = caption;
            Visibility = visibility;
            Expanded = expanded;
        }
    }
}
