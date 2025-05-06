using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinLogParser
{
    public class LogStream
    {
        private string m_FilePath;
        private int m_IntervalMs;
        private Thread m_Thread;
        private volatile bool m_Running;

        public event Action<string> OnNewLine;

        public LogStream(string filePath, int intervalMs = 100)
        {
            m_FilePath = filePath;
            m_IntervalMs = intervalMs;
        }

        public void Start()
        {
            if (m_Running) return;
            m_Running = true;

            m_Thread = new Thread(ReadLoop) { IsBackground = true };
            m_Thread.Start();
        }

        public void Stop()
        {
            m_Running = false;
        }

        private void ReadLoop()
        {
            try
            {
                using (var fs = new FileStream(m_FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var sr = new StreamReader(fs))
                    {
                        fs.Seek(0, SeekOrigin.End);

                        while (m_Running)
                        {
                            var line = sr.ReadLine();
                            if (line != null)
                                OnNewLine?.Invoke(line);
                            else
                                Thread.Sleep(m_IntervalMs);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // to do...
            }
        }
    }
}
