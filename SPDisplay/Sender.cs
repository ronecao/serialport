using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SPDisplay.ProtocolControl;
using static SPDisplay.Utils;

namespace SPDisplay
{
    public delegate void ThreadCallBackDelegate(string msg);
    public delegate void ThreadCallBackFinished(ArrayList data);
    public delegate void SetTextCallback(int loc, String text);
    public delegate void ProcessChartForm(ArrayList i);
    public delegate void UpdateLabels(DataCell d);

    public delegate void UpdateErrorList(String d);

    

    //public delegate void ThreadCallBackDelegate(string msg);
    class Sender
    {
        public static byte[] m_ReceivedData;
        public SerialPortControl sp1;
        public ThreadCallBackDelegate callback;
        public ThreadCallBackFinished finishCallback;
        public void Dispose() {
            try {
                sp1.sp1.Dispose();
            }
            catch (Exception e) {
                
            }
            
        }

        public void initSerialPort(String name, String baudratestr, String paritystr, String databitstr, String stopbitstr,String ReadingTimeout){
            sp1 = new SerialPortControl( name,  baudratestr,  paritystr,  databitstr, stopbitstr,ReadingTimeout);
		}
        public int OpenPort() {
            
            return sp1.OpenPort();
        }
        public void ClosePort() {
            sp1.ClosePort();
        }
        public ArrayList Receivedata(){

            byte dataresult = 0;
            int packagestatus = -1;
            ReceiverRest();
            int recvresult;
            int readStatus = -4;
            byte[] result;
           
            /*result =sp1.Read( out recvresult);
            Console.WriteLine("recvlenght" + recvresult +"buffersize"+ sp1.sp1.ReadBufferSize);
            return null;*/

            while (true)
            {
                /* dataresult = sp1.ReadByte(out readStatus);
                 if (readStatus == RECVSUCC) {
                     recvresult = SaveReceiverData(dataresult);
                 }
                 else {
                     Console.WriteLine("readStatus" + readStatus);
                     break; 
                 }*/
                try {
                    dataresult = (byte)sp1.sp1.ReadByte();
                    recvresult = SaveReceiverData(dataresult);
                  
                }
                catch (Exception e) {
                    Console.WriteLine("readStatus" + e.ToString());
                    break;

                }
               

                /*if (sp1.ReadByte(out dataresult) == 0) {
					recvresult = SaveReceiverData(dataresult);
				}else {
                    break;
                }*/

             
                
                
                switch (recvresult)
                {
                    case 3:
                        packagestatus = 3;
                        break;
                    case 1:
                        packagestatus = 1;
                        Console.WriteLine("收到头");
                        break;
                    case 2:
                        Console.WriteLine("收到垃圾数据");
                        break;
                    case 0:
                        //Console.WriteLine("收到数据");
                        break;
                    default:
                        Console.WriteLine("UNKOWN");
                        break;

                }
                if (packagestatus == 3) {
                    break;
                }
               

            }

            if (packagestatus == RECVEND)
            {
                byte[] newdata = new byte[downRecvData.Count];
                newdata = (byte[])downRecvData.ToArray(typeof(byte));
                Utils.dumpdata(newdata, newdata.Length, "receiveddata");
				return Downunpackdata(newdata,(ulong) newdata.Length);
            }
            return null;
        }

        public byte[] Receivedatatest() {
            byte[] result = new byte[1024 * 1024 * 10];
            int counter=0;
            int oneTimeCounter = 0;
            while (true) {

                try {
                    oneTimeCounter = sp1.sp1.Read(result, counter, 1024 * 12);
                    counter = counter + oneTimeCounter;

                }
                catch (Exception e) {
                    Console.WriteLine("readStatus" + e.ToString());
                    
                        Console.WriteLine("counter:" + counter);
                    try {

                        byte[] a = new byte[counter];
                        Buffer.BlockCopy(result, 0, a, 0, counter);
                       
                        return a;

                    }
                    catch (Exception es) {
                        
                        return null;
                    } 
                  
                  
                 

                }
               

            }
            
        }





        public void ThreadReceiveData() {

            byte dataresult = 0;
            int packagestatus = -1;
            ReceiverRest();
            int recvresult;
            int readStatus = -4;
            byte[] result=new byte[1024 * 1024 * 20];
            int counter = 0;

            ReceiverRest();
            int oneTimeCounter = 0;
            /*result =sp1.Read( out recvresult);
            Console.WriteLine("recvlenght" + recvresult +"buffersize"+ sp1.sp1.ReadBufferSize);
            return null;*/
            TimeSpan ts1 = Process.GetCurrentProcess().TotalProcessorTime;
            Stopwatch stw = new Stopwatch();
            double Msecs;



            /*result =sp1.Read( out recvresult);
            Console.WriteLine("recvlenght" + recvresult +"buffersize"+ sp1.sp1.ReadBufferSize);
            return null;*/
            stw.Start();
            while (true) {
                /* dataresult = sp1.ReadByte(out readStatus);
                 if (readStatus == RECVSUCC) {
                     recvresult = SaveReceiverData(dataresult);
                 }
                 else {
                     Console.WriteLine("readStatus" + readStatus);
                     break; 
                 }*/
       

                try {
                    oneTimeCounter = sp1.sp1.Read(result, counter, 1024 * 12);
                    counter = counter + oneTimeCounter;

                    callback("收到数据" + counter);

                }
                catch (Exception e) {
                    Console.WriteLine("readStatus" + e.ToString());

                    Console.WriteLine("counter:" + counter);
                    if (counter == 0) {
                        Msecs = Process.GetCurrentProcess().TotalProcessorTime.Subtract(ts1).TotalMilliseconds;
                        stw.Stop();
                        Console.WriteLine(string.Format("循环次数:{0} CPU时间(毫秒)={1} 实际时间(毫秒)={2}", downRecvDataCounter, Msecs, stw.Elapsed.TotalMilliseconds, stw.ElapsedTicks));
                        Console.WriteLine(string.Format("1 tick = {0}毫秒", stw.Elapsed.TotalMilliseconds / stw.Elapsed.Ticks));
                        finishCallback(null);
                        break;
                    }
                    m_ReceivedData = new byte[counter];
                    Buffer.BlockCopy(result, 0, m_ReceivedData, 0, counter);

                    ArrayList a = Downunpackdata(result, (ulong)counter);
                    finishCallback(a);



                    break;

                }


                /*if (sp1.ReadByte(out dataresult) == 0) {
					recvresult = SaveReceiverData(dataresult);
				}else {
                    break;
                }*/




            }

            

            
        }
        public int SendData(byte[] data) {
            byte[] start = new byte[10+data.Length];
            for (int i = 0; i < 10+data.Length; i++) {
                if (i < 10) {
                    start[i] = 0x00;
                }
                else {
                    start[i] = data[i - 10];
                }
                
             }

            try
            {
                //sp1.sp1.DiscardInBuffer();
               // sp1.sp1.DiscardOutBuffer();
                //sp1.WriteData(start, start.Length);
                sp1.WriteData(data, data.Length);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
                sp1.ClosePort();
                return -1;
            }
            return 0;
        }

        public int SendRequest(REQTYPE type, byte[] value) {
           byte[] request =  Packrequest(type, value);
            dumpdata(request,request.Length,"request");
           int i= SendData(request);
            //sp1.ClosePort();

            return i;
        }
    }
}
