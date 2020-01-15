//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System.Collections.Generic;
using System;
using Xarial.XCad.Utils.PageBuilder.Attributes;
using Xarial.XCad.Utils.PageBuilder.Base;
using Xarial.XCad.Services;
using Xarial.XCad.Enums;

namespace Xarial.XCad.Attributes
{
    public interface ISelectionBoxConstructor 
    {
    }

    /// <summary>
    /// Sets the current control to be a selection box
    /// </summary>
    /// <remarks>This attribute is applicable for properties of type <see cref="object"/> or
    /// specific type etc.
    /// In this case the selection box will allow single entity selection only.
    /// <see cref="IList{T}"/> are also supported. In this case multiple entities can be selected</remarks>
    public class SelectionBoxAttribute : SpecificConstructorAttribute
    {
        public SelectType_e[] Filters { get; private set;}
        public int SelectionMark { get; private set; }
        public Type CustomFilter { get; private set; }

        /// <summary>
        /// Constructor for selection box options
        /// </summary>
        /// <param name="filters">Filters allowed for selection into this selection box</param>
        public SelectionBoxAttribute(params SelectType_e[] filters)
            : this(-1, filters)
        {
        }

        /// <inheritdoc cref="SelectionBoxAttribute(SelectType_e[])"/>
        /// <param name="mark">Selection mark. If multiple selections box are used - use different selection marks for each of them
        /// to differentiate the selections</param>
        public SelectionBoxAttribute(int mark, params SelectType_e[] filters)
            : this(mark, null, filters)
        {
        }

        /// <inheritdoc cref="SelectionBoxAttribute(int, Type, SelectType_e[])"/>
        public SelectionBoxAttribute(Type customFilter, params SelectType_e[] filters)
            : this(-1, customFilter, filters)
        {
        }

        /// <inheritdoc cref="SelectionBoxAttribute(int, SelectType_e[])"/>
        /// <param name="customFilter">Type of custom filter of <see cref="SelectionCustomFilter{TSelection}"/> for custom logic for filtering selection objects</param>
        /// <exception cref="InvalidCastException"/>
        public SelectionBoxAttribute(int mark, Type customFilter, params SelectType_e[] filters)
            : base(typeof(ISelectionBoxConstructor))
        {
            Filters = filters;
            SelectionMark = mark;

            if (customFilter != null)
            {
                if (!typeof(ISelectionCustomFilter).IsAssignableFrom(customFilter))
                {
                    throw new InvalidCastException($"{customFilter.FullName} doesn't implement {typeof(ISelectionCustomFilter).FullName}");
                }

                CustomFilter = customFilter;
            }
        }
    }
}
