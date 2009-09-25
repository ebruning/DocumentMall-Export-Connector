using System;
using System.Collections.Generic;
using System.Text;
using DocumentMallExportConnector.Properties;

namespace DocumentMallExportConnector
{
    class ReleaseSettings
    {
        readonly Settings _settings = new Settings();

        public string Server
        {
            get { return _settings.Server; }
            set { _settings.Server = value; }
        }

        public string User
        {
            get { return _settings.User; }
            set { _settings.User = value; }
        }

        public string Password
        {
            get { return _settings.Password; }
            set { _settings.Password = value; }
        }

        public string Destination
        {
            get { return _settings.Destination; }
            set { _settings.Destination = value; }
        }

        public void SaveSettings()
        {
            _settings.Save();
        }

        public void ResetSettings()
        {
            _settings.Reset();
        }

        public void ReloadSettings()
        {
            _settings.Reload();
        }

    }
}
