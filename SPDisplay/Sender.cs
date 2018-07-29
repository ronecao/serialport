using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SPDisplay.ProtocolControl;

namespace SPDisplay
{
    class Sender
    {
       public SerialPortControl sp1;
        
        public void initSerialPort(String name, String baudratestr, String paritystr, String databitstr, String stopbitstr){
            sp1 = new SerialPortControl( name,  baudratestr,  paritystr,  databitstr, stopbitstr);
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
				return Downunpackdata(newdata, newdata.Length);
            }
            return null;
        }
        public int SendData(byte[] data) {
            try
            {
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
           
           int i= SendData(request);
            //sp1.ClosePort();

            return i;
        }
    }
}
