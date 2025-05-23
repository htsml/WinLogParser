﻿using WinLogParser.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinLogParser.Define;

namespace WinLogParser
{
    public partial class HexCmdSettingsForm : Form
    {
        public string Title { get; private set; }
        public string CmdValue { get; private set; }
        public string CmdIndex { get; private set; }
        public bool IsRead { get; private set; }
        public EFilterSettingSelectOptionType FilterSettingSelectOptionType { get; private set; }
        private readonly List<Field> m_Fields = new List<Field>();
        public IReadOnlyList<Field> Fields => m_Fields.AsReadOnly();

        public HexCmdSettingsForm(string title,string cmdValue, string cmdIndex, IEnumerable<Field> fields,bool isRead)
        {
            InitializeComponent();

            Title = title ?? "";
            CmdValue = cmdValue ?? "";
            CmdIndex = cmdIndex ?? "";
            IsRead = isRead;

            Title_TxtBox.Text = Title;
            Cmd_Value_TxtBox.Text = CmdValue;
            Cmd_Index_TxtBox.Text = CmdIndex;
            IsRead_CheckBox.Checked = IsRead;

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
            dataGridView.Columns.Add("ByteCount", "Byte Count");
            dataGridView.Columns["ByteCount"].ValueType = typeof(int);
        }

        private void Apply_Btn_Click(object sender, EventArgs e)
        {
            List<Field> newFields = new List<Field>();

            bool isRead = IsRead_CheckBox.Checked;
            string title = Title_TxtBox.Text.Trim();
            string cmdValue = Cmd_Value_TxtBox.Text.Trim();
            string cmdIndex = Cmd_Index_TxtBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Please enter the 'Title' Text.");
                return;
            }

            if (string.IsNullOrWhiteSpace(cmdValue))
            {
                MessageBox.Show("Please enter the CMD Value.");
                return;
            }

            if (string.IsNullOrWhiteSpace(cmdIndex))
            {
                MessageBox.Show("Please enter the CMD Index.");
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

                if (!int.TryParse(row.Cells["ByteCount"].Value?.ToString(), out int byteCount))
                {
                    MessageBox.Show($"Invalid byte count for field '{fieldName}'.");
                    return;
                }

                newFields.Add(new Field
                {
                    FieldName = fieldName,
                    Count = byteCount
                });
            }

            Title = title;
            CmdValue = cmdValue;
            CmdIndex = cmdIndex;
            IsRead = isRead;

            FilterSettingSelectOptionType = EFilterSettingSelectOptionType.HEX;

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
