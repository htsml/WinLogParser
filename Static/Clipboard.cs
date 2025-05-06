using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinLogParser
{
    public static class ClipboardService
    {
        public static void CopySelectedRowText(DataGridView grid)
        {
            if (grid.SelectedRows.Count == 0) return;
            var row = grid.SelectedRows[0];
            var cells = row.Cells.Cast<DataGridViewCell>().Select(c => c.Value?.ToString() ?? "");
            Clipboard.SetText(string.Join("\t", cells));
        }
    }
}
