using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Xml;


namespace DocumentMallExportConnector
{
    public class XmlWriter
    {
        private readonly string _batchName;
        private string _xmlFileName = string.Empty;

        private XmlTextWriter _xmlWriter;
        private XmlDocument _xmldocument = new XmlDocument();
        
        public XmlWriter(string destination, string batchId)
        {
            _batchName = batchId;
            _xmlFileName = Path.Combine(destination, "Batch.tmp");

            _xmlWriter = new XmlTextWriter(_xmlFileName, Encoding.UTF8);
            _xmlWriter.Formatting = Formatting.Indented;
            _xmlWriter.WriteStartElement("batch");
            _xmlWriter.WriteEndElement();
            _xmlWriter.Close();
            _xmldocument.Load(_xmlFileName);
        }

        public void WriteBatchHeader(string releaseDateTime, string docbase, string user)
        {
            XmlNode root = _xmldocument.DocumentElement;
            XmlElement headerNode = _xmldocument.CreateElement("header");

            root.AppendChild(headerNode);

            WriteChildNode(headerNode, "batchid", _batchName);
            WriteChildNode(headerNode, "date", releaseDateTime);
            WriteChildNode(headerNode, "user", user);
            WriteChildNode(headerNode, "docbase", docbase);
            WriteChildNode(headerNode, "source", "Express");

            XmlElement bodyNode = _xmldocument.CreateElement("body");
            root.AppendChild(bodyNode);
        }

        public void WriteDocumentData(string docName, string securityKey, string path, string docType)
        {
            if (string.IsNullOrEmpty(docName) || string.IsNullOrEmpty(securityKey) || string.IsNullOrEmpty(path))
                throw new Exception("Document data is blank");

            XmlElement root = _xmldocument.DocumentElement;
            XmlNode bodyNode = root.SelectSingleNode("//*/body");
            XmlElement documentNode = _xmldocument.CreateElement("document");

            bodyNode.AppendChild(documentNode);

            WriteChildNode(documentNode, "name", docName);
            WriteChildNode(documentNode, "title", string.Empty);
            WriteChildNode(documentNode, "desc", string.Empty);
            WriteChildNode(documentNode, "keywords", string.Empty);
            WriteChildNode(documentNode, "authors", string.Empty);
            WriteChildNode(documentNode, "securitykey", securityKey);

            XmlElement folderLinksNode = _xmldocument.CreateElement("folderlinks");
            
            WriteChildNode(folderLinksNode, "path", path);
            documentNode.AppendChild(folderLinksNode);

            XmlElement docTypeNode = _xmldocument.CreateElement("doctype");

            WriteChildNode(docTypeNode, "tname", docType);
            documentNode.AppendChild(docTypeNode);
        }

        public void WriteDocumentIndexData(string indexName, string indexValue, string documentName)
        {
            XmlElement root = _xmldocument.DocumentElement;
            XmlNode indexNode;

            indexNode = root.SelectSingleNode("//*/document[name='" + Path.GetFileName(documentName) + "']/doctype");
            
            XmlElement indexElement = _xmldocument.CreateElement("index");

            WriteChildNode(indexElement, "iname", indexName);
            WriteChildNode(indexElement, "ivalue", indexValue);
            indexNode.AppendChild(indexElement);
        }

        public void WriteDocumentFileDataMultiPage(string fileName)
        {
            XmlElement root = _xmldocument.DocumentElement;
            XmlNode documentNode = root.SelectSingleNode("//*/document[name='" + Path.GetFileName(fileName) + "']");
            XmlElement contentNode = _xmldocument.CreateElement("content");

            documentNode.AppendChild(contentNode);

            XmlElement fileNode = _xmldocument.CreateElement("file");
            
            WriteChildNode(fileNode, "fname", Path.GetFileName(fileName));
            WriteChildNode(fileNode, "format", GetFileExtension(Path.GetExtension(fileName).TrimStart('.')));
            contentNode.AppendChild(fileNode);
        }

