namespace LeetCode
{
    public class AddTwoNumbers_2
    {
        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int x)
            {
                val = x;
            }
        }

        private static void PrintNodeNumber(ListNode nodeNumber)
        {
            if (nodeNumber == null)
            {
                return;
            }

            var head = nodeNumber;
            string number = "";
            while (head != null)
            {
                number = head.val + number;
                head = head.next;
            }

            Utils.Print(number);
        }

        public static void Test()
        {
            var obj = new AddTwoNumbers_2();
            var res = obj.AddTwoNumbers(CreateNumber(5), CreateNumber(5));
            PrintNodeNumber(res);
        }

        static ListNode CreateNumber(int val)
        {
            ListNode res = null;
            ListNode temp = null;
            while (val != 0)
            {
                var number = val % 10;
                val /= 10;
                var newNode = new ListNode(number);
                if (temp == null)
                {
                    res = newNode;
                }
                else
                {
                    temp.next = newNode;
                }

                temp = newNode;
            }

            return res;
        }

        /*
         * 给出两个 非空 的链表用来表示两个非负的整数。其中，它们各自的位数是按照 逆序 的方式存储的，并且它们的每个节点只能存储 一位 数字。

            如果，我们将这两个数相加起来，则会返回一个新的链表来表示它们的和。

            您可以假设除了数字 0 之外，这两个数都不会以 0 开头。

            示例：

            输入：(2 -> 4 -> 3) + (5 -> 6 -> 4)
            输出：7 -> 0 -> 8
            原因：342 + 465 = 807
         */
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var l1Temp = l1;
            var l2Temp = l2;

            ListNode res = null;
            ListNode temp = null;
            int addVal = 0;
            while (l1Temp != null || l2Temp != null || addVal != 0)
            {
                var l1Val = l1Temp?.val ?? 0;
                var l2Val = l2Temp?.val ?? 0;

                var sum = l1Val + l2Val + addVal;
                var resVal = sum % 10;
                addVal = sum / 10;

                l1Temp = l1Temp?.next;
                l2Temp = l2Temp?.next;

                var newNode = new ListNode(resVal);
                if (temp == null)
                {
                    res = newNode;
                }
                else
                {
                    temp.next = newNode;
                }
                
                temp = newNode;
            }
            
            return res;
        }
    }
}