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
        #region �t�B�[���h

        private int _selectColumnIndex = 0;
        private ArrayList _columnList = null;

        #endregion

        #region �v���p�e�B

        /// <summary>
        /// �I���������Ԃ��v���p�e�B
        /// </summary>
        public int SelectColumnIndex
        {
            get
            {
                return this._selectColumnIndex;
            }
        }

        /// <summary>
        /// �P�s�ڂ�ǂݍ��ނ��̃v���p�e�B
        /// </summary>
        public bool ReadFirstRow
        {
            get
            {
                return this.chkHeaderRead.Checked;
            }
        }

        #endregion

        #region �R���X�g���N�^

        public ColumnSelectForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public ColumnSelectForm(ArrayList list)
        {
            InitializeComponent();

            this._columnList = list;
        }

        #endregion

        /// <summary>
        /// �t�H�[�����ǂݍ��܂ꂽ�Ƃ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColumnSelectForm_Load(object sender, EventArgs e)
        {
            //�R���X�g���N�^�Ŏ󂯎������ꗗ��\������B
            this.listColumn.Items.AddRange(this._columnList.ToArray());
            this.listColumn.SelectedIndex = 0;
        }

        /// <summary>
        /// �t�H�[����������ꍇ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColumnSelectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //�����s��Ȃ�
        }

        /// <summary>
        /// �I���{�^���������ꂽ�Ƃ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            //���X�g�{�b�N�X�őI�����ꂽ�l���t�B�[���h�ɃZ�b�g���ĕ���B
            this._selectColumnIndex = this.listColumn.SelectedIndex;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// ���X�g�{�b�N�X�Ń_�u���N���b�N���ꂽ�Ƃ��̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listColumn_DoubleClick(object sender, EventArgs e)
        {
            //���X�g�{�b�N�X�őI�����ꂽ�l���t�B�[���h�ɃZ�b�g���ĕ���B
            this._selectColumnIndex = this.listColumn.SelectedIndex;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}