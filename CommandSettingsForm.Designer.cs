using System.Drawing;
using System.Windows.Forms;

namespace WinLogParser
{
    partial class CommandSettingsForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.Cmd_Value_TxtBox = new System.Windows.Forms.TextBox();
            this.Cmd_Index_TxtBox = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.Apply_Btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Title_TxtBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "CMD Value : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 59);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(80, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "CMD Index : ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cmd_Value_TxtBox
            // 
            this.Cmd_Value_TxtBox.Location = new System.Drawing.Point(88, 32);
            this.Cmd_Value_TxtBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cmd_Value_TxtBox.Name = "Cmd_Value_TxtBox";
            this.Cmd_Value_TxtBox.Size = new System.Drawing.Size(86, 21);
            this.Cmd_Value_TxtBox.TabIndex = 2;
            // 
            // Cmd_Index_TxtBox
            // 
            this.Cmd_Index_TxtBox.Location = new System.Drawing.Point(88, 57);
            this.Cmd_Index_TxtBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cmd_Index_TxtBox.Name = "Cmd_Index_TxtBox";
            this.Cmd_Index_TxtBox.Size = new System.Drawing.Size(86, 21);
            this.Cmd_Index_TxtBox.TabIndex = 3;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 100);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(243, 278);
            this.dataGridView.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Field Setting";
            // 
            // Apply_Btn
            // 
            this.Apply_Btn.Location = new System.Drawing.Point(180, 5);
            this.Apply_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Apply_Btn.Name = "Apply_Btn";
            this.Apply_Btn.Size = new System.Drawing.Size(75, 18);
            this.Apply_Btn.TabIndex = 6;
            this.Apply_Btn.Text = "Apply";
            this.Apply_Btn.UseVisualStyleBackColor = true;
            this.Apply_Btn.Click += new System.EventHandler(this.Apply_Btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 11);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Title : ";
            // 
            // Title_TxtBox
            // 
            this.Title_TxtBox.Location = new System.Drawing.Point(88, 9);
            this.Title_TxtBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Title_TxtBox.Name = "Title_TxtBox";
            this.Title_TxtBox.Size = new System.Drawing.Size(86, 21);
            this.Title_TxtBox.TabIndex = 8;
            // 
            // CommandSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 388);
            this.Controls.Add(this.Title_TxtBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Apply_Btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.Cmd_Index_TxtBox);
            this.Controls.Add(this.Cmd_Value_TxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CommandSettingsForm";
            this.Text = "CommandSettingsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox Cmd_Value_TxtBox;
        private TextBox Cmd_Index_TxtBox;
        private DataGridView dataGridView;
        private Label label3;
        private Button Apply_Btn;
        private Label label4;
        private TextBox Title_TxtBox;
    }
}