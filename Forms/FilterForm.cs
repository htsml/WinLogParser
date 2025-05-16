using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.Threading.Tasks;

using WinLogParser;
using WinLogParser.Utils;
using WinLogParser.Model;
using WinLogParser.Define;

namespace WinLogParser
{
    public partial class FilterForm : Form
    {
        private bool m_IsAutoScroll = false;
        private bool m_IsColumnInit = false;
        private bool m_IsLoadingLog = false;

        private CmdSetting m_Setting;

        private EFilterSettingSelectOptionType m_CurrentSettingSelectOptionType;

        public FilterForm()
        {
            InitializeComponent();

            m_CurrentSettingSelectOptionType = EFilterSettingSelectOptionType.NONE;

            InitializeSplitButtons();

            EnableDoubleBuffering(dataGridView);
        }

        public void AppendLog(string line)
        {
            if (m_Setting == null)
                return;

            switch(m_CurrentSettingSelectOptionType)
            {
                case EFilterSettingSelectOptionType.HEX:
                    if (LogParser.TryParseHexLogLine(line, m_Setting, out List<string> hexRow))
                        AddLogLine(hexRow);
                    break;
                case EFilterSettingSelectOptionType.DIRECTION:
                    if (LogParser.TryParseDirectionLogLine(line, m_Setting, out List<string> directionRow))
                        AddLogLine(directionRow);
                    break;
                case EFilterSettingSelectOptionType.MACHINE:
                    if(LogParser.TryParseMachineCommand(line, m_Setting, out List<string> machineRow))
                        AddLogLine(machineRow);
                    break;
            }
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

        private void InitializeSettings()
        {
            if (m_Setting == null)
            {
                m_Setting = new CmdSetting()
                {
                    To = "",
                    Title = "",
                    CMD = "",
                    From = "",
                    CmdIndex = "",
                    CmdValue = "",
                    IsDirection = false,
                    IsRead = false,

                    Fields = new List<Field>(),
                };
            }
        }
        private void EnableDoubleBuffering(DataGridView dgv)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                                                                          BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                                                                          null, dgv, new object[] { true });
        }
        private void GridUpdate()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            dataGridView.Columns.Add("TimeDir", "Time/Direction");
            foreach (var field in m_Setting.Fields)
                dataGridView.Columns.Add(field.FieldName, field.FieldName);
        }
        private void Clean()
        {
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();
        }
        private void SaveSettingsToFile(string filePath)
        {
            SettingsStorage.SaveToFile(m_Setting, filePath);
        }
        private void LoadSettingsFromFile(string filePath)
        {
            try
            {
                Clean();
                m_Setting = SettingsStorage.LoadFromFile(filePath);
                this.Text = m_Setting.Title;

                m_CurrentSettingSelectOptionType = m_Setting.FilterSettingSelectOptionType;

                GridUpdate();

                m_IsColumnInit = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async Task LoadLogFromFile(string filePath)
        {
            try
            {
                if (m_IsLoadingLog)
                {
                    MessageBox.Show("Logs are currently loading.");
                    return;
                }

                if (m_IsColumnInit == false)
                {
                    MessageBox.Show("The column has not been initialized. Please initialize it and try loading again.");
                    return;
                }

                m_IsLoadingLog = true;

                var lines = new BlockingCollection<string>(boundedCapacity: 10000);

                Task readerTask = Task.Run(() =>
                {
                    using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (var reader = new StreamReader(fs))
                    {
                        while (!reader.EndOfStream)
                        {
                            lines.Add(reader.ReadLine());
                        }
                    }

                    lines.CompleteAdding();
                });

                var processorTask = Enumerable.Range(0, Environment.ProcessorCount).Select(_ =>
                Task.Run(() =>
                {
                    foreach (var line in lines.GetConsumingEnumerable())
                    {
                        AppendLog(line);
                    }
                })
                ).ToArray();

                await Task.WhenAll(processorTask);

                m_IsLoadingLog = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AddLogLine(List<string> row)
        {
            if (dataGridView.InvokeRequired)
            {
                dataGridView.Invoke(new MethodInvoker(() =>
                {
                    if (!m_IsAutoScroll)
                        dataGridView.Rows.Add(row.ToArray());
                    else
                        AddLogAndScroll(row);
                }));
            }
            else
            {
                if (!m_IsAutoScroll)
                    dataGridView.Rows.Add(row.ToArray());
                else
                    AddLogAndScroll(row);
            }
        }
        private void AddLogAndScroll(List<string> row)
        {
            int rowIndex = dataGridView.Rows.Add(row.ToArray());
            int visibleRows = 0;
            int targetIndex = 0;

            try
            {
                visibleRows = dataGridView.DisplayedRowCount(false);
                targetIndex = Math.Max(0, dataGridView.RowCount - visibleRows);
                dataGridView.FirstDisplayedScrollingRowIndex = targetIndex;
            }
            catch (Exception e)
            {
                Console.WriteLine($"AddLogAndScroll_____{e.Message}");
            }
        }

        private void OpenCMDSettingForm_TSBtn_Click(object sender, EventArgs e)
        {
            bool isFieldClean = false;
            if (m_Setting == null)
                InitializeSettings();

            using (var filterSelectSettingForm = new FilterSettingSelection())
            {
                filterSelectSettingForm.ShowDialog();

                EFilterSettingSelectOptionType settingSelectOptionType = filterSelectSettingForm.FilterSettingSelectOptionType;

                if (m_CurrentSettingSelectOptionType != settingSelectOptionType)
                    isFieldClean = true;

                if (settingSelectOptionType == EFilterSettingSelectOptionType.HEX)
                {
                    using (var dig = new HexCmdSettingsForm(m_Setting.Title, m_Setting.CmdValue, m_Setting.CmdIndex, m_Setting.Fields, m_Setting.IsRead))
                    {
                        if (dig.ShowDialog() == DialogResult.OK)
                        {
                            m_Setting = new CmdSetting
                            {
                                Title = dig.Title,
                                CmdValue = dig.CmdValue,
                                CmdIndex = dig.CmdIndex,
                                Fields = dig.Fields.ToList(),
                                FilterSettingSelectOptionType = dig.FilterSettingSelectOptionType,
                            };

                            if (isFieldClean)
                                dig.Clean();

                            m_CurrentSettingSelectOptionType = EFilterSettingSelectOptionType.HEX;

                            GridUpdate();
                        }
                    }
                }
                else if(settingSelectOptionType == EFilterSettingSelectOptionType.DIRECTION)
                {
                    using (var dig = new DirectionCmdSettingsForm(m_Setting.Title, m_Setting.From, m_Setting.To, m_Setting.CMD, m_Setting.Fields))
                    {
                        if (dig.ShowDialog() == DialogResult.OK)
                        {
                            m_Setting = new CmdSetting
                            {
                                Title = dig.Title,
                                CMD = dig.CMD,
                                From = dig.From,
                                To = dig.To,
                                IsDirection = dig.IsDirection,
                                Fields = dig.Fields.ToList(),
                                FilterSettingSelectOptionType = dig.FilterSettingSelectOptionType,
                            };

                            if (isFieldClean)
                                dig.Clean();

                            m_CurrentSettingSelectOptionType = EFilterSettingSelectOptionType.DIRECTION;

                            GridUpdate();
                        }
                    }
                }
                else if(settingSelectOptionType == EFilterSettingSelectOptionType.MACHINE)
                {
                    using (var dig = new MachineCmdSettingsForm(m_Setting.Title, m_Setting.From,m_Setting.CMD,m_Setting.Fields))
                    {
                        if(dig.ShowDialog() == DialogResult.OK)
                        {
                            m_Setting = new CmdSetting()
                            {
                                Title = dig.Title,
                                From = dig.From,
                                CMD = dig.CMD,
                                Fields = dig.Fields.ToList(),
                                FilterSettingSelectOptionType = dig.FilterSettingSelectOptionType,
                            };
                        }

                        if (isFieldClean)
                            dig.Clean();

                        m_CurrentSettingSelectOptionType = EFilterSettingSelectOptionType.MACHINE;

                        GridUpdate();
                    }
                }

                this.Text = m_Setting.Title;
            }
        }
        private void CmdSave_TSBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "JSON File (*.json)|*.json";
                if (sfd.ShowDialog() == DialogResult.OK)
                    SaveSettingsToFile(sfd.FileName);
            }
        }
        private void CmdLoad_TSBtn_Click(object sender, EventArgs e)
        {
            using (var filterLoadSelectionForm = new FilterLoadSelection(m_IsColumnInit))
            {
                filterLoadSelectionForm.ShowDialog();
                EFilterLoadSelectOptionType selected = filterLoadSelectionForm.FilterLoadSelectOptionType;

                if (selected == EFilterLoadSelectOptionType.LOG)
                {
                    using (OpenFileDialog ofd = new OpenFileDialog())
                    {
                        ofd.Filter = "Text and Log Files (*.txt;*.log)|*.txt;*.log";
                        if (ofd.ShowDialog() == DialogResult.OK)
                            LoadLogFromFile(ofd.FileName);
                    }
                }
                else if(selected == EFilterLoadSelectOptionType.COLUMNS)
                {
                    using (OpenFileDialog ofd = new OpenFileDialog())
                    {
                        ofd.Filter = "JSON File (*.json)|*.json";
                        if (ofd.ShowDialog() == DialogResult.OK)
                            LoadSettingsFromFile(ofd.FileName);
                    }
                }
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            dataGridView.Rows[e.RowIndex].Selected = true;
            if (m_IsAutoScroll)
            {
                m_IsAutoScroll = false;
                ScrollMode_SplitBtn.Text = "Manual";
            }
        }
    }
}
