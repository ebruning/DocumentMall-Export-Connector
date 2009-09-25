using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DocumentMallExportConnector.Properties;
using Kofax.Eclipse.Base;

namespace DocumentMallExportConnector
{
    public partial class DmEcSetup : XtraForm
    {
        readonly Settings _settings = new Settings();

        public DmEcSetup(IEnumerable<IExporter> exporters)
        {
            InitializeComponent();
            
            
        }

        private void ConnectClicked()
        {
            //Need to throw error if server name is blank
            if (string.IsNullOrEmpty(serverLogonUserControl.Server))
                return;

            _settings.Server = serverLogonUserControl.Server;
            _settings.User = serverLogonUserControl.User;
            _settings.Password = serverLogonUserControl.Password;
            _settings.Destination = serverLogonUserControl.Destination;

            
            documentUserControl.Enabled = true;
            indexUserControl.Enabled = true;

        }
    }
}