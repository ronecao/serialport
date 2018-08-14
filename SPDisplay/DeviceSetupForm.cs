using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using static SPDisplay.Utils;

namespace SPDisplay
{
    public partial class DeviceSetupForm : Form
    {

        Boolean formload;
        public DeviceSetupForm()
        {
            InitializeComponent();
        }
        //保存按钮事件
        private void button1_Click(object sender, EventArgs e)
        {
            saveFile();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            formload = true;
            loadFile();
        
            Console.WriteLine("length"+paramList.Length);
            port = SerialPort.GetPortNames();
           
            if (port.Length == 0) {
                port = new string[1];
                port[0] = paramList[0];
            }
            portlistCombo.DataSource = port;
            int i = 0;
            foreach (String name in port) {
                if (name.Equals(paramList[0]))
                {
                    portlistCombo.SelectedIndex = i;
                    break;
                }
                i++;
            }

            TimeoutText.Text = paramList[1];
          
            formload = false;

            
            
        }
        //读取文件
        private void loadFile() {

            if (File.Exists("Port.txt"))
            {
                //8string readText = File.ReadAllText("open.txt");  //读取的结果包含了\r\n
                paramList = File.ReadAllLines("port.txt");
            }
            else {
                FileStream fs1 = new FileStream("port.txt", FileMode.OpenOrCreate);
                byte[] data = new UTF8Encoding().GetBytes("COM1\r\n115200\r\n");
                fs1.Write(data, 0, data.Length);
                fs1.Flush();
                fs1.Close();
               paramList = File.ReadAllLines("port.txt");
            }
        }
        //保存文件
        private void saveFile() {
            FileStream fs1 = new FileStream("port.txt", FileMode.OpenOrCreate);
            String fileContent = "";
            foreach (String content in paramList){
                fileContent = fileContent + content + "\r\n";
            }
            byte[] data = new UTF8Encoding().GetBytes(fileContent);
            fs1.Write(data, 0, data.Length);
            fs1.Flush();
            fs1.Close();
            paramList = File.ReadAllLines("port.txt");
        }

        //保存
        private void TimeoutText_TextChanged(object sender, EventArgs e)
        {
            paramList[1] = TimeoutText.Text;
        }

        private void portlistCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!formload) {
                paramList[0] = port[portlistCombo.SelectedIndex];
            }
            
        }


        

      
    }
}
