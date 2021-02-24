using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class IsBalanced_interview_4
    {
        /*
         * 实现一个函数，检查二叉树是否平衡。在这个问题中，平衡树的定义如下：任意一个节点，其两棵子树的高度差不超过 1。
         * 示例 1:
            给定二叉树 [3,9,20,null,null,15,7]
                3
               / \
              9  20
                /  \
               15   7
            返回 true 。
            示例 2:
            给定二叉树 [1,2,2,3,3,null,null,4,4]
                  1
                 / \
                2   2
               / \
              3   3
             / \
            4   4
            返回 false 。

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

        public bool IsBalanced(TreeNode root)
        {
            isBalance = true;
            WalkTree(root);
            return isBalance;
        }

        private bool isBalance;
        private int WalkTree(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            var heightL = WalkTree(root.left);
            var heightR = WalkTree(root.right);

            if (Math.Abs(heightL - heightR) > 1)
            {
                isBalance = false;
            }
            
            return Math.Max(heightL, heightR) + 1;
        }

        public static void Test()
        {
            var obj = new IsBalanced_interview_4();
            var tree = MakeTree(new[] {1,2,2,3,3,-1,-1,4,4});
            var res = obj.IsBalanced(tree);
            Utils.Print($"IsBalanced = {res}");
        }
        
        private static TreeNode MakeTree(int[] data)
        {
            var root = new TreeNode(data[0]);
            TreeNode[] nodeRecord = new TreeNode[data.Length + 1];
            nodeRecord[1] = root;

            for (int i = 1; i < data.Length; i++)
            {
                var nodeVal = data[i];
                var parentNode = nodeRecord[(i + 1) / 2];
                if (nodeVal != -1 && parentNode != null)
                {
                    var bLeft = (i + 1) % 2 == 0;
                    if (bLeft)
                    {
                        nodeRecord[i + 1] = parentNode.left = new TreeNode(nodeVal);
                    }
                    else
                    {
                        nodeRecord[i + 1] = parentNode.right = new TreeNode(nodeVal);
                    }
                }
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

                lineStr += $"{res[i]},";
                
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