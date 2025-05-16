
namespace WinLogParser.Utils
{
    partial class FilterLoadSelection
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
            this.LoadLog_Btn = new System.Windows.Forms.Button();
            this.LoadColumns_Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoadLog_Btn
            // 
            this.LoadLog_Btn.Location = new System.Drawing.Point(48, 12);
            this.LoadLog_Btn.Name = "LoadLog_Btn";
            this.LoadLog_Btn.Size = new System.Drawing.Size(188, 51);
            this.LoadLog_Btn.TabIndex = 0;
            this.LoadLog_Btn.Text = "Load Log";
            this.LoadLog_Btn.UseVisualStyleBackColor = true;
            this.LoadLog_Btn.Click += new System.EventHandler(this.LoadLog_Btn_Click);
            // 
            // LoadColumns_Btn
            // 
            this.LoadColumns_Btn.Location = new System.Drawing.Point(48, 82);
            this.LoadColumns_Btn.Name = "LoadColumns_Btn";
            this.LoadColumns_Btn.Size = new System.Drawing.Size(188, 51);
            this.LoadColumns_Btn.TabIndex = 1;
            this.LoadColumns_Btn.Text = "Load Columns";
            this.LoadColumns_Btn.UseVisualStyleBackColor = true;
            this.LoadColumns_Btn.Click += new System.EventHandler(this.LoadColumns_Btn_Click);
            // 
            // FilterLoadSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 146);
            this.Controls.Add(this.LoadColumns_Btn);
            this.Controls.Add(this.LoadLog_Btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterLoadSelection";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoadLog_Btn;
        private System.Windows.Forms.Button LoadColumns_Btn;
    }
}