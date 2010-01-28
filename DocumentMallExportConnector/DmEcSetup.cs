using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Kofax.Eclipse.Base;
using Kofax.VRS.UI.Common.Tools;
using KXP.Export.Controls;

namespace DocumentMallExportConnector
{
    public partial class DmEcSetup : XtraForm
    {
        readonly ReleaseSettings _settings = new ReleaseSettings();
        private bool _setupFolderButton = false;

        public DmEcSetup(ref ReleaseSettings settings, IEnumerable<IExporter> exporters, IIndexField [] indexFields)
        {
            InitializeComponent();
            Text = string.Format("DocumentMall Export Setup - {0}",System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
            _settings = settings;

            documentUserControl.InitializeControl(exporters, _settings.ReleaseMode, _settings.FileTypeId);
            //documentUserControl.HideSingleMultiPage(DocumentUserControl.PageType.Single);

            LoadSettings();
            PopulateDocType(indexFields);
            UpdateFileNameSetupButton(indexFields);
            documentUserControl.DisplayDocumentType(false);

            this.Text = "DocumentMall Setup - " +
                        System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        }

        private void LoadSettings()
        { 
            txtAccount.Text = _settings.Account;
            txtUser.Text = _settings.User;
            txtDestination.Text = _settings.Destination;
            txtSecurityKey.Text = _settings.SecurityKey;
            txtRepositoryPath.Text = _settings.RepositoryPath;
            txtDocumentFileName.Text = _settings.DocumentName;

            SetDocumentType();
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

            if (ValidateForm())
            {
                _settings.User = txtUser.Text;
                _settings.Account = txtAccount.Text;
                _settings.Destination = txtDestination.Text;

                _settings.FileTypeId = documentUserControl.FileTypeId;
                _settings.ReleaseMode = documentUserControl.GetSingleMiltiPage();
                _settings.RepositoryPath = txtRepositoryPath.Text;
                _settings.SecurityKey = txtSecurityKey.Text;
                _settings.DocumentType = txtDocType.Enabled ? txtDocType.Text : drbDocumentType.Text;
                _settings.DocumentName = txtDocumentFileName.Text;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //_settings.ReloadSettings();
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
                _settings.CustomDocType = true;
                txtDocType.Enabled = true;
                drbDocumentType.Text = "Custom Document Type";
            }
            else
            {
                _settings.CustomDocType = false;
                txtDocType.Enabled = false;
                drbDocumentType.Text = e.Item.Caption;
            }
        }

        private void btnFileNameSetup_Click(object sender, EventArgs e)
        {
            Point p = PointToScreen(btnFileNameSetup.Location);
            p.Offset(0, btnFileNameSetup.Height);
            pmFileName.ShowPopup(p);
            _setupFolderButton = false;
        }

        private void UpdateFileNameSetupButton(IIndexField[] indexFields)
        {
            foreach (DefaultName name in DefaultName.GeneralValues)
            {
                pmFileName.AddItem(CreateBarButtonItem(name));
                pmFolderPath.AddItem(CreateBarButtonItem(name));
            }
            BarSubItem dateGroup = new BarSubItem();
            dateGroup.Name = dateGroup.Caption = DefaultName.DateGroupName;
            dateGroup.ClearLinks();
            pmFileName.AddItem(dateGroup);
            pmFolderPath.AddItem(dateGroup);

            foreach (DefaultName name in DefaultName.DateValues)
                dateGroup.AddItem(CreateBarButtonItem(name));

            BarSubItem timeGroup = new BarSubItem();
            timeGroup.Caption = DefaultName.TimeGroupName;
            timeGroup.ClearLinks();
            pmFileName.AddItem(timeGroup);
            pmFolderPath.AddItem(timeGroup);

            foreach (DefaultName name in DefaultName.TimeValues)
                timeGroup.AddItem(CreateBarButtonItem(name));

            if (indexFields != null && indexFields.Length > 0)
            {
                BarSubItem indexGroup = new BarSubItem();
                indexGroup.Caption = "Index Fields";
                indexGroup.ClearLinks();
                pmFileName.AddItem(indexGroup);
                pmFolderPath.AddItem(indexGroup);

                for (int i = 0; i < indexFields.Length; i++)
                {
                    BarButtonItem barButtonItem = new BarButtonItem();
                    barButtonItem.Caption = DefaultName.IndexValue.DescriptionOf(i + 1) + " - " + indexFields[i].Label;
                    barButtonItem.Tag = DefaultName.IndexValue.TagOf(i + 1);
                    barButtonItem.ItemClick += barButtonItem_ItemClick;
                    indexGroup.AddItem(barButtonItem);
                }
            }
        }

        private BarButtonItem CreateBarButtonItem(DefaultName name)
        {
            BarButtonItem barButtonItem = new BarButtonItem();
            barButtonItem.Caption = name.Description;
            barButtonItem.Tag = name.Tag;
            barButtonItem.ItemClick += barButtonItem_ItemClick;
            return barButtonItem;
        }

        private void barButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            string tag = e.Item.Tag as string;
            if (string.IsNullOrEmpty(tag))
                if(_setupFolderButton)
                    txtRepositoryPath.Text = string.Empty;
                else
                    txtDocumentFileName.Text = string.Empty;
                
            else
            {
                if (_setupFolderButton)
                {
                    int start = txtRepositoryPath.SelectionStart;
                    txtRepositoryPath.Text = txtRepositoryPath.Text.Insert(start, tag);
                    txtRepositoryPath.Focus();
                    txtRepositoryPath.SelectionStart = start + tag.Length;
                    txtRepositoryPath.SelectionLength = 0;
                    txtRepositoryPath.ScrollToCaret();
                }
                else
                {
                    int start = txtDocumentFileName.SelectionStart;
                    txtDocumentFileName.Text = txtDocumentFileName.Text.Insert(start, tag);
                    txtDocumentFileName.Focus();
                    txtDocumentFileName.SelectionStart = start + tag.Length;
                    txtDocumentFileName.SelectionLength = 0;
                    txtDocumentFileName.ScrollToCaret();
                }
            }
        }

