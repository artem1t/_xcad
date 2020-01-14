//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;

namespace Xarial.XCad.Utils.PageBuilder.Base
{
    public interface IBinding
    {
        event Action<IBinding> ModelUpdated;
        event Action<IBinding> ControlUpdated;

        IControl Control { get; }
        object Model { get; }

        void UpdateControl();
        void UpdateDataModel();
    }
}
