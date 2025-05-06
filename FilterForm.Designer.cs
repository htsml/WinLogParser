using System.Drawing;
using System.Windows.Forms;

namespace WinLogParser
{
    partial class FilterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.CmdSave_TSBtn = new System.Windows.Forms.ToolStripButton();
            this.CmdLoad_TSBtn = new System.Windows.Forms.ToolStripButton();
            this.OpenCMDSettingForm_TSBtn = new System.Windows.Forms.ToolStripButton();
            this.ScrollMode_SplitBtn = new System.Windows.Forms.ToolStripSplitButton();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmdSave_TSBtn,
            this.CmdLoad_TSBtn,
            this.OpenCMDSettingForm_TSBtn,
            this.ScrollMode_SplitBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // CmdSave_TSBtn
            // 
            this.CmdSave_TSBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CmdSave_TSBtn.Image = ((System.Drawing.Image)(resources.GetObject("CmdSave_TSBtn.Image")));
            this.CmdSave_TSBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CmdSave_TSBtn.Name = "CmdSave_TSBtn";
            this.CmdSave_TSBtn.Size = new System.Drawing.Size(36, 22);
            this.CmdSave_TSBtn.Text = "Save";
            this.CmdSave_TSBtn.Click += new System.EventHandler(this.CmdSave_TSBtn_Click);
            // 
            // CmdLoad_TSBtn
            // 
            this.CmdLoad_TSBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CmdLoad_TSBtn.Image = ((System.Drawing.Image)(resources.GetObject("CmdLoad_TSBtn.Image")));
            this.CmdLoad_TSBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CmdLoad_TSBtn.Name = "CmdLoad_TSBtn";
            this.CmdLoad_TSBtn.Size = new System.Drawing.Size(37, 22);
            this.CmdLoad_TSBtn.Text = "Load";
            this.CmdLoad_TSBtn.Click += new System.EventHandler(this.CmdLoad_TSBtn_Click);
            // 
            // OpenCMDSettingForm_TSBtn
            // 
            this.OpenCMDSettingForm_TSBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.OpenCMDSettingForm_TSBtn.Image = ((System.Drawing.Image)(resources.GetObject("OpenCMDSettingForm_TSBtn.Image")));
            this.OpenCMDSettingForm_TSBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenCMDSettingForm_TSBtn.Name = "OpenCMDSettingForm_TSBtn";
            this.OpenCMDSettingForm_TSBtn.Size = new System.Drawing.Size(54, 22);
            this.OpenCMDSettingForm_TSBtn.Text = "Settings";
            this.OpenCMDSettingForm_TSBtn.Click += new System.EventHandler(this.OpenCMDSettingForm_TSBtn_Click);
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
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 25);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(800, 335);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 360);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FilterForm";
            this.Text = "Monitor";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton CmdSave_TSBtn;
        private ToolStripButton CmdLoad_TSBtn;
        private ToolStripButton OpenCMDSettingForm_TSBtn;
        private DataGridView dataGridView;
        private ToolStripSplitButton ScrollMode_SplitBtn;
    }
}