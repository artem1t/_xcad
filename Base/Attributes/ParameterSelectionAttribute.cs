//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.ComponentModel;

namespace Xarial.XCad.Attributes
{
    /// <summary>
    /// Specifies that the current property is a selection of the macro feature.
    /// Selections allows to provide the relations between existing objects and this macro feature.
    /// Not only macro feature can access those selections to update itself, but the <see cref="IXCustomFeatureDefinition.OnRebuild(IXApplication, IXDocument, IXCustomFeature)"/>
    /// will be automatically triggered every time the geometry of related selections is changed enabling the parametric nature of the macro feature
    /// </summary>
    /// <remarks>Supported property types <see cref="IXSelObject"/>)
    /// To specify multiple entities set the property type of <see cref="System.Collections.Generic.List{T}"/>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Property)]
    public class ParameterSelectionAttribute : Attribute
    {
    }
}
