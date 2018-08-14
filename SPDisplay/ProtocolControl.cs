using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SPDisplay.Utils;

namespace SPDisplay {
    class ProtocolControl {
        public static int TOTALADDRES = 268435455;
        public static byte[] L1Control = new byte[TOTALADDRES];
        public static ArrayList L1Data = new ArrayList();
        public enum REQTYPE { NONE, ERROR, FIND, DATA, VERSION, LOCALUPDATE };
        static readonly byte[] upheader = new byte[3] { 0x81, 0x06, 0x09 };
        static readonly byte[] downheader = new byte[4] { 0xFF, 0xFF, 0x87, 0x7E };
        static readonly byte[] downtail = new byte[3] { 0x00, 0xFF, 0xFF };
        public static readonly int RECVTRACH = 2;
        public static readonly int RECVSUCC = 0;
        public static readonly int RECVHEADER = 1;
        public static readonly int RECVEND = 3;
        public static readonly int RECVCRC = -1;

        public static int upRecvDataCounter = 0;
        public static ArrayList upRecvData = new ArrayList();

        public static int downRecvDataCounter = 0;
        public static ArrayList downRecvData = new ArrayList();
        public static int downTailCounter = 0;
        public static ArrayList downTailData = new ArrayList(10);


        //status bar 错误显示 线程调用
        public static UpdateErrorList updateErrorListCallback;


        /*
         * 重置receiver数据
         */
        public static void ReceiverRest() {
            downRecvData = new ArrayList();
            downRecvDataCounter = 0;

            downTailCounter = 0;
            downTailData = new ArrayList(10);
    }
        /*
         * 重置sender数据
         */

