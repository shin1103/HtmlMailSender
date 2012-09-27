using System;
using System.Collections.Generic;
using System.Windows.Forms;

using System.Threading;

namespace SHashiba.HtmlMailSender
{

    class MyAppContext : ApplicationContext
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new TestForm());
            //Application.Run(new MainForm());
            Application.Run(new MyAppContext());
        }

        //ログを出力するライター
        public static LogWriter _writer = null;
        public MyAppContext()
        {
            Application.EnableVisualStyles();

            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
            Application.ThreadException += new ThreadExceptionEventHandler(this.OnThreadException);

            //ログ出力先の決定
            string logfileName = System.IO.Path.Combine(Application.StartupPath, DateTime.Now.ToString("yyyy年MM月dd日HH時mm分ss秒の") + "Log.log");
            _writer = new LogWriter(logfileName);

            MainForm f = new MainForm();
            f.FormClosed  += new FormClosedEventHandler(this.OnMainFormClosedEvent);
            f.Show();

       }

        /// <summary>
        /// アプリケーションが終了する時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnApplicationExit(object sender, EventArgs e)
        {
            //ログライターを解放する。
            if (_writer != null) _writer.Dispose();
        }

        /// <summary>
        /// メインフォームが閉じられるときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMainFormClosedEvent(object sender, FormClosedEventArgs e)
        {
            //スレッドを終了する。
            this.ExitThread();
        }

        /// <summary>
        /// 予期せぬ例外が発生したとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="t"></param>
        private void OnThreadException(object sender, ThreadExceptionEventArgs t)
        {
            //ログライターを解放する。
            if (_writer != null) _writer.Dispose();

            MessageBox.Show("予期せぬエラーが発生しました。アプリケーションを終了します。","例外発生",MessageBoxButtons.OK,MessageBoxIcon.Error);
            int maxLength = System.Math.Min(t.Exception.ToString().Length, 16000);
            System.Diagnostics.EventLog.WriteEntry("HtmlMailSender", t.Exception.ToString().Substring(0, maxLength), System.Diagnostics.EventLogEntryType.Error);
            Application.Exit();
        }
    }
}

