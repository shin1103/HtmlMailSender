using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SHashiba.HtmlMailSender.DataSet;


namespace SHashiba.HtmlMailSender
{
    public partial class AddressDirectInputForm : Form
    {
        private Address_DS _ads = null;

        public AddressDirectInputForm()
        {
            InitializeComponent();
        }

        public AddressDirectInputForm(Address_DS ads)
        {
            InitializeComponent();

            this._ads = ads;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.errorProvider1.Clear();

            //入力値があるかチェック
            if (this.txtMailAddress.Text == string.Empty)
            {
                this.errorProvider1.SetError(this.txtMailAddress, "メールアドレスが入力されていません。");
                MessageBox.Show(this, "メールアドレスが入力されていません。");
                this.txtMailAddress.Focus();
                return;
            }

            //メールアドレス形式であるかチェック
            if (TKMP.Writer.MailAddressCollection.IsAddressPattern(this.txtMailAddress.Text) == false)
            {
                this.errorProvider1.SetError(this.txtMailAddress, "メールアドレスの形式で入力されていません。");
                MessageBox.Show(this, "メールアドレスの形式で入力されていません。");
                this.txtMailAddress.Focus();
                return;
            }

            //すでに登録されているアドレスかチェック
            if (this._ads.Address.FindByMailAddress(this.txtMailAddress.Text) != null)
            {
                this.errorProvider1.SetError(this.txtMailAddress, "すでに送信予定に含まれているメールアドレスです。");
                MessageBox.Show(this, "すでに送信予定に含まれているメールアドレスです。");
                this.txtMailAddress.Focus();
                return;
            }

            //入力されたアドレスをデータセットに保存
            this._ads.Address.AddAddressRow(this.txtMailAddress.Text, string.Empty, string.Empty);
            this._ads.AcceptChanges();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}