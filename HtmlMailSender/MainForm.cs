using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SHashiba.HtmlMailSender.DataSet;
using System.Net.Mail;
using System.IO;
using TKMP.Net;


namespace SHashiba.HtmlMailSender
{
    /// <summary>
    /// �^�u�̃C���f�b�N�X
    /// </summary>
    public enum TabInd : int
    {
        Source,
        HTML
    }

    public partial class MainForm : Form
    {
        #region �t�B�[���h

        //�A�J�E���g���L�q���ꂽXML�t�@�C���p�X
        private string _accoutPath = Path.Combine(Environment.CurrentDirectory, @"Data\Account.xml");

        private LogWriter _writer = MyAppContext._writer;

        #endregion

        //public MainForm()
        //{
        //    InitializeComponent();
        //}

        public MainForm()
        {
            InitializeComponent();
            //this._writer = writer;

            System.Reflection.Assembly thisExe;
            thisExe = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream file =
                thisExe.GetManifestResourceStream("SHashiba.HtmlMailSender.Data.icon2.ico");
            this.Icon = new Icon(file);

        }

        /// <summary>
        /// �t�H�[�����ǂݍ��܂ꂽ�Ƃ��̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //�Z�b�e�B���O����ǂݎ��B
            if (File.Exists(this._accoutPath) == true)
            {
                this._accountds.ReadXml(this._accoutPath, XmlReadMode.Auto);
            }

        }

        /// <summary>
        /// �I���A�C�e�����N���b�N���ꂽ�ꍇ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuEnd_Click(object sender, EventArgs e)
        {
            //�A�v���P�[�V�������I������B
            Application.Exit();
        }

        #region ��ʕ\��

