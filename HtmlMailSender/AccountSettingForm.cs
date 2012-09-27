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
        /// 編集タイプを設定するENUM
        /// </summary>
        public enum AccountSettingType
        {
            New,
            Edit
        }

        #region フィールド

        private AccountSettingType _type;

        private string _beforeAccountName = string.Empty;
        
        //アカウントが記述されたXMLファイルパス
        
        private string _accoutPath = Path.Combine(Application.StartupPath, @"Data\Account.xml");

        //コンボボックスの変更前の値を保存
        private string _cboBeforeValue = string.Empty;

        //アカウント編集が行われているか？
        private bool _isAccountEdited = false;
        #endregion

        #region コンストラクタ

        public AccountSettingForm()
        {
            InitializeComponent();

            this._type = AccountSettingType.New;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="t"></param>
        public AccountSettingForm(AccountSettingType t)
        {
            InitializeComponent();
            this._type = t;
        }

        #endregion

        /// <summary>
        /// フォームが読み込まれたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccountSettingForm_Load(object sender, EventArgs e)
        {
            //セッティング情報を読み取る。
            if (File.Exists(this._accoutPath) == true)
            {
                this._ads.ReadXml(this._accoutPath, XmlReadMode.Auto);
                this._adsCbo.Merge(this._ads);
            }

            switch (this._type)
            {
                case AccountSettingType.New:        //新規の場合
                    //デフォルトのポート番号をセット
                    this.txtSmtpPort.Text = "25";
                    this.txtPopPort.Text = "110";
                    //画面表示設定
                    this.cboAccount.Visible = false;
                    this.btnDelete.Visible = false;
                    break;

                case AccountSettingType.Edit:       //編集の場合

                    //編集でセッティング情報がない場合はメッセージを表示して画面を閉じる。
                    if ((this._type == AccountSettingType.Edit) && (this._ads.Account.Count == 0))
                    {
                        MessageBox.Show(this, "設定情報がありません。");
                        this.Close();
                        return;
                    }

                    //デフォルトセッティング情報を表示する。
                    this.cboAccount.SelectedIndex = 0;
                    this.ShowAccount();

                    break;
            }

        }

        /// <summary>
        /// 閉じるボタンが押されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            //画面を閉じる
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #region 画面表示

        /// <summary>
        /// ドロップダウンに表示されている設定情報を表示する。
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
        /// PopBeforeSMTPチェックボックスのチェックが変更になった場合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkPopBeforeSmtp_CheckedChanged(object sender, EventArgs e)
        {
            //PopBeforeSMTPかSMTPAUTHのどちらかにチェックが入っていれば、利用可能に
            this.gboPopBeforeSmtp.Enabled = (this.chkPopBeforeSmtp.Checked || this.chkSmtpAuth.Checked);
        }

        /// <summary>
        /// SMTP authチェックボックスのチェックが変更になった場合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSmtpAuth_CheckedChanged(object sender, EventArgs e)
        {
            //PopBeforeSMTPかSMTPAUTHのどちらかにチェックが入っていれば、利用可能に
            this.gboPopBeforeSmtp.Enabled = (this.chkPopBeforeSmtp.Checked || this.chkSmtpAuth.Checked);
        }

        #endregion

        #region 保存時の処理

        /// <summary>
        /// 保存ボタンが押されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //エラー状態を解除
            this.errorProvider1.Clear();
            this.lblErrorMessage.Text = string.Empty;

            //すべて必須入力項目が入力されていない場合は終了
            if (this.IsValidInput() == false)
            {
                this.lblErrorMessage.Text = "未入力・フォーマットを満たさない項目があります。";
                return;
            }

            //新規の場合はすでにアカウント名が登録されていないかを確認
            if ((this._type == AccountSettingType.New) && (this._ads.Account.FindByAccountName(this.txtAccount.Text) != null))
            {
                this.errorProvider1.SetError(this.txtAccount, "アカウント名はすでに使用されています。");
                this.lblErrorMessage.Text = "アカウント名はすでに使用されています。";
                return;
            }

            //画面の入力項目をセット
            this.SetAccount();

            //情報を確定し、書き込む
            this._ads.AcceptChanges();
            if (File.Exists(this._accoutPath) == false)
            {
                //ファイルが存在しない場合は作成。
                using (Stream s = File.Create(this._accoutPath)) { }
            }
            using (StreamWriter writer = new StreamWriter(this._accoutPath, false, System.Text.Encoding.UTF8))
            {
                this._ads.WriteXml(writer);
            }

            //画面を閉じる
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 入力項目が正しいかチェックする。
        /// </summary>
        /// <returns></returns>
        private bool IsValidInput()
        {
            bool result = true;

            if (this.txtAccount.Text == string.Empty)               //アカウント名
            {
                this.errorProvider1.SetError(this.txtAccount, "アカウント名は必須入力項目です。");
                result = false;
            }
            if (this.txtSmtpServer.Text == string.Empty)            //SMTPサーバ名
            {
                this.errorProvider1.SetError(this.txtSmtpServer, "SMTPサーバ名は必須入力項目です。");
                result = false;
            }
            if (this.txtSenderMail.Text == string.Empty)            //送信者メールアドレス
            {
                this.errorProvider1.SetError(this.txtSenderMail, "送信者メールアドレスは必須入力項目です。");
                result = false;
            }
            if (this.txtSenderName.Text == string.Empty)            //送信者名
            {
                this.errorProvider1.SetError(this.txtSenderName, "送信者名は必須入力項目です。");
                result = false;
            }
            if (this.txtSmtpPort.Text == string.Empty)              //SMTPポート番号
            {
                this.errorProvider1.SetError(this.txtSmtpPort, "SMTPポート番号は必須入力項目です。");
                result = false;
            }
            else if (Microsoft.VisualBasic.Information.IsNumeric(this.txtSmtpPort.Text) == false)
            {
                this.errorProvider1.SetError(this.txtSmtpPort, "SMTPポート番号数値のみ入力可能です。");
                result = false;
            }

            //PopBeforeSmtpを使う場合は以下の項目もチェック
            if (this.chkPopBeforeSmtp.Checked == true)
            {
                if (this.txtPopServer.Text == string.Empty)         //POPサーバ名
                {
                    this.errorProvider1.SetError(this.txtPopServer, "POPサーバ名は必須入力項目です。");
                    result = false;
                }
                if (this.txtPopUser.Text == string.Empty)           //POPユーザ
                {
                    this.errorProvider1.SetError(this.txtPopUser, "POPユーザは必須入力項目です。");
                    result = false;
                }
                if (this.txtPopPassword.Text == string.Empty)       //POPパスワード
                {
                    this.errorProvider1.SetError(this.txtPopPassword, "POPパスワードは必須入力項目です。");
                    result = false;
                }
                if (this.txtPopPort.Text == string.Empty)           //POPポート
                {
                    this.errorProvider1.SetError(this.txtPopPort, "POPポートは必須入力項目です。");
                    result = false;
                }
                else if (Microsoft.VisualBasic.Information.IsNumeric(this.txtSmtpPort.Text) == false)
                {
                    this.errorProvider1.SetError(this.txtSmtpPort, "POPポート番号数値のみ入力可能です。");
                    result = false;
                }
            }

            return result;
        }

        /// <summary>
        /// 画面のアカウント設定を取得する。
        /// </summary>
        private void SetAccount()
        {
            Account_DS.AccountRow row = null;
            switch (this._type)
            {
                case AccountSettingType.New:
                    //新規の場合は新規行を作成
                    row = this._ads.Account.NewAccountRow();
                    break;
                case AccountSettingType.Edit:
                    //編集の場合は編集行を設定
                    row = this._ads.Account.FindByAccountName(this._beforeAccountName);
                    break;
            }

            //画面の情報を取り込む
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

        #region 削除時の処理

        /// <summary>
        /// 削除ボタンが押されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //削除確認メッセージを表示し、Yesでければ終了。
            if (MessageBox.Show(this, string.Format("アカウント「{0}」を削除してもよろしいですか？", this.txtAccount.Text),
                                    "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            //削除設定をし確定する。
            this._ads.Account.FindByAccountName(this._beforeAccountName).Delete();
            this._ads.AcceptChanges();


            //設定情報を書き込む
            using (StreamWriter writer = new StreamWriter(this._accoutPath, false, System.Text.Encoding.UTF8))
            {
                this._ads.WriteXml(writer);
            }

            //画面を閉じる
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion

        #region ドロップダウンのイベント
        /// <summary>
        /// ドロップダウンのインデックスが変更されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            //アカウントに対して編集があったら、
            if (this._isAccountEdited == true)
            {
                //確認を行う。
                if (MessageBox.Show(this, "アカウントの変更は保存されませんがよろしいですか？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes )
                {
                    this.cboAccount.SelectedIndexChanged -= new System.EventHandler(this.cboAccount_SelectedIndexChanged);
                    this.cboAccount.SelectedValue = this._cboBeforeValue;
                    this.cboAccount.SelectedIndexChanged += new System.EventHandler(this.cboAccount_SelectedIndexChanged);
                    return;
                }
            }

            //新しいアカウント情報を表示する。
            this.ShowAccount();

            //編集アカウントが変更されたので、編集なしに戻す。
            this._isAccountEdited = false;

        }

        /// <summary>
        /// ドロップダウンが表示されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboAccount_DropDown(object sender, EventArgs e)
        {
            //ドロップダウン変更前の値を保存しておく
            this._cboBeforeValue = this.cboAccount.SelectedValue.ToString();
        }
        #endregion

        #region テキストボックス変更

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