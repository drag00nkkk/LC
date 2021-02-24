namespace LeetCode
{
    public class ReverseNodeList
    {
        public static void Test()
        {

        }
       /*
            反转一个单链表。

            示例:

            输入: 1->2->3->4->5->NULL
            输出: 5->4->3->2->1->NULL
            进阶:
            你可以迭代或递归地反转链表。你能否用两种方法解决这道题？
         */
        private static ListNode ReverseList(ListNode head)
        {
            if (head?.next == null)
            {
                return head;
            }

            var res = ReverseList(head.next);
            head.next.next = head;
            head.next = null;

            return res;
        }

        private static ListNode ReverseList2(ListNode head)
        {
            ListNode resNode = null;
            ListNode currNode = head;
            while(currNode != null)
            {
                var nextNode = currNode.next;
                currNode.next = resNode;
                resNode = currNode;
                currNode = nextNode;
            }
            return resNode;
        }

    }

}