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
    /// タブのインデックス
    /// </summary>
    public enum TabInd : int
    {
        Source,
        HTML
    }

    public partial class MainForm : Form
    {
        #region フィールド

        //アカウントが記述されたXMLファイルパス
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
        /// フォームが読み込まれたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //セッティング情報を読み取る。
            if (File.Exists(this._accoutPath) == true)
            {
                this._accountds.ReadXml(this._accoutPath, XmlReadMode.Auto);
            }

        }

        /// <summary>
        /// 終了アイテムがクリックされた場合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuEnd_Click(object sender, EventArgs e)
        {
            //アプリケーションを終了する。
            Application.Exit();
        }

        #region 画面表示

        /// <summary>
        /// タブの選択が変更された場合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex)
            {
                case (int)TabInd.HTML:
                    //HTMLタブが選択されたら、再読み込みを行う。
                    this.ShowHTML();
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// HTMLをWebブラウザで表示する。
        /// </summary>
        private void ShowHTML()
        {
            this.webBrowser1.DocumentText = this.txtSource.Text;
            this.webBrowser1.Show();
        }


        /// <summary>
        /// HTMLソース読み込みメニューが選択された場合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuReadHtml_Click(object sender, EventArgs e)
        {
            //HTMLファイルを読み込む
            this.ReadHtml();
        }

        /// <summary>
        /// 本文選択ボタンが押されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBody_Click(object sender, EventArgs e)
        {
            //HTMLファイルを読み込む
            this.ReadHtml();
        }

        /// <summary>
        /// HTMLファイルを読み込む
        /// </summary>
        private void ReadHtml()
        {
            DialogResult result = this.openFileHtml.ShowDialog();
            if (result != DialogResult.OK)
            {
                //ファイルが選択されなければ、終了。
                return;
            }

            //ファイルの読み込みを行う
            //using (StreamReader reader = new StreamReader(this.openFileHtml.FileName, System.Text.Encoding.GetEncoding("SHIFT-JIS")))
            using (StreamReader reader = new StreamReader(this.openFileHtml.FileName, System.Text.Encoding.GetEncoding("ISO-2022-JP")))
            {
                this.txtSource.Text = reader.ReadToEnd();
            }

            //テキストボックス・プレビュー画面に変更を反映
            this.ShowHTML();
        }

        #endregion

        #region メール送信

        /// <summary>
        /// あて先設定ボタンが押されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddress_Click(object sender, EventArgs e)
        {
            //宛先選択画面を表示する。
            using (AddressSelectForm f = new AddressSelectForm(this._addressds))
            {
                f.ShowDialog();
            }

            if (this._addressds.Address.Count != 0) this.btnAddress.BackColor = SystemColors.ControlDark ;
            else this.btnAddress.BackColor = SystemColors.Control;
        }

        /// <summary>
        /// メール送信ボタンが押下されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuMailSend_Click(object sender, EventArgs e)
        {
            //メールを送信する。
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
        /// メール送信ボタンが押された場合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            //メールを送信する。
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
        /// メールを送信する。
        /// </summary>
        private void SendMail()
        {
            if (this.IsValid() == false)
            {
                return;
            }
 
            //送信確認を行い、OKでなければ中止する。
            if (MessageBox.Show(this, "メールを送信しますか？", "送信確認",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.OK)
            {
                return;
            }

            //送信処理を実行
            Account_DS.AccountRow accountRow = this._accountds.Account.FindByAccountName(this.cboAccount.SelectedValue.ToString());
            using (ProgressForm f = new ProgressForm(accountRow, this._addressds ,this.txtSubject.Text, this.txtSource.Text))
            {
                f.ShowDialog();
            }

        }

        /// <summary>
        /// 送信に可能な情報がそろっているかをチェックする
        /// </summary>
        /// <returns>正しければ、Trueを返す。</returns>
        /// <remarks>このメソッドでエラー表示も行う。</remarks>
        private bool IsValid()
        {
            //アカウントが設定されていなければ、メッセージを表示して終了。
            if (this.cboAccount.SelectedIndex == -1)
            {
                MessageBox.Show(this, "アカウントが設定されていません。");
                return false ;
            }
            //メールの内容が何もかかれていなければ、終了。
            if (this.txtSource.Text == string.Empty)
            {
                MessageBox.Show(this, "メールの内容が記述されていません。");
                return false ;
            }

            //BCCに値が設定されていなければ、メッセージを表示して終了
            if (this._addressds.Address.Count == 0)
            {
                MessageBox.Show(this, "あて先が設定されていません。");
                return false ;
            }

            return true;
        }

#endregion

        #region アカウント設定

        /// <summary>
        /// アカウント新規メニューが押されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAccountNew_Click(object sender, EventArgs e)
        {
            //アカウント設定画面を表示
            using (AccountSettingForm f = new AccountSettingForm(AccountSettingForm.AccountSettingType.New))
            {
                DialogResult result = f.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //変更があれば、更新する。(もともと選択していたものを再選択する)
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
        /// アカウント編集メニューが押されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAccountEdit_Click(object sender, EventArgs e)
        {
            //アカウント設定画面を表示
            using (AccountSettingForm f = new AccountSettingForm(AccountSettingForm.AccountSettingType.Edit))
            {
                DialogResult result = f.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //変更があれば、更新する。
                    //変更があれば、更新する。(もともと選択していたものを再選択する)
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
        /// キーが押されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSource_KeyUp(object sender, KeyEventArgs e)
        {
            //Ctrl+Aであれば、テキストをすべて選択する。
            if ((e.Control == true) && (e.KeyCode  == Keys.A))
            {
                this.txtSource.SelectAll();
            }
        }

    }
}