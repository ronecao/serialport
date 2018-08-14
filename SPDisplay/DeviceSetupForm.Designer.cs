namespace SPDisplay
{
    partial class DeviceSetupForm
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
            this.saveBtn = new System.Windows.Forms.Button();
            this.TimeoutText = new System.Windows.Forms.TextBox();
            this.portlistCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "端口号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "读取超时";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(128, 97);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 5;
            this.saveBtn.Text = "保存";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // TimeoutText
            // 
            this.TimeoutText.Location = new System.Drawing.Point(110, 62);
            this.TimeoutText.Name = "TimeoutText";
            this.TimeoutText.Size = new System.Drawing.Size(157, 25);
            this.TimeoutText.TabIndex = 9;
            this.TimeoutText.TextChanged += new System.EventHandler(this.TimeoutText_TextChanged);
            // 
            // portlistCombo
            // 
            this.portlistCombo.FormattingEnabled = true;
            this.portlistCombo.Location = new System.Drawing.Point(110, 27);
            this.portlistCombo.Name = "portlistCombo";
            this.portlistCombo.Size = new System.Drawing.Size(157, 23);
            this.portlistCombo.TabIndex = 11;
            this.portlistCombo.SelectedIndexChanged += new System.EventHandler(this.portlistCombo_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 143);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.portlistCombo);
            this.Controls.Add(this.TimeoutText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "设置硬件参数";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox TimeoutText;
        private System.Windows.Forms.ComboBox portlistCombo;
    }
}