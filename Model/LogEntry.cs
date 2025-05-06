using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinLogParser.Model
{
    public class LogEntry
    {
        public DateTime Timestamp { get; set; }
        public string Direction { get; set; }
        public Dictionary<string, string> Columns { get; set; } = new Dictionary<string, string>();
    }
}
