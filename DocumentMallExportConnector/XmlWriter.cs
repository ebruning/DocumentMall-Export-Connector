﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Kofax.Eclipse.Base;

namespace DocumentMallExportConnector
{
    public class XmlWriter
    {
        private readonly string _batchName;
        private string _xmlFileName = "";

        private XmlTextWriter _xmlWriter;
        private XmlDocument _xmldocument = new XmlDocument();
        
        public XmlWriter(string destination, string batchId)
        {
            _batchName = batchId;
            _xmlFileName = Path.Combine(destination, "batch.xml");

            _xmlWriter = new XmlTextWriter(_xmlFileName, Encoding.UTF8);
            _xmlWriter.Formatting = Formatting.Indented;
            _xmlWriter.WriteStartElement("batch");
            _xmlWriter.WriteEndElement();
            _xmlWriter.Close();
            _xmldocument.Load(_xmlFileName);
        }

        public void WriteBatchHeader(string releaseDateTime, string docbase)
        {
            XmlNode root = _xmldocument.DocumentElement;
            XmlElement headerNode = _xmldocument.CreateElement("header");

            root.AppendChild(headerNode);

            WriteChildNode(headerNode, "batchid", _batchName);
            WriteChildNode(headerNode, "date", releaseDateTime);
            WriteChildNode(headerNode, "docbase", docbase);
            WriteChildNode(headerNode, "source", "Express");

            XmlElement bodyNode = _xmldocument.CreateElement("body");
            root.AppendChild(bodyNode);
        }

        public void WriteDocumentData(string docName, string securityKey, string path, string docType)
        {
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

            WriteChildNode(docTypeNode, "iname", docType);
            documentNode.AppendChild(docTypeNode);
        }

        public void WriteDocumentIndexData(string indexName, string indexValue, string documentName)
        {
            XmlElement root = _xmldocument.DocumentElement;
            XmlNode indexNode = root.SelectSingleNode("//*/document[name='" + Path.GetFileName(documentName) + "']/doctype");
            XmlElement indexElement = _xmldocument.CreateElement("index");

            WriteChildNode(indexElement, "iname", indexName);
            WriteChildNode(indexElement, "ivalue", indexValue);
            indexNode.AppendChild(indexElement);
        }

        public void WriteDocumentFileData(string fileName)
        {
            XmlElement root = _xmldocument.DocumentElement;
            XmlNode documentNode = root.SelectSingleNode("//*/document[name='" + Path.GetFileName(fileName) + "']");
            XmlElement contentNode = _xmldocument.CreateElement("content");

            documentNode.AppendChild(contentNode);

            XmlElement fileNode = _xmldocument.CreateElement("file");
            
            WriteChildNode(fileNode, "fname", Path.GetFileName(fileName));
            WriteChildNode(fileNode, "format", Path.GetExtension(fileName).TrimStart('.'));
            contentNode.AppendChild(fileNode);
        }

        public void CloseXml()
        {
            _xmldocument.Save(_xmlFileName);
            _xmlWriter.Close();
        }

        private void WriteChildNode(XmlElement root, string element, string value)
        {
            XmlElement childNode = _xmldocument.CreateElement(element);

            childNode.InnerText = value;

            root.AppendChild(childNode);
        }
    }
 }
