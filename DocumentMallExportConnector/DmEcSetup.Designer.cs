namespace DocumentMallExportConnector
{
    partial class DmEcSetup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnFileNameSetup = new DevExpress.XtraEditors.SimpleButton();
            this.txtDocumentFileName = new DevExpress.XtraEditors.TextEdit();
            this.bmDocType = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.drbDocumentType = new DevExpress.XtraEditors.DropDownButton();
            this.pmDocType = new DevExpress.XtraBars.PopupMenu(this.components);
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtDocType = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtRepositoryPath = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtSecurityKey = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.txtDestination = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtUser = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtAccount = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.documentUserControl = new KXP.Export.Controls.DocumentUserControl();
            this.pmFileName = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentFileName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmDocType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmDocType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRepositoryPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecurityKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDestination.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pmFileName)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(396, 477);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(315, 477);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnFileNameSetup);
            this.groupControl1.Controls.Add(this.txtDocumentFileName);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.txtDocType);
            this.groupControl1.Controls.Add(this.drbDocumentType);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.txtRepositoryPath);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.txtSecurityKey);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.btnBrowse);
            this.groupControl1.Controls.Add(this.txtDestination);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtUser);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtAccount);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(483, 354);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "DocumentMall";
            // 
            // btnFileNameSetup
            // 
            this.btnFileNameSetup.Location = new System.Drawing.Point(396, 225);
            this.btnFileNameSetup.Name = "btnFileNameSetup";
            this.btnFileNameSetup.Size = new System.Drawing.Size(75, 23);
            this.btnFileNameSetup.TabIndex = 16;
            this.btnFileNameSetup.Text = "Setup";
            this.btnFileNameSetup.Click += new System.EventHandler(this.btnFileNameSetup_Click);
            // 
            // txtDocumentFileName
            // 
            this.txtDocumentFileName.Location = new System.Drawing.Point(12, 228);
            this.txtDocumentFileName.MenuManager = this.bmDocType;
            this.txtDocumentFileName.Name = "txtDocumentFileName";
            this.txtDocumentFileName.Size = new System.Drawing.Size(378, 20);
            this.txtDocumentFileName.TabIndex = 15;
            // 
            // bmDocType
            // 
            this.bmDocType.DockControls.Add(this.barDockControlTop);
            this.bmDocType.DockControls.Add(this.barDockControlBottom);
            this.bmDocType.DockControls.Add(this.barDockControlLeft);
            this.bmDocType.DockControls.Add(this.barDockControlRight);
            this.bmDocType.Form = this;
            this.bmDocType.MaxItemId = 1;
            // 
            // drbDocumentType
            // 
            this.drbDocumentType.Location = new System.Drawing.Point(12, 273);
            this.drbDocumentType.Name = "drbDocumentType";
            this.bmDocType.SetPopupContextMenu(this.drbDocumentType, this.pmDocType);
            this.drbDocumentType.Size = new System.Drawing.Size(236, 23);
            this.drbDocumentType.TabIndex = 12;
            // 
            // pmDocType
            // 
            this.pmDocType.Manager = this.bmDocType;
            this.pmDocType.Name = "pmDocType";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 209);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(94, 13);
            this.labelControl7.TabIndex = 14;
            this.labelControl7.Text = "Document file name";
            // 
            // txtDocType
            // 
            this.txtDocType.Location = new System.Drawing.Point(254, 276);
            this.txtDocType.Name = "txtDocType";
            this.txtDocType.Size = new System.Drawing.Size(136, 20);
            this.txtDocType.TabIndex = 13;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 254);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(75, 13);
            this.labelControl6.TabIndex = 11;
            this.labelControl6.Text = "Document Type";
            // 
            // txtRepositoryPath
            // 
            this.txtRepositoryPath.Location = new System.Drawing.Point(12, 182);
            this.txtRepositoryPath.Name = "txtRepositoryPath";
            this.txtRepositoryPath.Size = new System.Drawing.Size(378, 20);
            this.txtRepositoryPath.TabIndex = 10;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 163);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(122, 13);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "DocumentMall folder path";
            // 
            // txtSecurityKey
            // 
            this.txtSecurityKey.Location = new System.Drawing.Point(12, 321);
            this.txtSecurityKey.Name = "txtSecurityKey";
            this.txtSecurityKey.Size = new System.Drawing.Size(236, 20);
            this.txtSecurityKey.TabIndex = 8;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 302);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 13);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Security Key";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(396, 134);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(12, 137);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(378, 20);
            this.txtDestination.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 118);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(129, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "DocumentMall watch folder";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(12, 91);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(236, 20);
            this.txtUser.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 71);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(22, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "User";
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(12, 44);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(236, 20);
            this.txtAccount.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(39, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Account";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Money Twins";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.documentUserControl);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(0, 354);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(483, 106);
            this.groupControl2.TabIndex = 6;
            this.groupControl2.Text = "File Type";
            // 
            // documentUserControl
            // 
            this.documentUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentUserControl.Location = new System.Drawing.Point(2, 22);
            this.documentUserControl.Name = "documentUserControl";
            this.documentUserControl.Size = new System.Drawing.Size(479, 82);
            this.documentUserControl.TabIndex = 0;
            // 
            // pmFileName
            // 
            this.pmFileName.Manager = this.bmDocType;
            this.pmFileName.Name = "pmFileName";
            // 
            // DmEcSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 512);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DmEcSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DocumentMall Export Setup";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentFileName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmDocType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmDocType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRepositoryPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecurityKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDestination.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pmFileName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtUser;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtAccount;
        private DevExpress.XtraEditors.SimpleButton btnBrowse;
        private DevExpress.XtraEditors.TextEdit txtDestination;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private KXP.Export.Controls.DocumentUserControl documentUserControl;
        private DevExpress.XtraEditors.TextEdit txtSecurityKey;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtRepositoryPath;
        private DevExpress.XtraEditors.TextEdit txtDocType;
        private DevExpress.XtraEditors.DropDownButton drbDocumentType;
        private DevExpress.XtraBars.BarManager bmDocType;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.PopupMenu pmDocType;
        private DevExpress.XtraEditors.SimpleButton btnFileNameSetup;
        private DevExpress.XtraEditors.TextEdit txtDocumentFileName;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraBars.PopupMenu pmFileName;



    }
}