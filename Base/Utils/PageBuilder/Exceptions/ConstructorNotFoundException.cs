//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;

namespace Xarial.XCad.Utils.PageBuilder.Exceptions
{
    public class ConstructorNotFoundException : Exception
    {
        internal ConstructorNotFoundException(Type type, string message = "") 
            : base($"Constructor for type {type.FullName} is not found. {message}")
        {
        }
    }
}
