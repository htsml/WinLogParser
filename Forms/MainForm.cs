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

        private int m_PageSize = 500;
        private int m_PageIndex = 0;
        private int m_DisplayStartIndex = 0;
        private int m_NewTotalPages = 0;

        private bool m_isDirty = false;
        private bool m_IsInitialized = false;
        private bool m_IsAutoScroll = false;

        private string m_FormattedLine = "";

        private List<string> m_AllLogs = new List<string>();

        private Timer m_UiRefreshTimer;

        private int m_TotalPages
        {
            get { return (int)Math.Ceiling((double)m_AllLogs.Count / m_PageSize); }
        }

        public MainForm()
        {
            InitializeComponent();
            InitializeSplitButtons();

            InitializeDataGridView();

            InitializeTimer();
        }

        private void InitializeSplitButtons()
        {
            ScrollMode_SplitBtn.DropDownItems.Add("Auto", null, (s, e) =>
            {
                m_IsAutoScroll = true;
                ScrollMode_SplitBtn.Text = "Auto";

                BeginInvoke((MethodInvoker)(() => ScrollToBottom()));
            });

            ScrollMode_SplitBtn.DropDownItems.Add("Manual", null, (s, e) =>
            {
                m_IsAutoScroll = false;
                ScrollMode_SplitBtn.Text = "Manual";
            });
        }
        private void InitializeDataGridView()
        {
            dataGridViewAll.VirtualMode = true;

            dataGridViewAll.RowCount = 1;

            dataGridViewAll.Rows.Clear();
            dataGridViewAll.Columns.Clear();

            dataGridViewAll.CellValueNeeded += delegate (object sender, DataGridViewCellValueEventArgs e)
            {
                int index = m_PageIndex * m_PageSize + e.RowIndex;
                if (index >= 0 && index < m_AllLogs.Count)
                    e.Value = m_AllLogs[index];
                else
                    e.Value = "";
            };

            //dataGridViewAll.Scroll += (s, e) =>
            //{
            //    if (m_IsAutoScroll == false && dataGridViewAll.FirstDisplayedScrollingRowIndex == 0 && m_DisplayStartIndex > 0)
            //    {
            //        m_DisplayStartIndex = Math.Max(0, m_DisplayStartIndex - m_PageSize);
            //        dataGridViewAll.RowCount = Math.Min(m_PageSize, m_AllLogs.Count - m_DisplayStartIndex);
            //        dataGridViewAll.Invalidate();
            //    }
            //};

            UpdatePage();

            EnableDoubleBuffering(dataGridViewAll);
        }
        private void InitializeDataGridViewDisplay()
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
        private void InitializeTimer()
        {
            m_UiRefreshTimer = new Timer();
            m_UiRefreshTimer.Interval = 200; // 200ms 간격으로 UI 업데이트

            m_UiRefreshTimer.Tick += (s, e) =>
            {
                if (m_IsInitialized == false)
                    return;

                m_DisplayStartIndex = Math.Max(0, m_AllLogs.Count - m_PageSize);
                dataGridViewAll.Invalidate();

                if (m_IsAutoScroll)
                    BeginInvoke((MethodInvoker)(() => ScrollToBottom()));

                if(m_isDirty)
                {
                    LoadPage(m_NewTotalPages);
                    m_isDirty = false;
                }
            };

            m_UiRefreshTimer.Start();
        }
        private void HandleNewLogLine(string line)
        {
            if (!m_IsInitialized)
                InitializeDataGridViewDisplay();

            m_FormattedLine = m_InsertLineManager.FormatLine(line);

            foreach (var form in m_FilterForms)
                form.AppendLog(line);

            AddLog(m_FormattedLine);
        }

        private void AddLog(string line)
        {
            int oldTotalPages = m_TotalPages;

            m_AllLogs.Add(line);

            m_NewTotalPages = (int)Math.Ceiling((double)m_AllLogs.Count / m_PageSize);

            if (m_PageIndex == oldTotalPages - 1)
                m_isDirty = true;
            else
                UpdatePage();
        }
        private void ScrollToBottom()
        {
            try
            {
                if (dataGridViewAll.RowCount > 0)
                {
                    int lastIndex = dataGridViewAll.RowCount - 1;
                    dataGridViewAll.FirstDisplayedScrollingRowIndex = lastIndex;
                }
            }
            catch
            {
                // to do...
            }
        }
        private void EnableDoubleBuffering(DataGridView dgv)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.SetProperty,
                null, dgv, new object[] { true });
        }
        private void LoadPage(int pageNumber)
        {
            int targetIndex = Math.Max(0, Math.Min(pageNumber - 1, Math.Max(0, m_TotalPages - 1)));
            m_PageIndex = targetIndex;

            int startIndex = m_PageIndex * m_PageSize;
            int visibleCount = Math.Min(m_PageSize, m_AllLogs.Count - startIndex);

            dataGridViewAll.RowCount = visibleCount;
            dataGridViewAll.Invalidate();

            UpdatePage();
        }
        private void UpdatePage()
        {
            if(InvokeRequired)
            {
                BeginInvoke((MethodInvoker)UpdatePage);
                return;
            }

            Page_TSlbl.Text = $"{m_PageIndex + 1} / {Math.Max(1, m_TotalPages)}";
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

        private void Left_TSBtn_Click(object sender, EventArgs e)
        {
            LoadPage(m_PageIndex);
        }

        private void Right_TSBtn_Click(object sender, EventArgs e)
        {
            LoadPage(m_PageIndex + 2);
        }

        private void PageInputText_TSTxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int page;
                if (int.TryParse(PageInputText_TSTxtbox.Text, out page))
                    LoadPage(page);
            }
        }
    }
}
