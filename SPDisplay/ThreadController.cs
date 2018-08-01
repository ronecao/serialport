using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPDisplay {
    class ThreadController {
       //public delegate void ThreadCallBackDelegate(string msg);
        public ThreadController() {
        }
        private void ThreadCallBack(string msg) {
            Console.WriteLine("CallBack:" + msg);
        }
    }
   
    
}
