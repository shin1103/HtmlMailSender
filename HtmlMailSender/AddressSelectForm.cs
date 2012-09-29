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
        /// �A�h���X�O���b�h�̍s�ԍ����w�肷��B
        /// </summary>
        private enum AddressGridColumnIndex
        {
            MainAddress = 0,
            DeleteBtn,
        }

        #region �R���X�g���N�^
        
        //public AddressSelectForm()
        //{
        //    InitializeComponent();
        //}

        /// <summary>
        /// �R���X�g���N�^
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
        /// �t�H�[�����ǂݍ��܂ꂽ�Ƃ��̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddressSelectForm_Load(object sender, EventArgs e)
        {
            //�����s��Ȃ�
        }

        /// <summary>
        /// ����{�^���������ꂽ�Ƃ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            //��ʂ����
            this.Close();
        }

        /// <summary>
        /// �捞�{�^���������ꂽ�Ƃ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            //�G���[���X�g��ʂ��J�����A�V������ʂ��쐬����B
            if ((this._errorForm != null) && (this._errorForm.IsDisposed == false))
            {
                this._errorForm.Dispose();
            }
            this._errorForm = new ErrorListForm();

            if (this.rdoExcel.Checked == true)
            {
                //Excel�̃t�@�C����ǂݍ���
                this.ReadExcel();
            }
            else if (this.rdoCSV.Checked == true)
            {
                //CSV�̃t�@�C����ǂݍ���
                this.ReadCSV();
            }
            //else if (this.rdoOutLook.Checked == true)
            //{
            //    //OutLook�̃A�h���X���f�[�^��ǂݎ��
            //    this._addressds.Merge(ReadOutLook());
            //}

            //�G���[�������O���łȂ���Ε\������B
            if (this._errorForm.ErrorList.Address.Count != 0)
            {
                this._errorForm.Show();
            }
        }

        #region Excel�ǂݍ���

        /// <summary>
        /// �w�肳�ꂽExcel�t�@�C����ǂݍ���
        /// </summary>
        private void ReadExcel()
        {
            //Excel�t�@�C���I�����A�I������Ȃ���ΏI���B
            if (this.openFileExcel.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Address_DS ads = new Address_DS();
            Address_DS errords = new Address_DS();

            // ExcelWorkBook�I�[�v��
            ExcelWorkBook wBook = new ExcelWorkBook();
            wBook.Open(this.openFileExcel.FileName);
            try
            {
                //�P�s�ڂ�ǂݍ���
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

                //�ǂݍ��ݍs���Ȃ��ꍇ�͋�̃f�[�^�Z�b�g��Ԃ��B
                if (columnList.Count == 0)
                {
                    MessageBox.Show(this, "�ǂݍ��݉\�ȍs������܂���B");
                    return;
                }

                using (ColumnSelectForm f = new ColumnSelectForm(columnList))
                {
                    //�s�I����ʂ�\�����A���[�U�ɓǂݍ��ލs���w�肵�Ă��炤
                    if (f.ShowDialog() != DialogResult.OK)
                    {
                        //�I������Ȃ���΁A��̃f�[�^�Z�b�g��Ԃ��B
                        return ;
                    }

                    int readStartRowIndex = 0;
                    if (f.ReadFirstRow == true) readStartRowIndex = 0;
                    else readStartRowIndex = 1;


                    //���[�U���w�肵�����ǂݍ���
                    for (int row = readStartRowIndex; row <= sheet.LastRow; row++)
                    {
                        //NULL�₷�łɎ�荞�܂ꂽ���[���A�h���X�͂͂����B
                        if (!((sheet.Cells[row, f.SelectColumnIndex].Value == null) || 
                            ads.Address.FindByMailAddress(sheet.Cells[row, f.SelectColumnIndex].Value.ToString()) != null))
                        {
                            string mailAddr = sheet.Cells[row, f.SelectColumnIndex].Value.ToString();
                            //���[���A�h���X�`���̃A�h���X�̂ݓo�^
                            if (TKMP.Writer.MailAddressCollection.IsAddressPattern(mailAddr) == true)
                            {
                                Address_DS.AddressRow aRow = ads.Address.NewAddressRow();
                                aRow.MailAddress = mailAddr;
                                ads.Address.AddAddressRow(aRow);
                            }
                            else
                            {
                                //���[���A�h���X�`���łȂ����̂́A�G���[���X�g�ɕۑ�
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
                // ExcelWorkBook�N���[�Y
                wBook.Close();
            }

            //Excel�t�@�C����ǂݎ��B
            this._addressds.Merge(ads);

            //�G���[�����Z�b�g����B
            this._errorForm.ErrorList = errords;

        }

        #endregion

        #region CSV�ǂݍ���

        private void ReadCSV()
        {
            //CSV�t�@�C���I�����A�I������Ȃ���ΏI���B
            if (this.openFileCSV.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Address_DS ads = new Address_DS();
            Address_DS errords = new Address_DS();

            //CSV�t�@�C���̓ǂݍ���
            using (TextFieldParser parser = new TextFieldParser(this.openFileCSV.FileName, System.Text.Encoding.GetEncoding("Shift-Jis")))
            {
                //CSV�̋�؂蕶�����Z�b�g
                parser.SetDelimiters(",");

                //�P�s�ڂ����݂��邩�`�F�b�N
                if (parser.EndOfData == true)
                {
                    //���݂��Ȃ��ꍇ�̓��b�Z�[�W�{�b�N�X��\�����ďI��
                    MessageBox.Show(this, "�ǂݍ��݉\�ȍs������܂���B");
                    return ;
                }

                //�P�s�ڂ̓ǂݍ���
                ArrayList columnList = null;
                string[] firstRows = null;
                try
                {
                    firstRows = parser.ReadFields();
                    columnList = new ArrayList(firstRows);
                }
                catch (MalformedLineException)
                {
                    //�ǂݍ��ݕs�\�ȍs�ł���΁A�I������B
                    //���݂��Ȃ��ꍇ�̓��b�Z�[�W�{�b�N�X��\�����ďI��
                    MessageBox.Show(this, 
                        "�P�s�ڂ̃t�H�[�}�b�g�������������߁A�����𑱍s�ł��܂���B" + Environment.NewLine + 
                        "Excel�Ńt�@�C���𐳂����J���邩�m�F���Ă��������B");
                    return;
                }

                using (ColumnSelectForm f = new ColumnSelectForm(columnList))
                {
                    //�s�I����ʂ�\�����A���[�U�ɓǂݍ��ލs���w�肵�Ă��炤
                    if (f.ShowDialog() != DialogResult.OK)
                    {
                        //�I������Ȃ���΁A��̃f�[�^�Z�b�g��Ԃ��B
                        return;
                    }

                    //�P�s�ڂ�ǂݍ��ނȂ�΁A���̍s���f�[�^�Z�b�g�Ɋi�[�B
                    if (f.ReadFirstRow == true)
                    {
                        Address_DS.AddressRow aRow = ads.Address.NewAddressRow();
                        aRow.MailAddress = firstRows[f.SelectColumnIndex];
                        ads.Address.AddAddressRow(aRow);
                    }

                    //���[�U���w�肵�����ǂݍ���
                    while (parser.EndOfData == false)
                    {
                        try
                        {
                            //NULL��󕶎���E���łɎ�荞�܂ꂽ�s����荞�܂Ȃ��B
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
                                    //���[���A�h���X�`���łȂ����̂́A�G���[���X�g�ɕۑ�
                                    Address_DS.AddressRow aeRow = errords.Address.NewAddressRow();
                                    aeRow.MailAddress = mailAddr;
                                    errords.Address.AddAddressRow(aeRow);
                                }
                            }
                        }
                        catch
                        {
                            //�s�̉�͂Ɏ��s�����炻�̍s���G���[���X�g�ɕۑ�
                            Address_DS.AddressRow aeRow = errords.Address.NewAddressRow();
                            aeRow.MailAddress = string.Format("�i{0}�s�ڂ͓ǂݍ��݃G���[�ł��j", parser.ErrorLineNumber.ToString());
                            errords.Address.AddAddressRow(aeRow);
                        }
                    }
                }
            }

            //CSV�t�@�C����ǂݎ��B
            this._addressds.Merge(ads);

            //�G���[�����Z�b�g����B
            this._errorForm.ErrorList = errords;

        }

        #endregion

        #region OUTLOOK�ǂݍ���

        /// <summary>
        /// OutLook�̃A�h���X����ǂݍ���
        /// </summary>
        /// <remarks>COM�������炸Windows7�ł͎g���Ȃ����߃R�����g�A�E�g</remarks>
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

            //    //�A�h���X���X�g�͂����炭�A�h���X�̃f�B���N�g���P�ʂł���B
            //    //���̃f�B���N�g�����P�����Ă����B
            //    foreach (Outlook.AddressList list in addressList)
            //    {
            //        //Entry�P�P�����ۂ̃A�h���X�ɑ�������B
            //        //�����̓��e���擾���A�f�[�^�Z�b�g�Ɋi�[����B
            //        foreach (Outlook.AddressEntry oEntry in list.AddressEntries)
            //        {
            //            //NULL��󕶎���E���łɎ�荞�܂ꂽ�s����荞�܂Ȃ��B
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

        #region �O���b�h�̃C�x���g

        /// <summary>
        /// �Z�����N���b�N���ꂽ�ꍇ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridAddress_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //�s�w�b�_���w�b�_�̏ꍇ�͉����s��Ȃ��B
            if ((e.ColumnIndex == -1) || (e.RowIndex == -1))
            {
                return;
            }

            //�폜�{�^���ł���΁A�{�^�����������s���폜����B
            if (e.ColumnIndex == (int)AddressGridColumnIndex.DeleteBtn)
            {
                this._addressds.Address.FindByMailAddress(
                    this.gridAddress[(int)AddressGridColumnIndex.MainAddress, e.RowIndex].Value.ToString()).Delete();
                this._addressds.AcceptChanges();
            }
        }

        #endregion

        #region �A�C�e�����j���[�̃C�x���g

        /// <summary>
        /// ���[���A�h���X�N���A�A�C�e�����j���[���N���b�N���ꂽ�Ƃ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuClear_Click(object sender, EventArgs e)
        {
            //�m�F�_�C�A���O��\�����A�n�j�łȂ���΁A�I���B
            if (MessageBox.Show(this, "���[���A�h���X�����ׂč폜���܂����H", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
            {
                return;
            }

            this._addressds.Clear();
            this._addressds.AcceptChanges();
        }

        #endregion

        private void AddressSelectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //�G���[���X�g��ʂ��J�����A�V������ʂ��쐬����B
            if ((this._errorForm != null) && (this._errorForm.IsDisposed == false))
            {
                this._errorForm.Dispose();
            }
        }

        private void btnDirectInput_Click(object sender, EventArgs e)
        {
            //�A�h���X���ړ��͉�ʂɑJ�ڂ���B
            using (AddressDirectInputForm f = new AddressDirectInputForm(this._addressds))
            {
                f.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //OutLook�̃A�h���X���f�[�^��ǂݎ��
            this._addressds.Merge(ReadOutLook());
        }

   }

}