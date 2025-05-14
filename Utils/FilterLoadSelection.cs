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
    public partial class FilterLoadSelection : Form
    {
        public ELoadSelectOptionType LoadSelectOptionType { get; private set; }
        public FilterLoadSelection()
        {
            InitializeComponent();
        }

        private void LoadLog_Btn_Click(object sender, EventArgs e)
        {
            LoadSelectOptionType = ELoadSelectOptionType.LOG;
            this.Close();
        }

        private void LoadColumns_Btn_Click(object sender, EventArgs e)
        {
            LoadSelectOptionType = ELoadSelectOptionType.COLUMNS;
            this.Close();
        }
    }
}
