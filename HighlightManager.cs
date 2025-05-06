using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinLogParser
{
    public class HighlightManager
    {
        private string m_Keyword;
        public void SetKeyword(string keyword) => m_Keyword = keyword;

        public void ApplyHighlight(DataGridViewCellFormattingEventArgs e)
        {
            if (string.IsNullOrEmpty(m_Keyword)) return;

            var text = e.Value as string;
            if (text == null) return;

            string plain = text.Replace("\r", "").Replace("\n", "");
            if (plain.Contains(m_Keyword))
            {
                e.CellStyle.ForeColor = Color.Green;
                e.CellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            }
            else
            {
                e.CellStyle.ForeColor = Color.Black;
                e.CellStyle.Font = new Font("Arial", 10, FontStyle.Regular);
            }
        }

    }
}
