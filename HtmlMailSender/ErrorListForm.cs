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
        /// �G���[��Ԃ�ݒ�擾���邽�߂̃v���p�e�B
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
        /// �R���X�g���N�^
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
        /// �t�H�[�����ǂݍ��܂ꂽ�Ƃ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ErrorListForm_Load(object sender, EventArgs e)
        {
            //�����s��Ȃ��B
        }

        /// <summary>
        /// �{�^��������ꂽ�Ƃ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}