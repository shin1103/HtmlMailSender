namespace SHashiba.HtmlMailSender
{
    partial class MainForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSource = new System.Windows.Forms.TabPage();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.tabHTML = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReadHtml = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMail = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMailSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAccountNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAccountEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuMailSend = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileHtml = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnBody = new System.Windows.Forms.Button();
            this.lblBody = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.btnAddress = new System.Windows.Forms.Button();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblAccount = new System.Windows.Forms.Label();
            this.cboAccount = new System.Windows.Forms.ComboBox();
            this._accountds = new SHashiba.HtmlMailSender.DataSet.Account_DS();
            this._addressds = new SHashiba.HtmlMailSender.DataSet.Address_DS();
            this.tabControl1.SuspendLayout();
            this.tabSource.SuspendLayout();
            this.tabHTML.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._accountds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._addressds)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSource);
            this.tabControl1.Controls.Add(this.tabHTML);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(792, 385);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabSource
            // 
            this.tabSource.Controls.Add(this.txtSource);
            this.tabSource.Location = new System.Drawing.Point(4, 21);
            this.tabSource.Name = "tabSource";
            this.tabSource.Padding = new System.Windows.Forms.Padding(3);
            this.tabSource.Size = new System.Drawing.Size(784, 360);
            this.tabSource.TabIndex = 0;
            this.tabSource.Text = "ソース";
            this.tabSource.UseVisualStyleBackColor = true;
            // 
            // txtSource
            // 
            this.txtSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSource.Location = new System.Drawing.Point(3, 3);
            this.txtSource.MaxLength = 10000000;
            this.txtSource.Multiline = true;
            this.txtSource.Name = "txtSource";
            this.txtSource.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSource.Size = new System.Drawing.Size(778, 354);
            this.txtSource.TabIndex = 0;
            this.txtSource.WordWrap = false;
            this.txtSource.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSource_KeyUp);
            // 
            // tabHTML
            // 
            this.tabHTML.Controls.Add(this.webBrowser1);
            this.tabHTML.Location = new System.Drawing.Point(4, 21);
            this.tabHTML.Name = "tabHTML";
            this.tabHTML.Padding = new System.Windows.Forms.Padding(3);
            this.tabHTML.Size = new System.Drawing.Size(784, 360);
            this.tabHTML.TabIndex = 1;
            this.tabHTML.Text = "HTML";
            this.tabHTML.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(778, 354);
            this.webBrowser1.TabIndex = 0;
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuMail});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(792, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuReadHtml,
            this.toolStripSeparator1,
            this.menuEnd});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(66, 20);
            this.menuFile.Text = "ファイル(&F)";
            // 
            // menuReadHtml
            // 
            this.menuReadHtml.Name = "menuReadHtml";
            this.menuReadHtml.Size = new System.Drawing.Size(176, 22);
            this.menuReadHtml.Text = "HTMLソースの読込(&L)";
            this.menuReadHtml.Click += new System.EventHandler(this.menuReadHtml_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(173, 6);
            // 
            // menuEnd
            // 
            this.menuEnd.Name = "menuEnd";
            this.menuEnd.Size = new System.Drawing.Size(176, 22);
            this.menuEnd.Text = "終了(&X)";
            this.menuEnd.Click += new System.EventHandler(this.menuEnd_Click);
            // 
            // menuMail
            // 
            this.menuMail.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMailSetting,
            this.toolStripSeparator2,
            this.menuMailSend});
            this.menuMail.Name = "menuMail";
            this.menuMail.Size = new System.Drawing.Size(62, 20);
            this.menuMail.Text = "メール(&M)";
            // 
            // menuMailSetting
            // 
            this.menuMailSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAccountNew,
            this.menuAccountEdit});
            this.menuMailSetting.Name = "menuMailSetting";
            this.menuMailSetting.Size = new System.Drawing.Size(154, 22);
            this.menuMailSetting.Text = "アカウント設定(&A)";
            // 
            // menuAccountNew
            // 
            this.menuAccountNew.Name = "menuAccountNew";
            this.menuAccountNew.Size = new System.Drawing.Size(110, 22);
            this.menuAccountNew.Text = "新規(&N)";
            this.menuAccountNew.Click += new System.EventHandler(this.menuAccountNew_Click);
            // 
            // menuAccountEdit
            // 
            this.menuAccountEdit.Name = "menuAccountEdit";
            this.menuAccountEdit.Size = new System.Drawing.Size(110, 22);
            this.menuAccountEdit.Text = "編集(&E)";
            this.menuAccountEdit.Click += new System.EventHandler(this.menuAccountEdit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(151, 6);
            // 
            // menuMailSend
            // 
            this.menuMailSend.Name = "menuMailSend";
            this.menuMailSend.Size = new System.Drawing.Size(154, 22);
            this.menuMailSend.Text = "メール送信(&S)";
            this.menuMailSend.Click += new System.EventHandler(this.menuMailSend_Click);
            // 
            // openFileHtml
            // 
            this.openFileHtml.Filter = "HTMLファイル|*.html;*.htm|すべてのファイル|*.*";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnBody);
            this.splitContainer1.Panel1.Controls.Add(this.lblBody);
            this.splitContainer1.Panel1.Controls.Add(this.lblAddress);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddress);
            this.splitContainer1.Panel1.Controls.Add(this.txtSubject);
            this.splitContainer1.Panel1.Controls.Add(this.lblSubject);
            this.splitContainer1.Panel1.Controls.Add(this.btnSend);
            this.splitContainer1.Panel1.Controls.Add(this.lblAccount);
            this.splitContainer1.Panel1.Controls.Add(this.cboAccount);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(792, 542);
            this.splitContainer1.SplitterDistance = 153;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnBody
            // 
            this.btnBody.Location = new System.Drawing.Point(101, 118);
            this.btnBody.Name = "btnBody";
            this.btnBody.Size = new System.Drawing.Size(75, 23);
            this.btnBody.TabIndex = 6;
            this.btnBody.Text = "本文選択";
            this.btnBody.UseVisualStyleBackColor = true;
            this.btnBody.Click += new System.EventHandler(this.btnBody_Click);
            // 
            // lblBody
            // 
            this.lblBody.AutoSize = true;
            this.lblBody.Location = new System.Drawing.Point(22, 123);
            this.lblBody.Name = "lblBody";
            this.lblBody.Size = new System.Drawing.Size(29, 12);
            this.lblBody.TabIndex = 5;
            this.lblBody.Text = "本文";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(22, 58);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(29, 12);
            this.lblAddress.TabIndex = 1;
            this.lblAddress.Text = "宛先";
            // 
            // btnAddress
            // 
            this.btnAddress.Location = new System.Drawing.Point(101, 53);
            this.btnAddress.Name = "btnAddress";
            this.btnAddress.Size = new System.Drawing.Size(75, 23);
            this.btnAddress.TabIndex = 2;
            this.btnAddress.Text = "宛先設定";
            this.btnAddress.UseVisualStyleBackColor = true;
            this.btnAddress.Click += new System.EventHandler(this.btnAddress_Click);
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(101, 91);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(433, 19);
            this.txtSubject.TabIndex = 4;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(22, 91);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(29, 12);
            this.lblSubject.TabIndex = 3;
            this.lblSubject.Text = "題名";
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(705, 20);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "送信";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(22, 25);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(73, 12);
            this.lblAccount.TabIndex = 0;
            this.lblAccount.Text = "送信アカウント";
            // 
            // cboAccount
            // 
            this.cboAccount.DataSource = this._accountds;
            this.cboAccount.DisplayMember = "Account.AccountName";
            this.cboAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccount.FormattingEnabled = true;
            this.cboAccount.Location = new System.Drawing.Point(101, 20);
            this.cboAccount.Name = "cboAccount";
            this.cboAccount.Size = new System.Drawing.Size(121, 20);
            this.cboAccount.TabIndex = 1;
            this.cboAccount.ValueMember = "Account.AccountName";
            // 
            // _accountds
            // 
            this._accountds.DataSetName = "Account_DS";
            this._accountds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // _addressds
            // 
            this._addressds.DataSetName = "Address_DS";
            this._addressds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStripMain);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "メール送信アプリケーション";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabSource.ResumeLayout(false);
            this.tabSource.PerformLayout();
            this.tabHTML.ResumeLayout(false);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._accountds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._addressds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSource;
        private System.Windows.Forms.TabPage tabHTML;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuReadHtml;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuEnd;
        private System.Windows.Forms.ToolStripMenuItem menuMail;
        private System.Windows.Forms.ToolStripMenuItem menuMailSetting;
        private System.Windows.Forms.ToolStripMenuItem menuMailSend;
        private System.Windows.Forms.OpenFileDialog openFileHtml;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.ComboBox cboAccount;
        private SHashiba.HtmlMailSender.DataSet.Account_DS _accountds;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Button btnAddress;
        private SHashiba.HtmlMailSender.DataSet.Address_DS _addressds;
        private System.Windows.Forms.ToolStripMenuItem menuAccountNew;
        private System.Windows.Forms.ToolStripMenuItem menuAccountEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Button btnBody;
        private System.Windows.Forms.Label lblBody;
    }
}