        /// <summary>
        /// �^�u�̑I�����ύX���ꂽ�ꍇ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex)
            {
                case (int)TabInd.HTML:
                    //HTML�^�u���I�����ꂽ��A�ēǂݍ��݂��s���B
                    this.ShowHTML();
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// HTML��Web�u���E�U�ŕ\������B
        /// </summary>
        private void ShowHTML()
        {
            this.webBrowser1.DocumentText = this.txtSource.Text;
            this.webBrowser1.Show();
        }


        /// <summary>
        /// HTML�\�[�X�ǂݍ��݃��j���[���I�����ꂽ�ꍇ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuReadHtml_Click(object sender, EventArgs e)
        {
            //HTML�t�@�C����ǂݍ���
            this.ReadHtml();
        }

        /// <summary>
        /// �{���I���{�^���������ꂽ�Ƃ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBody_Click(object sender, EventArgs e)
        {
            //HTML�t�@�C����ǂݍ���
            this.ReadHtml();
        }

        /// <summary>
        /// HTML�t�@�C����ǂݍ���
        /// </summary>
        private void ReadHtml()
        {
            DialogResult result = this.openFileHtml.ShowDialog();
            if (result != DialogResult.OK)
            {
                //�t�@�C�����I������Ȃ���΁A�I���B
                return;
            }

            //�t�@�C���̓ǂݍ��݂��s��
            //using (StreamReader reader = new StreamReader(this.openFileHtml.FileName, System.Text.Encoding.GetEncoding("SHIFT-JIS")))
            using (StreamReader reader = new StreamReader(this.openFileHtml.FileName, System.Text.Encoding.GetEncoding("ISO-2022-JP")))
            {
                this.txtSource.Text = reader.ReadToEnd();
            }

            //�e�L�X�g�{�b�N�X�E�v���r���[��ʂɕύX�𔽉f
            this.ShowHTML();
        }

        #endregion

        #region ���[�����M

        /// <summary>
        /// ���Đ�ݒ�{�^���������ꂽ�Ƃ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddress_Click(object sender, EventArgs e)
        {
            //����I����ʂ�\������B
            using (AddressSelectForm f = new AddressSelectForm(this._addressds))
            {
                f.ShowDialog();
            }

            if (this._addressds.Address.Count != 0) this.btnAddress.BackColor = SystemColors.ControlDark ;
            else this.btnAddress.BackColor = SystemColors.Control;
        }

        /// <summary>
        /// ���[�����M�{�^�����������ꂽ�Ƃ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuMailSend_Click(object sender, EventArgs e)
        {
            //���[���𑗐M����B
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.SendMail();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ���[�����M�{�^���������ꂽ�ꍇ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            //���[���𑗐M����B
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.SendMail();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ���[���𑗐M����B
        /// </summary>
        private void SendMail()
        {
            if (this.IsValid() == false)
            {
                return;
            }
 
            //���M�m�F���s���AOK�łȂ���Β��~����B
            if (MessageBox.Show(this, "���[���𑗐M���܂����H", "���M�m�F",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.OK)
            {
                return;
            }

            //���M���������s
            Account_DS.AccountRow accountRow = this._accountds.Account.FindByAccountName(this.cboAccount.SelectedValue.ToString());
            using (ProgressForm f = new ProgressForm(accountRow, this._addressds ,this.txtSubject.Text, this.txtSource.Text))
            {
                f.ShowDialog();
            }

        }

        /// <summary>
        /// ���M�ɉ\�ȏ�񂪂�����Ă��邩���`�F�b�N����
        /// </summary>
        /// <returns>��������΁ATrue��Ԃ��B</returns>
        /// <remarks>���̃��\�b�h�ŃG���[�\�����s���B</remarks>
        private bool IsValid()
        {
            //�A�J�E���g���ݒ肳��Ă��Ȃ���΁A���b�Z�[�W��\�����ďI���B
            if (this.cboAccount.SelectedIndex == -1)
            {
                MessageBox.Show(this, "�A�J�E���g���ݒ肳��Ă��܂���B");
                return false ;
            }
            //���[���̓��e������������Ă��Ȃ���΁A�I���B
            if (this.txtSource.Text == string.Empty)
            {
                MessageBox.Show(this, "���[���̓��e���L�q����Ă��܂���B");
                return false ;
            }

            //BCC�ɒl���ݒ肳��Ă��Ȃ���΁A���b�Z�[�W��\�����ďI��
            if (this._addressds.Address.Count == 0)
            {
                MessageBox.Show(this, "���Đ悪�ݒ肳��Ă��܂���B");
                return false ;
            }

            return true;
        }

#endregion

        #region �A�J�E���g�ݒ�

        /// <summary>
        /// �A�J�E���g�V�K���j���[�������ꂽ�Ƃ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAccountNew_Click(object sender, EventArgs e)
        {
            //�A�J�E���g�ݒ��ʂ�\��
            using (AccountSettingForm f = new AccountSettingForm(AccountSettingForm.AccountSettingType.New))
            {
                DialogResult result = f.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //�ύX������΁A�X�V����B(���Ƃ��ƑI�����Ă������̂��đI������)
                    string nowAccount = this.cboAccount.SelectedValue.ToString();
                    this._accountds.Clear();
                    this._accountds.ReadXml(this._accoutPath, XmlReadMode.Auto);
                    if (this._accountds.Account.FindByAccountName(nowAccount) != null)
                    {
                        this.cboAccount.SelectedValue = nowAccount;
                    }
                }
            }

        }

        /// <summary>
        /// �A�J�E���g�ҏW���j���[�������ꂽ�Ƃ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAccountEdit_Click(object sender, EventArgs e)
        {
            //�A�J�E���g�ݒ��ʂ�\��
            using (AccountSettingForm f = new AccountSettingForm(AccountSettingForm.AccountSettingType.Edit))
            {
                DialogResult result = f.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //�ύX������΁A�X�V����B
                    //�ύX������΁A�X�V����B(���Ƃ��ƑI�����Ă������̂��đI������)
                    string nowAccount = this.cboAccount.SelectedValue.ToString();
                    this._accountds.Clear();
                    this._accountds.ReadXml(this._accoutPath, XmlReadMode.Auto);
                    if (this._accountds.Account.FindByAccountName(nowAccount) != null)
                    {
                        this.cboAccount.SelectedValue = nowAccount;
                    }
                }
            }

        }

        #endregion 

        /// <summary>
        /// �L�[�������ꂽ�Ƃ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSource_KeyUp(object sender, KeyEventArgs e)
        {
            //Ctrl+A�ł���΁A�e�L�X�g�����ׂđI������B
            if ((e.Control == true) && (e.KeyCode  == Keys.A))
            {
                this.txtSource.SelectAll();
            }
        }

    }
}