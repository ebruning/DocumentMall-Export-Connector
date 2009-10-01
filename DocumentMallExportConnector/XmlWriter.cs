using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Kofax.Eclipse.Base;

namespace DocumentMallExportConnector
{
    public class XmlWriter
    {
        private string _batchName;

        private FileStream _stream;
        private StreamWriter _writer;

        public XmlWriter(string destination, string batchId)
        {
            _batchName = batchId;
            _stream = new FileStream(Path.Combine(destination, batchId + ".xml"), FileMode.Append, FileAccess.Write, FileShare.None);
            _writer = new StreamWriter(_stream, Encoding.ASCII);
        }

        public void WriteBatchHeader(string releaseDateTime, string docbase)
        {
            _writer.Write("<batch>" + Environment.NewLine);
            _writer.Write("  <header>" + Environment.NewLine);
            _writer.Write(string.Format("    <batchid>{0}</batchid>", _batchName) + Environment.NewLine);
            _writer.Write( string.Format("    <date>{0}</date>", releaseDateTime) + Environment.NewLine);
            _writer.Write(string.Format("  <docbase>{0}</docbase>", docbase) + Environment.NewLine);
            _writer.Write(string.Format("  <source>{0}</source>", "Express") + Environment.NewLine);
            _writer.Write("  </header>" + Environment.NewLine);
            _writer.Write("  <body>" + Environment.NewLine);
        }

        public void WriteDocumentData(string docName, string securityKey, string path, string docType)
        {
            _writer.Write("    <document>" + Environment.NewLine);
            _writer.Write(string.Format("      <name>{0}</name>", docName) + Environment.NewLine);
            _writer.Write("      <title />" + Environment.NewLine);
            _writer.Write("      <desc></desc>" + Environment.NewLine);
            _writer.Write("      <keywords />" + Environment.NewLine);
            _writer.Write("      <authors />" + Environment.NewLine);
            _writer.Write(string.Format("      <securitykey>{0}</securitykey>", securityKey) + Environment.NewLine);
            _writer.Write("      <folderlinks>" + Environment.NewLine);
            _writer.Write(string.Format("        <path>{0}</path>", path) + Environment.NewLine);
            _writer.Write("      </folderlinks>" + Environment.NewLine);
            _writer.Write("      <doctype>" + Environment.NewLine);
            _writer.Write(string.Format("        <tname>{0}</tname>", docType) + Environment.NewLine);
            _writer.Write("      </doctype>" + Environment.NewLine);
        }

        public void WriteDocumentIndexData(string indexName, string indexValue)
        {
            _writer.Write("        <index>" + Environment.NewLine);
            _writer.Write(string.Format("          <iname>{0}</iname>", indexName) + Environment.NewLine);
            _writer.Write(string.Format("          <ivalue>{0}</ivalue>", indexValue) + Environment.NewLine);
            _writer.Write("        </index>" + Environment.NewLine);
        }

        public void WriteDocumentFileData(string fileName)
        {
            _writer.Write("		<content>" + Environment.NewLine);
            _writer.Write("		  <file>" + Environment.NewLine);
            _writer.Write(string.Format("		    <fname>{0}</fname>", fileName) + Environment.NewLine);
            _writer.Write(string.Format("		    <format>{0}</format>", Path.GetExtension(fileName).TrimStart('.')) + Environment.NewLine);
            _writer.Write("		  </file>" + Environment.NewLine);
        }

        public void WriteFooter()
        {
            _writer.Write("    </document>" + Environment.NewLine);
            _writer.Write("  </body>" + Environment.NewLine);
            _writer.Write("</batch>" + Environment.NewLine);
        }

        public void CloseXml()
        {
            _writer.Flush();
            _writer.Close();
        }
    }
 }
