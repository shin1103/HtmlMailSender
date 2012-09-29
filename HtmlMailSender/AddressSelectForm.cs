using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SHashiba.HtmlMailSender.DataSet;
using Bravo2.Excel;
using System.Collections;
using Microsoft.VisualBasic.FileIO;
//using Outlook = Microsoft.Office.Interop.Outlook;

namespace SHashiba.HtmlMailSender
{
    public partial class AddressSelectForm : Form
    {
        ErrorListForm _errorForm = null;

        /// <summary>
        /// アドレスグリッドの行番号を指定する。
        /// </summary>
        private enum AddressGridColumnIndex
        {
            MainAddress = 0,
            DeleteBtn,
        }

        #region コンストラクタ
        
        //public AddressSelectForm()
        //{
        //    InitializeComponent();
        //}

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="ads"></param>
        public AddressSelectForm(Address_DS ads)
        {
            InitializeComponent();

            this._addressds = ads;
            this.gridAddress.DataMember = "Address";
            this.gridAddress.DataSource = this._addressds;

        }

        #endregion 

        /// <summary>
        /// フォームが読み込まれたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddressSelectForm_Load(object sender, EventArgs e)
        {
            //何も行わない
        }

        /// <summary>
        /// 閉じるボタンが押されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            //画面を閉じる
            this.Close();
        }

        /// <summary>
        /// 取込ボタンが押されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            //エラーリスト画面を開放し、新しい画面を作成する。
            if ((this._errorForm != null) && (this._errorForm.IsDisposed == false))
            {
                this._errorForm.Dispose();
            }
            this._errorForm = new ErrorListForm();

            if (this.rdoExcel.Checked == true)
            {
                //Excelのファイルを読み込む
                this.ReadExcel();
            }
            else if (this.rdoCSV.Checked == true)
            {
                //CSVのファイルを読み込む
                this.ReadCSV();
            }
            //else if (this.rdoOutLook.Checked == true)
            //{
            //    //OutLookのアドレス帳データを読み取る
            //    this._addressds.Merge(ReadOutLook());
            //}

