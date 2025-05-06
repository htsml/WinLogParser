using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WinLogParser
{
    public class LogReader
    {
        public Action<string> OnNewLogLine;

        private FileStream m_LogFileStream;
        private StreamReader m_LogReader;
        private System.Windows.Forms.Timer m_Timer;

        private long m_LastPosition = 0;
        private string m_LogFilePath;

        public void Start() => m_Timer.Start();
        public void Stop() => m_Timer.Stop();

        public LogReader(string path, int interval = 500)
        {
            m_LogFilePath = path;
            m_LogFileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            m_LogReader = new StreamReader(m_LogFileStream);
            m_LogFileStream.Seek(0, SeekOrigin.End);
            m_LastPosition = m_LogFileStream.Position;

            m_Timer = new System.Windows.Forms.Timer();
            m_Timer.Interval = interval;
            m_Timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            string line;

            m_LogFileStream.Seek(m_LastPosition, SeekOrigin.Begin);
            
            while ((line = m_LogReader.ReadLine()) != null)
                OnNewLogLine?.Invoke(line);  

            m_LastPosition = m_LogFileStream.Position;
        }
    }
}
