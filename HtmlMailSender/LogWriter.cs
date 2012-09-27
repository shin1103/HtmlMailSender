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
        /// ディスポーズされるとき
        /// </summary>
        public void Dispose()
        {
            //ライターを解放する。
            if (this._writer != null)
            {
                this._writer.Dispose();
                this._writer = null;
            }            
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="errorLogName"></param>
        public LogWriter(string errorLogName)
        {
            this._errorLogName = errorLogName;
        }

        /// <summary>
        /// ログを記述する。
        /// </summary>
        /// <param name="text">記述したい内容</param>
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
        /// ログライターを初期化する。
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
