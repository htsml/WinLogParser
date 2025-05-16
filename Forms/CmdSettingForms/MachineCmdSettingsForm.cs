using WinLogParser.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinLogParser.Define;

namespace WinLogParser
{
    public partial class MachineCmdSettingsForm : Form
    {
        public string Title { get; private set; }
        public string From { get; private set; }
        public string CMD { get; private set; }
        public EFilterSettingSelectOptionType FilterSettingSelectOptionType { get; private set; }
        private readonly List<Field> m_Fields = new List<Field>();
        public IReadOnlyList<Field> Fields => m_Fields.AsReadOnly();

        public MachineCmdSettingsForm(string title,string from, string cmd, IEnumerable<Field> fields)
        {
            InitializeComponent();

            FilterSettingSelectOptionType = EFilterSettingSelectOptionType.MACHINE;

            Title = title ?? "";
            From = from ?? "";
            CMD = cmd ?? "";

            Title_TxtBox.Text = Title;
            From_TxtBox.Text = From;
            Cmd_TxtBox.Text = CMD;

            InitializeFieldGrid();

            foreach (var field in fields ?? Array.Empty<Field>())
                dataGridView.Rows.Add(field.FieldName, field.Count);
        }
        public void Clean()
        {
            m_Fields.Clear();
        }
        private void InitializeFieldGrid()
        {
            dataGridView.Columns.Add("FieldName", "Field Name");
            dataGridView.Columns.Add("Count", "Count");
            dataGridView.Columns["Count"].ValueType = typeof(int);
        }

        private void Apply_Btn_Click(object sender, EventArgs e)
        {
            List<Field> newFields = new List<Field>();

            string title = Title_TxtBox.Text.Trim();
            string from = From_TxtBox.Text.Trim();
            string cmd = Cmd_TxtBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Please enter the 'Title' Text.");
                return;
            }

            if (string.IsNullOrWhiteSpace(from))
            {
                MessageBox.Show("Please enter the 'From' Text.");
                return;
            }

            if (string.IsNullOrWhiteSpace(cmd))
            {
                MessageBox.Show("Please enter the 'CMD' Text.");
                return;
            }

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.IsNewRow) continue;

                var fieldName = row.Cells["FieldName"].Value?.ToString()?.Trim() ?? "";
                if (string.IsNullOrEmpty(fieldName))
                {
                    MessageBox.Show("Field name cannot be empty.");
                    return;
                }

                if (!int.TryParse(row.Cells["Count"].Value?.ToString(), out int byteCount))
                {
                    MessageBox.Show($"Invalid count for field '{fieldName}'.");
                    return;
                }

                newFields.Add(new Field
                {
                    FieldName = fieldName,
                    Count = byteCount
                });
            }

            Title = title;
            From = from;
            CMD = cmd;

            FilterSettingSelectOptionType = EFilterSettingSelectOptionType.MACHINE;

            m_Fields.Clear();
            m_Fields.AddRange(newFields);

            DialogResult = DialogResult.OK;
            Close(); 
        }

        private void CommandSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                DialogResult = DialogResult.Cancel;
        }
    }
}
