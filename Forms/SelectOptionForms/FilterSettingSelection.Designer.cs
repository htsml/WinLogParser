
namespace WinLogParser.Utils
{
    partial class FilterSettingSelection
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
            this.HEX_Btn = new System.Windows.Forms.Button();
            this.Direction_Btn = new System.Windows.Forms.Button();
            this.Machine_Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HEX_Btn
            // 
            this.HEX_Btn.Location = new System.Drawing.Point(48, 12);
            this.HEX_Btn.Name = "HEX_Btn";
            this.HEX_Btn.Size = new System.Drawing.Size(188, 51);
            this.HEX_Btn.TabIndex = 0;
            this.HEX_Btn.Text = "HEX";
            this.HEX_Btn.UseVisualStyleBackColor = true;
            this.HEX_Btn.Click += new System.EventHandler(this.FilterHEXSetting_Btn_Click);
            // 
            // Direction_Btn
            // 
            this.Direction_Btn.Location = new System.Drawing.Point(48, 69);
            this.Direction_Btn.Name = "Direction_Btn";
            this.Direction_Btn.Size = new System.Drawing.Size(188, 51);
            this.Direction_Btn.TabIndex = 1;
            this.Direction_Btn.Text = "Direction";
            this.Direction_Btn.UseVisualStyleBackColor = true;
            this.Direction_Btn.Click += new System.EventHandler(this.FilterDirectionSetting_Btn_Click);
            // 
            // Machine_Btn
            // 
            this.Machine_Btn.Location = new System.Drawing.Point(48, 126);
            this.Machine_Btn.Name = "Machine_Btn";
            this.Machine_Btn.Size = new System.Drawing.Size(188, 51);
            this.Machine_Btn.TabIndex = 2;
            this.Machine_Btn.Text = "Machine";
            this.Machine_Btn.UseVisualStyleBackColor = true;
            this.Machine_Btn.Click += new System.EventHandler(this.Machine_Btn_Click);
            // 
            // FilterSettingSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 187);
            this.Controls.Add(this.Machine_Btn);
            this.Controls.Add(this.Direction_Btn);
            this.Controls.Add(this.HEX_Btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterSettingSelection";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select";
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button HEX_Btn;
        private System.Windows.Forms.Button Direction_Btn;
        private System.Windows.Forms.Button Machine_Btn;
    }
}