namespace SHashiba.HtmlMailSender
{
    partial class AddressSelectForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gboPivot = new System.Windows.Forms.GroupBox();
            this.btnDirectInput = new System.Windows.Forms.Button();
            this.gboSelectType = new System.Windows.Forms.GroupBox();
            this.rdoCSV = new System.Windows.Forms.RadioButton();
            this.btnImport = new System.Windows.Forms.Button();
            this.rdoExcel = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuItemAction = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClear = new System.Windows.Forms.ToolStripMenuItem();
            this.gridAddress = new System.Windows.Forms.DataGridView();
            this.mailAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this._addressds = new SHashiba.HtmlMailSender.DataSet.Address_DS();
            this.openFileExcel = new System.Windows.Forms.OpenFileDialog();
            this.openFileCSV = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gboSelectType.SuspendLayout();
            this.menuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._addressds)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gboPivot);
            this.splitContainer1.Panel1.Controls.Add(this.btnDirectInput);
            this.splitContainer1.Panel1.Controls.Add(this.gboSelectType);
            this.splitContainer1.Panel1.Controls.Add(this.btnClose);
            this.splitContainer1.Panel1.Controls.Add(this.menuMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridAddress);
            this.splitContainer1.Size = new System.Drawing.Size(602, 497);
            this.splitContainer1.SplitterDistance = 114;
            this.splitContainer1.TabIndex = 1;
            // 
            // gboPivot
            // 
            this.gboPivot.BackColor = System.Drawing.SystemColors.Control;
            this.gboPivot.Location = new System.Drawing.Point(451, 35);
            this.gboPivot.Name = "gboPivot";
            this.gboPivot.Size = new System.Drawing.Size(10, 73);
            this.gboPivot.TabIndex = 2;
            this.gboPivot.TabStop = false;
            // 
            // btnDirectInput
            // 
            this.btnDirectInput.Location = new System.Drawing.Point(337, 55);
            this.btnDirectInput.Name = "btnDirectInput";
            this.btnDirectInput.Size = new System.Drawing.Size(75, 23);
            this.btnDirectInput.TabIndex = 1;
            this.btnDirectInput.Text = "直接入力";
            this.btnDirectInput.UseVisualStyleBackColor = true;
            this.btnDirectInput.Click += new System.EventHandler(this.btnDirectInput_Click);
            // 
            // gboSelectType
            // 
            this.gboSelectType.Controls.Add(this.rdoCSV);
            this.gboSelectType.Controls.Add(this.btnImport);
            this.gboSelectType.Controls.Add(this.rdoExcel);
            this.gboSelectType.Location = new System.Drawing.Point(12, 35);
            this.gboSelectType.Name = "gboSelectType";
            this.gboSelectType.Size = new System.Drawing.Size(291, 74);
            this.gboSelectType.TabIndex = 0;
            this.gboSelectType.TabStop = false;
            this.gboSelectType.Text = "取り込み";
            // 
            // rdoCSV
            // 
            this.rdoCSV.AutoSize = true;
            this.rdoCSV.Checked = true;
            this.rdoCSV.Location = new System.Drawing.Point(21, 45);
            this.rdoCSV.Name = "rdoCSV";
            this.rdoCSV.Size = new System.Drawing.Size(132, 16);
            this.rdoCSV.TabIndex = 1;
            this.rdoCSV.TabStop = true;
            this.rdoCSV.Text = "CSVファイルを取り込み";
            this.rdoCSV.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(188, 20);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "取込";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // rdoExcel
            // 
            this.rdoExcel.AutoSize = true;
            this.rdoExcel.Location = new System.Drawing.Point(21, 23);
            this.rdoExcel.Name = "rdoExcel";
            this.rdoExcel.Size = new System.Drawing.Size(137, 16);
            this.rdoExcel.TabIndex = 0;
            this.rdoExcel.Text = "Excelファイルを取り込み";
            this.rdoExcel.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(502, 55);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAction});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(602, 24);
            this.menuMain.TabIndex = 3;
            this.menuMain.Text = "menuStrip1";
            // 
            // menuItemAction
            // 
            this.menuItemAction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuClear});
            this.menuItemAction.Name = "menuItemAction";
            this.menuItemAction.Size = new System.Drawing.Size(57, 20);
            this.menuItemAction.Text = "操作(&A)";
            // 
            // menuClear
            // 
            this.menuClear.Name = "menuClear";
            this.menuClear.Size = new System.Drawing.Size(174, 22);
            this.menuClear.Text = "メールアドレスクリア(&C)";
            this.menuClear.Click += new System.EventHandler(this.menuClear_Click);
            // 
            // gridAddress
            // 
            this.gridAddress.AllowUserToAddRows = false;
            this.gridAddress.AllowUserToDeleteRows = false;
            this.gridAddress.AutoGenerateColumns = false;
            this.gridAddress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAddress.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mailAddressDataGridViewTextBoxColumn,
            this.colDelete});
            this.gridAddress.DataMember = "Address";
            this.gridAddress.DataSource = this._addressds;
            this.gridAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAddress.Location = new System.Drawing.Point(0, 0);
            this.gridAddress.Name = "gridAddress";
            this.gridAddress.ReadOnly = true;
            this.gridAddress.RowTemplate.Height = 21;
            this.gridAddress.Size = new System.Drawing.Size(602, 379);
            this.gridAddress.TabIndex = 0;
            this.gridAddress.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAddress_CellContentClick);
            // 
            // mailAddressDataGridViewTextBoxColumn
            // 
            this.mailAddressDataGridViewTextBoxColumn.DataPropertyName = "MailAddress";
            this.mailAddressDataGridViewTextBoxColumn.HeaderText = "メールアドレス";
            this.mailAddressDataGridViewTextBoxColumn.MinimumWidth = 100;
            this.mailAddressDataGridViewTextBoxColumn.Name = "mailAddressDataGridViewTextBoxColumn";
            this.mailAddressDataGridViewTextBoxColumn.ReadOnly = true;
            this.mailAddressDataGridViewTextBoxColumn.Width = 500;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "";
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.Text = "削除";
            this.colDelete.UseColumnTextForButtonValue = true;
            this.colDelete.Width = 40;
            // 
            // _addressds
            // 
            this._addressds.DataSetName = "Address_DS";
            this._addressds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // openFileExcel
            // 
            this.openFileExcel.Filter = "Excelファイル|*.xls|すべてのファイル|*.*";
            // 
            // openFileCSV
            // 
            this.openFileCSV.Filter = "CSVファイル|*.csv|すべてのファイル|*.*";
            // 
            // AddressSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(602, 497);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuMain;
            this.MaximizeBox = false;
            this.Name = "AddressSelectForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "送信先選択";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddressSelectForm_FormClosing);
            this.Load += new System.EventHandler(this.AddressSelectForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.gboSelectType.ResumeLayout(false);
            this.gboSelectType.PerformLayout();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._addressds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SHashiba.HtmlMailSender.DataSet.Address_DS _addressds;
        private System.Windows.Forms.DataGridView gridAddress;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.OpenFileDialog openFileExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn mailAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
        private System.Windows.Forms.OpenFileDialog openFileCSV;
        private System.Windows.Forms.GroupBox gboSelectType;
        private System.Windows.Forms.RadioButton rdoCSV;
        private System.Windows.Forms.RadioButton rdoExcel;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuItemAction;
        private System.Windows.Forms.ToolStripMenuItem menuClear;
        private System.Windows.Forms.Button btnDirectInput;
        private System.Windows.Forms.GroupBox gboPivot;
    }
}