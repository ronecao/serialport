namespace SPDisplay
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.硬件HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartCollectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置硬件参数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.在线更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.检查程序版本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.检查网络版本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于软件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Dialog = new System.Windows.Forms.OpenFileDialog();
            this.chartForm2 = new _5SeriesChart.ChartForm();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripReceivedBytesLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(915, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(43, 24);
            this.toolStripButton1.Text = "开始";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.设置ToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(112, 52);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.startToolStripMenuItem.Text = "start";
            // 
            // 设置ToolStripMenuItem1
            // 
            this.设置ToolStripMenuItem1.Name = "设置ToolStripMenuItem1";
            this.设置ToolStripMenuItem1.Size = new System.Drawing.Size(111, 24);
            this.设置ToolStripMenuItem1.Text = "设置";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.OperationToolStripMenuItem,
            this.硬件HToolStripMenuItem,
            this.工具TToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(915, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFileToolStripMenuItem,
            this.SaveFileToolStripMenuItem,
            this.ExitFileToolStripMenuItem});
            this.FileToolStripMenuItem.Enabled = false;
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.FileToolStripMenuItem.Text = "文件(F)";
            // 
            // OpenFileToolStripMenuItem
            // 
            this.OpenFileToolStripMenuItem.Name = "OpenFileToolStripMenuItem";
            this.OpenFileToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.OpenFileToolStripMenuItem.Text = "打开文件";
            this.OpenFileToolStripMenuItem.Click += new System.EventHandler(this.端口ToolStripMenuItem_Click);
            // 
            // SaveFileToolStripMenuItem
            // 
            this.SaveFileToolStripMenuItem.Name = "SaveFileToolStripMenuItem";
            this.SaveFileToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.SaveFileToolStripMenuItem.Text = "保存文件";
            // 
            // ExitFileToolStripMenuItem
            // 
            this.ExitFileToolStripMenuItem.Name = "ExitFileToolStripMenuItem";
            this.ExitFileToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.ExitFileToolStripMenuItem.Text = "退出文件";
            // 
            // OperationToolStripMenuItem
            // 
            this.OperationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZoomInToolStripMenuItem,
            this.ZoomOutToolStripMenuItem,
            this.ShowAllToolStripMenuItem});
            this.OperationToolStripMenuItem.Name = "OperationToolStripMenuItem";
            this.OperationToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.OperationToolStripMenuItem.Text = "操作(O)";
            // 
            // ZoomInToolStripMenuItem
            // 
            this.ZoomInToolStripMenuItem.Name = "ZoomInToolStripMenuItem";
            this.ZoomInToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.ZoomInToolStripMenuItem.Text = "放大";
            // 
            // ZoomOutToolStripMenuItem
            // 
            this.ZoomOutToolStripMenuItem.Name = "ZoomOutToolStripMenuItem";
            this.ZoomOutToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.ZoomOutToolStripMenuItem.Text = "缩小";
            // 
            // ShowAllToolStripMenuItem
            // 
            this.ShowAllToolStripMenuItem.Name = "ShowAllToolStripMenuItem";
            this.ShowAllToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.ShowAllToolStripMenuItem.Text = "全显";
            // 
            // 硬件HToolStripMenuItem
            // 
            this.硬件HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartCollectToolStripMenuItem,
            this.设置硬件参数ToolStripMenuItem});
            this.硬件HToolStripMenuItem.Name = "硬件HToolStripMenuItem";
            this.硬件HToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.硬件HToolStripMenuItem.Text = "硬件(H)";
            // 
            // StartCollectToolStripMenuItem
            // 
            this.StartCollectToolStripMenuItem.Name = "StartCollectToolStripMenuItem";
            this.StartCollectToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.StartCollectToolStripMenuItem.Text = "开始采集";
            // 
            // 设置硬件参数ToolStripMenuItem
            // 
            this.设置硬件参数ToolStripMenuItem.Name = "设置硬件参数ToolStripMenuItem";
            this.设置硬件参数ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.设置硬件参数ToolStripMenuItem.Text = "设置硬件参数";
            this.设置硬件参数ToolStripMenuItem.Click += new System.EventHandler(this.设置硬件参数ToolStripMenuItem_Click);
            // 
            // 工具TToolStripMenuItem
            // 
            this.工具TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.在线更新ToolStripMenuItem,
            this.检查程序版本ToolStripMenuItem,
            this.检查网络版本ToolStripMenuItem});
            this.工具TToolStripMenuItem.Name = "工具TToolStripMenuItem";
            this.工具TToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.工具TToolStripMenuItem.Text = "工具(T)";
            // 
            // 在线更新ToolStripMenuItem
            // 
            this.在线更新ToolStripMenuItem.Name = "在线更新ToolStripMenuItem";
            this.在线更新ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.在线更新ToolStripMenuItem.Text = "在线更新";
            // 
            // 检查程序版本ToolStripMenuItem
            // 
            this.检查程序版本ToolStripMenuItem.Name = "检查程序版本ToolStripMenuItem";
            this.检查程序版本ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.检查程序版本ToolStripMenuItem.Text = "检查程序版本";
            // 
            // 检查网络版本ToolStripMenuItem
            // 
            this.检查网络版本ToolStripMenuItem.Name = "检查网络版本ToolStripMenuItem";
            this.检查网络版本ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.检查网络版本ToolStripMenuItem.Text = "检查网络版本";
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于软件ToolStripMenuItem});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.帮助HToolStripMenuItem.Text = "帮助(H)";
            // 
            // 关于软件ToolStripMenuItem
            // 
            this.关于软件ToolStripMenuItem.Name = "关于软件ToolStripMenuItem";
            this.关于软件ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.关于软件ToolStripMenuItem.Text = "关于软件";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Dialog
            // 
            this.Dialog.FileName = "openFileDialog1";
            // 
            // chartForm2
            // 
            this.chartForm2.Location = new System.Drawing.Point(6, 59);
            this.chartForm2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartForm2.Name = "chartForm2";
            this.chartForm2.Size = new System.Drawing.Size(902, 255);
            this.chartForm2.TabIndex = 5;
            this.chartForm2.Load += new System.EventHandler(this.chartForm2_Load);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripReceivedBytesLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 520);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(915, 25);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(80, 20);
            this.toolStripStatusLabel1.Text = "Received:";
            // 
            // toolStripReceivedBytesLabel
            // 
            this.toolStripReceivedBytesLabel.Name = "toolStripReceivedBytesLabel";
            this.toolStripReceivedBytesLabel.Size = new System.Drawing.Size(115, 20);
            this.toolStripReceivedBytesLabel.Text = "ReceivedBytes";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 545);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.chartForm2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.OpenFileDialog Dialog;

        private _5SeriesChart.ChartForm chartForm2;
        private System.Windows.Forms.ToolStripMenuItem SaveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OperationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ZoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ZoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 硬件HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StartCollectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置硬件参数ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 在线更新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 检查程序版本ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 检查网络版本ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于软件ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripReceivedBytesLabel;
    }
}

