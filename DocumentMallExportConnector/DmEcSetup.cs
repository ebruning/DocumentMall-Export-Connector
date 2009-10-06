using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
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

            documentUserControl.InitializeControl(exporters, _settings.ReleaseMode, _settings.FileTypeId);

            LoadSettings();
            PopulateDocType(indexFields);
            documentUserControl.DisplayDocumentType(false);
            txtDocType.Enabled = false;
        }

        private void LoadSettings()
        { 
            txtAccount.Text = _settings.Account;
            txtUser.Text = _settings.User;
            txtDestination.Text = _settings.Destination;
            txtSecurityKey.Text = _settings.SecurityKey;
            txtRepositoryPath.Text = _settings.RepositoryPath;
            
        }

        private void PopulateDocType(IIndexField [] indexFields)
        {
            pmDocType.ClearLinks();

            pmDocType.AddItem(bmDocType.Items.CreateButton("Custom Document Type"));

            foreach (IIndexField field in indexFields)
            {
                pmDocType.AddItem(bmDocType.Items.CreateButton(field.Label));
            }

            SetClickEvent();
            drbDocumentType.DropDownControl = pmDocType;
        }

        private void SetClickEvent()
        {
            for (int buttonIndex = 0; buttonIndex < bmDocType.Items.Count; buttonIndex++)
            {
                bmDocType.Items[buttonIndex].ItemClick += docTypeDropDown_ItemClick;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _settings.User = txtUser.Text;
            _settings.Account = txtAccount.Text;
            _settings.Destination = txtDestination.Text;

            _settings.FileTypeId = documentUserControl.FileTypeId;
            _settings.ReleaseMode = documentUserControl.GetSingleMiltiPage();
            _settings.RepositoryPath = txtRepositoryPath.Text;
            _settings.SecurityKey = txtSecurityKey.Text;
            _settings.DocumentType = txtDocType.Enabled ? txtDocType.Text : drbDocumentType.Text;

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _settings.ReloadSettings();
            Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = txtDestination.Text;

            if (dialog.ShowDialog(this) == DialogResult.OK)
                txtDestination.Text = dialog.SelectedPath;
        }

        private void docTypeDropDown_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Caption.Equals("Custom Document Type"))
            {
                txtDocType.Enabled = true;
                drbDocumentType.Text = "Custom Document Type";
            }
            else
            {
                txtDocType.Enabled = false;
                drbDocumentType.Text = e.Item.Caption;
            }
        }
    }
}