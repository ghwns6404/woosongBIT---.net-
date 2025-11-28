using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0402_계좌관리프로그램
{
    //이벤트 구독자
    internal class LogManager : IDisposable
    {
        private StreamWriter writer = null;

        #region 생성자 & 소멸자 
        public LogManager()
        {
            AccountControl con = AccountControl.Singleton;
            con.InsertAccount += InsertAccount;
            con.SelectAccount += SelectAccount;
            con.DeleteAccount += DeleteAccount;
            con.InputAccount += InputAccount;
            con.OutputAccount += OutputAccount;
            con.TotalAccount += TotalAccount;

            writer = new StreamWriter("logfile.txt");
        }

        ~LogManager()
        {
            Dispose();
        }

        public void Dispose()
        {
            writer.Dispose();  //writer.Close()
            GC.SuppressFinalize(this);
        }
        #endregion

        #region  이벤트를 수신할 핸들러 함수
        public void InsertAccount(object obj, LogArgs e)
        {
            string msg = string.Format("[{0}] {1} ({2} {3})", 
                e.Type, e.Msg, e.CurrentTime.ToShortDateString(), e.CurrentTime.ToShortTimeString());
            writer.WriteLine(msg);
        }
        public void SelectAccount(object obj, LogArgs e)
        {
            string msg = string.Format("[{0}] {1} ({2} {3})",
                e.Type, e.Msg, e.CurrentTime.ToShortDateString(), e.CurrentTime.ToShortTimeString());
            writer.WriteLine(msg);
        }
        public void InputAccount(object obj, LogArgs e)
        {
            string msg = string.Format("[{0}] {1} ({2} {3})",
                e.Type, e.Msg, e.CurrentTime.ToShortDateString(), e.CurrentTime.ToShortTimeString());
            writer.WriteLine(msg);
        }
        public void OutputAccount(object obj, LogArgs e)
        {
            string msg = string.Format("[{0}] {1} ({2} {3})",
                e.Type, e.Msg, e.CurrentTime.ToShortDateString(), e.CurrentTime.ToShortTimeString());
            writer.WriteLine(msg);
        }
        public void DeleteAccount(object obj, LogArgs e)
        {
            string msg = string.Format("[{0}] {1} ({2} {3})",
                e.Type, e.Msg, e.CurrentTime.ToShortDateString(), e.CurrentTime.ToShortTimeString());
            writer.WriteLine(msg);
        }
        public void TotalAccount(object obj, LogArgs e)
        {
            string msg = string.Format("[{0}] {1} ({2} {3})",
                e.Type, e.Msg, e.CurrentTime.ToShortDateString(), e.CurrentTime.ToShortTimeString());
            writer.WriteLine(msg);
        }
       
        #endregion
    }
}
