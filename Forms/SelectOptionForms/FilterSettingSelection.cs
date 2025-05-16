using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinLogParser.Define;

namespace WinLogParser.Utils
{
    public partial class FilterSettingSelection : Form
    {
        public EFilterSettingSelectOptionType FilterSettingSelectOptionType { get; private set; }
             
        public FilterSettingSelection()
        {
            InitializeComponent();

            FilterSettingSelectOptionType = EFilterSettingSelectOptionType.NONE;
        }

        private void FilterHEXSetting_Btn_Click(object sender, EventArgs e)
        {
            FilterSettingSelectOptionType = EFilterSettingSelectOptionType.HEX;
            this.Close();
        }

        private void FilterDirectionSetting_Btn_Click(object sender, EventArgs e)
        {
            FilterSettingSelectOptionType = EFilterSettingSelectOptionType.DIRECTION;
            this.Close();
        }

        private void Machine_Btn_Click(object sender, EventArgs e)
        {
            FilterSettingSelectOptionType = EFilterSettingSelectOptionType.MACHINE;
            this.Close();
        }
    }
}
