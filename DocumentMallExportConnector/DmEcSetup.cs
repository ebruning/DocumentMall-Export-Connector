using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Kofax.Eclipse.Base;

namespace DocumentMallExportConnector
{
    public partial class DmEcSetup : XtraForm
    {
        readonly ReleaseSettings _settings = new ReleaseSettings();

        public DmEcSetup(ref ReleaseSettings settings, IEnumerable<IExporter> exporters, IIndexField [] indexFields)
        {
            InitializeComponent();

            _settings = settings;

            LoadSettings();

            indexUserControl.SetRepositoryHeader("DocumentMall Index");
            indexUserControl.SetExpressIndexDropDown(indexFields);

            documentUserControl.DisplayDocumentType(false);
        }

        private void LoadSettings()
        {
            txtAccount.Text = _settings.Account;
            txtUser.Text = _settings.User;
            txtDestination.Text = _settings.Destination; 

            if(_settings.IndexPairs.Count > 0)
                indexUserControl.SetIndexGrid(_settings.IndexPairs);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _settings.User = txtUser.Text;
            _settings.Account = txtAccount.Text;
            _settings.Destination = txtDestination.Text;

            _settings.FileTypeId = documentUserControl.FileTypeId;
            _settings.ReleaseMode = documentUserControl.GetSingleMiltiPage();

            _settings.IndexPairs = indexUserControl.GetIndexPairsDictionary();

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _settings.ReloadSettings();
            Close();
        }

        private void btnAddIndex_Click(object sender, EventArgs e)
        {
            indexUserControl.AddRepositoryIndex();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = txtDestination.Text;

            if (dialog.ShowDialog(this) == DialogResult.OK)
                txtDestination.Text = dialog.SelectedPath;
        }
    }
}