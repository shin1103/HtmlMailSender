namespace SHashiba.HtmlMailSender
{
    partial class ColumnSelectForm
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
            this.listColumn = new System.Windows.Forms.ListBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.chkHeaderRead = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listColumn
            // 
            this.listColumn.FormattingEnabled = true;
            this.listColumn.ItemHeight = 12;
            this.listColumn.Location = new System.Drawing.Point(12, 12);
            this.listColumn.Name = "listColumn";
            this.listColumn.Size = new System.Drawing.Size(170, 244);
            this.listColumn.TabIndex = 0;
            this.listColumn.DoubleClick += new System.EventHandler(this.listColumn_DoubleClick);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(205, 231);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "選択";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // chkHeaderRead
            // 
            this.chkHeaderRead.AutoSize = true;
            this.chkHeaderRead.Location = new System.Drawing.Point(205, 209);
            this.chkHeaderRead.Name = "chkHeaderRead";
            this.chkHeaderRead.Size = new System.Drawing.Size(103, 16);
            this.chkHeaderRead.TabIndex = 1;
            this.chkHeaderRead.Text = "一行目を読込む";
            this.chkHeaderRead.UseVisualStyleBackColor = true;
            // 
            // ColumnSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 266);
            this.Controls.Add(this.chkHeaderRead);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.listColumn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColumnSelectForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "列選択";
            this.Load += new System.EventHandler(this.ColumnSelectForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ColumnSelectForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listColumn;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.CheckBox chkHeaderRead;
    }
}