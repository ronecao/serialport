using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            portctl = new ProcessPort(this);
            
            portctl.scan();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
    }
}
