using System;
using System.Collections;
using System.Collections.Generic;


namespace LeetCode
{
    public class AddTwoNumbersByNode
    {
        public static void Test()
        {
            PrintNumber(AddTwoNumbersRev(CreateNumber(new int[] {5}), CreateNumber(new int[] {5})));
            PrintNumber(AddTwoNumbersRev(CreateNumber(new int[] {6, 1, 7}), CreateNumber(new int[] {2, 9, 5})));
            PrintNumber(AddTwoNumbersRev(CreateNumber(new int[] {6, 9}), CreateNumber(new int[] {2, 9, 5})));
        }

        private static ListNode CreateNumber(int[] number)
        {
            void CN(ListNode node, int nIndex)
            {
                if (nIndex >= number.Length)
                {
                    return;
                }

                var newNode = new ListNode(number[nIndex]);
                CN(newNode, nIndex + 1);
                node.next = newNode;
            }

            ListNode head = new ListNode(0);
            CN(head, 0);
            return head.next;
        }

        private static void PrintNumber(ListNode node)
        {
            string res = "";
            while (node != null)
            {
                res += node.val + "->";
                node = node.next;
            }

            Utils.Print(res);
        }

        /*
         * 给定两个用链表表示的整数，每个节点包含一个数位。

            这些数位是反向存放的，也就是个位排在链表首部。

            编写函数对这两个整数求和，并用链表形式返回结果。

            示例：
            输入：(7 -> 1 -> 6) + (5 -> 9 -> 2)，即617 + 295
            输出：2 -> 1 -> 9，即912
            
            进阶：思考一下，假设这些数位是正向存放的，又该如何解决呢?

            示例：
            输入：(6 -> 1 -> 7) + (2 -> 9 -> 5)，即617 + 295
            输出：9 -> 1 -> 2，即912
            
             * public class ListNode {
             *     public int val;
             *     public ListNode next;
             *     public ListNode(int x) { val = x; }
             * }
         */
        private static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode res = new ListNode(0);
            ListNode head = res;
            int carry = 0;
            while (l1 != null || l2 != null || carry > 0)
            {
                int v1 = l1?.val ?? 0;
                int v2 = l2?.val ?? 0;
                int ri = 0;
                if (carry + v1 + v2 >= 10)
                {
                    ri = (carry + v1 + v2) % 10;
                    carry = (carry + v1 + v2) / 10;
                }
                else
                {
                    ri = carry + v1 + v2;
                    carry = 0;
                }

                res.next = new ListNode(ri);
                res = res.next;

                l1 = l1?.next;
                l2 = l2?.next;
            }

            head = head.next;
            return head;
        }

        private static ListNode AddTwoNumbersRev(ListNode l1, ListNode l2)
        {
            void listNode2Stack(ListNode head, Stack<int> saveStack)
            {
                while (head != null)
                {
                    saveStack.Push(head.val);
                    head = head.next;
                }
            }

            var s1 = new Stack<int>();
            listNode2Stack(l1, s1);
            var s2 = new Stack<int>();
            listNode2Stack(l2, s2);

            ListNode res = new ListNode(0);
            int carry = 0;

            while (s1.Count > 0 || s2.Count > 0 || carry > 0)
            {
                int v1 = s1.Count > 0 ? s1.Pop() : 0;
                int v2 = s2.Count > 0 ? s2.Pop() : 0;
                int ri = 0;
                if (carry + v1 + v2 >= 10)
                {
                    ri = (carry + v1 + v2) % 10;
                    carry = (carry + v1 + v2) / 10;
                }
                else
                {
                    ri = carry + v1 + v2;
                    carry = 0;
                }

                var newNode = new ListNode(ri);
                newNode.next = res.next;
                res.next = newNode;
            }
            
            return res.next;
        }
    }
}