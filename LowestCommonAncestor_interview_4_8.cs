using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApplication1.Properties
{
    public class LowestCommonAncestor_interview_4_8
    {
        /*
         *
            设计并实现一个算法，找出二叉树中某两个节点的第一个共同祖先。不得将其他的节点存储在另外的数据结构中。注意：这不一定是二叉搜索树。

            例如，给定如下二叉树: root = [3,5,1,6,2,0,8,-999,-999,7,4]

                3
               / \
              5   1
             / \ / \
            6  2 0  8
              / \
             7   4
            示例 1:

            输入: root = [3,5,1,6,2,0,8,-999,-999,7,4], p = 5, q = 1
            输出: 3
            解释: 节点 5 和节点 1 的最近公共祖先是节点 3。
            示例 2:

            输入: root = [3,5,1,6,2,0,8,-999,-999,7,4], p = 5, q = 4
            输出: 5
            解释: 节点 5 和节点 4 的最近公共祖先是节点 5。因为根据定义最近公共祖先节点可以为节点本身。
            说明:

            所有节点的值都是唯一的。
            p、q 为不同节点且均存在于给定的二叉树中。
         */
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

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root.val == p.val || root.val == q.val)
            {
                return root;
            }

            var left = LowestCommonAncestor(root.left, p, q);
            var right = LowestCommonAncestor(root.right, p, q);
            if (left != null && right != null)
            {
                return root;
            }
            
            return left ?? right;
        }

        private void DumpStack(Stack<TreeNode> stack)
        {
            var array = stack.ToArray();
            var res = "";
            for (int i = 0; i < stack.Count; i++)
            {
                res += $"[{array[i].val}]";
            }

            Utils.Print(res);
        }

        public static void Test()
        {
            var obj = new LowestCommonAncestor_interview_4_8();
//            var tree = MakeTree(new[] {3, 5, 1, 6, 2, 0, 8, -1, -1, 7, 4});
//            var resNode = obj.LowestCommonAncestor(tree, new TreeNode(5), new TreeNode(1));
//            var tree = MakeTree(new[] {0, 1, -1, 2, -1, -1, -1, 3});
//            var tree = MakeTree(new[]
//                {37, -34, -48, -1, -100, -101, 48, -1, -1, -1, -1, -54, -1, -71, -22, -1, -1, -1, 8});

            var tree = MakeTree(new[]
                {1, 2, -1, 3, -1, 4, -1, 5, -1, 6, -1});

            DumpTree(tree);
            var resNode = obj.LowestCommonAncestor(tree, new TreeNode(3), new TreeNode(6));
            Utils.Print($"vvval = {resNode?.val}");
        }

        private static TreeNode MakeTree(int[] data)
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

        private static void DumpTree(TreeNode tree)
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