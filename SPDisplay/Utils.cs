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

        public static String HextString(byte[] b, int length, Boolean spac) {
            String ret = "";
            for (int i = 0; i < length; i++) {
                ret = ret + b[i].ToString("X2");
                if (spac) {
                    ret = ret + " ";
                }
            }
            return ret;
        }

        public static byte getbitValue(byte invalue, byte bitadd) {
           return (byte)((byte)(invalue << (bitadd)) >> 7);
        }
        public static Boolean SameArray(byte[] arr1, byte[] arr2) {
            for (int i = 0; i < arr2.Length; i++) {
                if (arr1[i] != arr2[i]) {
                    return false;
                }
            }
            return true;
        }
    }
}
