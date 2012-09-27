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

            //���͒l�����邩�`�F�b�N
            if (this.txtMailAddress.Text == string.Empty)
            {
                this.errorProvider1.SetError(this.txtMailAddress, "���[���A�h���X�����͂���Ă��܂���B");
                MessageBox.Show(this, "���[���A�h���X�����͂���Ă��܂���B");
                this.txtMailAddress.Focus();
                return;
            }

            //���[���A�h���X�`���ł��邩�`�F�b�N
            if (TKMP.Writer.MailAddressCollection.IsAddressPattern(this.txtMailAddress.Text) == false)
            {
                this.errorProvider1.SetError(this.txtMailAddress, "���[���A�h���X�̌`���œ��͂���Ă��܂���B");
                MessageBox.Show(this, "���[���A�h���X�̌`���œ��͂���Ă��܂���B");
                this.txtMailAddress.Focus();
                return;
            }

            //���łɓo�^����Ă���A�h���X���`�F�b�N
            if (this._ads.Address.FindByMailAddress(this.txtMailAddress.Text) != null)
            {
                this.errorProvider1.SetError(this.txtMailAddress, "���łɑ��M�\��Ɋ܂܂�Ă��郁�[���A�h���X�ł��B");
                MessageBox.Show(this, "���łɑ��M�\��Ɋ܂܂�Ă��郁�[���A�h���X�ł��B");
                this.txtMailAddress.Focus();
                return;
            }

            //���͂��ꂽ�A�h���X���f�[�^�Z�b�g�ɕۑ�
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