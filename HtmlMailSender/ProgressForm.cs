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
    /// 実際にメール送信を行うクラス。
    /// </summary>
    public partial class ProgressForm : Form
    {
        private Account_DS.AccountRow _accountRow = null;
        private Address_DS _addressDs = null;
        private string _mailSubject = null;
        private string _mailBody = null;
        private LogWriter _writer = MyAppContext._writer;

        private bool _isAccountError = false;

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
            //ユーザ以外が閉じる命令を発した場合は閉じる。
            if (e.CloseReason != CloseReason.UserClosing)
            {
                return;
            }

        }

        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
                        //送信アカウント情報を取得
            Account_DS.AccountRow accountRow = e.Argument as Account_DS.AccountRow;

            //POP  Before SMTPの場合
            if (accountRow.UsePopBeforeSmtp == true)
            {
                this.DoPopBeforeSMTP(accountRow);
            }

            //SMTPクライアントの作成
            TKMP.Net.SmtpClient smtp = this.CreateSMTPClient(accountRow);

            //接続に失敗したら、終了。
            if (!smtp.Connect())
            {
                System.Windows.Forms.MessageBox.Show("インターネット接続に失敗しました。インターネットに接続していないか、アカウント情報が間違っています。");
                this._isAccountError = true;
                return;
            }

            try
            {
                //メール送信を開始

                smtp.MessageReceive += new TKMP.Net.MessageReceiveHandler(smtp_MessageReceive);
                smtp.MessageSend += new TKMP.Net.MessageSendHandler(smtp_MessageSend);

                //あて先アドレスをセット
                int totalCount = 0;
                int clusterCount = 0;
                foreach (Address_DS.AddressRow adder in this._addressDs.Address)
                {
                    clusterCount ++;
                    totalCount++;

                    //メールオブジェクトの作成
                    TKMP.Writer.MailWriter mail = new TKMP.Writer.MailWriter();

                    //SMTPサーバーの問い合わせ用のアドレスをセット
                    mail.FromAddress = accountRow.SmtpSenderMail;
                    mail.ToAddressList.Add(adder.MailAddress);

                    //Toにメーラーに表示させるにはこの行を追加
                    //mail.Headers.Add("To", adder.MailAddress);

                    //本文の作成。（HTMLとして認識）
                    this.CreateMailBody(mail);

                    //ヘッダ情報を追加
                    this.CreateMailHeader(mail, accountRow);

                    smtp.SendMail(mail);

                    this._writer.Write(string.Format("{0}にメールを送信しました。", adder.MailAddress));
                    double percentage = ((double)totalCount / (double)this._addressDs.Address.Count) * 100;

                    if (clusterCount == HtmlMailSender.Properties.Settings.Default.ClusterSize)
                    {
                        //クラスタサイズに達した場合はいったんとめる。
                        this._worker.ReportProgress((int)System.Math.Ceiling(percentage), new object[] { totalCount, true });
                        this._writer.Write(string.Format("インターバルで停止中です。"));
                        this._writer.Flush();
                        System.Threading.Thread.Sleep((int)(HtmlMailSender.Properties.Settings.Default.Interval * 1000));
                        clusterCount = 0;
                    }
                    else
                    {
                        //それ以外は情報のみを返す。
                        this._worker.ReportProgress((int)System.Math.Ceiling(percentage), new object[] { totalCount, false });
                    }

                }
            }
            finally
            {
                //サーバーから切断
                smtp.Close();
                this._writer.Dispose();
            }
        }

        private void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState != null)
            {
                //全体とその件数を表示。クラスター間隔により停止している場合はその旨を表示
                object[] o = (object[])e.UserState;
                if ((bool)o[1] == false)
                {
                    this.lblMessage.Text = string.Format("{0}/{1}を送信", o[0],this._addressDs.Address.Count);
                }
                else
                {
                    this.lblMessage.Text = string.Format("{0}/{1}を送信(クラスタ間隔に達したためいったん停止中)", o[0], this._addressDs.Address.Count);
                }
            }
            
            //プログレスバーに進捗状況を表示
            this._progressBar.Value = e.ProgressPercentage;
        }

        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //エラーの場合
            if (e.Error != null)
            {
                MessageBox.Show(this, "メッセージの送信に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this._writer.Write(e.Error.ToString());
                Application.Exit();
                return;
            }

            this._writer.Flush();

            if (this._isAccountError)
            {
                this._isAccountError = false;
                this.Close();
                return;
            }

            MessageBox.Show(this, "メッセージの送信が完了しました。", "完了");
            this.Close();
        }

        /// <summary>
        /// メール本文を作成する。
        /// </summary>
        /// <param name="mail">本文を追加したいメールオブジェクト</param>
        private void CreateMailBody(TKMP.Writer.MailWriter mail)
        {
            TKMP.Writer.IPart part1 = new TKMP.Writer.TextPart("このメールはHTML形式表示可能なメーラーでご覧ください。", TKMP.Writer.Charsets.JIS);
            part1.Headers.Add("Content-Type", @"text/plain; charset=""ISO-2022-JP""");

            TKMP.Writer.IPart part = new TKMP.Writer.TextPart(this._mailBody, TKMP.Writer.Charsets.JIS);
            part.Headers.Add("Content-Type", @"text/html; charset=""ISO-2022-JP""");
            //mail.MainPart = part;
            TKMP.Writer.MultiPart mainpart = new TKMP.Writer.MultiPart(part1, part);
            mainpart.Headers.Add("Content-Type", mainpart.Headers["Content-Type"].Replace("mixed", "alternative"));
            mail.MainPart = mainpart;

        }

        /// <summary>
        /// メールヘッダーを作成する
        /// </summary>
        /// <param name="mail">ヘッダーをつけたいメールオブジェクト</param>
        /// <param name="accountRow">アカウント情報</param>
        private void CreateMailHeader(TKMP.Writer.MailWriter mail, Account_DS.AccountRow accountRow)
        {
            //ヘッダ情報を追加します
            mail.Headers.Add("From", string.Format("{0} <{1}>", accountRow.SmtpSenderName, accountRow.SmtpSenderMail)); //「差出人」
            mail.Headers.Add("Subject", this._mailSubject); //メールの件名

        }

        /// <summary>
        /// Pop Before SMTPを行う。
        /// </summary>
        /// <param name="accountRow">アカウント情報</param>
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
        /// smtpクライアントを作成する。
        /// </summary>
        /// <param name="accountRow">アカウント情報</param>
        /// <returns>smtpクライアント</returns>
        private TKMP.Net.SmtpClient CreateSMTPClient(Account_DS.AccountRow accountRow)
        {
            TKMP.Net.SmtpClient smtp = null;

            if (accountRow.UseSmtpAuth == true)
            {
                //SMTPサーバーで認証を利用する場合
                TKMP.Net.ISmtpLogon logon = new TKMP.Net.AuthLogin(accountRow.PopUserId, CryptographyUtil.DecryptString(accountRow.PopPassword));
                smtp = new TKMP.Net.SmtpClient(accountRow.SmtpServer, accountRow.SmtpPort, logon);
            }
            else
            {
                //通常送信
                smtp = new TKMP.Net.SmtpClient(accountRow.SmtpServer, accountRow.SmtpPort);
            }

            return smtp;
        }

        /// <summary>
        /// メッセージの受信イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smtp_MessageReceive(object sender, TKMP.Net.MessageArgs e)
        {
            this._writer.Write("recieve:" + e.Message);
        }

        /// <summary>
        /// メッセージの送信イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smtp_MessageSend(object sender, TKMP.Net.MessageArgs e)
        {
            this._writer.Write("send:" + e.Message);
        }

    }
}