            //エラー件数が０件でなければ表示する。
            if (this._errorForm.ErrorList.Address.Count != 0)
            {
                this._errorForm.Show();
            }
        }

        #region Excel読み込み

        /// <summary>
        /// 指定されたExcelファイルを読み込む
        /// </summary>
        private void ReadExcel()
        {
            //Excelファイル選択し、選択されなければ終了。
            if (this.openFileExcel.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Address_DS ads = new Address_DS();
            Address_DS errords = new Address_DS();

            // ExcelWorkBookオープン
            ExcelWorkBook wBook = new ExcelWorkBook();
            wBook.Open(this.openFileExcel.FileName);
            try
            {
                //１行目を読み込む
                ExcelWorkSheet sheet = wBook.WorkSheets[0];
                ArrayList columnList = new ArrayList();
                for (int col = sheet.FirstColumn; col <= sheet.LastColumn; col++)
                {
                    if (sheet.Cells[0, col].Value == null)
                    {
                        continue;
                    }
                    columnList.Add(sheet.Cells[0, col].Value);
                }

                //読み込み行がない場合は空のデータセットを返す。
                if (columnList.Count == 0)
                {
                    MessageBox.Show(this, "読み込み可能な行がありません。");
                    return;
                }

                using (ColumnSelectForm f = new ColumnSelectForm(columnList))
                {
                    //行選択画面を表示し、ユーザに読み込む行を指定してもらう
                    if (f.ShowDialog() != DialogResult.OK)
                    {
                        //選択されなければ、空のデータセットを返す。
                        return ;
                    }

                    int readStartRowIndex = 0;
                    if (f.ReadFirstRow == true) readStartRowIndex = 0;
                    else readStartRowIndex = 1;


                    //ユーザが指定した列を読み込む
                    for (int row = readStartRowIndex; row <= sheet.LastRow; row++)
                    {
                        //NULLやすでに取り込まれたメールアドレスははずす。
                        if (!((sheet.Cells[row, f.SelectColumnIndex].Value == null) || 
                            ads.Address.FindByMailAddress(sheet.Cells[row, f.SelectColumnIndex].Value.ToString()) != null))
                        {
                            string mailAddr = sheet.Cells[row, f.SelectColumnIndex].Value.ToString();
                            //メールアドレス形式のアドレスのみ登録
                            if (TKMP.Writer.MailAddressCollection.IsAddressPattern(mailAddr) == true)
                            {
                                Address_DS.AddressRow aRow = ads.Address.NewAddressRow();
                                aRow.MailAddress = mailAddr;
                                ads.Address.AddAddressRow(aRow);
                            }
                            else
                            {
                                //メールアドレス形式でないものは、エラーリストに保存
                                Address_DS.AddressRow aeRow = errords.Address.NewAddressRow();
                                aeRow.MailAddress = mailAddr;
                                errords.Address.AddAddressRow(aeRow);
                            }
                        }
                    }
                }
            }
            finally
            {
                // ExcelWorkBookクローズ
                wBook.Close();
            }

            //Excelファイルを読み取る。
            this._addressds.Merge(ads);

            //エラー情報をセットする。
            this._errorForm.ErrorList = errords;

        }

        #endregion

        #region CSV読み込み

        private void ReadCSV()
        {
            //CSVファイル選択し、選択されなければ終了。
            if (this.openFileCSV.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Address_DS ads = new Address_DS();
            Address_DS errords = new Address_DS();

            //CSVファイルの読み込み
            using (TextFieldParser parser = new TextFieldParser(this.openFileCSV.FileName, System.Text.Encoding.GetEncoding("Shift-Jis")))
            {
                //CSVの区切り文字をセット
                parser.SetDelimiters(",");

                //１行目が存在するかチェック
                if (parser.EndOfData == true)
                {
                    //存在しない場合はメッセージボックスを表示して終了
                    MessageBox.Show(this, "読み込み可能な行がありません。");
                    return ;
                }

                //１行目の読み込み
                ArrayList columnList = null;
                string[] firstRows = null;
                try
                {
                    firstRows = parser.ReadFields();
                    columnList = new ArrayList(firstRows);
                }
                catch (MalformedLineException)
                {
                    //読み込み不可能な行であれば、終了する。
                    //存在しない場合はメッセージボックスを表示して終了
                    MessageBox.Show(this, 
                        "１行目のフォーマットがおかしいため、処理を続行できません。" + Environment.NewLine + 
                        "Excelでファイルを正しく開けるか確認してください。");
                    return;
                }

                using (ColumnSelectForm f = new ColumnSelectForm(columnList))
                {
                    //行選択画面を表示し、ユーザに読み込む行を指定してもらう
                    if (f.ShowDialog() != DialogResult.OK)
                    {
                        //選択されなければ、空のデータセットを返す。
                        return;
                    }

                    //１行目を読み込むならば、その行をデータセットに格納。
                    if (f.ReadFirstRow == true)
                    {
                        Address_DS.AddressRow aRow = ads.Address.NewAddressRow();
                        aRow.MailAddress = firstRows[f.SelectColumnIndex];
                        ads.Address.AddAddressRow(aRow);
                    }

                    //ユーザが指定した列を読み込む
                    while (parser.EndOfData == false)
                    {
                        try
                        {
                            //NULLや空文字列・すでに取り込まれた行を取り込まない。
                            string mailAddr = parser.ReadFields()[f.SelectColumnIndex];
                            if ((string.IsNullOrEmpty(mailAddr) == false) && (ads.Address.FindByMailAddress(mailAddr) == null))
                            {
                                if (TKMP.Writer.MailAddressCollection.IsAddressPattern(mailAddr) == true)
                                {
                                    Address_DS.AddressRow aRow = ads.Address.NewAddressRow();
                                    aRow.MailAddress = mailAddr;
                                    ads.Address.AddAddressRow(aRow);
                                }
                                else
                                {
                                    //メールアドレス形式でないものは、エラーリストに保存
                                    Address_DS.AddressRow aeRow = errords.Address.NewAddressRow();
                                    aeRow.MailAddress = mailAddr;
                                    errords.Address.AddAddressRow(aeRow);
                                }
                            }
                        }
                        catch
                        {
                            //行の解析に失敗したらその行をエラーリストに保存
                            Address_DS.AddressRow aeRow = errords.Address.NewAddressRow();
                            aeRow.MailAddress = string.Format("（{0}行目は読み込みエラーです）", parser.ErrorLineNumber.ToString());
                            errords.Address.AddAddressRow(aeRow);
                        }
                    }
                }
            }

            //CSVファイルを読み取る。
            this._addressds.Merge(ads);

            //エラー情報をセットする。
            this._errorForm.ErrorList = errords;

        }

        #endregion

        #region OUTLOOK読み込み

        /// <summary>
        /// OutLookのアドレス帳を読み込む
        /// </summary>
        /// <remarks>COMが見つからずWindows7では使えないためコメントアウト</remarks>
        /// <returns></returns>
        private Address_DS ReadOutLook()
        {
            Address_DS ads = new Address_DS();
            return ads;

            
            //Outlook.Application outlook = null;
            //Outlook.NameSpace nameSpace = null;
            //Outlook.AddressLists addressList = null;
            //try
            //{
            //    outlook = new Outlook.Application();
            //    nameSpace = outlook.Session;
            //    addressList = nameSpace.AddressLists;

            //    //アドレスリストはおそらくアドレスのディレクトリ単位である。
            //    //そのディレクトリを１つずつ見ていく。
            //    foreach (Outlook.AddressList list in addressList)
            //    {
            //        //Entry１つ１つが実際のアドレスに相当する。
            //        //これらの内容を取得し、データセットに格納する。
            //        foreach (Outlook.AddressEntry oEntry in list.AddressEntries)
            //        {
            //            //NULLや空文字列・すでに取り込まれた行を取り込まない。
            //            if ((string.IsNullOrEmpty(oEntry.Address) == false) && (ads.Address.FindByMailAddress(oEntry.Address) == null))
            //            {
            //                Address_DS.AddressRow aRow = ads.Address.NewAddressRow();
            //                aRow.MailAddress = oEntry.Address;
            //                ads.Address.AddAddressRow(aRow);
            //            }
            //        }
            //    }
            //}
            //finally
            //{
            //    if (addressList != null)
            //    {
            //        System.Runtime.InteropServices.Marshal.ReleaseComObject(addressList);
            //    }
            //    if (nameSpace != null)
            //    {
            //        System.Runtime.InteropServices.Marshal.ReleaseComObject(nameSpace);
            //    }
            //    if (outlook != null)
            //    {
            //        System.Runtime.InteropServices.Marshal.ReleaseComObject(outlook);
            //    }
            //}
        }

        #endregion

        #region グリッドのイベント

        /// <summary>
        /// セルがクリックされた場合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridAddress_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //行ヘッダや列ヘッダの場合は何も行わない。
            if ((e.ColumnIndex == -1) || (e.RowIndex == -1))
            {
                return;
            }

            //削除ボタンであれば、ボタンを押した行を削除する。
            if (e.ColumnIndex == (int)AddressGridColumnIndex.DeleteBtn)
            {
                this._addressds.Address.FindByMailAddress(
                    this.gridAddress[(int)AddressGridColumnIndex.MainAddress, e.RowIndex].Value.ToString()).Delete();
                this._addressds.AcceptChanges();
            }
        }

        #endregion

        #region アイテムメニューのイベント

        /// <summary>
        /// メールアドレスクリアアイテムメニューがクリックされたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuClear_Click(object sender, EventArgs e)
        {
            //確認ダイアログを表示し、ＯＫでなければ、終了。
            if (MessageBox.Show(this, "メールアドレスをすべて削除しますか？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
            {
                return;
            }

            this._addressds.Clear();
            this._addressds.AcceptChanges();
        }

        #endregion

        private void AddressSelectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //エラーリスト画面を開放し、新しい画面を作成する。
            if ((this._errorForm != null) && (this._errorForm.IsDisposed == false))
            {
                this._errorForm.Dispose();
            }
        }

        private void btnDirectInput_Click(object sender, EventArgs e)
        {
            //アドレス直接入力画面に遷移する。
            using (AddressDirectInputForm f = new AddressDirectInputForm(this._addressds))
            {
                f.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //OutLookのアドレス帳データを読み取る
            this._addressds.Merge(ReadOutLook());
        }

   }

}