        private void btnFolderSetup_Click(object sender, EventArgs e)
        {
            Point p = PointToScreen(btnFolderSetup.Location);
            p.Offset(0, btnFolderSetup.Height);
            pmFolderPath.ShowPopup(p);
            _setupFolderButton = true;
        }

        private void SetDocumentType()
        {
            if (_settings.CustomDocType)
            {
                drbDocumentType.Text = "Custom Document Type";
                txtDocType.Text = _settings.DocumentType;
                txtDocType.Enabled = true;
            }
            else
            {
                drbDocumentType.Text = _settings.DocumentType;
                txtDocType.Enabled = false;
            }

        }

        private void txtRepositoryPath_EditValueChanged(object sender, EventArgs e)
        {
            txtRepositoryPath.ForeColor = DefaultName.IsValid(txtRepositoryPath.Text) ? Color.Empty : Color.Red;
        }

        private void txtDocumentFileName_EditValueChanged(object sender, EventArgs e)
        {
            txtDocumentFileName.ForeColor = DefaultName.IsValid(txtDocumentFileName.Text) ? Color.Empty : Color.Red;
        }

        internal bool ValidateForm()
        {
            if (string.IsNullOrEmpty(txtAccount.Text))
            {
                ErrorMessage("Account cannot be blank.", MessageBoxIcon.Warning);
                txtAccount.Focus();
                return false;
            }
            
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                ErrorMessage("User cannot be blank.", MessageBoxIcon.Warning);
                txtUser.Focus();
                return false;
            }
            
            if (string.IsNullOrEmpty(txtDestination.Text))
            {
                ErrorMessage("Invalid folder", MessageBoxIcon.Warning);
                txtDestination.Focus();
                return false;
            }       
            
            if (string.IsNullOrEmpty(txtDocumentFileName.Text) || !DefaultName.IsValid(txtDocumentFileName.Text))
            {
                ErrorMessage("Invalid file name", MessageBoxIcon.Warning);
                txtDocumentFileName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtDocType.Text) && drbDocumentType.Text == "Custom Document Type")
            {
                ErrorMessage("Invalid document type", MessageBoxIcon.Warning);
                txtDocType.Focus();
                return false;
            }                
     
            return true;
        }

        internal void ErrorMessage(string msg, MessageBoxIcon icon)
        {
            string caption = "Error";
            XtraMessageBox.Show(this,
                                msg,
                                caption,
                                MessageBoxButtons.OK,
                                icon,
                                MessageBoxDefaultButton.Button1);
        }
    }
}