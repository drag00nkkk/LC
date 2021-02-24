using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LeetCode
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
        
        public static void Test()
        {
            var obj = new LowestCommonAncestor_interview_4_8();
//            var tree = TreeHelper.MakeTree(new[] {3, 5, 1, 6, 2, 0, 8, -1, -1, 7, 4});
//            var resNode = obj.LowestCommonAncestor(tree, new TreeNode(5), new TreeNode(1));
//            var tree = TreeHelper.MakeTree(new[] {0, 1, -1, 2, -1, -1, -1, 3});
//            var tree = TreeHelper.MakeTree(new[]
//                {37, -34, -48, -1, -100, -101, 48, -1, -1, -1, -1, -54, -1, -71, -22, -1, -1, -1, 8});

            var tree = TreeHelper.MakeTree(new[]
                {1, 2, -1, 3, -1, 4, -1, 5, -1, 6, -1});

            TreeHelper.DumpTree(tree);
            var resNode = obj.LowestCommonAncestor(tree, new TreeNode(3), new TreeNode(6));
            Utils.Print($"vvval = {resNode?.val}");
        }
    }
}