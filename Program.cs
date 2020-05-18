using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Xml;
using ConsoleApplication1.Properties;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
//            Console.WriteLine($"res == {reverse(1563847412)}");
//            uint n = 43261596;
//            uint res = reverseBits(n);
//            Console.WriteLine($"{Convert.ToString(n, 2)} ==> {Convert.ToString(res, 2)}");
//            var head = new ListNode(1);
//            var pre = head;
//            for (int i = 2; i < 6; i++)
//            {
//                var node = new ListNode(i);
//                pre.next = node;
//                pre = node;
//            }
//
//            var reverseHead = ReverseList(head);
//            var tNode = reverseHead;
//            var res = "";
//            while (tNode != null)
//            {
//                res += tNode.val + ", ";
//                tNode = tNode.next;
//            }
//
//            Console.WriteLine(res);

//            var head = new ListNode(1);
//            head.next = new ListNode(2);
//            
//            var head2 = new ListNode(1);
//            var pre = head2;
//            pre.next = new ListNode(2);
//            pre = pre.next;
//            pre.next = new ListNode(3);
//            pre = pre.next;
//            pre.next = new ListNode(4);
//            pre = pre.next;
//            pre.next = new ListNode(2);
//            pre = pre.next;
//            pre.next = new ListNode(1);
//            
//            Console.WriteLine($"head = {IsPalindrome(head)}, head2 = {IsPalindrome(head2)}");


//            var str = "abcabcbb";
//            Console.WriteLine($"str = {str}, res = {LengthOfLongestSubstring(str)}");
//            str = "bbbbb";
//            Console.WriteLine($"str = {str}, res = {LengthOfLongestSubstring(str)}");
//            str = "pwwkew";
//            Console.WriteLine($"str = {str}, res = {LengthOfLongestSubstring(str)}");
//            str = "b";
//            Console.WriteLine($"str = {str}, res = {LengthOfLongestSubstring(str)}");
//            str = "dvdf";
//            Console.WriteLine($"str = {str}, res = {LengthOfLongestSubstring(str)}");
//            str = "abba";
//            Console.WriteLine($"str = {str}, res = {LengthOfLongestSubstring(str)}");

//            int[] a = {4, 5, 6, 0, 0, 0};
//            int[] b = {1, 2, 3};
//            Merge(a, 3, b, 3);
//            var res = "";
//            for (int i = 0; i < a.Length; i++)
//            {
//                res += a[i] + ", ";
//            }
//            Console.WriteLine(res);

//                CheckSuduko.Test();
//                copyNodeList138.Test();
//            distributeCandies1103.Test();
//            longestPalindrome5.Test();
//            maxDepthAfterSplit_1111.Test();
//            var machines = new Machines();
//            machines.PrintMachinesSize();
//            GameOfLife_289.Test();
//            RotateMatrix_inteview_01_07.Test();
//                RobotMovingCount_inteview_13.Test();
//            AddTwoNumbers_2.Test();
//            WiggleSort_324.Test();
//            AddOneRow_623.Test();
//            IsBalanced_interview_4.Test();
            LowestCommonAncestor_interview_4_8.Test();
//            QuickSort.Test();
//            QuickSelect.Test();
        }

        /*
         *给定两个排序后的数组 A 和 B，其中 A 的末端有足够的缓冲空间容纳 B。 编写一个方法，将 B 合并入 A 并排序。

            初始化 A 和 B 的元素数量分别为 m 和 n。

            示例:

            输入:
            A = [1,2,3,0,0,0], m = 3
            B = [2,5,6],       n = 3

            输出: [1,2,2,3,5,6]
         * 
         */
//        public static void Merge(int[] A, int m, int[] B, int n)
//        {
//            var pa = m - 1;
//            var pb = n - 1;
//            var cur = m + n - 1;
//            while (cur >= 0)
//            {
//                int val = 0;
//                if (pa < 0)
//                {
//                    val = B[pb--];
//                }
//                else if (pb < 0)
//                {
//                    val = A[pa--];
//                }
//                else if (A[pa] >= B[pb])
//                {
//                    val = A[pa--];
//                }
//                else if (A[pa] < B[pb])
//                {
//                    val = B[pb--];
//                }
//
//                A[cur--] = val;
//            }
//    }

        /*
         *给定一个字符串，请你找出其中不含有重复字符的 最长子串 的长度。

            示例 1:

            输入: "abcabcbb"
            输出: 3 
            解释: 因为无重复字符的最长子串是 "abc"，所以其长度为 3。
            示例 2:

            输入: "bbbbb"
            输出: 1
            解释: 因为无重复字符的最长子串是 "b"，所以其长度为 1。
            示例 3:

            输入: "pwwkew"
            输出: 3
            解释: 因为无重复字符的最长子串是 "wke"，所以其长度为 3。
                 请注意，你的答案必须是 子串 的长度，"pwke" 是一个子序列，不是子串。
         * 
         */
