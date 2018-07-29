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
    public partial class Form2 : Form
    {

        Boolean formload;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFile();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

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

            brateText.Text = paramList[1];
            //checkText.Text = paramList[2];
            switch (paramList[2]) {
                case "none":
                    PairtyCombo.SelectedIndex = 0;
                    break;
                case "even":
                    PairtyCombo.SelectedIndex = 1;
                    break;
                case "odd":
                    PairtyCombo.SelectedIndex = 2;
                    break;
                case "mark":
                    PairtyCombo.SelectedIndex = 3;
                    break;
                case "space":
                    PairtyCombo.SelectedIndex = 4;
                    break;
                default:
                    PairtyCombo.SelectedIndex = 0;
                    break;
            }

            databitText.Text = paramList[3];
            //stopbitText.Text = paramList[4];
            switch (paramList[4]) {
                case "1":
                    stopBitCombo.SelectedIndex = 0;
                    break;
                case "2":
                    stopBitCombo.SelectedIndex = 1;
                    break;
                case "3":
                    stopBitCombo.SelectedIndex = 2;
                    break;
                default:
                    stopBitCombo.SelectedIndex = 0;
                    break;
            }
            formload = false;

            
            
        }
        private void loadFile() {

            if (File.Exists("Port.txt"))
            {
                //8string readText = File.ReadAllText("open.txt");  //读取的结果包含了\r\n
                paramList = File.ReadAllLines("port.txt");
            }
            else {
                FileStream fs1 = new FileStream("port.txt", FileMode.OpenOrCreate);
                byte[] data = new UTF8Encoding().GetBytes("COM1\r\n115200\r\nnull\r\n8\r\n1\r\n");
                fs1.Write(data, 0, data.Length);
                fs1.Flush();
                fs1.Close();
               paramList = File.ReadAllLines("port.txt");
            }
        }
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

        private void brateText_TextChanged(object sender, EventArgs e)
        {
            paramList[1] = brateText.Text;
        }

        private void portlistCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!formload) {
                paramList[0] = port[portlistCombo.SelectedIndex];
            }
            
        }


        private void databitText_TextChanged(object sender, EventArgs e)
        {
            paramList[3] = databitText.Text;
        }

        private void PairtyCombo_SelectedIndexChanged(object sender, EventArgs e) {
            if (!formload) {
                switch (PairtyCombo.SelectedIndex) {
                    case 0:
                        paramList[2] = "none";
                        break;
                    case 1:
                        paramList[2] = "even";
                        break;
                    case 2:
                        paramList[2] = "odd";
                        break;
                    case 3:
                        paramList[2] = "mark";
                        break;
                    case 4:
                        paramList[2] = "space";
                        break;
                    default:
                        paramList[2] = "none";
                        break;
                }
                
            }
        }

        private void stopBitCombo_SelectedIndexChanged(object sender, EventArgs e) {
            switch (stopBitCombo.SelectedIndex) {
                case 0:
                    paramList[4] = "1";//1
                    break;
                case 1:
                    paramList[4] = "2";//2
                    break;
                case 2:
                    paramList[4] = "3";//1.5
                    break;
               
            }
        }
    }
}
