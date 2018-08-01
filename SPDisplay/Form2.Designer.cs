namespace SPDisplay
{
    partial class Form2
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.databitText = new System.Windows.Forms.TextBox();
            this.brateText = new System.Windows.Forms.TextBox();
            this.portlistCombo = new System.Windows.Forms.ComboBox();
            this.stopBitCombo = new System.Windows.Forms.ComboBox();
            this.PairtyCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "端口号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "波特率";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "校验位";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "数据位";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "停止位";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(124, 277);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 5;
            this.saveBtn.Text = "保存";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // databitText
            // 
            this.databitText.Enabled = false;
            this.databitText.Location = new System.Drawing.Point(110, 174);
            this.databitText.Name = "databitText";
            this.databitText.Size = new System.Drawing.Size(157, 25);
            this.databitText.TabIndex = 7;
            this.databitText.TextChanged += new System.EventHandler(this.databitText_TextChanged);
            // 
            // brateText
            // 
            this.brateText.Enabled = false;
            this.brateText.Location = new System.Drawing.Point(110, 98);
            this.brateText.Name = "brateText";
            this.brateText.Size = new System.Drawing.Size(157, 25);
            this.brateText.TabIndex = 9;
            this.brateText.TextChanged += new System.EventHandler(this.brateText_TextChanged);
            // 
            // portlistCombo
            // 
            this.portlistCombo.FormattingEnabled = true;
            this.portlistCombo.Location = new System.Drawing.Point(110, 56);
            this.portlistCombo.Name = "portlistCombo";
            this.portlistCombo.Size = new System.Drawing.Size(157, 23);
            this.portlistCombo.TabIndex = 11;
            this.portlistCombo.SelectedIndexChanged += new System.EventHandler(this.portlistCombo_SelectedIndexChanged);
            // 
            // stopBitCombo
            // 
            this.stopBitCombo.Enabled = false;
            this.stopBitCombo.FormattingEnabled = true;
            this.stopBitCombo.Items.AddRange(new object[] {
            "1",
            "2",
            "1.5"});
            this.stopBitCombo.Location = new System.Drawing.Point(110, 214);
            this.stopBitCombo.Name = "stopBitCombo";
            this.stopBitCombo.Size = new System.Drawing.Size(157, 23);
            this.stopBitCombo.TabIndex = 12;
            this.stopBitCombo.SelectedIndexChanged += new System.EventHandler(this.stopBitCombo_SelectedIndexChanged);
            // 
            // PairtyCombo
            // 
            this.PairtyCombo.Enabled = false;
            this.PairtyCombo.FormattingEnabled = true;
            this.PairtyCombo.Items.AddRange(new object[] {
            "none",
            "even",
            "odd",
            "mark",
            "space"});
            this.PairtyCombo.Location = new System.Drawing.Point(110, 136);
            this.PairtyCombo.Name = "PairtyCombo";
            this.PairtyCombo.Size = new System.Drawing.Size(157, 23);
            this.PairtyCombo.TabIndex = 13;
            this.PairtyCombo.SelectedIndexChanged += new System.EventHandler(this.PairtyCombo_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 387);
            this.Controls.Add(this.PairtyCombo);
            this.Controls.Add(this.stopBitCombo);
            this.Controls.Add(this.portlistCombo);
            this.Controls.Add(this.brateText);
            this.Controls.Add(this.databitText);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox databitText;
        private System.Windows.Forms.TextBox brateText;
        private System.Windows.Forms.ComboBox portlistCombo;
        private System.Windows.Forms.ComboBox stopBitCombo;
        private System.Windows.Forms.ComboBox PairtyCombo;
    }
}