﻿//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xarial.XCad.Enums;

namespace Xarial.XCad.Attributes
{
    /// <summary>
    /// Specifies that the current property is a dimension of the macro feature.
    /// The value if the property is the current value of the dimension.
    /// This property is bi-directional: it will update the value of the dimension
    /// when changed within the <see cref="IXCustomFeatureDefinition.OnRebuild(IXApplication, IXDocument, IXCustomFeature)"/> 
    /// as well as will contain the current value of the dimension when it got modified by the user in the 
    /// graphics area
    /// </summary>
    /// <remarks>This should only be used for numeric properties</remarks>
    [AttributeUsage(AttributeTargets.Property)]
    public class ParameterDimensionAttribute : Attribute
    {       
        public CustomFeatureDimensionType_e DimensionType { get; private set; }

        /// <summary>
        /// Marks this property as dimension and assigns the dimension type
        /// </summary>
        /// <param name="dimType">Type of the dimension</param>
        public ParameterDimensionAttribute(CustomFeatureDimensionType_e dimType)
        {
            DimensionType = dimType;
        }
    }
}
