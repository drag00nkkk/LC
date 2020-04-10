using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class maxDepthAfterSplit_1111
    {
        public static void Test()
        {
            var obj = new maxDepthAfterSplit_1111();
            var res = obj.MaxDepthAfterSplit("((()()))");
            Utils.DumpArray(res);
        }
        
        /*
         *  有效括号字符串 定义：对于每个左括号，都能找到与之对应的右括号，反之亦然。详情参见题末「有效括号字符串」部分。

            嵌套深度 depth 定义：即有效括号字符串嵌套的层数，depth(A) 表示有效括号字符串 A 的嵌套深度。详情参见题末「嵌套深度」部分。

 

            给你一个「有效括号字符串」 seq，请你将其分成两个不相交的有效括号字符串，A 和 B，并使这两个字符串的深度最小。

            不相交：每个 seq[i] 只能分给 A 和 B 二者中的一个，不能既属于 A 也属于 B 。
            A 或 B 中的元素在原字符串中可以不连续。
            A.length + B.length = seq.length
            max(depth(A), depth(B)) 的可能取值最小。
            划分方案用一个长度为 seq.length 的答案数组 answer 表示，编码规则如下：

            answer[i] = 0，seq[i] 分给 A 。
            answer[i] = 1，seq[i] 分给 B 。
            如果存在多个满足要求的答案，只需返回其中任意 一个 即可。

             

            示例 1：

            输入：seq = "(()())"
            输出：[0,1,1,1,1,0]
            示例 2：

            输入：seq = "()(())()"
            输出：[0,0,0,1,1,0,1,1]
         * 
         */
        public int[] MaxDepthAfterSplit(string seq)
        {
            int[] res = new int[seq.Length];
            if (seq == "")
            {
                return res;
            }

            int maxDepth = 0;
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < seq.Length; i++)
            {
                if (seq[i] == '(')
                {
                    stack.Push(i);
                    int depth = stack.Count;
                    if (depth >= maxDepth)
                    {
                        maxDepth = depth;
                    }
                }
                else if(seq[i] == ')')
                {
                    int depth = stack.Count;
                    int halfMaxDepth = maxDepth / 2;
                    int index = stack.Pop();
                    if (depth > halfMaxDepth)
                    {
                        res[i] = 1;
                        res[index] = 1;
                    }

                    if (depth == 1)
                    {
                        maxDepth = 0;
                    }
                }
            }
            
            return res;
        }
    }
}