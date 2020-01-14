//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Text;

namespace Xarial.XCad.Attributes
{
    public class SkipRegistrationAttribute : Attribute
    {
        public bool Skip { get; private set; }

        public SkipRegistrationAttribute() : this(true) 
        {
        }

        public SkipRegistrationAttribute(bool skip) 
        {
            Skip = skip;
        }
    }
}
