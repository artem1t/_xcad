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
    /// Specifies that the current property is an edit body of the macro feature.
    /// Edit bodies are used by macro feature if it is required to modify or replace any existing bodies.
    /// Edit bodies will be acquire by macro feature and replaced by the <see cref="Base.MacroFeatureRebuildBodyResult"/>
    /// returned from <see cref="IXCustomFeatureDefinition.OnRebuild(IXApplication, IXDocument, IXCustomFeature)"/>.
    /// Multiple bodies are supported
    /// </summary>
    /// <remarks>Supported property type is IXBody
    /// or <see cref="System.Collections.Generic.List{T}"/> of bodies</remarks>
    [AttributeUsage(AttributeTargets.Property)]
    public class ParameterEditBodyAttribute : Attribute
    {
    }
}
