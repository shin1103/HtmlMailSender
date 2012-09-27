using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;


namespace SHashiba.HtmlMailSender
{
    public partial class ColumnSelectForm : Form
    {
        #region フィールド

        private int _selectColumnIndex = 0;
        private ArrayList _columnList = null;

        #endregion

        #region プロパティ

        /// <summary>
        /// 選択した列を返すプロパティ
        /// </summary>
        public int SelectColumnIndex
        {
            get
            {
                return this._selectColumnIndex;
            }
        }

        /// <summary>
        /// １行目を読み込むかのプロパティ
        /// </summary>
        public bool ReadFirstRow
        {
            get
            {
                return this.chkHeaderRead.Checked;
            }
        }

        #endregion

        #region コンストラクタ

        public ColumnSelectForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ColumnSelectForm(ArrayList list)
        {
            InitializeComponent();

            this._columnList = list;
        }

        #endregion

        /// <summary>
        /// フォームが読み込まれたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColumnSelectForm_Load(object sender, EventArgs e)
        {
            //コンストラクタで受け取った列一覧を表示する。
            this.listColumn.Items.AddRange(this._columnList.ToArray());
            this.listColumn.SelectedIndex = 0;
        }

        /// <summary>
        /// フォームが閉じられる場合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColumnSelectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //何も行わない
        }

        /// <summary>
        /// 選択ボタンが押されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            //リストボックスで選択された値をフィールドにセットして閉じる。
            this._selectColumnIndex = this.listColumn.SelectedIndex;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// リストボックスでダブルクリックされたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listColumn_DoubleClick(object sender, EventArgs e)
        {
            //リストボックスで選択された値をフィールドにセットして閉じる。
            this._selectColumnIndex = this.listColumn.SelectedIndex;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}