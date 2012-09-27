using System;
using System.Collections.Generic;
using System.Text;

using System.IO;


namespace SHashiba.HtmlMailSender
{
    public class LogWriter: IDisposable
    {
        string _errorLogName = "errorLog.log";
        StreamWriter _writer = null;

        /// <summary>
        /// �f�B�X�|�[�Y�����Ƃ�
        /// </summary>
        public void Dispose()
        {
            //���C�^�[���������B
            if (this._writer != null)
            {
                this._writer.Dispose();
                this._writer = null;
            }            
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="errorLogName"></param>
        public LogWriter(string errorLogName)
        {
            this._errorLogName = errorLogName;
        }

        /// <summary>
        /// ���O���L�q����B
        /// </summary>
        /// <param name="text">�L�q���������e</param>
        public void Write(string text)
        {
            this.InitializeWriter();
            this._writer.WriteLine(text);
        }

        public void Flush()
        {
            this.InitializeWriter();
            this._writer.Flush();
        }

        /// <summary>
        /// ���O���C�^�[������������B
        /// </summary>
        private void InitializeWriter()
        {
            if (this._writer == null)
            {
                this._writer = new StreamWriter(this._errorLogName,true,System.Text.Encoding.GetEncoding("SHIFT_JIS"));
            }
        }

    }
}
