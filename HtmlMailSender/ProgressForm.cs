using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SHashiba.HtmlMailSender.DataSet;
using System.IO;


namespace SHashiba.HtmlMailSender
{
    /// <summary>
    /// ���ۂɃ��[�����M���s���N���X�B
    /// </summary>
    public partial class ProgressForm : Form
    {
        private Account_DS.AccountRow _accountRow = null;
        private Address_DS _addressDs = null;
        private string _mailSubject = null;
        private string _mailBody = null;
        private LogWriter _writer = MyAppContext._writer;

        private bool _enableClose = false;

        public ProgressForm(Account_DS.AccountRow accountRow, Address_DS addressDs, string mailSubject, string mailBody)
        {
            InitializeComponent();

            this._accountRow = accountRow;
            this._addressDs = addressDs;
            this._mailBody = mailBody;
            this._mailSubject = mailSubject;

        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            this._worker.RunWorkerAsync(this._accountRow);
        }

        private void ProgressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //���[�U�ȊO�����閽�߂𔭂����ꍇ�͕���B
            if (e.CloseReason != CloseReason.UserClosing)
            {
                return;
            }

            //����̂�������Ă��Ȃ���΁A����̂��L�����Z������B
            if (this._enableClose == false)
            {
                e.Cancel = true;
            }
        }

        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
                        //���M�A�J�E���g�����擾
            Account_DS.AccountRow accountRow = e.Argument as Account_DS.AccountRow;

            ////�e�X�g�p�ɍ쐬
            //int count = 0;
            //foreach (Address_DS.AddressRow adder in this._addressDs.Address)
            //{
            //    count++;
            //    System.Threading.Thread.Sleep(1000);
            //    this._writer.Write(string.Format("{0}�Ƀ��[���𑗐M���܂����B", adder.MailAddress));
            //    double percentage = ((double)count / (double)this._addressDs.Address.Count) * 100;
            //    this._worker.ReportProgress((int)System.Math.Ceiling(percentage));
            //}

            //return;

            //POP  Before SMTP�̏ꍇ
            if (accountRow.UsePopBeforeSmtp == true)
            {
                this.DoPopBeforeSMTP(accountRow);
            }

            //SMTP�N���C�A���g�̍쐬
            TKMP.Net.SmtpClient smtp = this.CreateSMTPClient(accountRow);

            //�ڑ��Ɏ��s������A�I���B
            if (!smtp.Connect())
            {
                System.Windows.Forms.MessageBox.Show("�C���^�[�l�b�g�ڑ��Ɏ��s���܂����B");
                return;
            }

