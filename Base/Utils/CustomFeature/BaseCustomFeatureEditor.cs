﻿//*********************************************************************
//xCAD
//Copyright(C) 2020 Xarial Pty Limited
//Product URL: https://www.xcad.net
//License: https://github.com/xarial/xcad/blob/master/LICENSE
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Xarial.XCad.Delegates;
using Xarial.XCad.Enums;
using Xarial.XCad.Structures;
using Xarial.XCad.Utils.Reflection;

namespace Xarial.XCad.Utils.CustomFeature
{
    public abstract class BaseCustomFeatureEditor<TCustomFeatureDef, TData, TPage> : IXCustomFeatureEditor<TCustomFeatureDef, TData, TPage>
        where TCustomFeatureDef : class, IXCustomFeatureDefinition<TData>, new()
        where TData : class, new()
        where TPage : class, new()
    {
        private IXNativePage<TPage> m_PmPage;
        private TPage m_CurData;

        private IXBody[] m_PreviewBodies;

        protected readonly IXApplication m_App;

        protected IXDocument CurModel { get; private set; }
        private IXCustomFeature<TData> m_EditingFeature;

        private Exception m_LastError;

        private readonly CustomFeatureParametersParser m_ParamsParser;

        private readonly DataConverterDelegate<TPage, TData> m_PageToDataConv;
        private readonly DataConverterDelegate<TData, TPage> m_DataToPageConv;
        private readonly CreateGeometryDelegate<TData> m_GeomCreator;

        public BaseCustomFeatureEditor(IXApplication app, IXExtension ext, 
            CustomFeatureParametersParser paramsParser,
            DataConverterDelegate<TPage, TData> pageToDataConv,
            DataConverterDelegate<TData, TPage> dataToPageConv,
            CreateGeometryDelegate<TData> geomCreator)
        {
            m_App = app;

            m_PageToDataConv = pageToDataConv;
            m_DataToPageConv = dataToPageConv;
            m_GeomCreator = geomCreator;
            
            m_PmPage = ext.CreatePage<TPage>();

            m_ParamsParser = paramsParser;

            m_PmPage.Closing += OnPageClosing;
            m_PmPage.DataChanged += OnDataChanged;
            m_PmPage.Closed += OnPageClosed;
        }

        public void Insert(IXDocument model)
        {
            m_CurData = new TPage();

            CurModel = model;

            m_EditingFeature = null;

            m_PmPage.Show(m_CurData);
        }

        public void Edit(IXDocument model, IXCustomFeature<TData> feature)
        {
            CurModel = model;
            m_EditingFeature = feature;

            try
            {
                var featParam = m_EditingFeature.GetParameters();

                m_CurData = m_DataToPageConv.Invoke(featParam);

                m_PmPage.Show(m_CurData);
                UpdatePreview();
            }
            catch
            {
                m_EditingFeature.SetParameters(null);
            }
        }

        private void OnDataChanged()
        {
            UpdatePreview();
        }

        private void UpdatePreview()
        {
            try
            {
                m_LastError = null;

                HidePreviewBodies();

                m_PreviewBodies = m_GeomCreator.Invoke(m_PageToDataConv.Invoke(m_CurData));

                HideEditBodies();

                if (m_PreviewBodies != null)
                {
                    DisplayPreview(m_PreviewBodies);
                }
            }
            catch (Exception ex)
            {
                m_PreviewBodies = null;
                m_LastError = ex;
            }
        }

        protected abstract void DisplayPreview(IXBody[] bodies);

        private void OnPageClosing(PageCloseReasons_e reason, PageClosingArg arg)
        {
            if (m_LastError != null)
            {
                arg.ErrorMessage = m_LastError.Message;
                arg.Cancel = true;
            }
        }

        private void HidePreviewBodies()
        {
            if (m_PreviewBodies != null)
            {
                HidePreview(m_PreviewBodies);
            }

            m_PreviewBodies = null;
        }

        protected abstract void HidePreview(IXBody[] bodies);

        private IXBody[] m_EditBodies;

        private void HideEditBodies()
        {
            IXBody[] editBodies;

            m_ParamsParser.Parse(m_CurData, out _, out _, out _, out _, out editBodies);

            var bodiesToShow = m_EditBodies.ValueOrEmpty().Except(editBodies.ValueOrEmpty());

            foreach (var body in bodiesToShow) 
            {
                body.Visible = true;
            }

            var bodiesToHide = editBodies.Except(m_EditBodies);

            foreach (var body in bodiesToHide)
            {
                body.Visible = false;
            }

            m_EditBodies = editBodies;
        }

        private void OnPageClosed(PageCloseReasons_e reason)
        {
            foreach (var body in m_EditBodies.ValueOrEmpty()) 
            {
                body.Visible = true;
            }

            HidePreviewBodies();

            if (reason == PageCloseReasons_e.Okay)
            {
                if (m_EditingFeature == null)
                {
                    CurModel.FeatureManager.CreateCustomFeature<TCustomFeatureDef, TData>(m_PageToDataConv.Invoke(m_CurData));
                }
                else
                {
                    m_EditingFeature.SetParameters(m_PageToDataConv.Invoke(m_CurData));
                }
            }
            else
            {
                if (m_EditingFeature != null)
                {
                    m_EditingFeature.SetParameters(null);
                }
            }
        }
    }
}