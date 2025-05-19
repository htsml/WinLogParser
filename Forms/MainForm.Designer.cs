using System.Drawing;
using System.Windows.Forms;

namespace WinLogParser
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.Open_TSBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Highlighting_TSBtn = new System.Windows.Forms.ToolStripButton();
            this.InsertLine_TSBtn = new System.Windows.Forms.ToolStripButton();
            this.ScrollMode_SplitBtn = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.NewLogFilterForm_TSBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.RowCopy_TSBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Right_TSBtn = new System.Windows.Forms.ToolStripButton();
            this.Page_TSlbl = new System.Windows.Forms.ToolStripLabel();
            this.PageInputText_TSTxtbox = new System.Windows.Forms.ToolStripTextBox();
            this.Left_TSBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.dataGridViewAll = new System.Windows.Forms.DataGridView();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAll)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open_TSBtn,
            this.toolStripSeparator2,
            this.Highlighting_TSBtn,
            this.InsertLine_TSBtn,
            this.ScrollMode_SplitBtn,
            this.toolStripSeparator3,
            this.NewLogFilterForm_TSBtn,
            this.toolStripSeparator4,
            this.RowCopy_TSBtn,
            this.toolStripSeparator1,
            this.Right_TSBtn,
            this.Page_TSlbl,
            this.PageInputText_TSTxtbox,
            this.Left_TSBtn,
            this.toolStripSeparator5});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(914, 27);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // Open_TSBtn
            // 
            this.Open_TSBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Open_TSBtn.Image = ((System.Drawing.Image)(resources.GetObject("Open_TSBtn.Image")));
            this.Open_TSBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Open_TSBtn.Name = "Open_TSBtn";
            this.Open_TSBtn.Size = new System.Drawing.Size(51, 24);
            this.Open_TSBtn.Text = "Open";
            this.Open_TSBtn.Click += new System.EventHandler(this.Open_TSBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // Highlighting_TSBtn
            // 
            this.Highlighting_TSBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Highlighting_TSBtn.Image = ((System.Drawing.Image)(resources.GetObject("Highlighting_TSBtn.Image")));
            this.Highlighting_TSBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Highlighting_TSBtn.Name = "Highlighting_TSBtn";
            this.Highlighting_TSBtn.Size = new System.Drawing.Size(99, 24);
            this.Highlighting_TSBtn.Text = "Highlighting";
            this.Highlighting_TSBtn.Click += new System.EventHandler(this.Highlighting_TSBtn_Click);
            // 
            // InsertLine_TSBtn
            // 
            this.InsertLine_TSBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.InsertLine_TSBtn.Image = ((System.Drawing.Image)(resources.GetObject("InsertLine_TSBtn.Image")));
            this.InsertLine_TSBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.InsertLine_TSBtn.Name = "InsertLine_TSBtn";
            this.InsertLine_TSBtn.Size = new System.Drawing.Size(78, 24);
            this.InsertLine_TSBtn.Text = "InsertLine";
            this.InsertLine_TSBtn.Click += new System.EventHandler(this.InsertLine_TSBtn_Click);
            // 
            // ScrollMode_SplitBtn
            // 
            this.ScrollMode_SplitBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ScrollMode_SplitBtn.Image = ((System.Drawing.Image)(resources.GetObject("ScrollMode_SplitBtn.Image")));
            this.ScrollMode_SplitBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ScrollMode_SplitBtn.Name = "ScrollMode_SplitBtn";
            this.ScrollMode_SplitBtn.Size = new System.Drawing.Size(80, 24);
            this.ScrollMode_SplitBtn.Text = "Manual";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // NewLogFilterForm_TSBtn
            // 
            this.NewLogFilterForm_TSBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.NewLogFilterForm_TSBtn.Image = ((System.Drawing.Image)(resources.GetObject("NewLogFilterForm_TSBtn.Image")));
            this.NewLogFilterForm_TSBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewLogFilterForm_TSBtn.Name = "NewLogFilterForm_TSBtn";
            this.NewLogFilterForm_TSBtn.Size = new System.Drawing.Size(81, 24);
            this.NewLogFilterForm_TSBtn.Text = "New Filter";
            this.NewLogFilterForm_TSBtn.Click += new System.EventHandler(this.NewLogFilterForm_TSBtn_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // RowCopy_TSBtn
            // 
            this.RowCopy_TSBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.RowCopy_TSBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RowCopy_TSBtn.Image = ((System.Drawing.Image)(resources.GetObject("RowCopy_TSBtn.Image")));
            this.RowCopy_TSBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RowCopy_TSBtn.Name = "RowCopy_TSBtn";
            this.RowCopy_TSBtn.Size = new System.Drawing.Size(48, 24);
            this.RowCopy_TSBtn.Text = "Copy";
            this.RowCopy_TSBtn.Click += new System.EventHandler(this.RowCopy_TSBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // Right_TSBtn
            // 
            this.Right_TSBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Right_TSBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Right_TSBtn.Image = ((System.Drawing.Image)(resources.GetObject("Right_TSBtn.Image")));
            this.Right_TSBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Right_TSBtn.Name = "Right_TSBtn";
            this.Right_TSBtn.Size = new System.Drawing.Size(29, 24);
            this.Right_TSBtn.Text = ">";
            this.Right_TSBtn.ToolTipText = "페이지를 오른쪽으로 이동합니다.";
            this.Right_TSBtn.Click += new System.EventHandler(this.Right_TSBtn_Click);
            // 
            // Page_TSlbl
            // 
            this.Page_TSlbl.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Page_TSlbl.Name = "Page_TSlbl";
            this.Page_TSlbl.Size = new System.Drawing.Size(28, 24);
            this.Page_TSlbl.Text = "/ 0";
            // 
            // PageInputText_TSTxtbox
            // 
            this.PageInputText_TSTxtbox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.PageInputText_TSTxtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PageInputText_TSTxtbox.Name = "PageInputText_TSTxtbox";
            this.PageInputText_TSTxtbox.Size = new System.Drawing.Size(44, 27);
            this.PageInputText_TSTxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PageInputText_TSTxtbox_KeyDown);
            // 
            // Left_TSBtn
            // 
            this.Left_TSBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Left_TSBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Left_TSBtn.Image = ((System.Drawing.Image)(resources.GetObject("Left_TSBtn.Image")));
            this.Left_TSBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Left_TSBtn.Name = "Left_TSBtn";
            this.Left_TSBtn.Size = new System.Drawing.Size(29, 24);
            this.Left_TSBtn.Text = "<";
            this.Left_TSBtn.ToolTipText = "페이지를 왼쪽으로 이동합니다.";
            this.Left_TSBtn.Click += new System.EventHandler(this.Left_TSBtn_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // dataGridViewAll
            // 
            this.dataGridViewAll.AllowUserToDeleteRows = false;
            this.dataGridViewAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAll.Location = new System.Drawing.Point(0, 27);
            this.dataGridViewAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewAll.Name = "dataGridViewAll";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAll.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewAll.RowHeadersWidth = 51;
            this.dataGridViewAll.Size = new System.Drawing.Size(914, 423);
            this.dataGridViewAll.TabIndex = 1;
            this.dataGridViewAll.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewAll_CellClick);
            this.dataGridViewAll.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewAll_CellFormatting);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 450);
            this.Controls.Add(this.dataGridViewAll);
            this.Controls.Add(this.toolStrip);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WinLogParser";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAll)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolStrip;
        private ToolStripButton Open_TSBtn;
        private ToolStripButton Highlighting_TSBtn;
        private ToolStripButton NewLogFilterForm_TSBtn;
        private DataGridView dataGridViewAll;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSplitButton ScrollMode_SplitBtn;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton InsertLine_TSBtn;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton RowCopy_TSBtn;
        private ToolStripButton Right_TSBtn;
        private ToolStripButton Left_TSBtn;
        private ToolStripLabel Page_TSlbl;
        private ToolStripTextBox PageInputText_TSTxtbox;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator5;
    }
}
