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
    public partial class RemoteVersion : Form {
        public RemoteVersion() {
            InitializeComponent();
        }

        private void RemoteVersion_Shown(object sender, EventArgs e) {
            bool result = 
                FTPHelper.FtpDownload("version.txt", "version.txt", true, null);
            if (result) {
             String[]   VersionList = File.ReadAllLines("version.txt");
                remoteVersionLabel.Text = "远程版本"+VersionList[0];
            }
            else {
                remoteVersionLabel.Text = "获取远程版本失败";
            }
        }
    }
}
