using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace ConsoleApplication1
{
    public class copyNodeList138
    {
        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node(int _val)
            {
                val = _val;
                next = null;
                random = null;
            }
        }

        /*
        public Node CopyRandomList(Node head)
        {
            if (head == null)
            {
                return null;
            }

            Dictionary<Node, Node> src2copy = new Dictionary<Node, Node>();

            Node GetCopyNode(Node oriNode)
            {
                if (oriNode == null)
                {
                    return null;
                }
                
                if (src2copy.ContainsKey(oriNode))
                {
                    return src2copy[oriNode];
                }
                else
                {
                    var newNode = new Node(oriNode.val);
                    src2copy.Add(oriNode, newNode);
                    return newNode;
                }
            }

            Node srcPtr = head;
            Node resHead = null;
            Node resPtr = null;
            while (srcPtr != null)
            {
                var copiedNode = GetCopyNode(srcPtr);
                if (resHead == null)
                {
                    resHead = copiedNode;
                }
                else
                {
                    resPtr.next = copiedNode;
                }
                copiedNode.random = GetCopyNode(srcPtr.random);
                
                resPtr = copiedNode;
                srcPtr = srcPtr.next;
            }
            
            return resHead;
        }
        */
        
        public Node CopyRandomList(Node head)
        {
            if (head == null)
            {
                return null;
            }

            var ele = head;
            while (ele != null)
            {
                var newNode = new Node(ele.val);
                newNode.next = ele.next;
                ele.next = newNode;

                ele = ele.next.next;
            }

            ele = head;
            while (ele != null)
            {
                if (ele.random != null)
                {
                    ele.next.random = ele.random.next;
                }

                ele = ele.next.next;
            }

            Node resHead = head.next;
            
            ele = head;
            while (ele != null)
            {
                var preEle = ele;
                var resPtr = preEle.next;
                
                ele = ele.next.next;
                
                preEle.next = ele;
                if (resPtr != null && resPtr.next != null)
                {
                    resPtr.next = resPtr.next.next;    
                }
            }
            
            return resHead;
        }

        private static Node CreateNodeList(int[,] inList)
        {
            Node AddNewNode(Node pre, int val)
            {
                var newNode = new Node(val);
                pre.next = newNode;
                return newNode;
            }

            Node head = new Node(inList[0, 0]);
            Node preNode = head;
            for (int i = 1; i < inList.Length / 2; i++)
            {
                preNode = AddNewNode(preNode, inList[i, 0]);
            }

            Node GetNode(Node inHead, int index)
            {
                if (index == 0)
                {
                    return inHead;
                }

                Node res = inHead;
                for (int i = 0; i < index; i++)
                {
                    res = res.next;
                }

                return res;
            }

            Node ele = head;
            for (int i = 0; i < inList.Length / 2; i++)
            {
                if (inList[i, 1] == -1)
                {
                    ele.random = null;
                }
                else
                {
                    ele.random = GetNode(head, inList[i, 1]);
                }

                ele = ele.next;
            }

            return head;
        }

        private static void Dump(Node head)
        {
            Dictionary<Node, int> nodeIndexMap = new Dictionary<Node, int>();
            var ele = head;
            int index = 0;
            while (ele != null)
            {
                nodeIndexMap.Add(ele, index++);
                ele = ele.next;
            }

            string res = "";
            ele = head;
            while (ele != null)
            {
                int i = -1;
                if (ele.random != null)
                {
                    i = nodeIndexMap[ele.random];
                }

                res += $"[{ele.val}, {i}]";
                ele = ele.next;
            }

            Console.WriteLine($"res = {res}");
        }

        public static void Test()
        {
            Console.WriteLine($"1111111111111 ");
            var func = new copyNodeList138();
            var node1 = CreateNodeList(new[,] {{7, -1}, {13, 0}, {11, 4}, {10, 2}, {1, 0}});
            Dump(node1);
            Dump(func.CopyRandomList(node1));
            Dump(node1);

            Console.WriteLine($"22222222222222 ");
            var node2 = CreateNodeList(new[,] {{1, 1}, {2, 1}});
            Dump(node2);
            Dump(func.CopyRandomList(node2));
            Dump(node2);

            Console.WriteLine($"33333333333333 ");
            var node3 = CreateNodeList(new[,] {{3, -1}, {3, 0}, {3, -1}});
            Dump(node3);
            Dump(func.CopyRandomList(node3));
            Dump(node3);

            // [[7,null],[13,0],[11,4],[10,2],[1,0]]
        }
    }
}