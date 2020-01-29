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

namespace Xarial.XCad.Services
{
    /// <summary>
    /// Handler of each macro feature
    /// </summary>
    /// <remarks>The instance of the specific class will be created for each macro feature</remarks>
    public interface ICustomFeatureHandler
    {
        /// <summary>
        /// Called when macro feature is created or loaded first time
        /// </summary>
        /// <param name="app">Pointer to application</param>
        /// <param name="model">Pointer to model</param>
        /// <param name="feat">Pointer to feature</param>
        void Init(IXApplication app, IXDocument model, IXFeature feat);

        /// <summary>
        /// Called when macro feature is deleted or model is closed
        /// </summary>
        /// <param name="reason">Reason of macro feature unload</param>
        void Unload(CustomFeatureUnloadReason_e reason);
    }
}