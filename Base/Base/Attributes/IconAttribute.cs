﻿//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Drawing;
using Xarial.XCad.Utils.Reflection;

namespace Xarial.XCad.Attributes
{
    /// <summary>
    /// General icon for any controls or objects
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class IconAttribute : Attribute
    {
        /// <summary>
        /// Image assigned to this icon
        /// </summary>
        public Image Icon { get; private set; }

        /// <param name="resType">Type of the static class (usually Resources)</param>
        /// <param name="masterResName">Resource name of the master icon</param>
        public IconAttribute(Type resType, string masterResName)
        {
            Icon = ResourceHelper.GetResource<Image>(resType, masterResName);
        }
    }
}