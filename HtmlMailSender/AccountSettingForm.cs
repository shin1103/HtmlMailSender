using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SHashiba.HtmlMailSender.DataSet;
using System.IO;
using Microsoft.VisualBasic;

namespace SHashiba.HtmlMailSender
{
    public partial class AccountSettingForm : Form
    {
        /// <summary>
        /// �ҏW�^�C�v��ݒ肷��ENUM
        /// </summary>
        public enum AccountSettingType
        {
            New,
            Edit
        }

        #region �t�B�[���h

        private AccountSettingType _type;

        private string _beforeAccountName = string.Empty;
        
        //�A�J�E���g���L�q���ꂽXML�t�@�C���p�X
        
        private string _accoutPath = Path.Combine(Application.StartupPath, @"Data\Account.xml");

        //�R���{�{�b�N�X�̕ύX�O�̒l��ۑ�
        private string _cboBeforeValue = string.Empty;

        //�A�J�E���g�ҏW���s���Ă��邩�H
        private bool _isAccountEdited = false;
        #endregion

        #region �R���X�g���N�^

        public AccountSettingForm()
        {
            InitializeComponent();

            this._type = AccountSettingType.New;
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="t"></param>
        public AccountSettingForm(AccountSettingType t)
        {
            InitializeComponent();
            this._type = t;
        }

        #endregion

        /// <summary>
        /// �t�H�[�����ǂݍ��܂ꂽ�Ƃ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccountSettingForm_Load(object sender, EventArgs e)
        {
            //�Z�b�e�B���O����ǂݎ��B
            if (File.Exists(this._accoutPath) == true)
            {
                this._ads.ReadXml(this._accoutPath, XmlReadMode.Auto);
                this._adsCbo.Merge(this._ads);
            }

            switch (this._type)
            {
                case AccountSettingType.New:        //�V�K�̏ꍇ
                    //�f�t�H���g�̃|�[�g�ԍ����Z�b�g
                    this.txtSmtpPort.Text = "25";
                    this.txtPopPort.Text = "110";
                    //��ʕ\���ݒ�
                    this.cboAccount.Visible = false;
                    this.btnDelete.Visible = false;
                    break;

                case AccountSettingType.Edit:       //�ҏW�̏ꍇ

                    //�ҏW�ŃZ�b�e�B���O��񂪂Ȃ��ꍇ�̓��b�Z�[�W��\�����ĉ�ʂ����B
                    if ((this._type == AccountSettingType.Edit) && (this._ads.Account.Count == 0))
                    {
                        MessageBox.Show(this, "�ݒ��񂪂���܂���B");
                        this.Close();
                        return;
                    }

                    //�f�t�H���g�Z�b�e�B���O����\������B
                    this.cboAccount.SelectedIndex = 0;
                    this.ShowAccount();

                    break;
            }

        }

        /// <summary>
        /// ����{�^���������ꂽ�Ƃ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            //��ʂ����
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #region ��ʕ\��

        /// <summary>
        /// �h���b�v�_�E���ɕ\������Ă���ݒ����\������B
        /// </summary>
        private void ShowAccount()
        {
            Account_DS.AccountRow row = this._ads.Account.FindByAccountName(this.cboAccount.SelectedValue.ToString());

            this.txtAccount.Text = row.AccountName;
            this.txtSmtpServer.Text = row.SmtpServer;
            this.txtSenderName.Text = row.SmtpSenderName;
            this.txtSenderMail.Text = row.SmtpSenderMail;
            this.txtSmtpPort.Text = row.SmtpPort.ToString();
            this.chkPopBeforeSmtp.Checked = row.UsePopBeforeSmtp;
            this.chkSmtpAuth.Checked = row.UseSmtpAuth;
            this.txtPopServer.Text = row.PopServer;
            this.txtPopUser.Text = row.PopUserId;
            this.txtPopPassword.Text = CryptographyUtil.DecryptString(row.PopPassword);
            this.txtPopPort.Text = row.PopPort.ToString();

            this._isAccountEdited = false;
            this._beforeAccountName = this.cboAccount.SelectedValue.ToString();
        }

        /// <summary>
        /// PopBeforeSMTP�`�F�b�N�{�b�N�X�̃`�F�b�N���ύX�ɂȂ����ꍇ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkPopBeforeSmtp_CheckedChanged(object sender, EventArgs e)
        {
            //PopBeforeSMTP��SMTPAUTH�̂ǂ��炩�Ƀ`�F�b�N�������Ă���΁A���p�\��
            this.gboPopBeforeSmtp.Enabled = (this.chkPopBeforeSmtp.Checked || this.chkSmtpAuth.Checked);
        }

        /// <summary>
        /// SMTP auth�`�F�b�N�{�b�N�X�̃`�F�b�N���ύX�ɂȂ����ꍇ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSmtpAuth_CheckedChanged(object sender, EventArgs e)
        {
            //PopBeforeSMTP��SMTPAUTH�̂ǂ��炩�Ƀ`�F�b�N�������Ă���΁A���p�\��
            this.gboPopBeforeSmtp.Enabled = (this.chkPopBeforeSmtp.Checked || this.chkSmtpAuth.Checked);
        }

        #endregion

        #region �ۑ����̏���

        /// <summary>
        /// �ۑ��{�^���������ꂽ�Ƃ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //�G���[��Ԃ�����
            this.errorProvider1.Clear();
            this.lblErrorMessage.Text = string.Empty;

            //���ׂĕK�{���͍��ڂ����͂���Ă��Ȃ��ꍇ�͏I��
            if (this.IsValidInput() == false)
            {
                this.lblErrorMessage.Text = "�����́E�t�H�[�}�b�g�𖞂����Ȃ����ڂ�����܂��B";
                return;
            }

            //�V�K�̏ꍇ�͂��łɃA�J�E���g�����o�^����Ă��Ȃ������m�F
            if ((this._type == AccountSettingType.New) && (this._ads.Account.FindByAccountName(this.txtAccount.Text) != null))
            {
                this.errorProvider1.SetError(this.txtAccount, "�A�J�E���g���͂��łɎg�p����Ă��܂��B");
                this.lblErrorMessage.Text = "�A�J�E���g���͂��łɎg�p����Ă��܂��B";
                return;
            }

            //��ʂ̓��͍��ڂ��Z�b�g
            this.SetAccount();

            //�����m�肵�A��������
            this._ads.AcceptChanges();
            if (File.Exists(this._accoutPath) == false)
            {
                //�t�@�C�������݂��Ȃ��ꍇ�͍쐬�B
                using (Stream s = File.Create(this._accoutPath)) { }
            }
            using (StreamWriter writer = new StreamWriter(this._accoutPath, false, System.Text.Encoding.UTF8))
            {
                this._ads.WriteXml(writer);
            }

            //��ʂ����
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// ���͍��ڂ����������`�F�b�N����B
        /// </summary>
        /// <returns></returns>
        private bool IsValidInput()
        {
            bool result = true;

            if (this.txtAccount.Text == string.Empty)               //�A�J�E���g��
            {
                this.errorProvider1.SetError(this.txtAccount, "�A�J�E���g���͕K�{���͍��ڂł��B");
                result = false;
            }
            if (this.txtSmtpServer.Text == string.Empty)            //SMTP�T�[�o��
            {
                this.errorProvider1.SetError(this.txtSmtpServer, "SMTP�T�[�o���͕K�{���͍��ڂł��B");
                result = false;
            }
            if (this.txtSenderMail.Text == string.Empty)            //���M�҃��[���A�h���X
            {
                this.errorProvider1.SetError(this.txtSenderMail, "���M�҃��[���A�h���X�͕K�{���͍��ڂł��B");
                result = false;
            }
            if (this.txtSenderName.Text == string.Empty)            //���M�Җ�
            {
                this.errorProvider1.SetError(this.txtSenderName, "���M�Җ��͕K�{���͍��ڂł��B");
                result = false;
            }
            if (this.txtSmtpPort.Text == string.Empty)              //SMTP�|�[�g�ԍ�
            {
                this.errorProvider1.SetError(this.txtSmtpPort, "SMTP�|�[�g�ԍ��͕K�{���͍��ڂł��B");
                result = false;
            }
            else if (Microsoft.VisualBasic.Information.IsNumeric(this.txtSmtpPort.Text) == false)
            {
                this.errorProvider1.SetError(this.txtSmtpPort, "SMTP�|�[�g�ԍ����l�̂ݓ��͉\�ł��B");
                result = false;
            }

            //PopBeforeSmtp���g���ꍇ�͈ȉ��̍��ڂ��`�F�b�N
            if (this.chkPopBeforeSmtp.Checked == true)
            {
                if (this.txtPopServer.Text == string.Empty)         //POP�T�[�o��
                {
                    this.errorProvider1.SetError(this.txtPopServer, "POP�T�[�o���͕K�{���͍��ڂł��B");
                    result = false;
                }
                if (this.txtPopUser.Text == string.Empty)           //POP���[�U
                {
                    this.errorProvider1.SetError(this.txtPopUser, "POP���[�U�͕K�{���͍��ڂł��B");
                    result = false;
                }
                if (this.txtPopPassword.Text == string.Empty)       //POP�p�X���[�h
                {
                    this.errorProvider1.SetError(this.txtPopPassword, "POP�p�X���[�h�͕K�{���͍��ڂł��B");
                    result = false;
                }
                if (this.txtPopPort.Text == string.Empty)           //POP�|�[�g
                {
                    this.errorProvider1.SetError(this.txtPopPort, "POP�|�[�g�͕K�{���͍��ڂł��B");
                    result = false;
                }
                else if (Microsoft.VisualBasic.Information.IsNumeric(this.txtSmtpPort.Text) == false)
                {
                    this.errorProvider1.SetError(this.txtSmtpPort, "POP�|�[�g�ԍ����l�̂ݓ��͉\�ł��B");
                    result = false;
                }
            }

            return result;
        }

        /// <summary>
        /// ��ʂ̃A�J�E���g�ݒ���擾����B
        /// </summary>
        private void SetAccount()
        {
            Account_DS.AccountRow row = null;
            switch (this._type)
            {
                case AccountSettingType.New:
                    //�V�K�̏ꍇ�͐V�K�s���쐬
                    row = this._ads.Account.NewAccountRow();
                    break;
                case AccountSettingType.Edit:
                    //�ҏW�̏ꍇ�͕ҏW�s��ݒ�
                    row = this._ads.Account.FindByAccountName(this._beforeAccountName);
                    break;
            }

            //��ʂ̏�����荞��
            row.AccountName = this.txtAccount.Text;
            row.SmtpServer = this.txtSmtpServer.Text;
            row.SmtpSenderName = this.txtSenderName.Text;
            row.SmtpSenderMail = this.txtSenderMail.Text;
            row.SmtpPort = int.Parse(this.txtSmtpPort.Text);
            row.UsePopBeforeSmtp = this.chkPopBeforeSmtp.Checked;
            row.UseSmtpAuth = this.chkSmtpAuth.Checked;
            row.PopServer = this.txtPopServer.Text;
            row.PopUserId = this.txtPopUser.Text;
            row.PopPassword = CryptographyUtil.EncryptString(this.txtPopPassword.Text);
            row.PopPort = int.Parse(this.txtPopPort.Text);

            if (this._type == AccountSettingType.New) this._ads.Account.AddAccountRow(row);
        }

        #endregion

        #region �폜���̏���

        /// <summary>
        /// �폜�{�^���������ꂽ�Ƃ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //�폜�m�F���b�Z�[�W��\�����AYes�ł���ΏI���B
            if (MessageBox.Show(this, string.Format("�A�J�E���g�u{0}�v���폜���Ă���낵���ł����H", this.txtAccount.Text),
                                    "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            //�폜�ݒ�����m�肷��B
            this._ads.Account.FindByAccountName(this._beforeAccountName).Delete();
            this._ads.AcceptChanges();


            //�ݒ������������
            using (StreamWriter writer = new StreamWriter(this._accoutPath, false, System.Text.Encoding.UTF8))
            {
                this._ads.WriteXml(writer);
            }

            //��ʂ����
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion

        #region �h���b�v�_�E���̃C�x���g
        /// <summary>
        /// �h���b�v�_�E���̃C���f�b�N�X���ύX���ꂽ�Ƃ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            //�A�J�E���g�ɑ΂��ĕҏW����������A
            if (this._isAccountEdited == true)
            {
                //�m�F���s���B
                if (MessageBox.Show(this, "�A�J�E���g�̕ύX�͕ۑ�����܂��񂪂�낵���ł����H", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes )
                {
                    this.cboAccount.SelectedIndexChanged -= new System.EventHandler(this.cboAccount_SelectedIndexChanged);
                    this.cboAccount.SelectedValue = this._cboBeforeValue;
                    this.cboAccount.SelectedIndexChanged += new System.EventHandler(this.cboAccount_SelectedIndexChanged);
                    return;
                }
            }

            //�V�����A�J�E���g����\������B
            this.ShowAccount();

            //�ҏW�A�J�E���g���ύX���ꂽ�̂ŁA�ҏW�Ȃ��ɖ߂��B
            this._isAccountEdited = false;

        }

        /// <summary>
        /// �h���b�v�_�E�����\�����ꂽ�Ƃ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboAccount_DropDown(object sender, EventArgs e)
        {
            //�h���b�v�_�E���ύX�O�̒l��ۑ����Ă���
            this._cboBeforeValue = this.cboAccount.SelectedValue.ToString();
        }
        #endregion

        #region �e�L�X�g�{�b�N�X�ύX

        private void txtAccount_TextChanged(object sender, EventArgs e)
        {
            this._isAccountEdited = true;
        }

        private void txtSmtpServer_TextChanged(object sender, EventArgs e)
        {
            this._isAccountEdited = true;

        }

        private void txtSenderName_TextChanged(object sender, EventArgs e)
        {
            this._isAccountEdited = true;

        }

        private void txtSenderMail_TextChanged(object sender, EventArgs e)
        {
            this._isAccountEdited = true;

        }

        private void txtSmtpPort_TextChanged(object sender, EventArgs e)
        {
            this._isAccountEdited = true;

        }

        private void txtPopServer_TextChanged(object sender, EventArgs e)
        {
            this._isAccountEdited = true;

        }

        private void txtPopUser_TextChanged(object sender, EventArgs e)
        {
            this._isAccountEdited = true;

        }

        private void txtPopPassword_TextChanged(object sender, EventArgs e)
        {
            this._isAccountEdited = true;

        }

        private void txtPopPort_TextChanged(object sender, EventArgs e)
        {
            this._isAccountEdited = true;

        }
        #endregion

    }
}