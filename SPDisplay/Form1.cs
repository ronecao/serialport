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

namespace SPDisplay
{
    public partial class Form1 : Form
    {
        private ProcessPort portctl;
        public Label[] labelArray;
        private Sender sender1;
        private static String[] paramList;

        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = false;
            sender1 = new Sender();
            loadFile();
            try {
                sender1.initSerialPort(paramList[0], paramList[1], paramList[2], paramList[3], paramList[4]);
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
            
        }

        private void DrawItems(ArrayList datalist) {
            for (int i = 0; i < datalist.Count; i++) {
                /*if (i % 2 == 0)
                    chartForm2.L1Add(i, 1, i + ".01");
                else
                    chartForm2.L1Add(i, 0, i + ".01");
                chartForm2.L2Add(i, "00 00 00 01");
                chartForm2.L3Add(i, "00 00 00 02");
                chartForm2.L4Add(i, "00 00 00 03");
                chartForm2.L5Add(i, "00 00 00 04");*/

                DataCell cell = (DataCell) datalist[i];
                String v = Utils.HextString(cell.data, cell.datalength, true);
                switch (cell.line) {
                    case 0x31:
                        //cell.data[3] = 0x03;
                        for (int j = 0; j < cell.datalength; j++) {
                            DrawLine(cell.address,j,cell.datalength,cell.data[j]);
                        }
                        


                        Console.WriteLine("Line1 address"+cell.address);
                        break;
                    case 0x32:
                        chartForm2.L2Add(cell.address, v);
                        Console.WriteLine("Line2 address" + cell.address);
                        break;
                    case 0x33:
                        chartForm2.L3Add(cell.address, v);
                        Console.WriteLine("Line3 address" + cell.address);
                        break;
                    case 0x34:
                        chartForm2.L4Add(cell.address, v);
                        Console.WriteLine("Line4 address" + cell.address);
                        break;
                    case 0x35:
                        chartForm2.L5Add(cell.address, v);
                        Console.WriteLine("Line5 address" + cell.address);
                        break;


                }
            }
        }
        /*
         * start, column number,
         * loc, byte loc in column
         * datalength total lungth;
         */
        public void DrawLine(int start,int loc,int datalength, byte value) {
            double xgap = 1.00 / (datalength*8*2);
            double x;
            for (int i = 0; i < 16; i++) {
                // byte j = (byte)((byte)(k << (7 - i))>>7);
                byte j = Utils.getbitValue(value, (byte)(i/2));


                x = start + loc * 16.0*xgap + (i) * xgap;
                chartForm2.L1Add(x, j, "value");
                Console.WriteLine(">>:" + i.ToString() + "值:" + j + "dboult:" + x);

                i++;
                x = start + loc * 16 * xgap + (i) * xgap;
                if (j == 0x01) {
                    j = 0x00;
                }
                chartForm2.L1Add(x, j, "value");
                Console.WriteLine(">>:" + i.ToString() + "值:" + j + "dboult:" + x);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //test
            labelArray = new System.Windows.Forms.Label[10];
            byte k = 0x11;
            Console.WriteLine("value" + ((byte)(k << 3)>>7));

            k = 0x01;
            for (int i = 0; i < 8; i++) {
                byte j = Utils.getbitValue(k, (byte)i);
                Console.WriteLine("ddddd" + j);
            }
            
            //DrawLine(1, 0, 4, 0xfe);

            /*for (int i = 0; i < labelArray.Length/2; i++)
            {
                labelArray[i] = new System.Windows.Forms.Label();
                labelArray[i].AutoSize = true;
                labelArray[i].Location = new System.Drawing.Point(247, 80 + i * 50);
                labelArray[i].Name = "Label" + i;
                labelArray[i].Size = new System.Drawing.Size(55, 15);
                labelArray[i].TabIndex = 2;
                labelArray[i].Text = "label"+i;

                labelArray[i+5] = new System.Windows.Forms.Label();
                labelArray[i+5].AutoSize = true;
                labelArray[i+5].Location = new System.Drawing.Point(247 + 200, 80 + i * 50);
                labelArray[i + 5].Name = "Label" + i;
                labelArray[i + 5].Size = new System.Drawing.Size(55, 15);
                labelArray[i + 5].TabIndex = 2;
                labelArray[i + 5].Text = "label"+(i+5);
                this.Controls.Add(labelArray[i]);
                this.Controls.Add(labelArray[i+5]);
            }*/
            /*for (int i = 0; i < 100; i++) {
                if (i % 2 == 0)
                    chartForm2.L1Add(i, 1, i + ".01");
                else
                    chartForm2.L1Add(i, 0, i + ".01");
                chartForm2.L2Add(i, "B1,C2 DF");
                if (i % 3 == 0) {
                    chartForm2.L3Add(i, "B6,C3");
                }
                
                chartForm2.L4Add(i, "FF,00");
                chartForm2.L5Add(i, "FF,FF");
            }*/


        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void 端口ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            while (true) {
                int ret = sender1.OpenPort();
                if (ret != 0) {
                    return;
                }
                sender1.SendRequest(ProtocolControl.REQTYPE.DATA, new byte[] { 0x01, 0x4f });

                //while (true) {
                ArrayList a = sender1.Receivedata();
                // }
                sender1.ClosePort();
            }
           

            // portctl.switcher = !portctl.switcher;
            //timer1.Enabled = !timer1.Enabled;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("timers");
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void selectFileMenuItem_Click(object sender, EventArgs e)
        {
            
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                byte[] dd = new byte[1024 * 1024 * 2];
                String fName = Dialog.FileName;
                FileStream fs1 = new FileStream(fName, FileMode.Open);
                fs1.Read(dd, 0, dd.Length);
                Utils.dumpdata(dd, 100, "readbyt");
                portctl = new ProcessPort(this);
                byte[] v= portctl.packupload(dd, 100);
                Utils.dumpdata(v, v.Length, "vvalue");
                /*byte[] data = new UTF8Encoding().GetBytes("COM1\r\n115200\r\nnull\r\n8\r\n1\r\n");
                fs1.Write(data, 0, data.Length);
                fs1.Flush();*/
                fs1.Close();
               // paramList = File.ReadAllLines("port.txt");
            }


        }

        private void chartForm2_Load(object sender, EventArgs e) {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

        }

        private void toolStripButton1_Click(object sender, EventArgs e) {
            statusStrip1.Items[0].Text = "aaa";
            sender1.callback = updateRecvBytes;
            sender1.finishCallback = finshrecv;
            int ret = sender1.OpenPort();
            if (ret != 0) {
                return;
            }
            toolStripButton1.Enabled = false;


            sender1.SendRequest(ProtocolControl.REQTYPE.DATA, new byte[] { 0x20, 0xff });

            ArrayList aaaa= sender1.Receivedatatest();
            sender1.ClosePort();
            toolStripButton1.Enabled = true;

            if (aaaa != null) {
                DrawItems(aaaa);
            }
            

            //while (true) {
            /*Thread t = new Thread(new ThreadStart(sender1.ThreadReceiveData));
            t.Start();*/
            /* ArrayList a = sender1.Receivedata();
             // }
             sender1.ClosePort();
             toolStripButton1.Enabled = true;

             if (a != null) {
                 DrawItems(a);
             }*/
        }
        private void normalprocess() {
            int ret = sender1.OpenPort();
            if (ret != 0) {
                return;
            }
            toolStripButton1.Enabled = false;


            sender1.SendRequest(ProtocolControl.REQTYPE.DATA, new byte[] { 0x01, 0xff });

            //while (true) {
             ArrayList a = sender1.Receivedata();
             // }
             sender1.ClosePort();
             toolStripButton1.Enabled = true;

             if (a != null) {
                 DrawItems(a);
             }
        }
        private void updateRecvBytes(String msg) {
            showvalue(1, msg + " bytes");
        }

        public void showvalue( int location, String text) {

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
            }


        }

