using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using _5SeriesChart;
using static SPDisplay.ProtocolControl;

namespace SPDisplay
{
    public partial class Form1 : Form {
        public Label[] labelArray;
        private Sender sender1;
        private static String[] paramList;
        private static String[] m_labelList;
        private ArrayList dataList;

        private ulong m_totalPoints;//总数据量
        private double m_begain = 0;//放大开始值
        private double m_end = 0; // 放大结束值
        private int m_ZoomStep = 0;//当前放大等级

        private bool m_HasMachine = true;
        private bool m_Continue = true;

        private TextBox[] LineGroupTextBox = new TextBox[6];





        internal _5SeriesChart.ChartProperties chartpro = new _5SeriesChart.ChartProperties();
        SynchronizationContext m_SyncContext = null;
        public Form1()
        {
            InitializeComponent();
            ///chartpro.SetAxisXGridEnable(true);
            //chartpro.SetAXisXGridInterval(1);

            chartForm2.chartpro.SetAxisXGridEnable(true);
            chartForm2.chartpro.SetAXisXGridInterval(1);


            /*chartForm1.chartpro.SetAxisXGridEnable(true);
            chartForm1.chartpro.SetAXisXGridInterval(5);*/

            //初始设置每行行标默认值
            LoadLabelFile();
            chartForm2.chartpro.L1LabelContext = m_labelList[0];
            chartForm2.chartpro.L15LabelContext = m_labelList[1];
            chartForm2.chartpro.L2LabelContext = m_labelList[2];
            chartForm2.chartpro.L3LabelContext = m_labelList[3];
            chartForm2.chartpro.L4LabelContext = m_labelList[4];
            chartForm2.chartpro.L5LabelContext = m_labelList[5];

            chartForm2.SetProperities();

            chartForm2.L1DoubleClickedEvent += Line1ChangeNmae;
            chartForm2.L15DoubleClickedEvent += Line15ChangeName;
            chartForm2.L2DoubleClickedEvent += Line2ChangeName;
            chartForm2.L3DoubleClickedEvent += Line3ChangeName;
            chartForm2.L4DoubleClickedEvent += Line4ChangeName;
            chartForm2.L5DoubleClickedEvent += Line5ChangeName;
            //chartForm2.ReLoadProperities();
            //chartForm2.SetProperities(chartpro);

            //Control.CheckForIllegalCrossThreadCalls = false;
            m_SyncContext = SynchronizationContext.Current;
            timer1.Enabled = false;
            sender1 = new Sender();
            loadFile();
            try {
                //sender1.initSerialPort(paramList[0], paramList[1], paramList[2], paramList[3], paramList[4]);
                sender1.initSerialPort(paramList[0], "115200", "none", "8", "1", paramList[1]);
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
            LineGroupTextBox[0] = L1TextBox;
            LineGroupTextBox[1] = L15TextBox;
            LineGroupTextBox[2] = L2TextBox;
            LineGroupTextBox[3] = L3TextBox;
            LineGroupTextBox[4] = L4TextBox;
            LineGroupTextBox[5] = L5TextBox;


        }

        /*******************************主页面控件响应函数****************************************************/
        //关闭事件
        private void frmFileDisposal_Closed(object sender, System.EventArgs e) {
            System.Environment.Exit(System.Environment.ExitCode);
            this.Dispose();
            this.Close();
        }
        //加载事件
        private void Form1_Load(object sender, EventArgs e)
        {
            //选择放大 响应函数
            chartForm2.selectionchangedevent += selctionChanged;
            timer1.Stop();
            //processfind();

        }
        //选择放大 响应函数
        private void selctionChanged(object sender, ChartEventArgs e) {
            // chartForm2.ResetScale();
            if (e != null) {
                if (e.ZoomEnd - e.ZoomBegin < 5) {
                    chartForm2.ResetScale();
                }
                else {
                    m_begain = e.ZoomBegin;
                    m_end = e.ZoomEnd;
                }
            }

           
        }
        //开始操作
        private void StartButton_Clicked(object sender, EventArgs e) {
            int i = 2147483647;
            if (!(changeText(toolStripTextBox1) && changeText(toolStripTextBox2))) {
                MessageBox.Show("请输入数据");
                return;
            }
            byte[] reqdata = packReqData();
            if (reqdata == null || reqdata.Length == 0) {
                MessageBox.Show("检查数据");
                return;
            }
            chartformclear();
            statusStrip1.Items[0].Text = "开始发送数据";
            statusStrip1.Items[3].Text = "";
            sender1.callback = updateRecvBytes;
            sender1.finishCallback = finshrecv;
            int ret = sender1.OpenPort();
            //status bar 错误显示
            updateErrorListCallback = updateErrorList;
            if (ret != 0) {
                switch (ret) {
                    case -1:
                        updateErrorList("端口访问被拒绝");
                        break;
                    case -2:
                        updateErrorList("无此端口");
                        break;
                    case -3:
                        updateErrorList("端口打开失败，其他错误");
                        break;
                }
                return;
            }
            DissableEnableAll(false);


            int d = sender1.SendRequest(ProtocolControl.REQTYPE.DATA, reqdata);
            if (d == -1) {
                updateErrorList("发送数据失败");
                statusStrip1.Items[0].Text = "发送数据失败";
                DissableEnableAll(true);
                return;
            }
          
            /*ArrayList aaaa= sender1.Receivedatatest();
            sender1.ClosePort();
            toolStripButton1.Enabled = true;

            if (aaaa != null) {
                DrawItems(aaaa);
            }*/


            //while (true) {
            Thread t = new Thread(new ThreadStart(sender1.ThreadReceiveData));
            t.Start();
            /* ArrayList a = sender1.Receivedata();
             // }
             sender1.ClosePort();
             toolStripButton1.Enabled = true;

             if (a != null) {
                 DrawItems(a);
             }*/
        }
        //硬件函数菜单
        private void 设置硬件参数ToolStripMenuItem_Click(object sender, EventArgs e) {
            DeviceSetupForm form2 = new DeviceSetupForm();
            form2.ShowDialog();
            loadFile();
            try {
                sender1.initSerialPort(paramList[0], "115200", "none", "8", "1", paramList[1]);
            }
            catch (Exception es) {
            }
            
        }
        private void ContinueButton_Clicked(object sender, EventArgs e) {
            if (!(changeText(toolStripTextBox1) && changeText(toolStripTextBox2))) {
                MessageBox.Show("请输入数据");
                return;
            }
            byte[] reqdata = packReqData();
            if (reqdata == null || reqdata.Length == 0) {
                MessageBox.Show("检查数据");
                return;
            }
            
            m_Continue = true;
            while(m_Continue){
                ArrayList a = new ArrayList();
                chartformclear();

               byte[] req= Packrequest(REQTYPE.DATA, reqdata);
                int status;
                byte[] receivedata = sendReceive(req, out status);
                if (receivedata != null && receivedata.Length > 0) {
                    a = Downunpackdata(receivedata, (ulong)receivedata.Length);
                    if (a != null && a.Count > 0) {
                      
                        DrawItems(a);
                    }
                    
                }
                Application.DoEvents();
            }
        }
        //value 1
        private void Value1TextChanged(object sender, EventArgs e) {
            Console.WriteLine(toolStripTextBox1.Text);
            changeText(toolStripTextBox1);
        }
        //value 2
        private void Value2TextChanged(object sender, EventArgs e) {
            Console.WriteLine(toolStripTextBox2.Text);
            changeText(toolStripTextBox2);
        }    
        private void 关于软件ToolStripMenuItem_Click(object sender, EventArgs e) {
          bool ddd=  FTPHelper.FtpDownload("index.txt", "index.txt", true, progressupdate);
            Console.WriteLine("ftp result {0}", ddd);
        }
        public void progressupdate(int total, int current) {
            Console.WriteLine("total i" + total + " current" + current);
        }

        private void ZoomInBtn_Click(object sender, EventArgs e) {
            zoomin();
        }

        private void zoomOutBtn_Click(object sender, EventArgs e) {
            //chartForm2.ResetScale();
            zoomout();
        }

        private void textBox1_KeyPressed(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Enter) {
                Console.WriteLine("Enter:{0}",textBox1.Text);
                byte[] data = Utils.HexToBytes(textBox1.Text);
                //Utils.dumpdata(data, data.Length, "dddd");
                textBox1.Text = "数据已经发送";
                int status;
                byte[] receivedata = sendReceive(data, out status);
                if (status == 0 && receivedata != null) {
                    string s = Utils.HextString(receivedata, receivedata.Length, true);
                    textBox1.Text = s;
                }
                
                // }


                //textBox1.Text = s;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e) {
            Console.WriteLine("Text changed"+textBox1.Text);
            textBox1.Text = textBox1.Text.Replace('\r', ' ');
        }

        private void L1TextBox_KeyPressed(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Enter) {
                if (L1TextBox.Text == null || L1TextBox.Text.Length == 0) {
                    MessageBox.Show("请输入行名");
                    return;
                }
                LoadLabelFile();
                m_labelList[0] = L1TextBox.Text;
                saveLabelFile();
                chartForm2.SetL1Context(L1TextBox.Text);
                L1TextBox.Visible = false;
            }
            if (e.KeyChar == (char)Keys.Escape) {
                L1TextBox.Visible = false;
                L1TextBox.Text = "";
            }
        }

