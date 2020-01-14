//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

namespace Xarial.XCad.Utils.PageBuilder.Base
{
    public interface IDependencyManager
    {
        void Init(IRawDependencyGroup depGroup);
        void UpdateAll();
    }
}
