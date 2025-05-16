using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinLogParser.Define;

namespace WinLogParser.Model
{
    public class CmdSetting
    {
        public string Title { get; set; }

        public string CmdValue { get; set; }
        public string CmdIndex { get; set; }
        
        public string To { get; set; }
        public string From { get; set; }
        public string CMD { get; set; }

        public bool IsDirection { get; set; }
        public bool IsRead { get; set; }

        public List<Field> Fields { get; set; }

        public EFilterSettingSelectOptionType FilterSettingSelectOptionType { get; set; }
    }
}