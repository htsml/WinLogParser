using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinLogParser
{
    public class InsertLineManager
    {
        private string m_Keyword;
        public void SetKeyword(string keyword) => m_Keyword = keyword;

        public string FormatLine(string line)
        {
            if (string.IsNullOrEmpty(line) || string.IsNullOrEmpty(m_Keyword)) return line;
            return line.Contains(m_Keyword) ? line.Replace(m_Keyword, m_Keyword + "\n") : line;
        }
    }
}
