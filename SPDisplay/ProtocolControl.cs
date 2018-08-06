﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SPDisplay.Utils;

namespace SPDisplay {
    class ProtocolControl {

        public enum REQTYPE { NONE, ERROR, FIND, DATA, VERSION };
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
        public static void SenderRest() {
            upRecvDataCounter = 0;
            upRecvData = new ArrayList();
        }
        private static int FindDownHeader(byte[] data, int inlength) {
            byte[] a = new byte[3];
            byte[] key = new byte[] {0x87,0x7e,0x23};
             for (int i = 0; i< inlength-3; inlength++) {
                Buffer.BlockCopy(data, i, a, 0, 3);
                if (SameArray(a, a)) {
                    return i+3;
                }
            }
            return -1;
        }
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
        public static ArrayList Downunpackdata(byte[] data, int length) {

            int line;
            int loc = 0;
            int datalength = 0;
            ArrayList datavalue = new ArrayList();
            int i = FindDownHeader(data, length);
            if (i < 0) {
                updateErrorListCallback("no header found");
                return null;
            }
            i = i + 2;
            //dumpdata(data, length, "recev");
            Console.WriteLine("header end loc"+ i);
            String log = "";
            for ( ; i < length - 10; i++) {
                line = data[i];
                if (line < 0x31 || line > 0x36) {
                    i = FindeNewFrame(data, i, length);
                    if (i > 0) {
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
                //Console.WriteLine("location:" + log);
                //Console.WriteLine("location:" + loc);
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
                if (datalength + i > length|| datalength<0) {
                   
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
                    valuestr = valuestr + data[i].ToString("X2") + " ";
                    
                    
                    cell.data[j] = data[i];
                    j++;
                }

                //Console.WriteLine(" ");

                //showvalue(line, loc, valuestr);
                byte crcres = CRCSUM(cell.data, datalength);
                Console.WriteLine("CRC1" + data[i].ToString("X2") + "res:" +crcres.ToString("X2") );
                //updateErrorListCallback("CRC1" + data[i].ToString("X2") + "res:" + crcres.ToString("X2"));
                if (crcres == data[i]) {
                    datavalue.Add(cell);
                    i++;
                    i = i + 2;
                    //Console.WriteLine("******************************" + i);
                    datalength = 0;
                    loc = 0;
                    //updateErrorListCallback("Data Added");
                }
                else {
                    datavalue.Add(cell);
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

        public static REQTYPE Upunpackdata(byte[] data) {

            switch (data[3]) {
                case 0x15:
                    return REQTYPE.ERROR;
                case 0x25:
                    return REQTYPE.FIND;
                case 0x35:
                    return REQTYPE.DATA;
                case 0x45:
                    return REQTYPE.VERSION;
            }

            return REQTYPE.NONE;
        }
        //up->down
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

        public static byte[] PackResponse(REQTYPE type, byte[] value, out int datalength) {
            switch (type) {
                case REQTYPE.DATA:
                    //case REQTYPE.ERROR:
                    return PackDataAll(value, out datalength);
                case REQTYPE.VERSION:
                    return PackVersion(out datalength);
                case REQTYPE.FIND:
                    datalength = 7;
                    return PackFindRes(value);
            }
            datalength = 0;
            return null;

        }

        public static byte[] PackDataHeader() {
            return new byte[] { 0xFF, 0xFF, 0x87, 0x7E, 0x23 };
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

        private static byte[] PackVersion(out int datalength) {
            byte[] returnvalue = new byte[7];
            System.Buffer.BlockCopy(upheader, 0, returnvalue, 0, 3);
            returnvalue[3] = 0x45;
            returnvalue[4] = 0x01;
            returnvalue[5] = 0x02;
            returnvalue[6] = CRCSUM(returnvalue, 6);
            datalength = 7;
            return returnvalue;
        }

        private static byte[] PackFindRes(byte[] value) {
            byte[] returnvalue = new byte[7];
            System.Buffer.BlockCopy(upheader, 0, returnvalue, 0, 3);
            returnvalue[3] = 0x25;
            returnvalue[4] = (byte)~value[0];
            returnvalue[5] = (byte)~value[1];
            returnvalue[6] = CRCSUM(returnvalue, 6);
            return returnvalue;
        }
        private static byte[] PackDataAll(byte[] value, out int datalength) {
            int x = value[0];
            int y = value[1];
            byte[] body;
            int bodaylegth;
            byte[] datavalue = new byte[15 + 17 * x * y];
            Buffer.BlockCopy(downheader, 0, datavalue, 0, 4);
            int counter = 4;
            datavalue[counter] = 0x23;
            counter++;
            for (int i = 0; i < x; i++) {
                for (int j = 0; j < y; j++) {
                    body = PackDatabody(out bodaylegth);
                    Buffer.BlockCopy(body, 0, datavalue, counter, bodaylegth);
                    counter = counter + bodaylegth;
                }
            }
            Buffer.BlockCopy(PackDataTail(), 0, datavalue, counter, 10);
            counter = counter + 10;
            datalength = counter;
            return datavalue;
        }

        public static int SaveSenderData(byte datain) {
            //当首字符不是0xff 非法数据丢
            if (upRecvDataCounter == 0 && datain != 0x81) {
                Console.WriteLine("数据非法丢弃");
                return RECVTRACH;
            }
            upRecvData.Add(datain);
            upRecvDataCounter++;
            if (upRecvDataCounter == 3) {
                byte[] temp = new byte[upRecvData.Count];
                temp = (byte[])upRecvData.ToArray(typeof(byte));
                dumpdata(temp, temp.Length, "temp");

                if (temp[1] == 0x06 && temp[2] == 0x09) {
                    //status = recState.bodyframe;
                    Console.WriteLine("找到包头");
                    return RECVHEADER;
                }
                else {
                    upRecvData.RemoveAt(0);
                    upRecvDataCounter--;
                }
            }
            if (upRecvDataCounter == 7) {
                byte[] temp = new byte[upRecvData.Count];
                temp = (byte[])upRecvData.ToArray(typeof(byte));
                byte crc = CRCSUM(temp, 6);
                Console.Write(crc.ToString("X2"));
                if (crc == temp[6]) {
                    return RECVEND;
                }
                else {
                    SenderRest();
                    return RECVCRC;
                }
            }

            return RECVSUCC;
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
