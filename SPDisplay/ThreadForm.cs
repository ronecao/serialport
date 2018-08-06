using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPDisplay {
    public partial class ThreadForm : Form {
        SynchronizationContext m_SyncContext = null;
        public delegate void UPDATESTATUSDELGATEFUNC(int loc);
        int num;
        //private UPDATESTATUSDELGATEFUNC dd;
        public ThreadForm() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            m_SyncContext = SynchronizationContext.Current;
            int i;
           
            Thread t = new Thread(new ThreadStart(forloop));
            t.Start();
            /*for( i = 0; i < 100; i++) {
                m_StatusBar.Value = i;
            }*/

        }

        private void forloop() {
            
            for ( num = 0; num < 100; num++) {

                Hashtable ht = new Hashtable();
                // Thread t2 = newThread(new  m_SyncContext.Post(updateStatusBar, i);
                Thread t1 = new Thread(new ParameterizedThreadStart(Threadfunc));
                ht.Add("a", num);
                t1.Name = "label";
                t1.Start(ht);
                Thread t2 = new Thread(new ParameterizedThreadStart(Threadfunc));
                ht = new Hashtable();
                ht.Add("b", num);
                t2.Name = "percent";
                t2.Start(ht);
                Thread.Sleep(100);
                /*if (num == 99) {
                    num = 0;
                }*/
            }
        }
        public void Threadfunc(object v) {
            Hashtable d = (Hashtable)v;
            if (d["a"] != null) {
                updatePercentLabel((int)d["a"]);
                return;
            }
            if (d["b"] != null) {
                updateStatusBar((int)d["b"]);
                return;
            }

        }
        private void updatePercentLabel(int v) {
            ShowMessage();
            if (m_PercentLabel.InvokeRequired)//如果调用控件的线程和创建创建控件的线程不是同一个则为True
          {


                while (!this.m_PercentLabel.IsHandleCreated) {
                    //解决窗体关闭时出现“访问已释放句柄“的异常
                    if (this.m_PercentLabel.Disposing || m_PercentLabel.IsDisposed)
                        return;
                }
                UPDATESTATUSDELGATEFUNC d = new UPDATESTATUSDELGATEFUNC(updatePercentLabel);
                this.m_PercentLabel.Invoke(d, new object[] { v });
            }
            else {
                m_PercentLabel.Text =""+ v + "%";
            }

        }

        private void updateStatusBar(int v) {
            ShowMessage();
            if (m_StatusBar.InvokeRequired)//如果调用控件的线程和创建创建控件的线程不是同一个则为True
          {


                while (!this.m_StatusBar.IsHandleCreated) {
                    //解决窗体关闭时出现“访问已释放句柄“的异常
                    if (this.m_StatusBar.Disposing || m_StatusBar.IsDisposed)
                        return;
                }
                UPDATESTATUSDELGATEFUNC d = new UPDATESTATUSDELGATEFUNC(updateStatusBar);
                this.m_StatusBar.Invoke(d, new object[] { v});
            }
            else {
                m_StatusBar.Value = v;
            }
           
        }
        private void ShowMessage() {
            string msg = "";
            
                msg = string.Format("线程 [{0}]，实例[{1}]中num的值是[{2}]", Thread.CurrentThread.Name, this.Name, num);
                Console.WriteLine(msg);
           
           // msg = string.Format("======线程 [{0}]执行完毕======", Thread.CurrentThread.Name);
           // Console.WriteLine(msg);
        }

        private void ThreadForm_Load(object sender, EventArgs e) {

        }

       
    }
}
