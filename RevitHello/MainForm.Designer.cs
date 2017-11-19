namespace RevitHello
{
    partial class MainForm
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
            this.btn_ver = new System.Windows.Forms.Button();
            this.text_info = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_ver
            // 
            this.btn_ver.Location = new System.Drawing.Point(34, 24);
            this.btn_ver.Name = "btn_ver";
            this.btn_ver.Size = new System.Drawing.Size(163, 38);
            this.btn_ver.TabIndex = 0;
            this.btn_ver.Text = "version";
            this.btn_ver.UseVisualStyleBackColor = true;
            this.btn_ver.Click += new System.EventHandler(this.btn_ver_Click);
            // 
            // text_info
            // 
            this.text_info.Location = new System.Drawing.Point(263, 24);
            this.text_info.Name = "text_info";
            this.text_info.Size = new System.Drawing.Size(298, 21);
            this.text_info.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 435);
            this.Controls.Add(this.text_info);
            this.Controls.Add(this.btn_ver);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Revit控件窗口";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ver;
        private System.Windows.Forms.TextBox text_info;
    }
}