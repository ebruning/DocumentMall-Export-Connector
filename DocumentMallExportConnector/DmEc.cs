using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Kofax.Eclipse.Base;
using Kofax.Eclipse.Tools;

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

        }

        public void SerializeSettings(Stream output)
        {
            _releaseSettings.SaveSettings();

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

            SetDocumentData(doc, fileName);

            _xmlData.WriteDocumentFileDataMultiPage(Path.GetFileName(fileName));
        }

        private string _strName = string.Empty;
        private string _docNumber = string.Empty;
        public object StartDocument(IDocument doc)
        {
            string[] indexValues = new string[doc.IndexDataCount];
            for (int i = 0; i < doc.IndexDataCount; i++)
                indexValues[i] = doc.GetIndexDataValue(i);

            _documentFolder = Path.Combine(_batchFolder, doc.Number.ToString());
            if (!Directory.Exists(_documentFolder))
                Directory.CreateDirectory(_documentFolder);

            //string fullyQulifiedFileName = GetPathFile(doc);
            _strName = DefaultName.CalculateDefaultName(_releaseSettings.DocumentName, _batchName, doc.Number, indexValues) + "." + _pageConverter.DefaultExtension;

            //SetDocumentData(doc, null);
            _docNumber = doc.Number.ToString();
            return null;
        }

        public void Release(IPage page)
        {

            //string _singlePageName = Utilities.UniqueFileName(Path.Combine(_batchFolder, strName));
            string _singlePageName = Utilities.UniqueFileName(Path.Combine(_documentFolder, _strName));
            _pageConverter.Convert(page, _singlePageName);

            //_xmlData.WriteDocumentFileDataMultiPage(_singlePageName);
            //_xmlData.WriteDocumentFileDataSinglePage(_docNumber, _singlePageName);
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

        public void SetDocumentData(IDocument doc, string fullyQulifiedFileName)
        {
            if (_releaseSettings.ReleaseMode == ReleaseMode.MultiPage)
                _xmlData.WriteDocumentData(Path.GetFileName(fullyQulifiedFileName), _releaseSettings.SecurityKey, ConvertRepositoryPath(doc), GetDocumentType(doc));
            else
                _xmlData.WriteDocumentData(doc.Number.ToString(), _releaseSettings.SecurityKey, ConvertRepositoryPath(doc), GetDocumentType(doc));

            for (int indexCount = 0; indexCount < doc.IndexDataCount; indexCount++)
            {
                if (doc.GetIndexDataValue(indexCount) != GetDocumentType(doc))
                {
                    if (_releaseSettings.ReleaseMode == ReleaseMode.MultiPage)
                        _xmlData.WriteDocumentIndexData(doc.GetIndexDataLabel(indexCount), doc.GetIndexDataValue(indexCount), fullyQulifiedFileName, true);
                    else
                        _xmlData.WriteDocumentIndexData(doc.GetIndexDataLabel(indexCount), doc.GetIndexDataValue(indexCount), doc.Number.ToString(), false);
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

        //public Dictionary<string,string> GetIndexDictionary(IDocument doc)
        //{
        //    Dictionary<string,string> output = new Dictionary<string, string>();

        //    foreach (KeyValuePair<string, string> index in _releaseSettings.IndexPairs)
        //    {
        //        for (int i = 0; i < doc.IndexDataCount; i++)
        //        {
        //            if (index.Value.Equals(doc.GetIndexDataLabel(i)))
        //                output.Add(index.Key, doc.GetIndexDataValue(i));
        //        }
        //    }
        //    return output;
        //}

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
