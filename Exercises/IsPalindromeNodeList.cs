namespace LeetCode
{
    public class IsPalindromeNodeList
    {
        public static void Test()
        {

        }

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
       public static bool IsPalindrome(ListNode head)
       {
           if (head?.next == null)
           {
               return true;
           }
           
           ListNode fast = head;
           ListNode slow = head;

           while (fast?.next != null)
           {
               fast = fast.next.next;
               slow = slow.next;
           }

           ListNode reserveHead = null;
           while (slow != null)
           {
               var temp = slow.next;
               slow.next = reserveHead;
               reserveHead = slow;
               slow = temp;
           }
           
           while (reserveHead != null && head != null)
           {
               if (reserveHead.val != head.val)
               {
                   return false;
               }

               reserveHead = reserveHead.next;
               head = head.next;
           }
           
           return true;
       }
    }

}