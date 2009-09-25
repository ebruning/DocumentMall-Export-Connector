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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.serverLogonUserControl = new KXP.Export.Controls.ServerLogonUserControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.documentUserControl = new KXP.Export.Controls.DocumentUserControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.indexUserControl = new KXP.Export.Controls.IndexUserControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.serverLogonUserControl);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(483, 171);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Server";
            // 
            // serverLogonUserControl
            // 
            this.serverLogonUserControl.Destination = null;
            this.serverLogonUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serverLogonUserControl.Location = new System.Drawing.Point(2, 22);
            this.serverLogonUserControl.Name = "serverLogonUserControl";
            this.serverLogonUserControl.Password = null;
            this.serverLogonUserControl.Server = "";
            this.serverLogonUserControl.Size = new System.Drawing.Size(479, 147);
            this.serverLogonUserControl.TabIndex = 0;
            this.serverLogonUserControl.User = null;
            this.serverLogonUserControl.ConnectClicked += new KXP.Export.Controls.ServerLogonUserControl.ConnectClickedHandler(this.ConnectClicked);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.documentUserControl);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(0, 171);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(483, 155);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Document";
            // 
            // documentUserControl
            // 
            this.documentUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentUserControl.Enabled = false;
            this.documentUserControl.Location = new System.Drawing.Point(2, 22);
            this.documentUserControl.Name = "documentUserControl";
            this.documentUserControl.Size = new System.Drawing.Size(479, 131);
            this.documentUserControl.TabIndex = 0;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.indexUserControl);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl3.Location = new System.Drawing.Point(0, 326);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(483, 175);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "Index";
            // 
            // indexUserControl
            // 
            this.indexUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.indexUserControl.Enabled = false;
            this.indexUserControl.Location = new System.Drawing.Point(2, 22);
            this.indexUserControl.Name = "indexUserControl";
            this.indexUserControl.RepositoryName = null;
            this.indexUserControl.Size = new System.Drawing.Size(479, 151);
            this.indexUserControl.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(396, 507);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(315, 507);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            // 
            // DmEcSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 542);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "DmEcSetup";
            this.Text = "DocumentMall Export Setup";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private KXP.Export.Controls.ServerLogonUserControl serverLogonUserControl;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private KXP.Export.Controls.DocumentUserControl documentUserControl;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private KXP.Export.Controls.IndexUserControl indexUserControl;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOk;



    }
}