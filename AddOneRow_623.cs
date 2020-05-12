using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Reflection;

namespace ConsoleApplication1
{
    /*
     * 给定一个二叉树，根节点为第1层，深度为 1。在其第 d 层追加一行值为 v 的节点。
       添加规则：给定一个深度值 d （正整数），针对深度为 d-1 层的每一非空节点 N，为 N 创建两个值为 v 的左子树和右子树。
       将 N 原先的左子树，连接为新节点 v 的左子树；将 N 原先的右子树，连接为新节点 v 的右子树。
       如果 d 的值为 1，深度 d - 1 不存在，则创建一个新的根节点 v，原先的整棵树将作为 v 的左子树。

       示例 1:

       输入: 
       二叉树如下所示:
              4
            /   \
           2     6
          / \   / 
         3   1 5   

       v = 1

       d = 2

       输出: 
              4
             / \
            1   1
           /     \
          2       6
         / \     / 
        3   1   5   

       示例 2:

       输入: 
       二叉树如下所示:
             4
            /   
           2    
          / \   
         3   1    

       v = 1

       d = 3

       输出: 
             4
            /   
           2
          / \    
         1   1
        /     \  
       3       1
       注意:

       输入的深度值 d 的范围是：[1，二叉树最大深度 + 1]。
       输入的二叉树至少有一个节点。
     */

    public class AddOneRow_623
    {
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

        private int Depth = 0;
        private int TargetDepth = -1;

        public TreeNode AddOneRow(TreeNode root, int v, int d)
        {
            if (d == 1)
            {
                return new TreeNode(v) {left = root};
            }

            TargetDepth = d - 1;
            Depth = 1;
            DFS(root, node =>
            {
                node.left = new TreeNode(v) {left = node.left};
                node.right = new TreeNode(v) {right = node.right};
            });

            return root;
        }


        private void DFS(TreeNode node, Action<TreeNode> handleHit)
        {
            if (node == null)
            {
                return;
            }
            
            if (Depth == TargetDepth)
            {
                handleHit.Invoke(node);
                return;
            }

            Depth++;

            DFS(node.left, handleHit);
            DFS(node.right, handleHit);
            
            Depth--;
        }

        public static void Test()
        {
            var obj = new AddOneRow_623();
            var tree = MakeTree(new[] {1, 2, 3, 4});
            Utils.Print("Ori = ");
            DumpTree(tree);
            tree = obj.AddOneRow(tree, 5, 4);
            Utils.Print("\n\n After = ");
            DumpTree(tree);
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