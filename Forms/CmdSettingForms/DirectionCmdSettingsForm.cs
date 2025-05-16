using WinLogParser.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinLogParser.Define;

namespace WinLogParser
{
    public partial class DirectionCmdSettingsForm : Form
    {
        public string Title { get; private set; }
        public string From { get; private set; }
        public string To { get; private set; }
        public string CMD { get; private set; }
        public bool IsDirection { get; private set; }
        private readonly List<Field> m_Fields = new List<Field>();
        public EFilterSettingSelectOptionType FilterSettingSelectOptionType { get; private set; }
        public IReadOnlyList<Field> Fields => m_Fields.AsReadOnly();

        public DirectionCmdSettingsForm(string title, string from, string to, string cmd, IEnumerable<Field> fields)
        {
            InitializeComponent();

            Title = title ?? "";
            From = from ?? "";
            To = to ?? "";
            CMD = cmd ?? "";

            Title_TxtBox.Text = Title;
            From_TxtBox.Text = From;
            To_TxtBox.Text = To;
            CMD_TxtBox.Text = CMD;

            FilterSettingSelectOptionType = EFilterSettingSelectOptionType.DIRECTION;

            InitializeFieldGrid();

            foreach (var field in fields ?? Array.Empty<Field>())
                dataGridView.Rows.Add(field.FieldName, field.Count);
        }

        private void InitializeFieldGrid()
        {
            dataGridView.Columns.Add("FieldName", "Field Name");
            dataGridView.Columns.Add("Length", "Length");
            dataGridView.Columns["Length"].ValueType = typeof(int);
        }
        public void Clean()
        {
            m_Fields.Clear();
        }

        private void Apply_Btn_Click(object sender, EventArgs e)
        {
            List<Field> newFields = new List<Field>();

            string title = Title_TxtBox.Text.Trim();
            string from = From_TxtBox.Text.Trim();
            string to = To_TxtBox.Text.Trim();
            string cmd = CMD_TxtBox.Text.Trim();

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

            if (string.IsNullOrWhiteSpace(to))
            {
                MessageBox.Show("Please enter the 'To' Text.");
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

                if (!int.TryParse(row.Cells["Length"].Value?.ToString(), out int length))
                {
                    MessageBox.Show($"Invalid length for field '{fieldName}'.");
                    return;
                }

                newFields.Add(new Field
                {
                    FieldName = fieldName,
                    Count = length
                });
            }

            Title = title;
            From = from;
            To = to;
            CMD = cmd;
            IsDirection = true;

            m_Fields.Clear();
            m_Fields.AddRange(newFields);

            FilterSettingSelectOptionType = EFilterSettingSelectOptionType.DIRECTION;

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
