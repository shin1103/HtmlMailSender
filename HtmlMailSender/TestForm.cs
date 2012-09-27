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
            //            this.textBox1.Text = this.textBox1.Text + string.Format("「{0}」",str);
            //        }
            //        this.textBox1.Text = this.textBox1.Text + Environment.NewLine;
            //    }
            //}
            //SmtpClient client = new SmtpClient("mail.biglobe.ne.jp",587);
            //client.Credentials = new System.Net.NetworkCredential("s-hashiba@mtd.biglobe.ne.jp", "xxxx");
            //client.Send("s-hashiba@mtd.biglobe.ne.jp", "hshb_shin@yahoo.co.jp", "test", "testmail");

            ////事前に必要な情報
            //string Server = "mail.biglobe.ne.jp";
            //int ServerPort = 587;
            //string FromAddress = "s-hashiba@mtd.biglobe.ne.jp";
            ////SMTPサーバーを利用するときに認証が必要な場合は、以下の情報が必要
            //string UserID = "s-hashiba@mtd.biglobe.ne.jp";
            //string Pass = "xxxx";

            ////------------------------------------------------------
            ////送信用のメールクラスを作成します
            ////------------------------------------------------------
            //TKMP.Writer.MailWriter mail = new TKMP.Writer.MailWriter();

            ////差出人のアドレスをセットします
            //mail.FromAddress = FromAddress; //SMTPサーバーの問い合わせに応答するための差出人です。送信先には伝わりません
            ////あて先アドレスをセットします
            //mail.ToAddressList.Add("hshb_shin@yahoo.co.jp"); //実際にメールを配信するあて先です。BCCなどの処理はここへのみ登録します。

            ////本文のクラスを作成します
            //TKMP.Writer.IPart part = new TKMP.Writer.TextPart(this.textBox1.Text);
            ////添付ファイルを持つマルチパートのメールを作成する場合は以下のようにします
            ////TKMP.Writer.IPart part = new TKMP.Writer.MultiPart(
            ////	new TKMP.Writer.TextPart(textBody.Text) ,
            ////	new TKMP.Writer.FilePart(@"c:\temp.txt")
            ////); 

            ////送信メールクラスに本文を登録します
            //mail.MainPart = part;
            //mail.MainPart.Headers.Add("Content-Type", "text/html");

            ////ヘッダ情報を追加します
            //mail.Headers.Add("From", FromAddress); //相手のメーラーで「差出人」として表示されます
            ////mail.Headers.Add("To", "hshb_shin@yahoo.co.jp"); //相手のメーラーで「あて先」として表示されます
            //mail.Headers.Add("Subject", "testmail"); //メールの件名
            //mail.Headers.Add("X-Mailer", "TKMP Version 2.0.0"); //付加情報など

            ////------------------------------------------------------
            ////サーバーへ接続します
            ////------------------------------------------------------
            ////TKMP.Net.SmtpClient smtp = new TKMP.Net.SmtpClient(Server, ServerPort);

            ////SMTPサーバーを利用する場合に認証が必要なときは以下のようにインスタンスを作成します
            //TKMP.Net.ISmtpLogon logon = new TKMP.Net.AuthLogin(UserID , Pass);
            //TKMP.Net.SmtpClient smtp = new TKMP.Net.SmtpClient(Server , ServerPort , logon);

            ////通信ログのイベント
            //smtp.MessageReceive += new TKMP.Net.MessageReceiveHandler(smtp_MessageReceive);
            //smtp.MessageSend += new TKMP.Net.MessageSendHandler(smtp_MessageSend);

            //// --------
            ////  暗号化
            //// --------
            ////smtp.AuthenticationProtocol = TKMP.Net.AuthenticationProtocols.TLS; //TLSでの暗号化通信を行います
            //// TKMP.Net.AuthenticationProtocols.SSL を使用する場合は接続ポートを465に変更してください
            ////SSLを使用し証明書の検証を行うには次のイベントを使用してください
            ////smtp.CertificateValidation += new TKMP.Net.CertificateValidationHandler(smtp_CertificateValidation);

            ////接続
            //if (!smtp.Connect())
            //{
            //    System.Windows.Forms.MessageBox.Show("接続に失敗しました。");
            //    return;
            //}

            //try
            //{
            //    //------------------------------------------------------
            //    //メール送信を開始します
            //    //------------------------------------------------------
            //    smtp.SendMail(mail);
            //}
            //finally
            //{
            //    //------------------------------------------------------
            //    //サーバーから切断します
            //    //------------------------------------------------------
            //    smtp.Close();
            //}





            //System.Windows.Forms.MessageBox.Show("メールを送信しました");
        }


        /// <summary>
        /// メッセージの受信イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smtp_MessageReceive(object sender, TKMP.Net.MessageArgs e)
        {
            System.Diagnostics.Debug.WriteLine("recieve:" + e.Message );
        }

        /// <summary>
        /// メッセージの送信イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smtp_MessageSend(object sender, TKMP.Net.MessageArgs e)
        {
            System.Diagnostics.Debug.WriteLine("send:" + e.Message);
        }
    }
}