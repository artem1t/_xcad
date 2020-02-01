using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Xarial.XCad.Properties;
using Xarial.XCad.Reflection;

namespace Xarial.XCad
{
    public static class Defaults
    {
        public static Image Icon 
        {
            get 
            {
                return ResourceHelper.FromBytes(Resources.default_icon);
            }
        }
    }
}
