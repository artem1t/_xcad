﻿//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Text;
using Xarial.XCad.Enums;
using Xarial.XCad.Structures;

namespace Xarial.XCad
{
    public interface IXCustomFeatureDefinition
    {
        /// <summary>
        /// Called when the Edit feature menu is clicked from the feature manager tree
        /// </summary>
        /// <param name="app">Pointer to the application</param>
        /// <param name="model">Pointer to the current model where the feature resided</param>
        /// <param name="feature">Pointer to the feature being edited</param>
        /// <returns>Result of the editing</returns>
        /// <remarks>Use this handler to display property manager page or any other user interface to edit feature.
        /// </remarks>
        bool OnEditDefinition(IXApplication app, IXDocument model, IXCustomFeature feature);

        /// <summary>
        /// Called when macro feature is rebuilding
        /// </summary>
        /// <param name="app">Pointer to the SOLIDWORKS application</param>
        /// <param name="model">Pointer to the document where the macro feature being rebuild</param>
        /// <param name="feature">Pointer to the feature</param>
        /// <returns>Result of the operation. Use static methods of <see cref="MacroFeatureRebuildResult"/>
        /// class to generate results</returns>
        CustomFeatureRebuildResult OnRebuild(IXApplication app, IXDocument model, IXCustomFeature feature);

        /// <summary>
        /// Called when state of the feature is changed (i.e. feature is selected, moved, updated etc.)
        /// Use this method to provide additional dynamic security options on your feature (i.e. do not allow dragging, editing etc.)
        /// </summary>
        /// <param name="app">Pointer to the application</param>
        /// <param name="model">Pointer to the model where the feature resides</param>
        /// <param name="feature">Pointer to the feature to updated state</param>
        /// <returns>State of feature</returns>
        CustomFeatureState_e OnUpdateState(IXApplication app, IXDocument model, IXCustomFeature feature);
    }

    public delegate void AlignDimensionDelegate(string paramName, IXDimension dim);

    public interface IXCustomFeatureDefinition<TParams> : IXCustomFeatureDefinition
        where TParams : class, new()
    {
        CustomFeatureRebuildResult OnRebuild(IXApplication app, IXDocument model, IXCustomFeature feature, TParams parameters, out AlignDimensionDelegate alignDim);

        void AlignDimension(IXDimension dim, Point originPt, Vector dir, Vector extDir);
    }

    public static class IXCustomFeatureDefinitionExtension 
    {
        public static void AlignRadialDimension<TParams>(this IXCustomFeatureDefinition<TParams> featDef, IXDimension dim, Point originPt, Vector normal)
            where TParams : class, new()
        {
            Vector dir = null;
            Vector extDir = null;

            var yVec = new Vector(0, 1, 0);

            if (normal.IsSame(yVec))
            {
                dir = new Vector(1, 0, 0);
            }
            else
            {
                dir = normal.Cross(yVec);
            }

            extDir = normal.Cross(dir);

            featDef.AlignDimension(dim, originPt, dir, extDir);
        }
    }
}
