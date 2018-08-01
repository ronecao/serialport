using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPDisplay {
    class Frame {
        public int line;
        public int location;
        public String content;
        public Frame(int l,int loc,String text ) {
            line = l;
            location = loc;
            content = text;
        }
    }
}
