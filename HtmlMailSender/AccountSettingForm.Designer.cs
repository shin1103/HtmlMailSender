namespace SHashiba.HtmlMailSender
{
    partial class AccountSettingForm
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cboAccount = new System.Windows.Forms.ComboBox();
            this._adsCbo = new SHashiba.HtmlMailSender.DataSet.Account_DS();
            this._ads = new SHashiba.HtmlMailSender.DataSet.Account_DS();
            this.lblAcountSelect = new System.Windows.Forms.Label();
            this.gboSetting = new System.Windows.Forms.GroupBox();
            this.chkSmtpAuth = new System.Windows.Forms.CheckBox();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.gboFundamental = new System.Windows.Forms.GroupBox();
            this.lblSenderMail = new System.Windows.Forms.Label();
            this.txtSenderName = new System.Windows.Forms.TextBox();
            this.lblSmtpPortMessage = new System.Windows.Forms.Label();
            this.txtSmtpServer = new System.Windows.Forms.TextBox();
            this.lblSmtpPort = new System.Windows.Forms.Label();
            this.txtSmtpPort = new System.Windows.Forms.TextBox();
            this.txtSenderMail = new System.Windows.Forms.TextBox();
            this.lblSmtpServer = new System.Windows.Forms.Label();
            this.lblSenderName = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.chkPopBeforeSmtp = new System.Windows.Forms.CheckBox();
            this.gboPopBeforeSmtp = new System.Windows.Forms.GroupBox();
            this.lblPopPortMessage = new System.Windows.Forms.Label();
            this.txtPopPort = new System.Windows.Forms.TextBox();
            this.txtPopPassword = new System.Windows.Forms.TextBox();
            this.txtPopUser = new System.Windows.Forms.TextBox();
            this.txtPopServer = new System.Windows.Forms.TextBox();
            this.lblPopServer = new System.Windows.Forms.Label();
            this.lblPopUser = new System.Windows.Forms.Label();
            this.lblPopPort = new System.Windows.Forms.Label();
            this.lblPopPassword = new System.Windows.Forms.Label();
            this.lblAccount = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._adsCbo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ads)).BeginInit();
            this.gboSetting.SuspendLayout();
            this.gboFundamental.SuspendLayout();
            this.gboPopBeforeSmtp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboAccount
            // 
            this.cboAccount.DataSource = this._adsCbo;
            this.cboAccount.DisplayMember = "Account.AccountName";
            this.cboAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccount.FormattingEnabled = true;
            this.cboAccount.Location = new System.Drawing.Point(145, 22);
            this.cboAccount.Name = "cboAccount";
            this.cboAccount.Size = new System.Drawing.Size(156, 20);
            this.cboAccount.TabIndex = 1;
            this.cboAccount.ValueMember = "Account.AccountName";
            this.cboAccount.SelectedIndexChanged += new System.EventHandler(this.cboAccount_SelectedIndexChanged);
            this.cboAccount.DropDown += new System.EventHandler(this.cboAccount_DropDown);
            // 
            // _adsCbo
            // 
            this._adsCbo.DataSetName = "Account_DS";
            this._adsCbo.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // _ads
            // 
            this._ads.DataSetName = "Account_DS";
            this._ads.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblAcountSelect
            // 
            this.lblAcountSelect.AutoSize = true;
            this.lblAcountSelect.Location = new System.Drawing.Point(12, 25);
            this.lblAcountSelect.Name = "lblAcountSelect";
            this.lblAcountSelect.Size = new System.Drawing.Size(61, 12);
            this.lblAcountSelect.TabIndex = 0;
            this.lblAcountSelect.Text = "アカウント名";
            // 
            // gboSetting
            // 
            this.gboSetting.Controls.Add(this.chkSmtpAuth);
            this.gboSetting.Controls.Add(this.lblErrorMessage);
            this.gboSetting.Controls.Add(this.gboFundamental);
            this.gboSetting.Controls.Add(this.txtAccount);
            this.gboSetting.Controls.Add(this.chkPopBeforeSmtp);
            this.gboSetting.Controls.Add(this.gboPopBeforeSmtp);
            this.gboSetting.Controls.Add(this.lblAccount);
            this.gboSetting.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gboSetting.Location = new System.Drawing.Point(0, 64);
            this.gboSetting.Name = "gboSetting";
            this.gboSetting.Size = new System.Drawing.Size(764, 247);
            this.gboSetting.TabIndex = 2;
            this.gboSetting.TabStop = false;
            this.gboSetting.Text = "アカウント設定";
            // 
            // chkSmtpAuth
            // 
            this.chkSmtpAuth.AutoSize = true;
            this.chkSmtpAuth.Location = new System.Drawing.Point(400, 40);
            this.chkSmtpAuth.Name = "chkSmtpAuth";
            this.chkSmtpAuth.Size = new System.Drawing.Size(125, 16);
            this.chkSmtpAuth.TabIndex = 4;
            this.chkSmtpAuth.Text = "SMTP AUTH　を使う";
            this.chkSmtpAuth.UseVisualStyleBackColor = true;
            this.chkSmtpAuth.CheckedChanged += new System.EventHandler(this.chkSmtpAuth_CheckedChanged);
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(569, 29);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(208, 39);
            this.lblErrorMessage.TabIndex = 5;
            // 
            // gboFundamental
            // 
            this.gboFundamental.Controls.Add(this.lblSenderMail);
            this.gboFundamental.Controls.Add(this.txtSenderName);
            this.gboFundamental.Controls.Add(this.lblSmtpPortMessage);
            this.gboFundamental.Controls.Add(this.txtSmtpServer);
            this.gboFundamental.Controls.Add(this.lblSmtpPort);
            this.gboFundamental.Controls.Add(this.txtSmtpPort);
            this.gboFundamental.Controls.Add(this.txtSenderMail);
            this.gboFundamental.Controls.Add(this.lblSmtpServer);
            this.gboFundamental.Controls.Add(this.lblSenderName);
            this.gboFundamental.Location = new System.Drawing.Point(14, 71);
            this.gboFundamental.Name = "gboFundamental";
            this.gboFundamental.Size = new System.Drawing.Size(378, 155);
            this.gboFundamental.TabIndex = 2;
            this.gboFundamental.TabStop = false;
            this.gboFundamental.Text = "基本設定";
            // 
            // lblSenderMail
            // 
            this.lblSenderMail.AutoSize = true;
            this.lblSenderMail.Location = new System.Drawing.Point(6, 95);
            this.lblSenderMail.Name = "lblSenderMail";
            this.lblSenderMail.Size = new System.Drawing.Size(105, 12);
            this.lblSenderMail.TabIndex = 4;
            this.lblSenderMail.Text = "送信者メールアドレス";
            // 
            // txtSenderName
            // 
            this.txtSenderName.Location = new System.Drawing.Point(139, 62);
            this.txtSenderName.Name = "txtSenderName";
            this.txtSenderName.Size = new System.Drawing.Size(217, 19);
            this.txtSenderName.TabIndex = 3;
            this.txtSenderName.TextChanged += new System.EventHandler(this.txtSenderName_TextChanged);
            // 
            // lblSmtpPortMessage
            // 
            this.lblSmtpPortMessage.AutoSize = true;
            this.lblSmtpPortMessage.Location = new System.Drawing.Point(212, 128);
            this.lblSmtpPortMessage.Name = "lblSmtpPortMessage";
            this.lblSmtpPortMessage.Size = new System.Drawing.Size(75, 12);
            this.lblSmtpPortMessage.TabIndex = 8;
            this.lblSmtpPortMessage.Text = "デフォルトは 25";
            // 
            // txtSmtpServer
            // 
            this.txtSmtpServer.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSmtpServer.Location = new System.Drawing.Point(139, 30);
            this.txtSmtpServer.Name = "txtSmtpServer";
            this.txtSmtpServer.Size = new System.Drawing.Size(217, 19);
            this.txtSmtpServer.TabIndex = 1;
            this.txtSmtpServer.TextChanged += new System.EventHandler(this.txtSmtpServer_TextChanged);
            // 
            // lblSmtpPort
            // 
            this.lblSmtpPort.AutoSize = true;
            this.lblSmtpPort.Location = new System.Drawing.Point(6, 124);
            this.lblSmtpPort.Name = "lblSmtpPort";
            this.lblSmtpPort.Size = new System.Drawing.Size(87, 12);
            this.lblSmtpPort.TabIndex = 6;
            this.lblSmtpPort.Text = "SMTPポート番号";
            // 
            // txtSmtpPort
            // 
            this.txtSmtpPort.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSmtpPort.Location = new System.Drawing.Point(139, 121);
            this.txtSmtpPort.Name = "txtSmtpPort";
            this.txtSmtpPort.Size = new System.Drawing.Size(48, 19);
            this.txtSmtpPort.TabIndex = 7;
            this.txtSmtpPort.TextChanged += new System.EventHandler(this.txtSmtpPort_TextChanged);
            // 
            // txtSenderMail
            // 
            this.txtSenderMail.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSenderMail.Location = new System.Drawing.Point(139, 92);
            this.txtSenderMail.Name = "txtSenderMail";
            this.txtSenderMail.Size = new System.Drawing.Size(217, 19);
            this.txtSenderMail.TabIndex = 5;
            this.txtSenderMail.TextChanged += new System.EventHandler(this.txtSenderMail_TextChanged);
            // 
            // lblSmtpServer
            // 
            this.lblSmtpServer.AutoSize = true;
            this.lblSmtpServer.Location = new System.Drawing.Point(6, 33);
            this.lblSmtpServer.Name = "lblSmtpServer";
            this.lblSmtpServer.Size = new System.Drawing.Size(77, 12);
            this.lblSmtpServer.TabIndex = 0;
            this.lblSmtpServer.Text = "SMTPサーバ名";
            // 
            // lblSenderName
            // 
            this.lblSenderName.AutoSize = true;
            this.lblSenderName.Location = new System.Drawing.Point(6, 65);
            this.lblSenderName.Name = "lblSenderName";
            this.lblSenderName.Size = new System.Drawing.Size(53, 12);
            this.lblSenderName.TabIndex = 2;
            this.lblSenderName.Text = "送信者名";
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(153, 33);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(217, 19);
            this.txtAccount.TabIndex = 1;
            this.txtAccount.TextChanged += new System.EventHandler(this.txtAccount_TextChanged);
            // 
            // chkPopBeforeSmtp
            // 
            this.chkPopBeforeSmtp.AutoSize = true;
            this.chkPopBeforeSmtp.Location = new System.Drawing.Point(400, 18);
            this.chkPopBeforeSmtp.Name = "chkPopBeforeSmtp";
            this.chkPopBeforeSmtp.Size = new System.Drawing.Size(152, 16);
            this.chkPopBeforeSmtp.TabIndex = 3;
            this.chkPopBeforeSmtp.Text = "POP before SMTP　を使う";
            this.chkPopBeforeSmtp.UseVisualStyleBackColor = true;
            this.chkPopBeforeSmtp.CheckedChanged += new System.EventHandler(this.chkPopBeforeSmtp_CheckedChanged);
            // 
            // gboPopBeforeSmtp
            // 
            this.gboPopBeforeSmtp.Controls.Add(this.lblPopPortMessage);
            this.gboPopBeforeSmtp.Controls.Add(this.txtPopPort);
            this.gboPopBeforeSmtp.Controls.Add(this.txtPopPassword);
            this.gboPopBeforeSmtp.Controls.Add(this.txtPopUser);
            this.gboPopBeforeSmtp.Controls.Add(this.txtPopServer);
            this.gboPopBeforeSmtp.Controls.Add(this.lblPopServer);
            this.gboPopBeforeSmtp.Controls.Add(this.lblPopUser);
            this.gboPopBeforeSmtp.Controls.Add(this.lblPopPort);
            this.gboPopBeforeSmtp.Controls.Add(this.lblPopPassword);
            this.gboPopBeforeSmtp.Enabled = false;
            this.gboPopBeforeSmtp.Location = new System.Drawing.Point(400, 71);
            this.gboPopBeforeSmtp.Name = "gboPopBeforeSmtp";
            this.gboPopBeforeSmtp.Size = new System.Drawing.Size(353, 155);
            this.gboPopBeforeSmtp.TabIndex = 6;
            this.gboPopBeforeSmtp.TabStop = false;
            this.gboPopBeforeSmtp.Text = "POP before SMTP";
            // 
            // lblPopPortMessage
            // 
            this.lblPopPortMessage.AutoSize = true;
            this.lblPopPortMessage.Location = new System.Drawing.Point(197, 124);
            this.lblPopPortMessage.Name = "lblPopPortMessage";
            this.lblPopPortMessage.Size = new System.Drawing.Size(81, 12);
            this.lblPopPortMessage.TabIndex = 9;
            this.lblPopPortMessage.Text = "デフォルトは 110";
            // 
            // txtPopPort
            // 
            this.txtPopPort.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPopPort.Location = new System.Drawing.Point(124, 121);
            this.txtPopPort.Name = "txtPopPort";
            this.txtPopPort.Size = new System.Drawing.Size(49, 19);
            this.txtPopPort.TabIndex = 7;
            this.txtPopPort.TextChanged += new System.EventHandler(this.txtPopPort_TextChanged);
            // 
            // txtPopPassword
            // 
            this.txtPopPassword.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPopPassword.Location = new System.Drawing.Point(124, 92);
            this.txtPopPassword.Name = "txtPopPassword";
            this.txtPopPassword.PasswordChar = '*';
            this.txtPopPassword.Size = new System.Drawing.Size(212, 19);
            this.txtPopPassword.TabIndex = 5;
            this.txtPopPassword.UseSystemPasswordChar = true;
            this.txtPopPassword.TextChanged += new System.EventHandler(this.txtPopPassword_TextChanged);
            // 
            // txtPopUser
            // 
            this.txtPopUser.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPopUser.Location = new System.Drawing.Point(124, 62);
            this.txtPopUser.Name = "txtPopUser";
            this.txtPopUser.Size = new System.Drawing.Size(212, 19);
            this.txtPopUser.TabIndex = 3;
            this.txtPopUser.TextChanged += new System.EventHandler(this.txtPopUser_TextChanged);
            // 
            // txtPopServer
            // 
            this.txtPopServer.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPopServer.Location = new System.Drawing.Point(124, 30);
            this.txtPopServer.Name = "txtPopServer";
            this.txtPopServer.Size = new System.Drawing.Size(212, 19);
            this.txtPopServer.TabIndex = 1;
            this.txtPopServer.TextChanged += new System.EventHandler(this.txtPopServer_TextChanged);
            // 
            // lblPopServer
            // 
            this.lblPopServer.AutoSize = true;
            this.lblPopServer.Location = new System.Drawing.Point(18, 33);
            this.lblPopServer.Name = "lblPopServer";
            this.lblPopServer.Size = new System.Drawing.Size(57, 12);
            this.lblPopServer.TabIndex = 0;
            this.lblPopServer.Text = "POPサーバ";
            // 
            // lblPopUser
            // 
            this.lblPopUser.AutoSize = true;
            this.lblPopUser.Location = new System.Drawing.Point(18, 65);
            this.lblPopUser.Name = "lblPopUser";
            this.lblPopUser.Size = new System.Drawing.Size(68, 12);
            this.lblPopUser.TabIndex = 2;
            this.lblPopUser.Text = "POPユーザID";
            // 
            // lblPopPort
            // 
            this.lblPopPort.AutoSize = true;
            this.lblPopPort.Location = new System.Drawing.Point(18, 124);
            this.lblPopPort.Name = "lblPopPort";
            this.lblPopPort.Size = new System.Drawing.Size(55, 12);
            this.lblPopPort.TabIndex = 6;
            this.lblPopPort.Text = "POPポート";
            // 
            // lblPopPassword
            // 
            this.lblPopPassword.AutoSize = true;
            this.lblPopPassword.Location = new System.Drawing.Point(18, 95);
            this.lblPopPassword.Name = "lblPopPassword";
            this.lblPopPassword.Size = new System.Drawing.Size(74, 12);
            this.lblPopPassword.TabIndex = 4;
            this.lblPopPassword.Text = "POPパスワード";
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(20, 36);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(61, 12);
            this.lblAccount.TabIndex = 0;
            this.lblAccount.Text = "アカウント名";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(453, 20);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(678, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(564, 21);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "削除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // AccountSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(764, 311);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gboSetting);
            this.Controls.Add(this.lblAcountSelect);
            this.Controls.Add(this.cboAccount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountSettingForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "アカウント設定";
            this.Load += new System.EventHandler(this.AccountSettingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._adsCbo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ads)).EndInit();
            this.gboSetting.ResumeLayout(false);
            this.gboSetting.PerformLayout();
            this.gboFundamental.ResumeLayout(false);
            this.gboFundamental.PerformLayout();
            this.gboPopBeforeSmtp.ResumeLayout(false);
            this.gboPopBeforeSmtp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboAccount;
        private System.Windows.Forms.Label lblAcountSelect;
        private System.Windows.Forms.GroupBox gboSetting;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Label lblPopPort;
        private System.Windows.Forms.Label lblPopPassword;
        private System.Windows.Forms.Label lblPopUser;
        private System.Windows.Forms.Label lblPopServer;
        private System.Windows.Forms.Label lblSmtpPort;
        private System.Windows.Forms.Label lblSenderMail;
        private System.Windows.Forms.Label lblSenderName;
        private System.Windows.Forms.Label lblSmtpServer;
        private System.Windows.Forms.CheckBox chkPopBeforeSmtp;
        private System.Windows.Forms.GroupBox gboPopBeforeSmtp;
        private System.Windows.Forms.Label lblSmtpPortMessage;
        private System.Windows.Forms.TextBox txtSmtpPort;
        private System.Windows.Forms.TextBox txtSenderMail;
        private System.Windows.Forms.TextBox txtSenderName;
        private System.Windows.Forms.TextBox txtSmtpServer;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.TextBox txtPopServer;
        private System.Windows.Forms.GroupBox gboFundamental;
        private System.Windows.Forms.TextBox txtPopPort;
        private System.Windows.Forms.TextBox txtPopPassword;
        private System.Windows.Forms.TextBox txtPopUser;
        private SHashiba.HtmlMailSender.DataSet.Account_DS _ads;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.Label lblPopPortMessage;
        private System.Windows.Forms.Button btnDelete;
        private SHashiba.HtmlMailSender.DataSet.Account_DS _adsCbo;
        private System.Windows.Forms.CheckBox chkSmtpAuth;
    }
}