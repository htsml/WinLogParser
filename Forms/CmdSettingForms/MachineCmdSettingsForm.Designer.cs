using System.Drawing;
using System.Windows.Forms;

namespace WinLogParser
{
    partial class MachineCmdSettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.From_TxtBox = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.Apply_Btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Title_TxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Cmd_TxtBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "From : ";
            // 
            // From_TxtBox
            // 
            this.From_TxtBox.Location = new System.Drawing.Point(72, 40);
            this.From_TxtBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.From_TxtBox.Name = "From_TxtBox";
            this.From_TxtBox.Size = new System.Drawing.Size(128, 25);
            this.From_TxtBox.TabIndex = 2;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(14, 130);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(278, 472);
            this.dataGridView.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Field Setting";
            // 
            // Apply_Btn
            // 
            this.Apply_Btn.Location = new System.Drawing.Point(206, 6);
            this.Apply_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Apply_Btn.Name = "Apply_Btn";
            this.Apply_Btn.Size = new System.Drawing.Size(86, 30);
            this.Apply_Btn.TabIndex = 6;
            this.Apply_Btn.Text = "Apply";
            this.Apply_Btn.UseVisualStyleBackColor = true;
            this.Apply_Btn.Click += new System.EventHandler(this.Apply_Btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 14);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(48, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Title : ";
            // 
            // Title_TxtBox
            // 
            this.Title_TxtBox.Location = new System.Drawing.Point(72, 11);
            this.Title_TxtBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Title_TxtBox.Name = "Title_TxtBox";
            this.Title_TxtBox.Size = new System.Drawing.Size(128, 25);
            this.Title_TxtBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "CMD : ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cmd_TxtBox
            // 
            this.Cmd_TxtBox.Location = new System.Drawing.Point(72, 69);
            this.Cmd_TxtBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cmd_TxtBox.Name = "Cmd_TxtBox";
            this.Cmd_TxtBox.Size = new System.Drawing.Size(128, 25);
            this.Cmd_TxtBox.TabIndex = 3;
            // 
            // MachineCmdSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 613);
            this.Controls.Add(this.Title_TxtBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Apply_Btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.Cmd_TxtBox);
            this.Controls.Add(this.From_TxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MachineCmdSettingsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Machine CMD Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CommandSettingsForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox From_TxtBox;
        private DataGridView dataGridView;
        private Label label3;
        private Button Apply_Btn;
        private Label label4;
        private TextBox Title_TxtBox;
        private Label label2;
        private TextBox Cmd_TxtBox;
    }
}