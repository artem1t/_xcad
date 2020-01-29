//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Text;

namespace Xarial.XCad.Features
{
    public static class IXFeatureCollectionExtension
    {
        public static void Add(this IXFeatureCollection featColl, params IXFeature[] feats)
        {
            featColl.AddRange(feats);
        }
    }
}
