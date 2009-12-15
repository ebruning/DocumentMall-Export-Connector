using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Kofax.Eclipse.Base;
using Kofax.VRS.UI.Common.Tools;

namespace DocumentMallExportConnector
{
    public class DmEc : IReleaseScript
    {
        private ReleaseSettings _releaseSettings = new ReleaseSettings();
        private IPageOutputConverter _pageConverter;
        private IDocumentOutputConverter _docConverter;

        private XmlWriter _xmlData;
        private string _batchFolder = string.Empty;
        private string _documentFolder = string.Empty;
        private string _batchName;

        private string _strName = string.Empty;
        ArrayList _indexArray = new ArrayList();
        private string _docNumber = string.Empty;
        private string _docRepositoryPath = string.Empty;
        private string _docType = string.Empty;
        
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
            get { return _releaseSettings.ReleaseMode; }
        }
        #endregion

        #region Settings
        public void DeserializeSettings(Stream input)
        {
            try
            {
                _releaseSettings = Serialization.Read<ReleaseSettings>(input) ?? new ReleaseSettings();
            }
            catch
            {
                _releaseSettings = new ReleaseSettings();
            }
        }

        public void SerializeSettings(Stream output)
        {
            Serialization.Write(output, _releaseSettings);
        }

        public void Setup(IList<IExporter> exporters, IIndexField[] indexFields,
                          IDictionary<string, string> releaseData)
        {
            DmEcSetup setup = new DmEcSetup(ref _releaseSettings, exporters, indexFields);
            setup.ShowDialog();

        }
        #endregion

        public object StartRelease(IList<IExporter> exporters,
                                   IIndexField[] indexFields,
                                   IDictionary<string, string> releaseData)
        {
            if (string.IsNullOrEmpty(_releaseSettings.Destination))
                throw new Exception("Please specify a release destination");

            _docConverter = null;
            _pageConverter = null;

            foreach (IExporter exporter in exporters)
            {
                if (exporter.Id == _releaseSettings.FileTypeId)
                {
                    if (_releaseSettings.ReleaseMode == ReleaseMode.SinglePage)
                        _pageConverter = exporter as IPageOutputConverter;
                    else
                        _docConverter = exporter as IDocumentOutputConverter;
                }
            }

            if (_pageConverter == null && _docConverter == null)
                throw new Exception("Please specify an output file type.");

            return null;
        }

        public object StartBatch(IBatch batch)
        {
            //Set the batch folder using the destination, Account and batch name
            _batchFolder = Path.Combine(_releaseSettings.Destination, Path.Combine(_releaseSettings.Account, batch.Name + "-" + Environment.MachineName));
            _batchName = batch.Name;

            if (Directory.Exists(_batchFolder))
                throw new Exception("Batch folder already exists");

            Directory.CreateDirectory(_batchFolder);
            _xmlData = new XmlWriter(_batchFolder, batch.Name);
            _xmlData.WriteBatchHeader(DateTime.Now.ToShortDateString(), _releaseSettings.Account, _releaseSettings.User);
            
            return null;
        }

        public void Release(IDocument doc)
        {
            string[] indexValues = new string[doc.IndexDataCount];
            for (int i = 0; i < doc.IndexDataCount; i++)
                indexValues[i] = doc.GetIndexDataValue(i);

            string strName = DefaultName.CalculateDefaultName(_releaseSettings.DocumentName, _batchName, doc.Number, indexValues) + "." + _docConverter.DefaultExtension;
            string fileName = Utilities.UniqueFileName(Path.Combine(_batchFolder, strName));

            _docConverter.Convert(doc, fileName);

            SetDocumentDataMultiPage(doc, fileName);

            _xmlData.WriteDocumentFileDataMultiPage(Path.GetFileName(fileName));
        }
        
