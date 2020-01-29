//*********************************************************************
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
using Xarial.XCad.Services;
using Xarial.XCad.Structures;
using Xarial.XCad.Utils.Reflection;

namespace Xarial.XCad.Utils.CustomFeature
{
    public abstract class BaseCustomFeatureEditor<TData, TPage> : IXCustomFeatureEditor<TData, TPage>
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

        private readonly XObjectEqualityComparer<IXBody> m_BodiesComparer;

        private readonly Type m_FeatDefType;

        public BaseCustomFeatureEditor(IXApplication app, IXExtension ext, 
            Type featDefType,
            CustomFeatureParametersParser paramsParser,
            DataConverterDelegate<TPage, TData> pageToDataConv,
            DataConverterDelegate<TData, TPage> dataToPageConv,
            CreateGeometryDelegate<TData> geomCreator)
        {
            m_App = app;
            m_FeatDefType = featDefType;

            if (!typeof(IXCustomFeatureDefinition<TData>).IsAssignableFrom(m_FeatDefType)) 
            {
                throw new InvalidCastException($"{m_FeatDefType.FullName} must implement {typeof(IXCustomFeatureDefinition<TData>).FullName}");
            }

            m_PageToDataConv = pageToDataConv;
            m_DataToPageConv = dataToPageConv;
            m_GeomCreator = geomCreator;

            m_BodiesComparer = new XObjectEqualityComparer<IXBody>();

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
                var featParam = m_EditingFeature.Parameters;

                m_CurData = m_DataToPageConv.Invoke(featParam);

                m_PmPage.Show(m_CurData);
                UpdatePreview();
            }
            catch
            {
                m_EditingFeature.Parameters = null;
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

                m_PreviewBodies = m_GeomCreator.Invoke(null, m_PageToDataConv.Invoke(m_CurData), true, out _);

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

            var bodiesToShow = m_EditBodies.ValueOrEmpty().Except(editBodies.ValueOrEmpty(), m_BodiesComparer);

            foreach (var body in bodiesToShow) 
            {
                body.Visible = true;
            }

            var bodiesToHide = editBodies.ValueOrEmpty().Except(m_EditBodies.ValueOrEmpty(), m_BodiesComparer);

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

            m_EditBodies = null;
            m_PreviewBodies = null;

            if (reason == PageCloseReasons_e.Okay)
            {
                if (m_EditingFeature == null)
                {
                    var feat = CurModel.Features.NewCustomFeature<TData>();
                    feat.DefinitionType = m_FeatDefType;
                    feat.Parameters = m_PageToDataConv.Invoke(m_CurData);
                    CurModel.Features.Add(feat);

                    if (feat == null) 
                    {
                        throw new NullReferenceException("Failed to create custom feature");
                    }
                }
                else
                {
                    m_EditingFeature.Parameters = m_PageToDataConv.Invoke(m_CurData);
                }
            }
            else
            {
                if (m_EditingFeature != null)
                {
                    m_EditingFeature.Parameters = null;
                }
            }
        }

        public IXBody[] CreateGeometry(IXCustomFeatureDefinition def, TData data, bool isPreview, out AlignDimensionDelegate<TData> alignDim)
        {
            return m_GeomCreator.Invoke(def, data, isPreview, out alignDim);
        }
    }
}
