using System;

namespace ConsoleApplication1
{
    public class Utils
    {
        public  static void DumpArray(int[] inArray)
        {
            if (inArray == null)
            {
                Console.WriteLine("in array is invalid ! ");
                return;
            }

            var res = "";
            for (int i = 0; i < inArray.Length; i++)
            {
                res += inArray[i] + ", ";
            }
            
            Console.WriteLine(res);
        }

        public static void Print(string str)
        {
            Console.WriteLine(str);
        }

    }
}