using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Net.Mail;
using Microsoft.VisualBasic.FileIO;
//using Outlook = Microsoft.Office.Interop.Outlook;
//using TKMP.Net;

namespace SHashiba.HtmlMailSender
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Outlook._Application oApp = new Outlook.Application();
            //Outlook.NameSpace oNameSpace = oApp.Session;
            //Outlook.AddressLists oAddrLists = oNameSpace.AddressLists;

            //foreach (Outlook.AddressList list in oAddrLists)
            //{
            //    foreach (Outlook.AddressEntry oEntry in list.AddressEntries)
            //    {
            //        this.textBox1.Text += oEntry.Name;
            //        this.textBox1.Text += " : ";
            //        this.textBox1.Text += oEntry.Address;
            //        this.textBox1.Text += " : ";
            //        this.textBox1.Text += oEntry.ID ;
            //        this.textBox1.Text += " : ";
                   
            //        this.textBox1.Text += Environment.NewLine;
            //    }
            //}

            //oAddrLists = null;
            //oNameSpace = null;
            //oApp.Quit();
            //oApp = null;


            //if(this.openFileDialog1.ShowDialog() != DialogResult.OK)
            //{
            //    return;
            //}

            //using(TextFieldParser parser = new TextFieldParser(this.openFileDialog1.FileName, System.Text.Encoding.GetEncoding("Shift-Jis")))
            //{
            //    parser.SetDelimiters(",");
            //    while(parser.EndOfData == false)
            //    {
            //        foreach(string str in parser.ReadFields())
            //        {
            //            this.textBox1.Text = this.textBox1.Text + string.Format("�u{0}�v",str);
            //        }
            //        this.textBox1.Text = this.textBox1.Text + Environment.NewLine;
            //    }
            //}
            //SmtpClient client = new SmtpClient("mail.biglobe.ne.jp",587);
            //client.Credentials = new System.Net.NetworkCredential("s-hashiba@mtd.biglobe.ne.jp", "xxxx");
            //client.Send("s-hashiba@mtd.biglobe.ne.jp", "hshb_shin@yahoo.co.jp", "test", "testmail");

            ////���O�ɕK�v�ȏ��
            //string Server = "mail.biglobe.ne.jp";
            //int ServerPort = 587;
            //string FromAddress = "s-hashiba@mtd.biglobe.ne.jp";
            ////SMTP�T�[�o�[�𗘗p����Ƃ��ɔF�؂��K�v�ȏꍇ�́A�ȉ��̏�񂪕K�v
            //string UserID = "s-hashiba@mtd.biglobe.ne.jp";
            //string Pass = "xxxx";

            ////------------------------------------------------------
            ////���M�p�̃��[���N���X���쐬���܂�
            ////------------------------------------------------------
            //TKMP.Writer.MailWriter mail = new TKMP.Writer.MailWriter();

            ////���o�l�̃A�h���X���Z�b�g���܂�
            //mail.FromAddress = FromAddress; //SMTP�T�[�o�[�̖₢���킹�ɉ������邽�߂̍��o�l�ł��B���M��ɂ͓`���܂���
            ////���Đ�A�h���X���Z�b�g���܂�
            //mail.ToAddressList.Add("hshb_shin@yahoo.co.jp"); //���ۂɃ��[����z�M���邠�Đ�ł��BBCC�Ȃǂ̏����͂����ւ̂ݓo�^���܂��B

            ////�{���̃N���X���쐬���܂�
            //TKMP.Writer.IPart part = new TKMP.Writer.TextPart(this.textBox1.Text);
            ////�Y�t�t�@�C�������}���`�p�[�g�̃��[�����쐬����ꍇ�͈ȉ��̂悤�ɂ��܂�
            ////TKMP.Writer.IPart part = new TKMP.Writer.MultiPart(
            ////	new TKMP.Writer.TextPart(textBody.Text) ,
            ////	new TKMP.Writer.FilePart(@"c:\temp.txt")
            ////); 

            ////���M���[���N���X�ɖ{����o�^���܂�
            //mail.MainPart = part;
            //mail.MainPart.Headers.Add("Content-Type", "text/html");

            ////�w�b�_����ǉ����܂�
            //mail.Headers.Add("From", FromAddress); //����̃��[���[�Łu���o�l�v�Ƃ��ĕ\������܂�
            ////mail.Headers.Add("To", "hshb_shin@yahoo.co.jp"); //����̃��[���[�Łu���Đ�v�Ƃ��ĕ\������܂�
            //mail.Headers.Add("Subject", "testmail"); //���[���̌���
            //mail.Headers.Add("X-Mailer", "TKMP Version 2.0.0"); //�t�����Ȃ�

            ////------------------------------------------------------
            ////�T�[�o�[�֐ڑ����܂�
            ////------------------------------------------------------
            ////TKMP.Net.SmtpClient smtp = new TKMP.Net.SmtpClient(Server, ServerPort);

            ////SMTP�T�[�o�[�𗘗p����ꍇ�ɔF�؂��K�v�ȂƂ��͈ȉ��̂悤�ɃC���X�^���X���쐬���܂�
            //TKMP.Net.ISmtpLogon logon = new TKMP.Net.AuthLogin(UserID , Pass);
            //TKMP.Net.SmtpClient smtp = new TKMP.Net.SmtpClient(Server , ServerPort , logon);

            ////�ʐM���O�̃C�x���g
            //smtp.MessageReceive += new TKMP.Net.MessageReceiveHandler(smtp_MessageReceive);
            //smtp.MessageSend += new TKMP.Net.MessageSendHandler(smtp_MessageSend);

            //// --------
            ////  �Í���
            //// --------
            ////smtp.AuthenticationProtocol = TKMP.Net.AuthenticationProtocols.TLS; //TLS�ł̈Í����ʐM���s���܂�
            //// TKMP.Net.AuthenticationProtocols.SSL ���g�p����ꍇ�͐ڑ��|�[�g��465�ɕύX���Ă�������
            ////SSL���g�p���ؖ����̌��؂��s���ɂ͎��̃C�x���g���g�p���Ă�������
            ////smtp.CertificateValidation += new TKMP.Net.CertificateValidationHandler(smtp_CertificateValidation);

            ////�ڑ�
            //if (!smtp.Connect())
            //{
            //    System.Windows.Forms.MessageBox.Show("�ڑ��Ɏ��s���܂����B");
            //    return;
            //}

            //try
            //{
            //    //------------------------------------------------------
            //    //���[�����M���J�n���܂�
            //    //------------------------------------------------------
            //    smtp.SendMail(mail);
            //}
            //finally
            //{
            //    //------------------------------------------------------
            //    //�T�[�o�[����ؒf���܂�
            //    //------------------------------------------------------
            //    smtp.Close();
            //}





            //System.Windows.Forms.MessageBox.Show("���[���𑗐M���܂���");
        }


        /// <summary>
        /// ���b�Z�[�W�̎�M�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smtp_MessageReceive(object sender, TKMP.Net.MessageArgs e)
        {
            System.Diagnostics.Debug.WriteLine("recieve:" + e.Message );
        }

        /// <summary>
        /// ���b�Z�[�W�̑��M�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smtp_MessageSend(object sender, TKMP.Net.MessageArgs e)
        {
            System.Diagnostics.Debug.WriteLine("send:" + e.Message);
        }
    }
}