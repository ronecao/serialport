using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace SPDisplay {
    class SerialPortControl {
        private readonly int SUCC = 0;
        private SerialPort sp1;
        public SerialPortControl(String name, String baudratestr, String paritystr, String databitstr, String stopbitstr) {
            sp1 = new SerialPort();
            sp1.PortName = name;
            sp1.BaudRate = int.Parse(baudratestr);
            switch (paritystr.ToLower()) {
                case "none":
                    sp1.Parity = Parity.None;
                    break;
                case "even":
                    sp1.Parity = Parity.Even;
                    break;
                case "odd":
                    sp1.Parity = Parity.Odd;
                    break;
                case "mark":
                    sp1.Parity = Parity.Mark;
                    break;
                case "space":
                    sp1.Parity = Parity.Space;
                    break;
                default:
                    sp1.Parity = Parity.None;
                    break;
            }
            switch (int.Parse(stopbitstr)) {
                case 0:
                    sp1.StopBits = StopBits.None;
                    break;
                case 1:
                    sp1.StopBits = StopBits.One;
                    break;
                case 2:
                    sp1.StopBits = StopBits.Two;
                    break;
                case 3:
                    sp1.StopBits = StopBits.OnePointFive;
                    break;
                default:
                    sp1.StopBits = StopBits.None;
                    break;
            }
            sp1.DataBits = int.Parse(databitstr);
            sp1.ReadTimeout = 5000;
            sp1.WriteTimeout = 1000;
        }

        public int OpenPort() {
            try {
                sp1.Open();
            }
            catch (Exception e) {
                if (e is System.UnauthorizedAccessException) {
                    System.Console.WriteLine("Scanning " + sp1.PortName + " - Opening Port get Access Denied exception: " + e.Message);
                    return -1;
                }
                else if (e is System.IO.IOException) {
                    System.Console.WriteLine("Scanning " + sp1.PortName + " - Opening Port get Port not exist exception: " + e.Message);
                    return -2;
                }
                else {
                    System.Console.WriteLine("Scanning " + e.Message);
                    return -3;
                }
            }
            return SUCC;
        }
        public int ReadByte(out byte dataout ) {
            try {
              dataout = (byte)sp1.ReadByte();
                return SUCC;
            } catch (Exception e) {
                dataout = 0xff;
                if (e is System.InvalidOperationException) {
                    System.Console.WriteLine("Scanning " + sp1.PortName + " :"+ e.Message);
                    return -1;
                }
                else if (e is System.TimeoutException) {
                    System.Console.WriteLine("Scanning " + sp1.PortName + ": " + e.Message);
                    return -2;
                }
                else {
                    System.Console.WriteLine("Scanning " + sp1.PortName + ": " + e.Message);
                    return -3;
                }
            }
        }
        public int WriteData(byte[] data, int length) {
            try {
                sp1.Write(data, 0, length);
                return SUCC;
            }
            catch (Exception e) {

                Console.WriteLine(e.ToString());
                sp1.Close();
                return -1;
            }
        }
        public void ClosePort() {
            sp1.Close();
        }


    }
}
