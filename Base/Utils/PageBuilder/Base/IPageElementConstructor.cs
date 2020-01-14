//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

namespace Xarial.XCad.Utils.PageBuilder.Base
{
    public interface IPageElementConstructor<TGroup, TPage>
        where TGroup : IGroup
        where TPage : IPage
    {
        IControl Create(TPage page, IAttributeSet atts, ref int idRange);
        IControl Create(TGroup group, IAttributeSet atts, ref int idRange);
    }
}
