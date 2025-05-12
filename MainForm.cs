using WinLogParser;
using WinLogParser.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace WinLogParser
{
    public partial class MainForm : Form
    {
        private readonly List<FilterForm> m_FilterForms = new List<FilterForm>();
        private readonly OpenFileDialog m_OpenFileDialog = new OpenFileDialog();
        private readonly HighlightManager m_HighlightManager = new HighlightManager();
        private readonly InsertLineManager m_InsertLineManager = new InsertLineManager();

        private LogStream m_LogStreamService;

        private bool m_IsInitialized = false;
        private bool m_IsAutoScroll = false;

        public MainForm()
        {
            InitializeComponent();
            InitializeSplitButtons();

            EnableDoubleBuffering(dataGridViewAll);
        }

        private void InitializeSplitButtons()
        {
            ScrollMode_SplitBtn.DropDownItems.Add("Auto", null, (s, e) =>
            {
                m_IsAutoScroll = true;
                ScrollMode_SplitBtn.Text = "Auto";
            });

            ScrollMode_SplitBtn.DropDownItems.Add("Manual", null, (s, e) =>
            {
                m_IsAutoScroll = false;
                ScrollMode_SplitBtn.Text = "Manual";
            });
        }
        private void EnableDoubleBuffering(DataGridView dgv)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                                                                          BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                                                                          null, dgv, new object[] { true });
        }
        private void InitializeLogGrid()
        {
            dataGridViewAll.Columns.Clear();

            dataGridViewAll.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewAll.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridViewAll.DefaultCellStyle.Font = new Font("Arial", 10);
            dataGridViewAll.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewAll.ReadOnly = false;
            dataGridViewAll.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            var col = new DataGridViewTextBoxColumn
            {
                Name = "RawLog",
                HeaderText = "Raw Log",
                Width = 20000,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    WrapMode = DataGridViewTriState.True,
                    Font = new Font("Arial", 10, FontStyle.Regular),
                    Alignment = DataGridViewContentAlignment.TopLeft
                }
            };

            dataGridViewAll.Invoke((MethodInvoker)(() =>
            {
                dataGridViewAll.Columns.Add(col);
                dataGridViewAll.RowHeadersVisible = false;
                dataGridViewAll.AllowUserToAddRows = false;
                dataGridViewAll.ScrollBars = ScrollBars.Both;
                dataGridViewAll.DefaultCellStyle.Padding = new Padding(0);
            }));

            m_IsInitialized = true;
        }

        private void HandleNewLogLine(string line)
        {
            if (!m_IsInitialized)
                InitializeLogGrid();

            string formattedLine = m_InsertLineManager.FormatLine(line);

            foreach (var form in m_FilterForms)
                form.AppendLog(line);

            AddLog(formattedLine);
        }

        private void AddLog(string line)
        {
            dataGridViewAll.Invoke((MethodInvoker)(() =>
            {
                int rowIndex = dataGridViewAll.Rows.Add(line);

                if (m_IsAutoScroll)
                {
                    int visibleRows = dataGridViewAll.DisplayedRowCount(false);
                    int targetIndex = Math.Max(0, dataGridViewAll.RowCount - visibleRows);
                    dataGridViewAll.FirstDisplayedScrollingRowIndex = targetIndex;
                }
            }));
        }

        private void Open_TSBtn_Click(object sender, EventArgs e)
        {
            m_IsInitialized = false;

            dataGridViewAll.Rows.Clear();
            dataGridViewAll.Columns.Clear();

            if (m_LogStreamService != null)
            {
                m_LogStreamService.Stop();
                m_LogStreamService.OnNewLine -= HandleNewLogLine;
                m_LogStreamService = null;
            }

            if (m_OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                m_LogStreamService = new LogStream(m_OpenFileDialog.FileName, 100);
                m_LogStreamService.OnNewLine += HandleNewLogLine;
                m_LogStreamService.Start();
            }
        }

        private void Highlighting_TSBtn_Click(object sender, EventArgs e)
        {
            string input = Prompt.ShowDialog("Enter a keyword to highlight:", "Keyword Settings");
            m_HighlightManager.SetKeyword(input);
            dataGridViewAll.Refresh();
        }

        private void InsertLine_TSBtn_Click(object sender, EventArgs e)
        {
            string input = Prompt.ShowDialog("Enter a keyword to New Insert Line:", "Keyword Settings");
            m_InsertLineManager.SetKeyword(input);
        }

        private void RowCopy_TSBtn_Click(object sender, EventArgs e)
        {
            ClipboardService.CopySelectedRowText(dataGridViewAll);
        }

        private void NewLogFilterForm_TSBtn_Click(object sender, EventArgs e)
        {
            var filterForm = new FilterForm();
            filterForm.FormClosed += (s, ea) => m_FilterForms.Remove(filterForm);
            m_FilterForms.Add(filterForm);
            filterForm.Show();
        }

        private void dataGridViewAll_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            dataGridViewAll.Rows[e.RowIndex].Selected = true;

            if (m_IsAutoScroll)
            {
                m_IsAutoScroll = false;
                ScrollMode_SplitBtn.Text = "Manual";
            }
        }

        private void dataGridViewAll_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            m_HighlightManager.ApplyHighlight(e);
        }
    }
}