        private void L15TextBox_KeyPressed(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Enter) {
                if (L15TextBox.Text == null || L15TextBox.Text.Length == 0) {
                    MessageBox.Show("请输入行名");
                    return;
                }
                LoadLabelFile();
                m_labelList[1] = L15TextBox.Text;
                saveLabelFile();
                chartForm2.SetL15Context(L15TextBox.Text);
                L15TextBox.Visible = false;
            }
            if (e.KeyChar == (char)Keys.Escape) {
                L15TextBox.Visible = false;
                L15TextBox.Text = "";
            }
        }
        private void L2TextBox_KeyPressed(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Enter) {
                if (L2TextBox.Text == null || L2TextBox.Text.Length == 0) {
                    MessageBox.Show("请输入行名");
                    return;
                }
                LoadLabelFile();
                m_labelList[2] = L2TextBox.Text;
                saveLabelFile();
                chartForm2.SetL2Context(L2TextBox.Text);
                L2TextBox.Visible = false;
            }
            if (e.KeyChar == (char)Keys.Escape) {
                L2TextBox.Visible = false;
                L2TextBox.Text = "";
            }
        }

        private void L3TextBox_KeyPressed(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Enter) {
                if (L3TextBox.Text == null || L3TextBox.Text.Length == 0) {
                    MessageBox.Show("请输入行名");
                    return;
                }
                LoadLabelFile();
                m_labelList[3] = L3TextBox.Text;
                saveLabelFile();
                chartForm2.SetL3Context(L3TextBox.Text);
                L3TextBox.Visible = false;
            }
            if (e.KeyChar == (char)Keys.Escape) {
                L3TextBox.Visible = false;
                L3TextBox.Text = "";
            }
        }

        private void L4TextBox_KeyPressed(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Enter) {
                if (L4TextBox.Text == null || L4TextBox.Text.Length == 0) {
                    MessageBox.Show("请输入行名");
                    return;
                }
                LoadLabelFile();
                m_labelList[4] = L4TextBox.Text;
                saveLabelFile();
                chartForm2.SetL4Context(L4TextBox.Text);
                L4TextBox.Visible = false;
            }
            if (e.KeyChar == (char)Keys.Escape) {
                L4TextBox.Visible = false;
                L4TextBox.Text = "";
            }
        }
        private void L5TextBox_KeyPressed(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Enter) {
                if (L5TextBox.Text == null || L5TextBox.Text.Length == 0) {
                    MessageBox.Show("请输入行名");
                    return;
                }
                LoadLabelFile();
                m_labelList[5] = L5TextBox.Text;
                saveLabelFile();
                chartForm2.SetL5Context(L5TextBox.Text);
                L5TextBox.Visible = false;
            }
            if (e.KeyChar == (char)Keys.Escape) {
                L5TextBox.Visible = false;
                L5TextBox.Text = "";
            }
        }
        private void ZoomInToolStripMenuItem_Click(object sender, EventArgs e) {
            zoomin();
        }

        private void ZoomOutToolStripMenuItem_Click(object sender, EventArgs e) {
            zoomout();
        }

        private void ShowAllToolStripMenuItem_Click(object sender, EventArgs e) {
            chartForm2.ResetScale();
            m_begain = 0;
            m_end = 0;
        }

        private void StartCollectToolStripMenuItem_Click(object sender, EventArgs e) {
            StartButton_Clicked(sender, e);
        }


        private byte[] sendReceive(byte[] data, out int errorcocde) {
            if (data == null || data.Length == 0) {
                errorcocde = -4;
                return null;
            }
            int ret = sender1.OpenPort();
            if (ret != 0) {
               errorcocde = ret;
              
                return null;
            }

            ret = sender1.sp1.WriteData(data, data.Length);
            //sender1.sp1.sp1.ReadTimeout = 500;

            if (ret != 0) {
               errorcocde = -3;
               return null;
            }

            //while (true) {
            byte []a  = sender1.Receivedatatest();
            sender1.ClosePort();
            errorcocde = 0;
            return a;
           
        }
        private void commandText_KeyPressed(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Enter) {
                Console.WriteLine("Enter:{0}", commandText.Text);
                String dstr = commandText.Text.Replace(" ", "");
                byte[] data = Utils.HexToBytes(dstr);
                if (data == null) {
                    MessageBox.Show("数据格式错误");
                }
                //Utils.dumpdata(data, data.Length, "dddd");
                int status;
                byte[] receivedata = sendReceive(data,out status);
                if (receivedata != null) {
                    string s = Utils.HextString(receivedata, receivedata.Length, true);
                    textBox1.Text = s;
                }
                else {
                    MessageBox.Show("接收数据错误");
                }
                commandText.Text = "";
            }
        }

        private void cmdSendBtn_Click(object sender, EventArgs e) {
            Console.WriteLine("Enter:{0}", commandText.Text);
            String dstr = commandText.Text.Replace(" ", "");
            byte[] data = Utils.HexToBytes(dstr);
            if (data == null) {
                MessageBox.Show("数据格式错误");
            }
            //Utils.dumpdata(data, data.Length, "dddd");
            int status;
            byte[] receivedata = sendReceive(data, out status);
            if (receivedata != null) {
                string s = Utils.HextString(receivedata, receivedata.Length, true);
                textBox1.Text = s;
            }
            else {
                MessageBox.Show("接收数据错误");
            }
            commandText.Text = "";
        }


        //计时器，如果没找到下位机持续运行
        private void timer1_Tick(object sender, EventArgs e) {
            Console.WriteLine("tick");
            processfind();

        }

        
        private void 本地更新ToolStripMenuItem_Click(object sender, EventArgs e) {
            LocalUpdateForm upd = new LocalUpdateForm();
            upd.ShowDialog();
        }

        private void StopStartBtn_Click(object sender, EventArgs e) {
            m_Continue = false;
        }
        //全显
        private void ShowAllBtn_Clicked(object sender, EventArgs e) {
            chartForm2.ResetScale();
            m_end = 0;
            m_begain = 0;
        }

        private void 检查程序版本ToolStripMenuItem_Click(object sender, EventArgs e) {
            byte[] request = ProtocolControl.Packrequest(REQTYPE.VERSION, new byte[] { 1, 1 });
            int status;
           byte []versionbytes = sendReceive(request, out status);
            if (status == 0)
            {
                int loc=FindDownHeaderVersion(versionbytes, versionbytes.Length);
                if (loc > 0) {
                    loc = loc + 3;
                    byte var1 = versionbytes[loc];
                    byte var2 = versionbytes[loc+1];
                    MessageBox.Show("下位机版本号" + var1 + "." + var2);
                }
            }
        }

        private void SaveFileToolStripMenuItem_Click(object sender, EventArgs e) {
            if (Sender.m_ReceivedData.Length != 0) {
                System.DateTime currentTime = new System.DateTime();
                currentTime = System.DateTime.Now;
                String Datatime = currentTime.ToString().Replace('/', '-');
                 Datatime = Datatime.Replace(' ', '-');
                Datatime = Datatime.Replace(':', '-');
                string Filename = "d:\\Data" + Datatime + ".dat";
                FileStream fs1 = new FileStream(Filename, FileMode.OpenOrCreate);


                fs1.Write(Sender.m_ReceivedData, 0, Sender.m_ReceivedData.Length);
                fs1.Flush();
                fs1.Close();
            }
            
            
        }
        //打开文件
        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";//注意这里写路径时要用c:\\而不是c:\
            openFileDialog.Filter = "dat文件|*.dat|所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 0;
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                string fName = openFileDialog.FileName;
               
                byte[] data = File.ReadAllBytes(fName);
                ArrayList a = Downunpackdata(data, (ulong)data.Length);
             
                DrawItems(a);
                //Utils.dumpdata(data, data.Length, "data");
                //isFileHaveName = true;
                //richTextBox1.Text = fileOpen.ReadFile();
                //richTextBox1.AppendText("");
            }
        }
        //退出文件
        private void ExitFileToolStripMenuItem_Click(object sender, EventArgs e) {
           chartformclear();
        }

        private void 关于软件ToolStripMenuItem_Click_1(object sender, EventArgs e) {
            AboutForm aboutform = new AboutForm();
            aboutform.Show();
        }

        private void 检查网络版本ToolStripMenuItem_Click(object sender, EventArgs e) {
            RemoteVersion v = new RemoteVersion();
            v.ShowDialog();
        }


        /*******************************主程序函数****************************************************/
        //握手协议
        private void processfind() {
            DissableEnableAll(false);
            byte[] data;
            REQTYPE type;
            byte[] ret;
            byte[] temp = Utils.getRadomByte();
            byte[] key = new byte[2];
            key[0] = (byte)~temp[0];
            key[1] = (byte)~temp[1];
            key = Utils.changeHigh(key);
            Utils.dumpdata(key, 2, "key after");
            int status;
            data = sendReceive(ProtocolControl.Packrequest(REQTYPE.FIND, temp), out status);
            if (data == null || data.Length == 0) {
                return;
            }
            ret = UnpackHandShake(data, out type);
            if (ret != null && ret.Length > 0) {
                Utils.dumpdata(ret, ret.Length, "unpack");
                if (ret[0] == key[0] && ret[1] == key[1]) {

                    Console.WriteLine("find machine");
                    if (type == REQTYPE.LOCALUPDATE) {
                        Console.WriteLine("start local update");
                        LocalUpdateForm d = new LocalUpdateForm();
                        d.ShowDialog();
                        m_HasMachine = true;
                        timer1.Stop();
                    }
                }
                else {
                    if (type == REQTYPE.LOCALUPDATE) {
                        Console.WriteLine("start local update");
                    }
                    Console.WriteLine("not found machine");

                }

                DissableEnableAll(true);
            }

        }
        //程序和线程中发现错误，显示出来
        public void updateErrorList(String s) {

            if (statusStrip1.InvokeRequired)//如果调用控件的线程和创建创建控件的线程不是同一个则为True
            {


                while (!this.statusStrip1.IsHandleCreated) {
                    //解决窗体关闭时出现“访问已释放句柄“的异常
                    if (this.statusStrip1.Disposing || statusStrip1.IsDisposed)
                        return;
                }
                UpdateErrorList d = new UpdateErrorList(updateErrorList);
                this.statusStrip1.Invoke(d, new object[] { s });
            }
            else {
                statusStrip1.Items[3].Text = s;
            }


        }

        private void normalprocess() {
            int ret = sender1.OpenPort();
            if (ret != 0) {
                return;
            }
            StartButton.Enabled = false;


            sender1.SendRequest(ProtocolControl.REQTYPE.DATA, new byte[] { 0x01, 0xff });

            //while (true) {
            ArrayList a = sender1.Receivedata();
            // }
            sender1.ClosePort();
            StartButton.Enabled = true;

            if (a != null) {
                //  DrawItems(a);
            }
        }
        // 线程数据更新函数
        public void showvalue(int location, String text) {

            if (statusStrip1.InvokeRequired)//如果调用控件的线程和创建创建控件的线程不是同一个则为True
            {


                while (!this.statusStrip1.IsHandleCreated) {
                    //解决窗体关闭时出现“访问已释放句柄“的异常
                    if (this.statusStrip1.Disposing || statusStrip1.IsDisposed)
                        return;
                }
                SetTextCallback d = new SetTextCallback(showvalue);
                this.statusStrip1.Invoke(d, new object[] { location, text });
            }
            else {
                this.statusStrip1.Items[location].Text = text;
                if (toolStripProgressBar1.Value + 10 < 100) {
                    toolStripProgressBar1.Value = toolStripProgressBar1.Value + 10;
                    Thread.Sleep(100);
                }
                else {
                    toolStripProgressBar1.Value = 10;
                }
                Application.DoEvents();

            }


        }

        // 线程打开开始按钮函数
        public void EnabletoolStripButton1() {
            if (InvokeRequired) {
                /*既然是外部线程，那么就没有权限访问主线程上的控件
                 * 故要主线程访问，开启一个异步委托捆绑要执行的方法
                 * 交给主线程执行
                 */
                Action ac = new Action(EnabletoolStripButton1);
                Invoke(ac); //这里执行后。则InvokeRequired就为false。因为此时已经是主线程访问当前创建的控件
            }
            else {
                StartButton.Enabled = true;
                DissableEnableAll(true);
                toolStripProgressBar1.Value = 100;
            }

        }
        //线程获取接受成功函数
        private void finshrecv(ArrayList data) {
            sender1.ClosePort();
            //toolStripButton1.Enabled = true;
            //show2();

            EnabletoolStripButton1();

            if (data != null && data.Count > 0) {
                showvalue(0, "数据接受完成");
                Utils.dumpdata(L1Control, 20, "L1");
                m_SyncContext.Post(DrawItems, data);
                dataList = data;
                return;
            }
            updateErrorList("接受的数据有问题，无法显示");
        }
        //DrawItems 重载，用来线程控制
        private void DrawItems(object state) {
            DrawItems((ArrayList)state);


        }

        private void updateRecvBytes(String msg) {
            showvalue(1, msg + " bytes");
        }
        //行标文件操作
        private void LoadLabelFile() {

            if (File.Exists("Label.txt")) {
                //8string readText = File.ReadAllText("open.txt");  //读取的结果包含了\r\n
                m_labelList = File.ReadAllLines("Label.txt");
            }
            else {
                FileStream fs1 = new FileStream("Label.txt", FileMode.OpenOrCreate);
                byte[] data = new UTF8Encoding().GetBytes("1\r\n1.5\r\n2\r\n3\r\n4\r\n5\r\n");
                fs1.Write(data, 0, data.Length);
                fs1.Flush();
                fs1.Close();
                m_labelList = File.ReadAllLines("Label.txt");
            }
        }
        private void saveLabelFile() {
            FileStream fs1 = new FileStream("Label.txt", FileMode.OpenOrCreate);
            String fileContent = "";
            foreach (String content in m_labelList) {
                fileContent = fileContent + content + "\r\n";
            }
            byte[] data = new UTF8Encoding().GetBytes(fileContent);
            fs1.Write(data, 0, data.Length);
            fs1.Flush();
            fs1.Close();
            m_labelList = File.ReadAllLines("Label.txt");
        }
        //修改输入value值如果值不合法
        private Boolean changeText(ToolStripTextBox t) {
            String texts = t.Text;
            try {
                int A = int.Parse(texts);
                if (A <= 0 || A > 255) {
                    texts = texts.Substring(0, texts.Length - 1);
                    t.Text = texts;
                    return false;
                }


            }
            catch (Exception e) {
                t.Text = "";
                return false;
            }
            return true;

        }
        //参数文件操作
        private void loadFile() {

            if (File.Exists("Port.txt")) {
                //8string readText = File.ReadAllText("open.txt");  //读取的结果包含了\r\n
                paramList = File.ReadAllLines("port.txt");
            }
            else {
                FileStream fs1 = new FileStream("port.txt", FileMode.OpenOrCreate);
                byte[] data = new UTF8Encoding().GetBytes("COM1\r\n5000\r\n");
                fs1.Write(data, 0, data.Length);
                fs1.Flush();
                fs1.Close();
                paramList = File.ReadAllLines("port.txt");
            }
        }
        private void saveFile() {
            FileStream fs1 = new FileStream("port.txt", FileMode.OpenOrCreate);
            String fileContent = "";
            foreach (String content in paramList) {
                fileContent = fileContent + content + "\r\n";
            }
            byte[] data = new UTF8Encoding().GetBytes(fileContent);
            fs1.Write(data, 0, data.Length);
            fs1.Flush();
            fs1.Close();
            paramList = File.ReadAllLines("port.txt");
        }

        private byte[] packReqData() {

            try {
                byte i = (byte)int.Parse(toolStripTextBox1.Text);
                byte j = (byte)int.Parse(toolStripTextBox2.Text);

                byte[] ret = new byte[2];
                ret[0] = i;
                ret[1] = j;
                return ret;

            }
            catch (Exception e) {
                return null;
            }


        }
        /********************************************************************************/

        /****************************显示数据部分开始*****************************************/


        /*
         * 修改行标识
         */
        public void ChangeLabe(int index) {
            // LableSet label = new LableSet(index);
            //label.ShowDialog();
            LineGroupTextBox[index].Visible = true;
            LineGroupTextBox[index].Focus();

        }
        private void Line1ChangeNmae(object sender, ChartEventArgs e) {
            ChangeLabe(0);


        }
        private void Line15ChangeName(object sender, ChartEventArgs e) {
            //chartForm2.SetL15Context("HAHAHA");
            ChangeLabe(1);
        }
        private void Line2ChangeName(object sender, ChartEventArgs e) {
            ChangeLabe(2);
        }
        private void Line3ChangeName(object sender, ChartEventArgs e) {
            ChangeLabe(3);
        }
        private void Line4ChangeName(object sender, ChartEventArgs e) {
            ChangeLabe(4);
        }
        private void Line5ChangeName(object sender, ChartEventArgs e) {
            ChangeLabe(5);
        }
        //计算放大倍数
        private ulong getZoomGap(bool zoomin) {
            ulong gap = 0;
            switch (m_ZoomStep) {
                case 0:
                case 1:
                case 2:
                    gap = m_totalPoints / 10;
                    break;
                case 3:
                case 4:
                case 5:
                    gap = 10;
                    break;
                case 6:
                case 7:
                    gap = 5;
                    break;

            }
            if (zoomin) {
                m_ZoomStep++;
                if (m_ZoomStep > 7) {
                    m_ZoomStep = 7;
                }
            }
            else {
                m_ZoomStep--;
                if (m_ZoomStep < 0) {
                    m_ZoomStep = 0;
                }
                gap = 5;
            }
            return gap;
        }
        //开启或者关闭所有按钮
        private void DissableEnableAll(bool v) {
            StartButton.Enabled = v;
            ContinueStartBtn.Enabled = v;
            stopBtn.Enabled = v;
            toolStripTextBox1.Enabled = v;
            toolStripSeparator1.Enabled = v;
            toolStripTextBox2.Enabled = v;
            ZoomInBtn.Enabled = v;
            zoomOutBtn.Enabled = v;
            ShowAllBtn.Enabled = v;
        }
        /*
         * 放大
         */
        private void zoomin() {
            if (this.m_ZoomStep == 0) {
                chartForm2.ForceUIRefresh();
            }
            double gap = getZoomGap(true);//10;//m_totalPoints / 10;
            if (double.IsNaN(m_begain)) {
                m_begain = 0;
            }
            if (double.IsNaN(m_end)) {
                m_end = 0;
            }
            if (m_begain == 0 && m_end == 0) {
                chartForm2.Zoom(m_begain, m_totalPoints - gap);
                m_end = m_totalPoints - gap;
            }
            else {
                if (m_end - m_begain - gap > gap) {
                    chartForm2.Zoom(m_begain, m_end - gap);
                    m_end = m_end - gap;
                }
                else {
                    if (m_end - m_begain - 5 > 5) {
                        chartForm2.Zoom(m_begain, m_end - 5);
                        m_end = m_end - 5;
                    }
                }
            }
            Console.WriteLine("Start {0} end {1}", m_begain, m_end);

        }
        /*
         * 缩小
         */
        private void zoomout() {
            if (double.IsNaN(m_begain)) {
                m_begain = 0;
            }
            if (double.IsNaN(m_end)) {
                m_end = 0;
            }
            double gap = getZoomGap(false);//10;//m_totalPoints / 10;
            if (m_begain == 0 && m_end == 0) {

            }
            else {

                chartForm2.Zoom(m_begain, m_end + gap);
                m_end = m_end + gap;


            }

        }
        /*
         * 显示数据
         */
        private void DrawItems(ArrayList datalist) {
            DataCell cell = new DataCell();
            double basewidth = 1;
            double basewidth2 = 0.25;
            double address = 0.0;
            for (int linc = 0; linc < L1Data.Count; linc++) {
                cell = (DataCell)L1Data[linc];
                if (linc + 1 < L1Data.Count) {
                    DrawLine(cell.address, cell.datalength, cell.data, basewidth, (DataCell)L1Data[linc + 1]);
                }
                else {
                    DrawLine(cell.address, cell.datalength, cell.data, basewidth, null);
                }
                
            }

            for (int i = 0; i < datalist.Count; i++) {

                cell = (DataCell)datalist[i];
                //updatelabelfunc(cell);
                String v = Utils.HextString(cell.data, cell.datalength, true);
                int j;
                switch (cell.line) {
                    case 0x31:
                        //cell.data[3] = 0x03;
                            
                       
                        Console.WriteLine("Line1 address" + cell.address);
                        break;
                    case 0x32:
                        for (j = 0; j < cell.datalength; j++) {
                            address = cell.address * basewidth2 + j * basewidth2;
                            chartForm2.L2Add(address, cell.data[j].ToString("X2"));
                        }

                        Console.WriteLine("Line2 address" + address);
                        break;
                    case 0x33:
                        for (j = 0; j < cell.datalength; j++) {
                            address = cell.address * basewidth2 + j * basewidth2;
                            chartForm2.L3Add(address, cell.data[j].ToString("X2"));
                        }
                        Console.WriteLine("Line3 address" + cell.address);
                        break;
                    case 0x34:
                        for (j = 0; j < cell.datalength; j++) {
                            address = cell.address * basewidth2 + j * basewidth2;
                            chartForm2.L4Add(address, cell.data[j].ToString("X2"));
                        }
                        Console.WriteLine("Line4 address" + cell.address);
                        break;
                    case 0x35:
                        for (j = 0; j < cell.datalength; j++) {
                            address =  cell.address * basewidth2 + j * basewidth2;
                            chartForm2.L5Add(address, cell.data[j].ToString("X2"));
                        }
                        Console.WriteLine("Line5 address" + cell.address);
                        break;


                }
            }

            m_totalPoints = (ulong)cell.address + (ulong)cell.datalength;

        }
        /*
         * start, column number,
         * loc, byte loc in column
         * datalength total lungth;
         */
        public void DrawLine(double start, int datalength, byte[] value, double basewidth,DataCell nextCell) {
            double xgap = basewidth / (8 * 2);
            double x;
            double address;
            Console.WriteLine("start" + start + "datalength:" + datalength);
            for (int k = 0; k < datalength; k++) {
                address = 0.5+start * basewidth + k * basewidth;
                chartForm2.L05Add(address, value[k].ToString("X2"));

                if (L1Control[(int)start + k] != 0) {
                    for (int i = 0; i < 16; i++) {
                        // byte j = (byte)((byte)(k << (7 - i))>>7);
                        byte j = Utils.getbitValue(value[k], (byte)(7 - (i / 2)));//i=2468
                        byte m;
                        if (j == 0x01) {
                            m = 0x00;
                        }
                        else {
                            m = 0x01;
                        }

                        x = start * basewidth + k * 16.0 * xgap + (i) * xgap;
                        chartForm2.L1Add(x, j, " ");
                        chartForm2.L15Add(x, m, " ");
                        //Console.WriteLine(">>:" + i.ToString() + "值:" + j + "dboult:" + x);

                        i++;
                        x = start * basewidth + k * 16 * xgap + (i) * xgap;
                        if (j == 0x01) {
                            j = 0x00;
                        }
                        if (m == 0x01) {
                            m = 0x00;
                        }
                        chartForm2.L1Add(x, j, " ");
                        chartForm2.L15Add(x, m, " ");
                        //Console.WriteLine(">>:" + i.ToString() + "值:" + j + "dboult:" + x);

                    }
                }
                else {

                   
                    chartForm2.L1Add(start + k, 0, "01");
                    chartForm2.L15Add(start + k, 1, "01");
                }
               
            }
            if (nextCell != null) {
                int addgap = nextCell.address-(int)start-datalength;
                if (addgap> 0) {
                    int k = (int)start + datalength;
                    for (; k < nextCell.address; k++) {
                        if (L1Control[k] == 1) {
                            chartForm2.L1Add( k, 1, "01");
                            chartForm2.L15Add(k, 0, "01");
                        }
                    }
                }
            }
            

            //补齐高位

        }
        //清空图表
        public void chartformclear() {
            chartForm2.L05Clear();
            chartForm2.L1Clear();
            chartForm2.L15Clear();
            chartForm2.L2Clear();
            chartForm2.L3Clear();
            chartForm2.L4Clear();
            chartForm2.L5Clear();
        }

        /****************************显示数据部分结束*****************************************/


    }

}
