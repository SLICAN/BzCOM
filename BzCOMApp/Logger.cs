using System;

namespace ChatTest
{
    public class Logger
    {
        public delegate void OnLoggerMessageDelegate(Logger sender, string msg);
        public event OnLoggerMessageDelegate OnLoggerMessage; 

        public void Debug(string obj)
        {
            OnLoggerMessage?.Invoke(this, obj);
            //System.Diagnostics.Debug.WriteLine(obj);
        }

        public static void Debug(string message, params object[] prm)
        {
            //MainForm.DoOnUIThread(rtb, () =>
            //{
            //    string msg = (prm.Length > 0) ? string.Format(message, prm) : message;
            //    rtb.AppendText(msg + Environment.NewLine);
            //    if (Follow)
            //    {
            //        rtb.SelectionStart = rtb.Text.Length;
            //        rtb.ScrollToCaret();
            //    }
            //});
        }
    }
}
