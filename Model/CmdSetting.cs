using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinLogParser.Model
{
    public class CmdSetting
    {
        public string Title { get; set; }
        public string CmdValue { get; set; }
        public string CmdIndex { get; set; }
        public List<Field> Fields { get; set; }
        public bool IsRead { get; set; }
    }
}