//        public static int LengthOfLongestSubstring(string s) {
//            Dictionary<char, int> window = new Dictionary<char, int>();
//            var longestLen = 0;
//            var left = 0;
//            for (int i = 0; i < s.Length; i++)
//            {
//                var word = s[i];
//                if (window.ContainsKey(word))
//                {
//                    left = Math.Max(window[word] + 1, left);
//                    window[word] = i;
//                }
//                else
//                {
//                    window.Add(word, i);    
//                }
//
//                longestLen = Math.Max(i - left + 1, longestLen);
//            }
//
//            return longestLen;
//        }

//        public class ListNode
//        {
//            public int val;
//            public ListNode next;
//
//            public ListNode(int x)
//            {
//                val = x;
//            }
//        }

        /*
         *请判断一个链表是否为回文链表。

        示例 1:

        输入: 1->2
        输出: false
        示例 2:

        输入: 1->2->2->1
        输出: true
        进阶：
        你能否用 O(n) 时间复杂度和 O(1) 空间复杂度解决此题？
        
         */
//        public static bool IsPalindrome(ListNode head)
//        {
//            if (head?.next == null)
//            {
//                return true;
//            }
//            
//            ListNode fast = head;
//            ListNode slow = head;
//
//            while (fast?.next != null)
//            {
//                fast = fast.next.next;
//                slow = slow.next;
//            }
//
//            ListNode reserveHead = null;
//            while (slow != null)
//            {
//                var temp = slow.next;
//                slow.next = reserveHead;
//                reserveHead = slow;
//                slow = temp;
//            }
//            
//            while (reserveHead != null && head != null)
//            {
//                if (reserveHead.val != head.val)
//                {
//                    return false;
//                }
//
//                reserveHead = reserveHead.next;
//                head = head.next;
//            }
//            
//            return true;
//        }

        /*
            反转一个单链表。

            示例:

            输入: 1->2->3->4->5->NULL
            输出: 5->4->3->2->1->NULL
            进阶:
            你可以迭代或递归地反转链表。你能否用两种方法解决这道题？
         */
//        private static ListNode ReverseList(ListNode head)
//        {
//            if (head?.next == null)
//            {
//                return head;
//            }
//
//            var res = ReverseList(head.next);
//            head.next.next = head;
//            head.next = null;
//
//            return res;
//        }

//        private static ListNode ReverseList(ListNode head)
//        {
//            ListNode resNode = null;
//            var currNode = head;
//            while (currNode != null)
//            {
//                var nextCurrNode = currNode.next;
//                currNode.next = resNode;
//                resNode = currNode;
//                currNode = nextCurrNode;
//            }
//            
//            return resNode;
//        }
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
//        private static uint reverseBits(uint n)
//        {
//            uint res = 0;
//            if (n == 0)
//            {
//                return res;
//            }
//            for (int i = 0; i < 32; i++)
//            {
//                res <<= 1;
//                res |= n & 1;
//                n >>= 1;
//            }
//
//            return res;
//        }

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

        假设我们的环境只能存储得下 32 位的有符号整数，则其数值范围为 [−231,  231 − 1]。请根据这个假设，如果反转后整数溢出那么就返回 0。 
         */
//        private static Int32 reverse(Int32 x)
//        {
//            if (x == 0)
//            {
//                return 0;
//            }
//
//            if (x == Int32.MinValue)
//            {
//                return 0;
//            }
//
//            if (Math.Abs(x) < 10)
//            {
//                return x;
//            }
//            
//            Queue<Int32> q = new Queue<Int32>();
//            Int32 positiveCell = x > 0 ? 1 : -1;
//            Int32 temp = Math.Abs(x);
//            while (temp / 10 > 0)
//            {
//                var lastNum = temp - temp / 10 * 10;
//                q.Enqueue(lastNum);
//                
//                temp /= 10;
//            }
//
//            if (temp > 0)
//            {
//                q.Enqueue(temp);
//            }
//
//            Int32 max = Int32.MaxValue;
//            Int32 min = Int32.MinValue;
//            var side = positiveCell > 0 ? max : min;
//            
//            Int32 res = 0;
//            
//            while (q.Count > 0)
//            {
//                var num = q.Dequeue() * positiveCell;
//                Console.WriteLine($"nnnn = {num}, {side}, {res}, L = {Math.Abs((side - num) / 10.0f)}, R = {Math.Abs(res)}");
//                if (res != 0 && Math.Abs((side - num) / 10) < Math.Abs(res))
//                {
//                    return 0;
//                }
//                res *= 10;
//                res += num;
//            }
//
//            return res;
//        }

//        private static Int32 reverse(Int32 x)
//        {
//            int res = 0;
//
//            while (x != 0)
//            {
//                if (res * 10 / 10 != res)
//                {
//                    res = 0;
//                    break;
//                }
//
//                res = res * 10 + x % 10;
//                x = x / 10;
//            }
//
//            return res;
//        }
    }
}