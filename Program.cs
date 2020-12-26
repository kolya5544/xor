using System;
using System.Text;

namespace xorProj
{
    class Program
    {
        public static byte[] strToBA(string hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
        public static string BAtoStr(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("1 for encrypt, 2 for decrypt");
            string answ = Console.ReadLine();
            Console.Write("Input:");
            string stuff = Console.ReadLine();
            Console.Write("Key:");
            byte[] key = Encoding.UTF8.GetBytes(Console.ReadLine());

            byte[] encBYTES;
            encBYTES = answ == "2" ? strToBA(stuff) : Encoding.UTF8.GetBytes(stuff);
            for (int i = 0; i < encBYTES.Length; i++)
            {
                encBYTES[i] = (byte)(encBYTES[i] ^ key[i % key.Length]);
            }
            Console.WriteLine(answ == "1" ? BAtoStr(encBYTES) : Encoding.UTF8.GetString(encBYTES));
        }
    }
}
