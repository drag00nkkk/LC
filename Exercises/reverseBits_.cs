using System;

namespace LeetCode
{
    public class ReverseBits
    {
        public static void Test()
        {
           uint n = 43261596;
           uint res = reverseBits(n);
           Console.WriteLine($"{Convert.ToString(n, 2)} ==> {Convert.ToString(res, 2)}");
        }

        /*
         颠倒给定的 32 位无符号整数的二进制位。
         
        示例 1：

        输入: 00000010100101000001111010011100
        输出: 00111001011110000010100101000000
        解释: 输入的二进制串 00000010100101000001111010011100 表示无符号整数 43261596，
              因此返回 964176192，其二进制表示形式为 00111001011110000010100101000000。
        示例 2：

        输入：11111111111111111111111111111101
        输出：10111111111111111111111111111111
        解释：输入的二进制串 11111111111111111111111111111101 表示无符号整数 4294967293，
              因此返回 3221225471 其二进制表示形式为 10101111110010110010011101101001。

         */
        private static uint reverseBits(uint n)
        {
            uint res = 0;
            if (n == 0)
            {
                return res;
            }
            for (int i = 0; i < 32; i++)
            {
                res <<= 1;
                res |= n & 1;
                n >>= 1;
            }

            return res;
        }
    }
}   
