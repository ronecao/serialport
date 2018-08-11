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

namespace SPDisplay {
    public partial class LableSet : Form {
        private String[] labelList;
        public int m_line;
        public LableSet(int line) {
            InitializeComponent();
            m_line = line;
        }

        private void button1_Click(object sender, EventArgs e) {
            if (NameTextbox.Text == null && NameTextbox.Text.Length == 0) {
                return;
            }
            
            saveLabelFile();
            Close();
        }

        private void LableSet_Load(object sender, EventArgs e) {
            LoadLabelFile();
        }
        private void LoadLabelFile() {

            if (File.Exists("Label.txt")) {
                //8string readText = File.ReadAllText("open.txt");  //读取的结果包含了\r\n
                labelList = File.ReadAllLines("Label.txt");
            }
            else {
                FileStream fs1 = new FileStream("Label.txt", FileMode.OpenOrCreate);
                byte[] data = new UTF8Encoding().GetBytes("1\r\n1.5\r\n2\r\n3\r\n4\r\n5\r\n");
                fs1.Write(data, 0, data.Length);
                fs1.Flush();
                fs1.Close();
                labelList = File.ReadAllLines("Label.txt");
            }
        }
        private void saveLabelFile() {
            FileStream fs1 = new FileStream("Label.txt", FileMode.OpenOrCreate);
            String fileContent = "";
            foreach (String content in labelList) {
                fileContent = fileContent + content + "\r\n";
            }
            byte[] data = new UTF8Encoding().GetBytes(fileContent);
            fs1.Write(data, 0, data.Length);
            fs1.Flush();
            fs1.Close();
            labelList = File.ReadAllLines("Label.txt");
        }

        private void NameTextbox_TextChanged(object sender, EventArgs e) {
            labelList[m_line] = NameTextbox.Text;
        }
    }
}
