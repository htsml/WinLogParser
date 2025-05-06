using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinLogParser.Utils
{
    public static class HighlightPrompt
    {
        public static Dictionary<string, Color> ShowDialog()
        {
            var result = new Dictionary<string, Color>();

            var prompt = new Form()
            {
                Width = 450,
                Height = 400,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Keyword Highlighter",
                StartPosition = FormStartPosition.CenterScreen
            };

            var lbl = new Label() { Left = 20, Top = 20, Text = "Enter keyword and select color", Width = 300 };
            var keywordBox = new TextBox() { Left = 20, Top = 50, Width = 280 };
            var pickColorBtn = new Button() { Text = "Pick Color", Left = 310, Top = 50, Width = 100 };
            var addBtn = new Button() { Text = "Add", Left = 160, Top = 90, Width = 80 };
            var listView = new ListView() { Left = 20, Top = 130, Width = 390, Height = 170, View = View.Details, FullRowSelect = true };
            var applyBtn = new Button() { Text = "Apply", Left = 320, Top = 320, Width = 90, DialogResult = DialogResult.OK };

            var colorDialog = new ColorDialog();
            Color selectedColor = Color.Green;

            listView.Columns.Add("Keyword", 200);
            listView.Columns.Add("Color", 150);

            pickColorBtn.Click += (s, e) =>
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                    selectedColor = colorDialog.Color;
            };

            addBtn.Click += (s, e) =>
            {
                var keyword = keywordBox.Text.Trim();
                if (string.IsNullOrEmpty(keyword)) return;

                var item = new ListViewItem(new[] { keyword, selectedColor.Name });
                item.BackColor = selectedColor;
                item.ForeColor = Color.White;
                listView.Items.Add(item);
                keywordBox.Clear();
            };

            prompt.Controls.Add(lbl);
            prompt.Controls.Add(keywordBox);
            prompt.Controls.Add(pickColorBtn);
            prompt.Controls.Add(addBtn);
            prompt.Controls.Add(listView);
            prompt.Controls.Add(applyBtn);
            prompt.AcceptButton = applyBtn;

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                foreach (ListViewItem item in listView.Items)
                {
                    var keyword = item.SubItems[0].Text;
                    var color = item.BackColor;
                    result[keyword] = color;
                }
            }

            return result;
        }
    }
}