        public void WriteDocumentFileDataSinglePage(string document, string fileName)
        {
            XmlElement root = _xmldocument.DocumentElement;
            XmlNode documentNode = root.SelectSingleNode("//*/document[name='" + document + "']");
            XmlElement contentNode = _xmldocument.CreateElement("content");

            documentNode.AppendChild(contentNode);

            XmlElement fileNode = _xmldocument.CreateElement("file");

            WriteChildNode(fileNode, "fname", Path.GetFileName(fileName));
            WriteChildNode(fileNode, "format", GetFileExtension(Path.GetExtension(fileName).TrimStart('.')));
            contentNode.AppendChild(fileNode);
        }

        public void WriteDocumentDataIndexFileSinglePage(string docName, string securityKey, string path, string docType, ArrayList indexArray, string fileName)
        {
            ValidationDocumentFields(docName, securityKey, path);

            XmlElement root = _xmldocument.DocumentElement;
            XmlNode bodyNode = root.SelectSingleNode("//*/body");
            XmlElement documentNode = _xmldocument.CreateElement("document");

            bodyNode.AppendChild(documentNode);

            WriteChildNode(documentNode, "name", docName);
            WriteChildNode(documentNode, "title", string.Empty);
            WriteChildNode(documentNode, "desc", string.Empty);
            WriteChildNode(documentNode, "keywords", string.Empty);
            WriteChildNode(documentNode, "authors", string.Empty);
            WriteChildNode(documentNode, "securitykey", securityKey);

            XmlElement folderLinksNode = _xmldocument.CreateElement("folderlinks");

            WriteChildNode(folderLinksNode, "path", path);
            documentNode.AppendChild(folderLinksNode);

            XmlElement docTypeNode = _xmldocument.CreateElement("doctype");

            WriteChildNode(docTypeNode, "tname", docType);
            documentNode.AppendChild(docTypeNode);

            XmlElement indexElement = _xmldocument.CreateElement("index");

            foreach (string list in indexArray)
            {
                string[] data = list.Split(',');

                WriteChildNode(indexElement, "iname", data[0]);
                WriteChildNode(indexElement, "ivalue", data[1]);
            }

            documentNode.AppendChild(indexElement);

            XmlElement contentNode = _xmldocument.CreateElement("content");

            documentNode.AppendChild(contentNode);

            XmlElement fileNode = _xmldocument.CreateElement("file");

            WriteChildNode(fileNode, "fname", Path.GetFileName(fileName));
            WriteChildNode(fileNode, "format", GetFileExtension(Path.GetExtension(fileName).TrimStart('.')));
            contentNode.AppendChild(fileNode);
        }

        public void CloseXml()
        {
            _xmldocument.Save(_xmlFileName);
            _xmlWriter.Close();

            File.Move(_xmlFileName, Path.ChangeExtension(_xmlFileName, "xml"));
        }

        private void WriteChildNode(XmlElement root, string element, string value)
        {
            XmlElement childNode = _xmldocument.CreateElement(element);

            childNode.InnerText = value;

            root.AppendChild(childNode);
        }

        private void ValidationDocumentFields(string docName, string securityKey, string path)
        {
            if (string.IsNullOrEmpty(docName))
                throw new Exception("DocumentName is empty");
            
            if (string.IsNullOrEmpty(securityKey))
                throw new Exception("SecurityKey is empty");
            
            if (string.IsNullOrEmpty(path))
                throw new Exception("Path is empty");
        }

        /// <summary>
        /// Converts tif to tiff for the format element in the xml
        /// </summary>
        /// <param name="extension">Image file extension</param>
        /// <returns>TIFF if the image is TIF. Otherwise returns the default extension</returns>
        private string GetFileExtension(string extension)
        {
            return extension.ToLower().Equals("tif") ? "tiff" : extension;
        }
    }
 }
