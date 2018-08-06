namespace SPDisplay {
    partial class ThreadForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.m_StatusBar = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.m_PercentLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_StatusBar
            // 
            this.m_StatusBar.Location = new System.Drawing.Point(170, 189);
            this.m_StatusBar.Name = "m_StatusBar";
            this.m_StatusBar.Size = new System.Drawing.Size(338, 28);
            this.m_StatusBar.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(134, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // m_PercentLabel
            // 
            this.m_PercentLabel.AutoSize = true;
            this.m_PercentLabel.Location = new System.Drawing.Point(313, 196);
            this.m_PercentLabel.Name = "m_PercentLabel";
            this.m_PercentLabel.Size = new System.Drawing.Size(23, 15);
            this.m_PercentLabel.TabIndex = 2;
            this.m_PercentLabel.Text = "0%";
            // 
            // ThreadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.m_PercentLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.m_StatusBar);
            this.Name = "ThreadForm";
            this.Text = "ThreadForm";
            this.Load += new System.EventHandler(this.ThreadForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar m_StatusBar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label m_PercentLabel;
    }
}