        void show2() {
            //说明的当前外部线程
            /*
             // 摘要:
        //     获取一个值，该值指示调用方在对控件进行方法调用时是否必须调用 Invoke 方法，因为调用方位于创建控件所在的线程以外的线程中。
        //
        // 返回结果:
        //     如果控件的 System.Windows.Forms.Control.Handle 是在与调用线程不同的线程上创建的（说明您必须通过 Invoke
        //     方法对控件进行调用），则为 true；否则为 false。
             */
            if (InvokeRequired) {
                /*既然是外部线程，那么就没有权限访问主线程上的控件
                 * 故要主线程访问，开启一个异步委托捆绑要执行的方法
                 * 交给主线程执行
                 */
                Action ac = new Action(show2);
                this.Invoke(ac); //这里执行后。则InvokeRequired就为false。因为此时已经是主线程访问当前创建的控件
            }
            else {
                toolStripButton1.Enabled = true;
            }
        }
        private void finshrecv(ArrayList data) {
            sender1.ClosePort();
            //toolStripButton1.Enabled = true;
            //show2();

            if (data != null) {
                //DrawItems(data);
            }
            
        }

        private void 设置硬件参数ToolStripMenuItem_Click(object sender, EventArgs e) {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            loadFile();
            sender1.initSerialPort(paramList[0], paramList[1], paramList[2], paramList[3], paramList[4]);
        }

       
        private void loadFile() {

            if (File.Exists("Port.txt")) {
                //8string readText = File.ReadAllText("open.txt");  //读取的结果包含了\r\n
                paramList = File.ReadAllLines("port.txt");
            }
            else {
                FileStream fs1 = new FileStream("port.txt", FileMode.OpenOrCreate);
                byte[] data = new UTF8Encoding().GetBytes("COM1\r\n115200\r\nnone\r\n8\r\n1\r\n");
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
    }

}