        public static int FindDownHeaderVersion(byte[] data, int inlength) {
            byte[] a = new byte[3];
            byte[] key = new byte[] { 0x87, 0x7e, 0x45 };
            for (int i = 0; i < inlength - 3; i++) {
                Buffer.BlockCopy(data, i, a, 0, 3);
                if (SameArray(a, key)) {
                    return i;
                }
            }
            return -1;
        }
        /*
         * 找到数据包头
         */
        private static int FindDownHeader(byte[] data, int inlength) {
            byte[] a = new byte[3];
            byte[] key = new byte[] {0x87,0x7e,0x23};
             for (int i = 0; i< inlength-3; i++) {
                Buffer.BlockCopy(data, i, a, 0, 3);
                if (SameArray(a, key)) {
                    return i;
                }
            }
            return -1;
        }
        /*
        * 找到握手包头
        */
        private static int FindDownHeaderHandShake(byte[] data, int inlength, out REQTYPE type) {
            byte[] a = new byte[3];
            byte[] key = new byte[] { 0x87, 0x7e, 03 };
            for (int i = 0; i < inlength - 3; i++) {
                Buffer.BlockCopy(data, i, a, 0, 3);
                if (SameArray(a, key)) {
                    type = REQTYPE.FIND;
                    return i+3;
                }
            }
            byte[] key2 = new byte[] { 0x87, 0x7e, 0x13 };
            for (int i = 0; i < inlength - 3; i++) {
                Buffer.BlockCopy(data, i, a, 0, 3);
                if (SameArray(a, key2)) {
                    type = REQTYPE.LOCALUPDATE;
                    return i + 3;
                }
            }
            type = REQTYPE.NONE;
            return -1;
        }
        /*
         * 查找新行数据，用于发现数据有问题
         */
        private static int FindeNewFrame(byte[] data, int start,int length) {

            byte[] temp = new byte[length];
            
            byte[] key = new byte[] { 0x87, 0x7e, 0x23 };
            long datalength = 0;
            for (int i = start; i < length - 8; i++) {
                Console.WriteLine("data[{0}] value {1}",i,data[i].ToString("X2"));
                if (data[i] >= 0x31 && data[i] <= 0x35) {
                    
                    datalength = 0;
                    datalength = datalength + data[i+5] * 256 * 256 * 256;
                    datalength = datalength + data[i+6] * 256 * 256;             
                    datalength = datalength + data[i+7] * 256;
                    datalength = datalength + data[i+8];
                    Console.WriteLine("data length"+ datalength);
                    
                    if ((i + datalength) < length && data[i+12+1 + datalength] >= 0x31 && data[i +12+1+ datalength] <= 0x35) {
                        Console.WriteLine("return i" + i);
                        return i;
                    }else{
                        try {
                            Console.WriteLine("i+datalength{0} lenght:{1} data[i+12 + datalength]{2}", i + datalength, length, data[i + 12 + datalength]);
                        }
                        catch (Exception es) {
                            
                            Console.WriteLine("i+datalength{0} lenght:{1}  ERROR:{2}", i + datalength, length,es.ToString());
                        }
                         
                    }
                   
                    
                }
            }
            return -1;
        }
        /*
         * Receiver数据解包
         */
        public static ArrayList Downunpackdata(byte[] data, ulong length) {

            int line;
            int loc = 0;
            int datalength = 0;
            int lLen = (int)length;
            ArrayList datavalue = new ArrayList();
            int i = FindDownHeader(data, (int)length);
            if (i < 0) {
                updateErrorListCallback("no header found");
                return null;
            }
            i = i + 3;
            for (int r = 0; r < TOTALADDRES; r++) {
                L1Control[r] = 0x01;
            }
            L1Data = new ArrayList();
            //dumpdata(data, length, "recev");
            Console.WriteLine("header end loc"+ i);
            String log = "";
            for ( ; i < (int)length - 10; i++) {
                line = data[i];
                if (line < 0x31 || line > 0x36) {
                    i = FindeNewFrame(data, i, (int)length);
                    if (i < lLen) {
                        line = data[i];
                        updateErrorListCallback("数据错误 line");
                    }
                    else {
                        updateErrorListCallback("数据错误 line 退出");
                        return datavalue;
                    }
                    
                
                }
                DataCell cell = new DataCell();
                cell.line = line;
               
                //Console.WriteLine("Line=" + data[i]);
                i++;
                log = data[i].ToString("X2");
                loc = loc + data[i] * 256 * 256 * 256;
                i++;
                log = log + data[i].ToString("X2");
                loc = loc + data[i] * 256 * 256;
                i++;
                log = log + data[i].ToString("X2");
                loc = loc + data[i] * 256;
                i++;
                log = log + data[i].ToString("X2");
                loc = loc + data[i];
                i++;
                cell.address = loc;
                log = data[i].ToString("X2");
                datalength = datalength + data[i] * 256 * 256 * 256;
                i++;
                log = log + data[i].ToString("X2");
                datalength = datalength + data[i] * 256 * 256;
                i++;
                log = log + data[i].ToString("X2");
                datalength = datalength + data[i] * 256;
                i++;
                log = log + data[i].ToString("X2");
                datalength = datalength + data[i];
                i++;
                if (datalength + i > lLen || datalength<0) {
                   
                        updateErrorListCallback("数据长度错误丢弃");
                    
                    continue;
                }
                cell.datalength = datalength;
                
                //Console.WriteLine("datalengt:"+log);
               // Console.WriteLine("datalenght" + datalength);
                int c = i;
                int j = 0;
                cell.data = new byte[datalength];
                String valuestr = " ";
                
                for (; i < c + datalength; i++) {
                    //Console.Write(data[i].ToString("X2"));

                    // Console.Write(" ");
                    if (line != 0x31){
                        
                            L1Control[cell.address + j] = 0;

                       
                    }
                    valuestr = valuestr + data[i].ToString("X2") + " ";
                    
                    
                    cell.data[j] = data[i];
                    j++;
                }

                //Console.WriteLine(" ");

                //showvalue(line, loc, valuestr);
                byte crcres = CRCSUM(cell.data,(int) datalength);
                Console.WriteLine("CRC1" + data[i].ToString("X2") + "res:" +crcres.ToString("X2") );
                //updateErrorListCallback("CRC1" + data[i].ToString("X2") + "res:" + crcres.ToString("X2"));
                if (crcres == data[i]) {
                    if (line == 0x31) {
                        L1Data.Add(cell);
                    }
                    else {
                        datavalue.Add(cell);
                    }

                    
                    i++;
                    i = i + 2;
                    //Console.WriteLine("******************************" + i);
                    datalength = 0;
                    loc = 0;
                    //updateErrorListCallback("Data Added");
                }
                else {
                    if (line == 0x31) {
                        L1Data.Add(cell);
                    }
                    else {
                        datavalue.Add(cell);
                    }
                    Console.WriteLine("CRCWRONG");
                    //updateErrorListCallback("Data Added with CRCERROR");
                    i++;
                    i = i + 2;
                    //Console.WriteLine("******************************" + i);
                    datalength = 0;
                    loc = 0;
                }
                    
                
               
               
            }
            return datavalue;
        }
        /*
         * 解压缩握手包
         */
        public static byte[] UnpackHandShake(byte[] data, out REQTYPE type) {
            byte[] result = new byte[2];
          int loc= FindDownHeaderHandShake(data, data.Length,out type);
            if (loc > 0 && type != REQTYPE.NONE) {
                result[0] = data[loc];
                result[1] = data[loc + 1];
            }
            else {
                return null;
            }

            return result;
        }
        //打包请求数据
        public static byte[] Packrequest(REQTYPE type, byte[] value) {
            byte[] returnvalue = new byte[7];
            returnvalue[0] = upheader[0];
            returnvalue[1] = upheader[1];
            returnvalue[2] = upheader[2];
            switch (type) {
                case REQTYPE.ERROR:
                    returnvalue[3] = 0x15;
                    returnvalue[4] = 0x00;
                    returnvalue[5] = 0x00;
                    break;
                case REQTYPE.FIND:
                    returnvalue[3] = 0x25;
                    returnvalue[4] = value[0];
                    returnvalue[5] = value[1];
                    break;
                case REQTYPE.DATA:
                    returnvalue[3] = 0x35;
                    returnvalue[4] = value[0];
                    returnvalue[5] = value[1];
                    break;
                case REQTYPE.VERSION:
                    returnvalue[3] = 0x45;
                    returnvalue[4] = value[0];
                    returnvalue[5] = value[1];
                    break;

            }
            returnvalue[6] = CRCSUM(returnvalue, 6);


            return returnvalue;
        }


