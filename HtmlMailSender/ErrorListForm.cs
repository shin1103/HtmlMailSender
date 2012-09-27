using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SHashiba.HtmlMailSender.DataSet;

namespace SHashiba.HtmlMailSender
{
    public partial class ErrorListForm : Form
    {
        /// <summary>
        /// エラー状態を設定取得するためのプロパティ
        /// </summary>
        public Address_DS ErrorList
        {
            get
            {
                return this._errords;
            }
            set
            {
                this._errords.Clear();
                this._errords.Merge((Address_DS)value);
            }
            
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ErrorListForm()
        {
            InitializeComponent();
        }

        //public ErrorListForm(Address_DS ads)
        //{
        //    InitializeComponent();

        //    this._errords.Merge(ads);
        //}

        /// <summary>
        /// フォームが読み込まれたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ErrorListForm_Load(object sender, EventArgs e)
        {
            //何も行わない。
        }

        /// <summary>
        /// ボタンが閉じられたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}