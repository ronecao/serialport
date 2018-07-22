using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPDisplay
{
    class Utils{
        public static String[] paramList;
        public static String[] port;
        public enum REQTYPE { ERROR, FIND,DATA};
        public static void dumpdata(byte[] b, int length, String title)
        {
            Console.WriteLine(title + "lengght" + length);
            for (int i = 0; i < length; i++)
            {
                Console.Write(b[i].ToString("X2"));
                Console.Write(" ");
                if ((i + 1) % 16 == 0)
                {
                    Console.WriteLine(" ");
                }

            }
            Console.WriteLine(" ");
        }
        public static byte CRCSUM(byte[] data, int length) {
            byte result = 0x00;
            for (int i = 0; i < length; i++) {
                result =(byte) (result + data[i]);
            }
            return result;
        }
    }
}
