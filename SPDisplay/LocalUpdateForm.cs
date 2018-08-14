using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPDisplay {
    public partial class LocalUpdateForm : Form {
        private static String[] paramList;
        public LocalUpdateForm() {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e) {
            Console.WriteLine("sender" + sender);
        }

        private void m_SelectFileBtn_Click(object sender, EventArgs e) {
            ////openFileDialog1.ShowDialog();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = "c:\\";//注意这里写路径时要用c:\\而不是c:\
            openFileDialog.Filter = "jed文件|*.jed|bit文件|*.bit|所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
               string fName = openFileDialog.FileName;
                FileNameTextBox.Text = fName;
            }
        }

        private void StartBtn_Click(object sender, EventArgs e) {
            Sender s = new Sender();
            StartBtn.Enabled = true;
            try {
                s.initSerialPort(paramList[0], "115200", "none", "8", "1", paramList[1]);
                s.OpenPort();
            }
            catch (Exception es) {
                Console.WriteLine(es.ToString());
                MessageBox.Show(es.ToString());
                return;
            }
            if (FileNameTextBox.Text != null && FileNameTextBox.Text.Length > 0) {
                byte[] data = File.ReadAllBytes(FileNameTextBox.Text);
                if (data == null || data.Length == 0) {
                    return;
                }
                int datalen = data.Length;
                int counter = (data.Length / 10240)+1;
                int sendcounter = 0;
                for (int i = 0; i < counter; i++) {
                    byte[] temp = new byte[10240];
                    if (sendcounter + 10240 > datalen) {
                        Buffer.BlockCopy(data, sendcounter, temp, 0, datalen - sendcounter);
                        //Utils.dumpdata(temp, datalen - sendcounter, "data send");
                        
                        s.sp1.WriteData(temp, datalen - sendcounter);
                        sendcounter = datalen;
                        System.Threading.Thread.Sleep(100);
                    }
                    else {
                        Buffer.BlockCopy(data, sendcounter, temp, 0, 10240);
                        //Utils.dumpdata(temp, 10240, "data send");
                        sendcounter = sendcounter + 10240;
                        s.sp1.WriteData(temp, 10240);
                    }
                    //Console.WriteLine();
                    progressBar1.Value = sendcounter/(datalen/100);
                    System.Threading.Thread.Sleep(100);
                    Application.DoEvents();
                   
                }
                s.ClosePort();
                progressBar1.Value = 100;
                
            }
            StartBtn.Enabled = false;
        }

        private void LocalUpdateForm_Load(object sender, EventArgs e) {
            //强制设置通讯端口
            while (loadFile() == -1) 
            {
                DeviceSetupForm f = new DeviceSetupForm();
                f.ShowDialog();
            }


        }
        private int loadFile() {

            if (File.Exists("Port.txt")) {
                //8string readText = File.ReadAllText("open.txt");  //读取的结果包含了\r\n
                paramList = File.ReadAllLines("port.txt");
                return 0;
            }
            else {
                return -1;
            }
            
        }
    }

}
