using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Kofax.Eclipse.Base;
using Kofax.Eclipse.Tools;
using KXP.Export.Controls;

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
            documentUserControl.HideSingleMultiPage(DocumentUserControl.PageType.Single);

            LoadSettings();
            PopulateDocType(indexFields);
            UpdateFileNameSetupButton(indexFields);
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
            txtDocumentFileName.Text = _settings.DocumentName;
            
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
            _settings.DocumentName = txtDocumentFileName.Text;
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

        private void btnFileNameSetup_Click(object sender, EventArgs e)
        {
            Point p = PointToScreen(btnFileNameSetup.Location);
            p.Offset(0, btnFileNameSetup.Height);
            pmFileName.ShowPopup(p);
        }

        private void UpdateFileNameSetupButton(IIndexField[] indexFields)
        {
            foreach (DefaultName name in DefaultName.GeneralValues)
                pmFileName.AddItem(CreateBarButtonItem(name));

            BarSubItem dateGroup = new BarSubItem();
            dateGroup.Name = dateGroup.Caption = DefaultName.DateGroupName;
            dateGroup.ClearLinks();
            pmFileName.AddItem(dateGroup);
            foreach (DefaultName name in DefaultName.DateValues)
                dateGroup.AddItem(CreateBarButtonItem(name));

            BarSubItem timeGroup = new BarSubItem();
            timeGroup.Caption = DefaultName.TimeGroupName;
            timeGroup.ClearLinks();
            pmFileName.AddItem(timeGroup);
            foreach (DefaultName name in DefaultName.TimeValues)
                timeGroup.AddItem(CreateBarButtonItem(name));

            if (indexFields != null && indexFields.Length > 0)
            {
                BarSubItem indexGroup = new BarSubItem();
                indexGroup.Caption = "Index Fields";
                indexGroup.ClearLinks();
                pmFileName.AddItem(indexGroup);
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
                txtDocumentFileName.Text = string.Empty;
                
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

        private void btnFolderSetup_Click(object sender, EventArgs e)
        {
            Point p = PointToScreen(btnFolderSetup.Location);
            p.Offset(0, btnFolderSetup.Height);
            pmFolderPath.ShowPopup(p);
        }
    }
}