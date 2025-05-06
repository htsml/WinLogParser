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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Open_TSBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Highlighting_TSBtn = new System.Windows.Forms.ToolStripButton();
            this.InsertLine_TSBtn = new System.Windows.Forms.ToolStripButton();
            this.ScrollMode_SplitBtn = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.NewLogFilterForm_TSBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.RowCopy_TSBtn = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewAll = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAll)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open_TSBtn,
            this.toolStripSeparator2,
            this.Highlighting_TSBtn,
            this.InsertLine_TSBtn,
            this.ScrollMode_SplitBtn,
            this.toolStripSeparator3,
            this.NewLogFilterForm_TSBtn,
            this.toolStripSeparator1,
            this.RowCopy_TSBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Open_TSBtn
            // 
            this.Open_TSBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Open_TSBtn.Image = ((System.Drawing.Image)(resources.GetObject("Open_TSBtn.Image")));
            this.Open_TSBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Open_TSBtn.Name = "Open_TSBtn";
            this.Open_TSBtn.Size = new System.Drawing.Size(40, 22);
            this.Open_TSBtn.Text = "Open";
            this.Open_TSBtn.Click += new System.EventHandler(this.Open_TSBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // Highlighting_TSBtn
            // 
            this.Highlighting_TSBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Highlighting_TSBtn.Image = ((System.Drawing.Image)(resources.GetObject("Highlighting_TSBtn.Image")));
            this.Highlighting_TSBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Highlighting_TSBtn.Name = "Highlighting_TSBtn";
            this.Highlighting_TSBtn.Size = new System.Drawing.Size(78, 22);
            this.Highlighting_TSBtn.Text = "Highlighting";
            this.Highlighting_TSBtn.Click += new System.EventHandler(this.Highlighting_TSBtn_Click);
            // 
            // InsertLine_TSBtn
            // 
            this.InsertLine_TSBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.InsertLine_TSBtn.Image = ((System.Drawing.Image)(resources.GetObject("InsertLine_TSBtn.Image")));
            this.InsertLine_TSBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.InsertLine_TSBtn.Name = "InsertLine_TSBtn";
            this.InsertLine_TSBtn.Size = new System.Drawing.Size(62, 22);
            this.InsertLine_TSBtn.Text = "InsertLine";
            this.InsertLine_TSBtn.Click += new System.EventHandler(this.InsertLine_TSBtn_Click);
            // 
            // ScrollMode_SplitBtn
            // 
            this.ScrollMode_SplitBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ScrollMode_SplitBtn.Image = ((System.Drawing.Image)(resources.GetObject("ScrollMode_SplitBtn.Image")));
            this.ScrollMode_SplitBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ScrollMode_SplitBtn.Name = "ScrollMode_SplitBtn";
            this.ScrollMode_SplitBtn.Size = new System.Drawing.Size(63, 22);
            this.ScrollMode_SplitBtn.Text = "Manual";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // NewLogFilterForm_TSBtn
            // 
            this.NewLogFilterForm_TSBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.NewLogFilterForm_TSBtn.Image = ((System.Drawing.Image)(resources.GetObject("NewLogFilterForm_TSBtn.Image")));
            this.NewLogFilterForm_TSBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewLogFilterForm_TSBtn.Name = "NewLogFilterForm_TSBtn";
            this.NewLogFilterForm_TSBtn.Size = new System.Drawing.Size(65, 22);
            this.NewLogFilterForm_TSBtn.Text = "New Filter";
            this.NewLogFilterForm_TSBtn.Click += new System.EventHandler(this.NewLogFilterForm_TSBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // RowCopy_TSBtn
            // 
            this.RowCopy_TSBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.RowCopy_TSBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RowCopy_TSBtn.Image = ((System.Drawing.Image)(resources.GetObject("RowCopy_TSBtn.Image")));
            this.RowCopy_TSBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RowCopy_TSBtn.Name = "RowCopy_TSBtn";
            this.RowCopy_TSBtn.Size = new System.Drawing.Size(39, 22);
            this.RowCopy_TSBtn.Text = "Copy";
            // 
            // dataGridViewAll
            // 
            this.dataGridViewAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAll.Location = new System.Drawing.Point(0, 25);
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
            this.dataGridViewAll.Size = new System.Drawing.Size(800, 335);
            this.dataGridViewAll.TabIndex = 1;
            this.dataGridViewAll.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAll_CellClick);
            this.dataGridViewAll.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewAll_CellFormatting);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 360);
            this.Controls.Add(this.dataGridViewAll);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "WinLogParser";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAll)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolStrip1;
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
        
    }
}
