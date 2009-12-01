using System;
using System.Collections;
using System.Collections.Generic;
using DocumentMallExportConnector.Properties;
using Kofax.Eclipse.Base;

namespace DocumentMallExportConnector
{
    public class ReleaseSettings
    {
        readonly Settings _settings = new Settings();

        public string User
        {
            get { return _settings.User; }
            set { _settings.User = value; }
        }

        public string Account
        {
            get { return _settings.Account; }
            set { _settings.Account = value; }
        }

        public string Destination
        {
            get { return _settings.Destination; }
            set { _settings.Destination = value; }
        }

        public ReleaseMode ReleaseMode
        {
            get { return _settings.ReleaseMode; }
            set { _settings.ReleaseMode = value; }
        }

        public Guid FileTypeId
        {
            get 
            {
                return CheckGuid(_settings.FileTypeId.ToString()) ? _settings.FileTypeId : new Guid();
            }
            set { _settings.FileTypeId = value; }
        }

        public string SecurityKey
        {
            get { return _settings.SecurityKey; }
            set { _settings.SecurityKey = value; }
        }

        public string DocumentType
        {
            get { return _settings.DocType; }
            set { _settings.DocType = value; }
        }

        public string RepositoryPath
        {
            get { return _settings.RepositoryPath; }
            set { _settings.RepositoryPath = value; }
        }

        public string DocumentName
        {
            get { return _settings.DocumentName; }
            set { _settings.DocumentName = value; }
        }

        public bool CustomDocType
        {
            get { return _settings.CustomDocType; }
            set { _settings.CustomDocType = value; }
        }
        //public Dictionary<string, string> IndexPairs
        //{
        //    get { return ConvertIndexStringToDictionary(_settings.IndexPairs); }
        //    set { _settings.IndexPairs = ConvertIndexDictionaryToString(value); }
        //}

        //private Dictionary<string, string> ConvertIndexStringToDictionary(string indexString)
        //{
        //    Dictionary<string, string> indexDictionary = new Dictionary<string, string>();

        //    if (string.IsNullOrEmpty(indexString))
        //        return indexDictionary;

        //    foreach (string s in indexString.Split('|'))
        //    {
        //        ArrayList tmp = new ArrayList(s.Split(','));
        //        indexDictionary.Add(tmp[0].ToString(), tmp[1].ToString());
        //    }
        //    return indexDictionary;
        //}

        //private string ConvertIndexDictionaryToString(Dictionary<string, string> indexDictionary)
        //{
        //    string indexString = "";

        //    foreach (KeyValuePair<string, string> data in indexDictionary)
        //    {
        //        indexString += string.Format("{0},{1}|", data.Key, data.Value);
        //    }
        //    return KXP.Tools.Export.TrimPipe(indexString);
        //}

        public bool CheckGuid(string guidString)
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

        #region Save/Reset/Reload Settings
        public void SaveSettings()
        {
            _settings.Save();
        }

        /// <summary>
        /// Resets the values to the default settings
        /// </summary>
        public void ResetSettings()
        {
            _settings.Reset();
        }

        /// <summary>
        /// Reloads the values from storage
        /// </summary>
        public void ReloadSettings()
        {
            _settings.Reload();
        } 
        #endregion

    }
}
