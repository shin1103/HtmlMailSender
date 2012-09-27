namespace SHashiba.HtmlMailSender
{
    partial class ErrorListForm
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
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.gridErrorList = new System.Windows.Forms.DataGridView();
            this.mailAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._errords = new SHashiba.HtmlMailSender.DataSet.Address_DS();
            ((System.ComponentModel.ISupportInitialize)(this.gridErrorList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._errords)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(12, 18);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(209, 37);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "以下のメールアドレスはメールアドレス形式でないため、読み込みませんでした。";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(283, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gridErrorList
            // 
            this.gridErrorList.AllowUserToAddRows = false;
            this.gridErrorList.AllowUserToDeleteRows = false;
            this.gridErrorList.AutoGenerateColumns = false;
            this.gridErrorList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridErrorList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mailAddressDataGridViewTextBoxColumn});
            this.gridErrorList.DataMember = "Address";
            this.gridErrorList.DataSource = this._errords;
            this.gridErrorList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridErrorList.Location = new System.Drawing.Point(0, 58);
            this.gridErrorList.Name = "gridErrorList";
            this.gridErrorList.ReadOnly = true;
            this.gridErrorList.RowTemplate.Height = 21;
            this.gridErrorList.Size = new System.Drawing.Size(394, 208);
            this.gridErrorList.TabIndex = 0;
            // 
            // mailAddressDataGridViewTextBoxColumn
            // 
            this.mailAddressDataGridViewTextBoxColumn.DataPropertyName = "MailAddress";
            this.mailAddressDataGridViewTextBoxColumn.HeaderText = "メールアドレス";
            this.mailAddressDataGridViewTextBoxColumn.Name = "mailAddressDataGridViewTextBoxColumn";
            this.mailAddressDataGridViewTextBoxColumn.ReadOnly = true;
            this.mailAddressDataGridViewTextBoxColumn.Width = 330;
            // 
            // _errords
            // 
            this._errords.DataSetName = "Address_DS";
            this._errords.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ErrorListForm
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(394, 266);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.gridErrorList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorListForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "読み込みエラーアドレス";
            this.Load += new System.EventHandler(this.ErrorListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridErrorList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._errords)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridErrorList;
        private SHashiba.HtmlMailSender.DataSet.Address_DS _errords;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn mailAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnClose;
    }
}