using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class Utils
    {
        public static void DumpArray(int[] inArray)
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

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int x)
        {
            val = x;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x)
        {
            val = x;
        }
    }

    public class TreeHelper
    {
        public static TreeNode MakeTree(int[] data)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();

            var root = new TreeNode(data[0]);
            q.Enqueue(root);
            var index = 1;
            while (q.Count > 0)
            {
                var parentNode = q.Dequeue();
                var leftIndex = index;
                if (leftIndex < data.Length && data[leftIndex] != -1)
                {
                    parentNode.left = new TreeNode(data[leftIndex]);
                    q.Enqueue(parentNode.left);
                }

                var rightIndex = index + 1;
                if (rightIndex < data.Length && data[rightIndex] != -1)
                {
                    parentNode.right = new TreeNode(data[rightIndex]);
                    q.Enqueue(parentNode.right);
                }

                index += 2;
            }

            return root;
        }

        public static void DumpTree(TreeNode tree)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            var index2Val = new Dictionary<int, int>();
            var node2Index = new Dictionary<TreeNode, int>();

            stack.Push(tree);
            node2Index[tree] = 1;

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                var index = node2Index[node];
                index2Val[index] = node.val;

                if (node.left != null)
                {
                    stack.Push(node.left);
                    node2Index[node.left] = index * 2;
                }

                if (node.right != null)
                {
                    stack.Push(node.right);
                    node2Index[node.right] = index * 2 + 1;
                }
            }

            List<int> res = new List<int>();
            foreach (var pair in index2Val)
            {
                var index = pair.Key - 1;
                if (index >= res.Count)
                {
                    var addLen = index - res.Count + 1;
                    for (int i = 0; i < addLen; i++)
                    {
                        res.Add(-1);
                    }
                }

                res[index] = pair.Value;
            }

            bool bEnd;
            var lineStr = "";
            int leftIndex = 1;
            for (int i = 0; i < res.Count; i++)
            {
                bEnd = false;
                if (i == (leftIndex << 1) - 1 - 1)
                {
                    bEnd = true;
                }

                var space = i % 2 == 0 ? " " : "";
                lineStr += $"{res[i]},{space}";

                if (bEnd)
                {
                    leftIndex <<= 1;
                    Utils.Print(lineStr);
                    lineStr = "";
                }
            }

            Utils.Print(lineStr);
        }
    }
}