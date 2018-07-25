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

namespace SPDisplay
{
    public partial class Form1 : Form
    {
        private ProcessPort portctl;
        public Label[] labelArray;

        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            portctl = new ProcessPort(this);
            
            portctl.scan();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //test
            labelArray = new System.Windows.Forms.Label[10];
            for (int i = 0; i < labelArray.Length/2; i++)
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
            }
            
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void 端口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // portctl.switcher = !portctl.switcher;
            timer1.Enabled = !timer1.Enabled;
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
    }
}
