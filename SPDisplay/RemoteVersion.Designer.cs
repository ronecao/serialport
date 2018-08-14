namespace SPDisplay {
    partial class RemoteVersion {
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
            this.remoteVersionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // remoteVersionLabel
            // 
            this.remoteVersionLabel.AutoSize = true;
            this.remoteVersionLabel.Location = new System.Drawing.Point(210, 91);
            this.remoteVersionLabel.Name = "remoteVersionLabel";
            this.remoteVersionLabel.Size = new System.Drawing.Size(82, 15);
            this.remoteVersionLabel.TabIndex = 1;
            this.remoteVersionLabel.Text = "获取信息中";
            // 
            // RemoteVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 207);
            this.Controls.Add(this.remoteVersionLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RemoteVersion";
            this.Text = "RemoteVersion";
            this.Shown += new System.EventHandler(this.RemoteVersion_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label remoteVersionLabel;
    }
}