        public object StartDocument(IDocument doc)
        {
            string[] indexValues = new string[doc.IndexDataCount];
            for (int i = 0; i < doc.IndexDataCount; i++)
                indexValues[i] = doc.GetIndexDataValue(i);

            //_documentFolder = Path.Combine(_batchFolder, doc.Number.ToString());
            if (!Directory.Exists(_batchFolder))
                Directory.CreateDirectory(_batchFolder);

            //string fullyQulifiedFileName = GetPathFile(doc);
            _strName = DefaultName.CalculateDefaultName(_releaseSettings.DocumentName, _batchName, doc.Number, indexValues);
            _docNumber = doc.Number.ToString();
            _docRepositoryPath = ConvertRepositoryPath(doc);
            _docType = GetDocumentType(doc);

            _indexArray.Clear();

            for (int i = 0; i < doc.IndexDataCount; i++)
            {
                _indexArray.Add(string.Format("{0},{1}", doc.GetIndexDataLabel(i), doc.GetIndexDataValue(i)));
            }

            return null;
        }

        public void Release(IPage page)
        {

            //string _singlePageName = Utilities.UniqueFileName(Path.Combine(_batchFolder, strName));
            string _singlePageName = Utilities.UniqueFileName(Path.Combine(_batchFolder, _strName) + "-" + page.Number + "." + _pageConverter.DefaultExtension);
            _pageConverter.Convert(page, _singlePageName);

            //_xmlData.WriteDocumentFileDataMultiPage(_singlePageName);
            //_xmlData.WriteDocumentFileDataSinglePage(_docNumber, _singlePageName);

            _xmlData.WriteDocumentDataIndexFileSinglePage(_docNumber, _releaseSettings.SecurityKey, _docRepositoryPath, _docType, _indexArray, _singlePageName);
        }

        public void EndDocument(IDocument doc, object handle, ReleaseResult result)
        {
        }

        public void EndBatch(IBatch batch, object handle, ReleaseResult result)
        {
            _xmlData.CloseXml();
        }

        public void EndRelease(object handle, ReleaseResult result)
        {
        }

        public void SetDocumentDataMultiPage(IDocument doc, string fullyQulifiedFileName)
        {
            _xmlData.WriteDocumentData(Path.GetFileName(fullyQulifiedFileName), _releaseSettings.SecurityKey, ConvertRepositoryPath(doc), GetDocumentType(doc));

            for (int indexCount = 0; indexCount < doc.IndexDataCount; indexCount++)
            {
                if (doc.GetIndexDataValue(indexCount) != GetDocumentType(doc))
                {
                    _xmlData.WriteDocumentIndexData(doc.GetIndexDataLabel(indexCount), doc.GetIndexDataValue(indexCount), fullyQulifiedFileName);
                }
            }
        }

        public string GetPathFile(IDocument doc)
        {
            string outputFileName = _releaseSettings.ReleaseMode == ReleaseMode.SinglePage ? Path.Combine(_documentFolder, doc.Number.ToString())
                                                                                           : Path.Combine(_batchFolder, doc.Number.ToString());

            string fullyQulifiedFileName = _releaseSettings.ReleaseMode == ReleaseMode.SinglePage ? Path.ChangeExtension(outputFileName, _pageConverter.DefaultExtension)
                                                                                           : Path.ChangeExtension(outputFileName, _docConverter.DefaultExtension);

            return fullyQulifiedFileName;
        }

        private string ConvertRepositoryPath(IDocument doc)
        {
            string[] indexValues = new string[doc.IndexDataCount];
            for (int i = 0; i < doc.IndexDataCount; i++)
                indexValues[i] = doc.GetIndexDataValue(i);

            return DefaultName.CalculateDefaultName(_releaseSettings.RepositoryPath, _batchName, doc.Number, indexValues);
        }

        private string GetDocumentType(IDocument doc)
        {
            return doc.GetIndexDataValue(_releaseSettings.DocumentType) ?? _releaseSettings.DocumentType;
        }
    }
}
