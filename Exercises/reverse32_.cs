using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class Reverse32
    {
        public static void Test()
        {
            Console.WriteLine($"x = {2147483644}, reverse = {reverse2(2147483644)}");
        }

        /*
        给出一个 32 位的有符号整数，你需要将这个整数中每位上的数字进行反转。
        示例 1:
        输入: 123
        输出: 321

        示例 2:
        输入: -123
        输出: -321

        示例 3:
        输入: 120
        输出: 21
        注意:

        假设我们的环境只能存储得下 32 位的有符号整数，则其数值范围为 [−2^31,  2^31 − 1]。请根据这个假设，如果反转后整数溢出那么就返回 0。 
         */
        private static Int32 reverse(Int32 x)
       {
           int res = 0;

           while (x != 0)
           {
               if (res * 10 / 10 != res)
               {
                   res = 0;
                   break;
               }

               res = res * 10 + x % 10;
               x = x / 10;
           }

           return res;
       }

       private static Int32 reverse2(Int32 x)
       {
           if (x == 0)
           {
               return 0;
           }

           if (x == Int32.MinValue)
           {
               return 0;
           }

           if (Math.Abs(x) < 10)
           {
               return x;
           }
           
           Queue<Int32> q = new Queue<Int32>();
           Int32 positiveCell = x > 0 ? 1 : -1;
           Int32 temp = Math.Abs(x);
           while (temp / 10 > 0)
           {
               var lastNum = temp - temp / 10 * 10;
               q.Enqueue(lastNum);
               
               temp /= 10;
           }

           if (temp > 0)
           {
               q.Enqueue(temp);
           }

           Int32 max = Int32.MaxValue;
           Int32 min = Int32.MinValue;
           var side = positiveCell > 0 ? max : min;

           Int32 res = 0;
           
           while (q.Count > 0)
           {
               var num = q.Dequeue() * positiveCell;
               if (res * 10 / 10 != res)
               {
                   return 0;
               }
               res *= 10;
               res += num;
           }

           return res;
       }


    }
    

}