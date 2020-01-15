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
    /// Property manager page options
    /// </summary>
    /// <remarks>Applied to the main class of the data model</remarks>
    public class PageOptionsAttribute : Attribute, IAttribute
    {   
        public PageOptions_e Options { get; private set; }
        
        /// <summary>Constructor for specifying property manager page options</summary>
        /// <param name="opts">property page options</param>
        public PageOptionsAttribute(PageOptions_e opts)
        {
            Options = opts;
        }
    }
}
