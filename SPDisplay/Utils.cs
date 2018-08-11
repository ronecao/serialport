using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPDisplay
{
    class Utils {
        public static String[] paramList;
        public static String[] port;
        public static Random utilsrandom = new Random();

        public static void dumpdata(byte[] b, int length, String title) {
            Console.WriteLine(title + "lengght" + length);
            for (int i = 0; i < length; i++) {
                Console.Write(b[i].ToString("X2"));
                Console.Write(" ");
                if ((i + 1) % 16 == 0) {
                    Console.WriteLine(" ");
                }

            }
            Console.WriteLine(" ");
        }
        public static byte CRCSUM(byte[] data, int length) {
            byte result = 0x00;
            for (int i = 0; i < length; i++) {
                result = (byte)(result + data[i]);
            }
            return result;
        }
        public static byte[] getRadomByte() {

            int n = utilsrandom.Next(0, 268465455);
            byte[] d = BitConverter.GetBytes(n);
            byte[] ret = new byte[4];
            ret[0] = d[3];
            ret[1] = d[2];
            ret[2] = d[1];
            ret[3] = d[0];
            return ret;
        }

        public static String HextString(byte[] b, ulong length, Boolean spac) {
            String ret = "";
            for (ulong i = 0; i < length; i++) {
                ret = ret + b[i].ToString("X2");
                if (spac) {
                    ret = ret + " ";
                }
            }
            return ret;
        }

      
        /*public static byte[] String2Byte(string s, bool space) {
           

            int byteLength = s.Length / 2;
            byte[] bytes = new byte[byteLength];
            string hex;
            int j = 0;
            for (int i = 0; i < bytes.Length; i++) {

                hex = new String(new Char[] { s[j], s[j + 1] });

                bytes[i] = HexToByte(hex);
                j = j + 2;

            }
        }*/
        public static byte[] HexToBytes(string s) {
            int len = s.Length;
            s = s.ToUpper();
            byte[] des;
            if (len % 2 != 0 || len == 0) {
                return null;
            }
            else {
                int halfLen = len / 2;
                des = new byte[halfLen];
                char[] tempChars = s.ToCharArray();
                for (int i = 0; i < halfLen; ++i) {
                    char c1 = tempChars[i * 2];
                    char c2 = tempChars[i * 2 + 1];
                    int tempI = 0;
                    if (c1 >= '0' && c1 <= '9') {
                        tempI += ((c1 - '0') << 4);
                    }
                    else if (c1 >= 'A' && c1 <= 'F') {
                        tempI += (c1 - 'A' + 10) << 4;
                    }
                    else {
                        return null;
                    }
                    if (c2 >= '0' && c2 <= '9') {
                        tempI += (c2 - '0');
                    }
                    else if (c2 >= 'A' && c2 <= 'F') {
                        tempI += (c2 - 'A' + 10);
                    }
                    else {
                        return null;
                    }
                    des[i] = (byte)tempI;
                    // System.out.println(des[i]);
                }
                return des;

            }

        }

        public static byte getbitValue(byte invalue, byte bitadd) {
           return (byte)((byte)(invalue << (bitadd)) >> 7);
        }
        public static Boolean SameArray(byte[] arr1, byte[] key) {
            for (int i = 0; i < key.Length; i++) {
                if (arr1[i] != key[i]) {
                    return false;
                }
            }
            return true;
        }
        public static byte[] getIntByte(int i) {

            byte[] d = BitConverter.GetBytes(i);
            byte[] ret = new byte[4];
            ret[0] = d[3];
            ret[1] = d[2];
            ret[2] = d[1];
            ret[3] = d[0];
            return ret;
        }
        public static byte[] changeHigh(byte[] datain) {
            byte temp1 = datain[0];
            byte temp2 = datain[1];

            byte hight1 = (byte) (temp1 >> 4);
            byte hight2 = (byte)(temp2 >> 4);

            byte reulst1 = (byte)(temp1 - hight1 * 16);
            byte reulst2 = (byte)(temp2 - hight2 * 16);
            Console.WriteLine("{0}{1}",reulst1.ToString("X2"),reulst2.ToString("X2"));
            reulst1 = (byte)(reulst1 + hight2 * 16);
            reulst2 = (byte)(reulst2 + hight1 * 16);
            return new byte[] { reulst1, reulst2};
        }
    }
}