        public static byte[] PackDataTail() {
            return new byte[] { 0xFF, 0xFF, 0x87, 0x7E, 0x29, 0x36, 0x00, 0x00, 0xFF, 0xFF };
        }
        public static byte[] PackDatabody(out int test) {
            int line;
            byte[] datavalue = new byte[17];
            byte[] lineadd = new byte[4];
            byte[] adddata = new byte[4];
            byte[] lengthdata = new byte[] { 0x00, 0x00, 0x00, 0x04 };
            int counter = 0;

            line = utilsrandom.Next(1, 5) + 48;

            datavalue[counter] = (byte)line;
            counter++;
            lineadd = getRadomByte();
            Buffer.BlockCopy(lineadd, 0, datavalue, counter, 4);
            counter = counter + 4;
            Buffer.BlockCopy(lengthdata, 0, datavalue, counter, 4);
            counter = counter + 4;
            adddata = getRadomByte();
            Buffer.BlockCopy(adddata, 0, datavalue, counter, 4);
            counter = counter + 4;
            datavalue[counter] = CRCSUM(datavalue, counter);
            counter++;
            Buffer.BlockCopy(downtail, 0, datavalue, counter, 3);
            counter = counter + 3;
            test = counter;
            return datavalue;
        }

       

       
    

        public static int SaveReceiverData(byte datain) {
           
            //当首字符不是0xff 非法数据丢
            if (downRecvDataCounter == 0 && datain != 0xff) {
                Console.WriteLine("数据非法丢弃"+datain.ToString("X2"));
                return RECVTRACH;
            }


           
            downRecvData.Add(datain);
            downRecvDataCounter++;
            
            if (downRecvDataCounter == 5) {
                byte[] temp = new byte[downRecvData.Count];
                temp = (byte[])downRecvData.ToArray(typeof(byte));
                Utils.dumpdata(temp, temp.Length, "temp");

                if (temp[1] == 0xff && temp[2] == 0x87 && temp[3] == 0x7e && temp[4] == 0x23) {
                    //status = recState.bodyframe;
                    Console.WriteLine("找到包头");
                    return RECVHEADER;
                }
                else {
                    downRecvData.RemoveAt(0);
                    downRecvDataCounter--;
                }
            }
            
            
            downTailData.Add(datain);
            downTailCounter++;
            if (downTailCounter == 10) {
                byte[] key = new byte[] { 0xff, 0xff, 0x87, 0x7e, 0x29, 0x36, 0x00, 0x00, 0xff, 0xff };
                byte[] values = (byte[])downTailData.ToArray(typeof(byte));
                if (SameArray(values, key)) {
                    Console.WriteLine("找到结尾了");
                    return RECVEND;
                }
                else {
                    downTailData.RemoveAt(0);
                    downTailCounter--;
                }
            }
            return RECVSUCC;
        }

    }
   

}
