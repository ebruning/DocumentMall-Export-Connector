using System;
using Kofax.Eclipse.Base;

namespace DocumentMallExportConnector
{
    public class ReleaseSettings
    {
        private string m_User;
        public string User
        {
            get { return m_User; }
            set { m_User = value; }
        }

        private string m_Account;
        public string Account
        {
            get { return m_Account; }
            set { m_Account = value; }
        }

        private string m_Destination;
        public string Destination
        {
            get { return m_Destination; }
            set { m_Destination = value; }
        }

        private ReleaseMode m_ReleaseMode;
        public ReleaseMode ReleaseMode
        {
            get { return m_ReleaseMode; }
            set { m_ReleaseMode = value; }
        }

        private Guid m_FileTypeId;
        public Guid FileTypeId
        {
            get 
            {
                return CheckGuid(m_FileTypeId.ToString()) ? m_FileTypeId : new Guid();
            }
            set { m_FileTypeId = value; }
        }

        private string m_SecurityKey;
        public string SecurityKey
        {
            get { return m_SecurityKey; }
            set { m_SecurityKey = value; }
        }

        private string m_DocumentType;
        public string DocumentType
        {
            get { return m_DocumentType; }
            set { m_DocumentType = value; }
        }

        private string m_RepositoryPath;
        public string RepositoryPath
        {
            get { return m_RepositoryPath; }
            set { m_RepositoryPath = value; }
        }

        private string m_DocumentName;
        public string DocumentName
        {
            get { return m_DocumentName; }
            set { m_DocumentName = value; }
        }

        private bool m_CustomDocType;
        public bool CustomDocType
        {
            get { return m_CustomDocType; }
            set { m_CustomDocType = value; }
        }

        public static bool CheckGuid(string guidString)
        {
            try
            {
                Guid g = new Guid(guidString);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
