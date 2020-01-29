﻿//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using Xarial.XCad.Utils.PageBuilder.Base.Attributes;

namespace Xarial.XCad.Attributes
{
    public class ControlTagAttribute : Attribute, IControlTagAttribute
    {
        /// <summary>
        /// Tag associated with the control
        /// </summary>
        public object Tag { get; private set; }

        public ControlTagAttribute(object tag)
        {
            Tag = tag;
        }
    }
}