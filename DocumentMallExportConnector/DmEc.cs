using System;
using System.Collections.Generic;
using System.Text;
using Kofax.Eclipse.Base;
namespace DocumentMallExportConnector
{
    public class DmEc : IReleaseScript
    {
        private ReleaseMode _workingMode;

        #region Export Connector definitions
        public string Description
        {
            get { return "Export connector for DocumentMall."; }
        }

        public Guid Id
        {
            get { return new Guid("{48F62FC5-3EAA-410c-962D-D817F1A4D4B7}"); }
        }

        public bool IsSupported(ReleaseMode mode)
        {
            return true;
        }

        public string Name
        {
            get { return "DocumentMall"; }
        }

        public ReleaseMode WorkingMode
        {
            get { return _workingMode; }
        } 
        #endregion
        
        #region Settings
        public void DeserializeSettings(System.IO.Stream input)
        {

        }

        public void SerializeSettings(System.IO.Stream output)
        {

        }

        public void Setup(IList<IExporter> exporters, IIndexField[] indexFields, IDictionary<string, string> releaseData)
        {
            DmEcSetup setup = new DmEcSetup(exporters);
            setup.ShowDialog();

        } 
        #endregion

        public object StartRelease(IList<IExporter> exporters, IIndexField[] indexFields, IDictionary<string, string> releaseData)
        {
            return null;
        }
        
        public object StartBatch(IBatch batch)
        {
            return null;
        }

        public void Release(IDocument doc)
        {

        }

        public object StartDocument(IDocument doc)
        {
            return null;
        }

        public void Release(IPage page)
        {

        }
        
        public void EndDocument(IDocument doc, object handle, ReleaseResult result)
        {

        }

        public void EndBatch(IBatch batch, object handle, ReleaseResult result)
        {

        }

        public void EndRelease(object handle, ReleaseResult result)
        {

        }
    }
}
