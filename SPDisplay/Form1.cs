using System;
using System.Collections;
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
        private Sender sender1;

        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = false;
            sender1 = new Sender();
            sender1.initSerialPort("COM4", "115200", "none", "8", "1");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sender1.SendRequest(ProtocolControl.REQTYPE.DATA, new byte[] { 0x01, 0xef });
            sender1.OpenPort();
            //while (true) {
            ArrayList a =sender1.Receivedata();
           // }
            sender1.ClosePort();

            if (a != null) {
                DrawItems(a);
            }
        }
        private void DrawItems(ArrayList datalist) {
            for (int i = 0; i < 100; i++) {
                if (i % 2 == 0)
                    chartForm2.L1Add(i, 1, i + ".01");
                else
                    chartForm2.L1Add(i, 0, i + ".01");

                DataCell cell = (DataCell) datalist[i];
                String v = Utils.HextString(cell.data, cell.datalength, true);
                switch (cell.line) {
                    case 0x32:
                        chartForm2.L2Add(i, v);
                        break;
                    case 0x33:
                        chartForm2.L3Add(i, v);
                        break;
                    case 0x34:
                        chartForm2.L4Add(i, v);
                        break;
                    case 0x35:
                        chartForm2.L5Add(i, v);
                        break;


                }
            }
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

        private void chartForm2_Load(object sender, EventArgs e) {

        }
    }
}