            try
            {
                //���[�����M���J�n

                smtp.MessageReceive += new TKMP.Net.MessageReceiveHandler(smtp_MessageReceive);
                smtp.MessageSend += new TKMP.Net.MessageSendHandler(smtp_MessageSend);

                //���Đ�A�h���X���Z�b�g
                int count = 0;
                foreach (Address_DS.AddressRow adder in this._addressDs.Address)
                {
                    count++;

                    //���[���I�u�W�F�N�g�̍쐬
                    TKMP.Writer.MailWriter mail = new TKMP.Writer.MailWriter();

                    //SMTP�T�[�o�[�̖₢���킹�p�̃A�h���X���Z�b�g
                    mail.FromAddress = accountRow.SmtpSenderMail;
                    mail.ToAddressList.Add(adder.MailAddress);

                    //To�Ƀ��[���[�ɕ\��������ɂ͂��̍s��ǉ�
                    //mail.Headers.Add("To", adder.MailAddress);

                    //�{���̍쐬�B�iHTML�Ƃ��ĔF���j
                    this.CreateMailBody(mail);

                    //�w�b�_����ǉ�
                    this.CreateMailHeader(mail, accountRow);

                    smtp.SendMail(mail);

                    this._writer.Write(string.Format("{0}�Ƀ��[���𑗐M���܂����B", adder.MailAddress));
                    double percentage = ((double)count / (double)this._addressDs.Address.Count) * 100;
                    this._worker.ReportProgress((int)System.Math.Ceiling(percentage));
                }
            }
            finally
            {
                //�T�[�o�[����ؒf
                smtp.Close();
                this._writer.Dispose();
            }
        }

        private void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this._progressBar.Value = e.ProgressPercentage;
        }

        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //�G���[�̏ꍇ
            if (e.Error != null)
            {
                MessageBox.Show(this, "���b�Z�[�W�̑��M�Ɏ��s���܂����B", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this._writer.Write(e.Error.ToString());
                Application.Exit();
                return;
            }

            this._writer.Flush();

            MessageBox.Show(this, "���b�Z�[�W�̑��M���������܂����B", "����");
            this._enableClose = true;
            this.Close();
        }

        /// <summary>
        /// ���[���{�����쐬����B
        /// </summary>
        /// <param name="mail">�{����ǉ����������[���I�u�W�F�N�g</param>
        private void CreateMailBody(TKMP.Writer.MailWriter mail)
        {
            TKMP.Writer.IPart part = new TKMP.Writer.TextPart(this._mailBody, TKMP.Writer.Charsets.JIS);
            part.Headers.Add("Content-Type", "text/html");
            mail.MainPart = part;
        }

        /// <summary>
        /// ���[���w�b�_�[���쐬����
        /// </summary>
        /// <param name="mail">�w�b�_�[�����������[���I�u�W�F�N�g</param>
        /// <param name="accountRow">�A�J�E���g���</param>
        private void CreateMailHeader(TKMP.Writer.MailWriter mail, Account_DS.AccountRow accountRow)
        {
            //�w�b�_����ǉ����܂�
            mail.Headers.Add("From", string.Format("{0} <{1}>", accountRow.SmtpSenderName, accountRow.SmtpSenderMail)); //�u���o�l�v
            mail.Headers.Add("Subject", this._mailSubject); //���[���̌���
        }

        /// <summary>
        /// Pop Before SMTP���s���B
        /// </summary>
        /// <param name="accountRow">�A�J�E���g���</param>
        private void DoPopBeforeSMTP(Account_DS.AccountRow accountRow)
        {
            System.Net.Sockets.TcpClient tcp = new System.Net.Sockets.TcpClient();
            tcp.Connect(accountRow.PopServer, accountRow.PopPort);
            Stream ns = tcp.GetStream();
            using (StreamWriter sw = new StreamWriter(ns))
            using (StreamReader sr = new StreamReader(ns))
            {
                sw.NewLine = "\r\n";
                sw.AutoFlush = true;
                sr.ReadLine();
                sw.WriteLine("USER {0}", accountRow.PopUserId);
                sr.ReadLine();
                sw.WriteLine("PASS {0}", CryptographyUtil.DecryptString(accountRow.PopPassword));
                sr.ReadLine();
                if (tcp.Connected)
                {
                    sw.WriteLine("QUIT");
                    sr.ReadLine();
                }
                tcp.Close();

            }
        }

        /// <summary>
        /// smtp�N���C�A���g���쐬����B
        /// </summary>
        /// <param name="accountRow">�A�J�E���g���</param>
        /// <returns>smtp�N���C�A���g</returns>
        private TKMP.Net.SmtpClient CreateSMTPClient(Account_DS.AccountRow accountRow)
        {
            TKMP.Net.SmtpClient smtp = null;

            if (accountRow.UseSmtpAuth == true)
            {
                //SMTP�T�[�o�[�ŔF�؂𗘗p����ꍇ
                TKMP.Net.ISmtpLogon logon = new TKMP.Net.AuthLogin(accountRow.PopUserId, CryptographyUtil.DecryptString(accountRow.PopPassword));
                smtp = new TKMP.Net.SmtpClient(accountRow.SmtpServer, accountRow.SmtpPort, logon);
            }
            else
            {
                //�ʏ푗�M
                smtp = new TKMP.Net.SmtpClient(accountRow.SmtpServer, accountRow.SmtpPort);
            }

            return smtp;
        }

        /// <summary>
        /// ���b�Z�[�W�̎�M�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smtp_MessageReceive(object sender, TKMP.Net.MessageArgs e)
        {
            this._writer.Write("recieve:" + e.Message);
        }

        /// <summary>
        /// ���b�Z�[�W�̑��M�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smtp_MessageSend(object sender, TKMP.Net.MessageArgs e)
        {
            this._writer.Write("send:" + e.Message);
        }

    }
}