using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPDisplay {
    public partial class AboutForm : Form {
        public AboutForm() {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e) {
           AboutLabel.Text= "版本：" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + "\n";
        }
    }
}
