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
            checkText.Text = paramList[2];
            databitText.Text = paramList[3];
            stopbitText.Text = paramList[4];
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

        private void checkText_TextChanged(object sender, EventArgs e)
        {
            paramList[2] = checkText.Text;
        }

        private void databitText_TextChanged(object sender, EventArgs e)
        {
            paramList[3] = databitText.Text;
        }

        private void stopbitText_TextChanged(object sender, EventArgs e)
        {
            paramList[4] = stopbitText.Text;
        }
    }
}
