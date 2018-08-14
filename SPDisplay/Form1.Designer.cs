using System.Windows.Forms;

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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.StartButton = new System.Windows.Forms.ToolStripButton();
            this.ContinueStartBtn = new System.Windows.Forms.ToolStripButton();
            this.stopBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.ZoomInBtn = new System.Windows.Forms.ToolStripButton();
            this.zoomOutBtn = new System.Windows.Forms.ToolStripButton();
            this.ShowAllBtn = new System.Windows.Forms.ToolStripButton();
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
            this.本地更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于软件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Dialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripReceivedBytesLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.commandText = new System.Windows.Forms.TextBox();
            this.chartForm2 = new _5SeriesChart.ChartForm();
            this.cmdSendBtn = new System.Windows.Forms.Button();
            this.L1TextBox = new System.Windows.Forms.TextBox();
            this.L15TextBox = new System.Windows.Forms.TextBox();
            this.L2TextBox = new System.Windows.Forms.TextBox();
            this.L3TextBox = new System.Windows.Forms.TextBox();
            this.L4TextBox = new System.Windows.Forms.TextBox();
            this.L5TextBox = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(26, 26);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartButton,
            this.ContinueStartBtn,
            this.stopBtn,
            this.toolStripTextBox1,
            this.toolStripSeparator1,
            this.toolStripTextBox2,
            this.ZoomInBtn,
            this.zoomOutBtn,
            this.ShowAllBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1173, 33);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // StartButton
            // 
            this.StartButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StartButton.Image = global::SPDisplay.Properties.Resources.PlayBTN;
            this.StartButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(30, 30);
            this.StartButton.Text = "    ";
            this.StartButton.ToolTipText = "开始";
            this.StartButton.Click += new System.EventHandler(this.StartButton_Clicked);
            // 
            // ContinueStartBtn
            // 
            this.ContinueStartBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ContinueStartBtn.Image = global::SPDisplay.Properties.Resources.cotinueBTN;
            this.ContinueStartBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ContinueStartBtn.Name = "ContinueStartBtn";
            this.ContinueStartBtn.Size = new System.Drawing.Size(30, 30);
            this.ContinueStartBtn.Text = "连续开始";
            this.ContinueStartBtn.Click += new System.EventHandler(this.ContinueButton_Clicked);
            // 
            // stopBtn
            // 
            this.stopBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopBtn.Image = global::SPDisplay.Properties.Resources.stopBtn;
            this.stopBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(30, 30);
            this.stopBtn.Text = "toolStripButton3";
            this.stopBtn.ToolTipText = "停止";
            this.stopBtn.Click += new System.EventHandler(this.StopStartBtn_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 33);
            this.toolStripTextBox1.Text = "1";
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.Value1TextChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 33);
            this.toolStripTextBox2.Text = "1";
            this.toolStripTextBox2.TextChanged += new System.EventHandler(this.Value2TextChanged);
            // 
            // ZoomInBtn
            // 
            this.ZoomInBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomInBtn.Image = global::SPDisplay.Properties.Resources.zoominbtn;
            this.ZoomInBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomInBtn.Name = "ZoomInBtn";
            this.ZoomInBtn.Size = new System.Drawing.Size(30, 30);
            this.ZoomInBtn.Text = "放大";
            this.ZoomInBtn.Click += new System.EventHandler(this.ZoomInBtn_Click);
            // 
            // zoomOutBtn
            // 
            this.zoomOutBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomOutBtn.Image = global::SPDisplay.Properties.Resources.zoomout;
            this.zoomOutBtn.ImageTransparentColor = System.Drawing.Color.LightSlateGray;
            this.zoomOutBtn.Name = "zoomOutBtn";
            this.zoomOutBtn.Size = new System.Drawing.Size(30, 30);
            this.zoomOutBtn.Text = "缩小";
            this.zoomOutBtn.Click += new System.EventHandler(this.zoomOutBtn_Click);
            // 
            // ShowAllBtn
            // 
            this.ShowAllBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ShowAllBtn.Image = global::SPDisplay.Properties.Resources.showAllbtn;
            this.ShowAllBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ShowAllBtn.Name = "ShowAllBtn";
            this.ShowAllBtn.Size = new System.Drawing.Size(30, 30);
            this.ShowAllBtn.Text = "toolStripButton2";
            this.ShowAllBtn.ToolTipText = "全显";
            this.ShowAllBtn.Click += new System.EventHandler(this.ShowAllBtn_Clicked);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.设置ToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(112, 52);
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
            this.menuStrip1.Size = new System.Drawing.Size(1173, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFileToolStripMenuItem,
            this.SaveFileToolStripMenuItem,
            this.ExitFileToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.FileToolStripMenuItem.Text = "文件(F)";
            // 
            // OpenFileToolStripMenuItem
            // 
            this.OpenFileToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.OpenFileToolStripMenuItem.Name = "OpenFileToolStripMenuItem";
            this.OpenFileToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.OpenFileToolStripMenuItem.Text = "打开文件";
            this.OpenFileToolStripMenuItem.Click += new System.EventHandler(this.OpenFileToolStripMenuItem_Click);
            // 
            // SaveFileToolStripMenuItem
            // 
            this.SaveFileToolStripMenuItem.Name = "SaveFileToolStripMenuItem";
            this.SaveFileToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.SaveFileToolStripMenuItem.Text = "保存文件";
            this.SaveFileToolStripMenuItem.Click += new System.EventHandler(this.SaveFileToolStripMenuItem_Click);
            // 
            // ExitFileToolStripMenuItem
            // 
            this.ExitFileToolStripMenuItem.Name = "ExitFileToolStripMenuItem";
            this.ExitFileToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.ExitFileToolStripMenuItem.Text = "退出文件";
            this.ExitFileToolStripMenuItem.Click += new System.EventHandler(this.ExitFileToolStripMenuItem_Click);
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
            this.ZoomInToolStripMenuItem.Click += new System.EventHandler(this.ZoomInToolStripMenuItem_Click);
            // 
            // ZoomOutToolStripMenuItem
            // 
            this.ZoomOutToolStripMenuItem.Name = "ZoomOutToolStripMenuItem";
            this.ZoomOutToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.ZoomOutToolStripMenuItem.Text = "缩小";
            this.ZoomOutToolStripMenuItem.Click += new System.EventHandler(this.ZoomOutToolStripMenuItem_Click);
            // 
            // ShowAllToolStripMenuItem
            // 
            this.ShowAllToolStripMenuItem.Name = "ShowAllToolStripMenuItem";
            this.ShowAllToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.ShowAllToolStripMenuItem.Text = "全显";
            this.ShowAllToolStripMenuItem.Click += new System.EventHandler(this.ShowAllToolStripMenuItem_Click);
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
            this.StartCollectToolStripMenuItem.Click += new System.EventHandler(this.StartCollectToolStripMenuItem_Click);
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
            this.检查网络版本ToolStripMenuItem,
            this.本地更新ToolStripMenuItem});
            this.工具TToolStripMenuItem.Name = "工具TToolStripMenuItem";
            this.工具TToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.工具TToolStripMenuItem.Text = "工具(T)";
            // 
            // 在线更新ToolStripMenuItem
            // 
            this.在线更新ToolStripMenuItem.Name = "在线更新ToolStripMenuItem";
            this.在线更新ToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.在线更新ToolStripMenuItem.Text = "在线更新";
            // 
            // 检查程序版本ToolStripMenuItem
            // 
            this.检查程序版本ToolStripMenuItem.Name = "检查程序版本ToolStripMenuItem";
            this.检查程序版本ToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.检查程序版本ToolStripMenuItem.Text = "检查程序版本";
            this.检查程序版本ToolStripMenuItem.Click += new System.EventHandler(this.检查程序版本ToolStripMenuItem_Click);
            // 
            // 检查网络版本ToolStripMenuItem
            // 
            this.检查网络版本ToolStripMenuItem.Name = "检查网络版本ToolStripMenuItem";
            this.检查网络版本ToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.检查网络版本ToolStripMenuItem.Text = "检查网络版本";
            this.检查网络版本ToolStripMenuItem.Click += new System.EventHandler(this.检查网络版本ToolStripMenuItem_Click);
            // 
            // 本地更新ToolStripMenuItem
            // 
            this.本地更新ToolStripMenuItem.Name = "本地更新ToolStripMenuItem";
            this.本地更新ToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.本地更新ToolStripMenuItem.Text = "本地更新(测试)";
            this.本地更新ToolStripMenuItem.Click += new System.EventHandler(this.本地更新ToolStripMenuItem_Click);
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
            this.关于软件ToolStripMenuItem.Click += new System.EventHandler(this.关于软件ToolStripMenuItem_Click_1);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 12000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Dialog
            // 
            this.Dialog.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripReceivedBytesLabel,
            this.toolStripProgressBar1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 695);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1173, 25);
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
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 19);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 20);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 445);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1148, 245);
            this.textBox1.TabIndex = 19;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPressed);
            // 
            // commandText
            // 
            this.commandText.Font = new System.Drawing.Font("宋体", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.commandText.Location = new System.Drawing.Point(13, 415);
            this.commandText.Name = "commandText";
            this.commandText.Size = new System.Drawing.Size(185, 21);
            this.commandText.TabIndex = 20;
            this.commandText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.commandText_KeyPressed);
            // 
            // chartForm2
            // 
            this.chartForm2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartForm2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.chartForm2.Location = new System.Drawing.Point(13, 82);
            this.chartForm2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartForm2.Name = "chartForm2";
            this.chartForm2.Size = new System.Drawing.Size(1147, 319);
            this.chartForm2.TabIndex = 5;
            // 
            // cmdSendBtn
            // 
            this.cmdSendBtn.Location = new System.Drawing.Point(204, 409);
            this.cmdSendBtn.Name = "cmdSendBtn";
            this.cmdSendBtn.Size = new System.Drawing.Size(88, 30);
            this.cmdSendBtn.TabIndex = 21;
            this.cmdSendBtn.Text = "发送";
            this.cmdSendBtn.UseVisualStyleBackColor = true;
            this.cmdSendBtn.Click += new System.EventHandler(this.cmdSendBtn_Click);
            // 
            // L1TextBox
            // 
            this.L1TextBox.Location = new System.Drawing.Point(53, 110);
            this.L1TextBox.Name = "L1TextBox";
            this.L1TextBox.Size = new System.Drawing.Size(100, 25);
            this.L1TextBox.TabIndex = 22;
            this.L1TextBox.Visible = false;
            this.L1TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.L1TextBox_KeyPressed);
            // 
            // L15TextBox
            // 
            this.L15TextBox.Location = new System.Drawing.Point(53, 168);
            this.L15TextBox.Name = "L15TextBox";
            this.L15TextBox.Size = new System.Drawing.Size(100, 25);
            this.L15TextBox.TabIndex = 23;
            this.L15TextBox.Visible = false;
            this.L15TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.L15TextBox_KeyPressed);
            // 
            // L2TextBox
            // 
            this.L2TextBox.Location = new System.Drawing.Point(53, 213);
            this.L2TextBox.Name = "L2TextBox";
            this.L2TextBox.Size = new System.Drawing.Size(100, 25);
            this.L2TextBox.TabIndex = 24;
            this.L2TextBox.Visible = false;
            this.L2TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.L2TextBox_KeyPressed);
            // 
            // L3TextBox
            // 
            this.L3TextBox.Location = new System.Drawing.Point(53, 258);
            this.L3TextBox.Name = "L3TextBox";
            this.L3TextBox.Size = new System.Drawing.Size(100, 25);
            this.L3TextBox.TabIndex = 25;
            this.L3TextBox.Visible = false;
            this.L3TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.L3TextBox_KeyPressed);
            // 
            // L4TextBox
            // 
            this.L4TextBox.Location = new System.Drawing.Point(53, 304);
            this.L4TextBox.Name = "L4TextBox";
            this.L4TextBox.Size = new System.Drawing.Size(100, 25);
            this.L4TextBox.TabIndex = 26;
            this.L4TextBox.Visible = false;
            this.L4TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.L4TextBox_KeyPressed);
            // 
            // L5TextBox
            // 
            this.L5TextBox.Location = new System.Drawing.Point(53, 350);
            this.L5TextBox.Name = "L5TextBox";
            this.L5TextBox.Size = new System.Drawing.Size(100, 25);
            this.L5TextBox.TabIndex = 27;
            this.L5TextBox.Visible = false;
            this.L5TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.L5TextBox_KeyPressed);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 720);
            this.Controls.Add(this.L5TextBox);
            this.Controls.Add(this.L4TextBox);
            this.Controls.Add(this.L3TextBox);
            this.Controls.Add(this.L2TextBox);
            this.Controls.Add(this.L15TextBox);
            this.Controls.Add(this.L1TextBox);
            this.Controls.Add(this.cmdSendBtn);
            this.Controls.Add(this.commandText);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.chartForm2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Closed += new System.EventHandler(this.frmFileDisposal_Closed);
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
        private System.Windows.Forms.ToolStripButton StartButton;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripButton ZoomInBtn;
        private System.Windows.Forms.ToolStripButton zoomOutBtn;

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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripReceivedBytesLabel;

        private System.Windows.Forms.TextBox textBox1;
        private TextBox commandText;
        private ToolStripMenuItem 本地更新ToolStripMenuItem;
        private ToolStripButton ContinueStartBtn;
        private ToolStripButton stopBtn;
        private ToolStripButton ShowAllBtn;
        private ToolStripProgressBar toolStripProgressBar1;
        private ToolStripMenuItem 关于软件ToolStripMenuItem;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private Button cmdSendBtn;
        private TextBox L1TextBox;
        private TextBox L15TextBox;
        private TextBox L2TextBox;
        private TextBox L3TextBox;
        private TextBox L4TextBox;
        private TextBox L5TextBox;
    }
}

