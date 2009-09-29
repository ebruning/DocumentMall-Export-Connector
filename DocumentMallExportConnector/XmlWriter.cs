using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentMallExportConnector
{
    class XmlWriter
    {
        private string _batchHeader = "";
        private string _batchFooter = "";
        private string _documentHeader = "";
        private string _documentFooter = "";

        public void SetBatchHeader(string batchId, string releaseDateTime)
        {
            _batchHeader += "<batch>" + Environment.NewLine;
            _batchHeader += "  <header>" + Environment.NewLine;
            _batchHeader += string.Format("    <batchid>{0}</batchid>", batchId) + Environment.NewLine;
            _batchHeader += string.Format("    <date>{0}</date>", releaseDateTime) + Environment.NewLine;
            _batchHeader += string.Format("  <docbase>{0}") + Environment.NewLine;
            _batchHeader += string.Format("  <source>{0}</source>", "Express") + Environment.NewLine;
            _batchHeader += "  </header>" + Environment.NewLine;
            _batchHeader += "  <body>" + Environment.NewLine;
        }


    }
}
