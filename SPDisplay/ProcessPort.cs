
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SPDisplay
{

    

    class ProcessPort
    {
        enum recState { startframe =1, bodyframe,endframe };
        public string[] g_ports;

        int Baudrate = 9600;
        //String Port = "COM1";
        String Parity = "none";
        int Stopbits = 1;
        int Databits = 8;
        int WriteTimout = 500;
        int ReadTimeout = 5000;
        byte[] startendframe = new byte[5];
        private Form1 mainform;
        SerialPort sp1;


        public ProcessPort( Form1 form){

            System.Console.WriteLine("port");
            g_ports = SerialPort.GetPortNames();

            this.mainform = form;



            int i = 1230;
            byte[] intBuff = BitConverter.GetBytes(i); // 将 int 转换成字节数组
            dumpdata(intBuff, 4, "int123");
            i = BitConverter.ToInt32(intBuff, 0);
            Console.WriteLine("i ="+i);

        }

        public void dumpdata(byte[] b, int length, String title) {
            Console.WriteLine(title + "lengght"+ length);
            for (int i = 0; i < length; i++){
                Console.Write(b[i].ToString("X2"));
                Console.Write(" ");
                if ((i+1) % 16 == 0)
                {
                    Console.WriteLine(" ");
                }
       
            }
            Console.WriteLine(" ");
        }

        public void scan() {
            /*for (int i = 0; i < g_ports.Length; i++){
               int k= findPorts(i);
                System.Console.WriteLine(" " + g_ports[i] + ": result:" + k);
            }*/
            sp1 = openport("COM4");
            for (int i = 0; i < 10; i++)
            {
                this.mainform.labelArray[i].Text = "Waiting Data";
            }
            Thread t = new Thread(new ThreadStart(dofun));
            t.Start();


        }
        public void dofun() {

            while (true)
            {
                down("COM4", sp1);
                //Thread.Sleep(50);
            }
        }
        public SerialPort openport(String Portname)
        {
            SerialPort sp1 = new SerialPort();
            sp1.BaudRate = Baudrate;
            sp1.PortName = Portname;

            switch (Parity.ToLower())
            {
                case "none":
                    sp1.Parity = System.IO.Ports.Parity.None;
                    break;
                case "even":
                    sp1.Parity = System.IO.Ports.Parity.Even;
                    break;
                case "odd":
                    sp1.Parity = System.IO.Ports.Parity.Odd;
                    break;
                case "mark":
                    sp1.Parity = System.IO.Ports.Parity.Mark;
                    break;
                case "space":
                    sp1.Parity = System.IO.Ports.Parity.Space;
                    break;
                default:
                    sp1.Parity = System.IO.Ports.Parity.None;
                    break;
            }
            sp1.DataBits = Databits;


            switch (Stopbits)
            {
                case 0:
                    sp1.StopBits = System.IO.Ports.StopBits.None;
                    break;
                case 1:
                    sp1.StopBits = System.IO.Ports.StopBits.One;
                    break;
                case 2:
                    sp1.StopBits = System.IO.Ports.StopBits.Two;
                    break;
                case 3:
                    sp1.StopBits = System.IO.Ports.StopBits.OnePointFive;
                    break;
                default:
                    sp1.StopBits = System.IO.Ports.StopBits.None;
                    break;
            }




            Byte[] srcBuff_1 = new byte[] { 0x31, 0x33 };
            try
            {
                sp1.Open();
            }
            catch (Exception e)
            {
                if (e is System.UnauthorizedAccessException)
                {
                    System.Console.WriteLine("Scanning " + sp1.PortName + " - Opening Port get Access Denied exception: " + e.Message);
                }
                else if (e is System.IO.IOException)
                {
                    System.Console.WriteLine("Scanning " + sp1.PortName + " - Opening Port get Port not exist exception: " + e.Message);
                }
                else
                {
                    System.Console.WriteLine("Scanning " + sp1.PortName + " - Opening Port get exception: " + e.Message);
                }

                return null; //openerror
            }
            return sp1;
        }

        public int down(String portname, SerialPort sp1)
        {
            Boolean secondTap;
            byte[] header = new byte[5];
            ArrayList body = new ArrayList();
            byte[] tail = new byte[5];
            recState status = recState.startframe;//1 start frame, 2 body, 3 end frame

            secondTap = false;

            ArrayList data = new ArrayList();
            sp1.WriteTimeout = WriteTimout;//500;

            sp1.ReadTimeout = ReadTimeout;//2500;

            byte dataresult = 0;
            int counter = 0;
            while (true){
                try
                {
                    dataresult = (byte)sp1.ReadByte();

                }catch (System.TimeoutException e){


                    break;
                }
                //当首字符不是0xff 非法数据丢
                if (counter == 0 && dataresult != 0xff){
                    Console.WriteLine("数据不对");
                    continue;
                }
                data.Add(dataresult);
                counter++;
                if (counter == 5){
                    byte[] temp = new byte[data.Count];
                    temp = (byte[])data.ToArray(typeof(byte));
                    dumpdata(temp, temp.Length, "temp");

                    if (temp[1] == 0xff && temp[2] == 0x87 && temp[3] == 0x7e && temp[4] == 0x23)
                    {
                        status = recState.bodyframe;
                    }
                    else {
                        data.RemoveAt(0);
                        counter--;
                    }
                }
                if (counter >= 15) {
                    byte[] temp = new byte[data.Count];
                    temp = (byte[])data.ToArray(typeof(byte));
                    if (temp[counter - 10] == 0xff && temp[counter - 9] == 0xff && temp[counter - 8] == 0x87 && temp[counter - 7] == 0x7e && temp[counter - 6] == 0x29 &&
                    temp[counter - 5] == 0x36 && temp[counter - 4] == 0x00 && temp[counter - 3] == 0x00 && temp[counter - 2] == 0xff && temp[counter - 1] == 0xff)
                    {

                        Console.WriteLine("找到结尾了");
                        break;
                    }

                }
                    
                
               


            }
            byte[] newdata = new byte[data.Count];
            newdata = (byte[])data.ToArray(typeof(byte));
            dumpdata(newdata, newdata.Length, "receiveddata");
            unpackdata(newdata, newdata.Length);



            return -3;

        }

        delegate void SetTextCallback(int line, int location, String text);

        public void showvalue(int line, int location, String text)
        {
            int labeindex = -1;
            switch (line)
            {
                case 49:
                    if (location == 32)
                    {
                        labeindex = 0;
                    }
                    else {
                        labeindex = 5;
                    }
                    break;
                case 50:
                    if (location == 32)
                    {
                        labeindex = 1;
                    }
                    else
                    {
                        labeindex = 6;
                    }
                    break;
                case 51:
                    if (location == 32)
                    {
                        labeindex = 2;
                    }
                    else
                    {
                        labeindex = 7;
                    }
                    break;
                case 52:
                    if (location == 32)
                    {
                        labeindex = 3;
                    }
                    else
                    {
                        labeindex = 8;
                    }
                    break;
                case 53:
                    if (location == 32)
                    {
                        labeindex = 4;
                    }
                    else
                    {
                        labeindex = 9;
                    }
                    break;
            }
            if (labeindex != -1) {
                if (this.mainform.labelArray[labeindex].InvokeRequired)//如果调用控件的线程和创建创建控件的线程不是同一个则为True
                {

                    
                    while (!this.mainform.labelArray[labeindex].IsHandleCreated)
                    {
                        //解决窗体关闭时出现“访问已释放句柄“的异常
                        if (this.mainform.labelArray[labeindex].Disposing || this.mainform.labelArray[labeindex].IsDisposed)
                            return;
                    }
                    SetTextCallback d = new SetTextCallback(showvalue);
                    this.mainform.labelArray[labeindex].Invoke(d, new object[] { line, location, text });
                }
                else
                {
                    this.mainform.labelArray[labeindex].Text = text;
                }


            }
        }


        public void unpackdata(byte[] data, int length){

            int line;
            int loc = 0;
            int datalength = 0;
            
            ArrayList datavalue = new ArrayList();

            for (int i = 5; i < length - 10; i++){
                line = data[i];
                Console.WriteLine("Line=" + data[i]);
                i++;
                loc = loc + data[i] * 256 * 256 * 256;
                i++;
                loc = loc + data[i] * 256 * 256;
                i++;
                loc = loc + data[i] * 256;
                i++;
                loc = loc + data[i];
                i++;
                Console.WriteLine("location:" + loc);


                datalength = datalength + data[i] * 256 * 256 * 256;
                i++;
                datalength = datalength + data[i] * 256 * 256;
                i++;
                datalength = datalength + data[i] * 256;
                i++;
                datalength = datalength + data[i];
                i++;

                Console.WriteLine("datalenght" + datalength);
                int c = i;
                String valuestr = " ";
                for (; i < c + datalength; i++)
                {  
                    Console.Write(data[i].ToString("X2"));

                    Console.Write(" ");
                    valuestr = valuestr + data[i].ToString("X2") + " ";
                    if ((i + 1) % 16 == 0)
                    {
                        Console.WriteLine(" ");
                    }
                }
                Console.WriteLine(" ");

                showvalue(line, loc, valuestr);

                Console.WriteLine("CRC1"+data[i].ToString("X2"));
                i++;
                Console.WriteLine("CRC2" + data[i].ToString("X2"));
                i++;
                i = i + 2;
                Console.WriteLine("******************************" + i);
                datalength = 0;
                loc = 0;







            }
        }

        public int findPorts(int i)
        {
            Boolean secondTap;
            SerialPort sp1 = new SerialPort();


            //todo need get config from chipdna.config.xml
            //sp1.BaudRate = 9600;
            sp1.BaudRate = Baudrate;
            sp1.PortName = g_ports[i];

            switch (Parity.ToLower())
            {
                case "none":
                    sp1.Parity = System.IO.Ports.Parity.None;
                    break;
                case "even":
                    sp1.Parity = System.IO.Ports.Parity.Even;
                    break;
                case "odd":
                    sp1.Parity = System.IO.Ports.Parity.Odd;
                    break;
                case "mark":
                    sp1.Parity = System.IO.Ports.Parity.Mark;
                    break;
                case "space":
                    sp1.Parity = System.IO.Ports.Parity.Space;
                    break;
                default:
                    sp1.Parity = System.IO.Ports.Parity.None;
                    break;
            }

            //sp1.DataBits = 8;
            sp1.DataBits = Databits;


            switch (Stopbits)
            {
                case 0:
                    sp1.StopBits = System.IO.Ports.StopBits.None;
                    break;
                case 1:
                    sp1.StopBits = System.IO.Ports.StopBits.One;
                    break;
                case 2:
                    sp1.StopBits = System.IO.Ports.StopBits.Two;
                    break;
                case 3:
                    sp1.StopBits = System.IO.Ports.StopBits.OnePointFive;
                    break;
                default:
                    sp1.StopBits = System.IO.Ports.StopBits.None;
                    break;
            }




            Byte[] srcBuff_1 = new byte[] { 0x31, 0x33 };
            secondTap = false;
            try
            {
                sp1.Open();
            }
            catch (Exception e)
            {
                if (e is System.UnauthorizedAccessException)
                {
                    System.Console.WriteLine("Scanning " + sp1.PortName + " - Opening Port get Access Denied exception: " + e.Message);
                }
                else if (e is System.IO.IOException)
                {
                    System.Console.WriteLine("Scanning " + sp1.PortName + " - Opening Port get Port not exist exception: " + e.Message);
                }
                else
                {
                    System.Console.WriteLine("Scanning " + sp1.PortName + " - Opening Port get exception: " + e.Message);
                }

                return -2; //openerror
            }
            ArrayList data = new ArrayList();
            sp1.WriteTimeout = WriteTimout;//500;

            sp1.ReadTimeout = ReadTimeout;//2500;


            try
            {
                sp1.Write(srcBuff_1, 0, srcBuff_1.Length);
            }
            catch (TimeoutException e)
            {

                System.Console.WriteLine("Scanning " + sp1.PortName + " - write data first try timeout: " + e.Message);
                sp1.Close();
                return -1;
            }

            byte dataresult;
            dataresult = 0;
            int counter = 0;
            while (true)
            {
                try
                {
                    dataresult = (byte)sp1.ReadByte();

                }
                catch (System.TimeoutException e)
                {

                    if (counter == 0)
                    {

                        System.Console.WriteLine("Scanning " + sp1.PortName + " - read data first try timeout: " + e.Message);
                        if (secondTap)
                        {
                            sp1.Close();
                            return -1;
                        }
                        else
                        {
                            try
                            {
                                sp1.Write(srcBuff_1, 0, srcBuff_1.Length);
                            }
                            catch (TimeoutException ei)
                            {
                                System.Console.WriteLine("Scanning " + sp1.PortName + " - write data second try timeout: " + e.Message);
                                sp1.Close();
                                return -1;
                            }
                            secondTap = true;

                        }


                    }
                    else
                    {
                        break;
                    }

                    continue;
                }
                data.Add(dataresult);
                counter++;
                if (counter >= 100)
                {
                    break;
                }


            }
            byte[] newdata = new byte[data.Count];
            newdata = (byte[])data.ToArray(typeof(byte));
            string s = System.Text.Encoding.Default.GetString(newdata);

            s = s.ToLower();
            System.Console.WriteLine("Scanning " + sp1.PortName + " - read data: " + s);

            int index = s.IndexOf("device powered on", 0);

            sp1.Close();

            if (index >= 0)
            {
                System.Console.WriteLine("Scanning " + sp1.PortName + " succeed, port is: " + sp1.PortName);
                return 0;
            }

            System.Console.WriteLine("Scanning " + sp1.PortName + " get unrecognized result: " + s);
            return -3;

        }
    }
}
