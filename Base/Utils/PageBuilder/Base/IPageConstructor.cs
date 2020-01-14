//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

namespace Xarial.XCad.Utils.PageBuilder.Base
{
    public interface IPageConstructor<TPage>
        where TPage : IPage
    {
        TPage Create(IAttributeSet atts);
    }
}
