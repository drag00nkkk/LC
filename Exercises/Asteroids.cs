using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class Asteroids
    {
        /*
         * // 给定一个整数数组 asteroids，表示在同一行的行星。

// 对于数组中的每一个元素，其绝对值表示行星的大小，正负表示行星的移动方向（正表示向右移动，负表示向左移动）。每一颗行星以相同的速度移动。

// 找出碰撞后剩下的所有行星。碰撞规则：两个行星相互碰撞，较小的行星会爆炸。如果两颗行星大小相同，则两颗行星都会爆炸。两颗移动方向相同的行星，永远不会发生碰撞。 

// 示例 1：
// 输入：asteroids = [5,10,-5]
// 输出：[5,10]
// 解释：10 和 -5 碰撞后只剩下 10 。 5 和 10 永远不会发生碰撞。

// 示例 2：
// 输入：asteroids = [8,-8]
// 输出：[]
// 解释：8 和 -8 碰撞后，两者都发生爆炸。

// 示例 3：
// 输入：asteroids = [10,2,-5]
// 输出：[10]
// 解释：2 和 -5 发生碰撞后剩下 -5 。10 和 -5 发生碰撞后剩下 10 。

// 示例 4：
// 输入：asteroids = [-2,-1,1,2]
// 输出：[-2,-1,1,2]
// 解释：-2 和 -1 向左移动，而 1 和 2 向右移动。 由于移动方向相同的行星不会发生碰撞，所以最终没有行星发生碰撞。
         */
        public static void Test()
        {
            Utils.DumpArray(asteroidsExp(new int[] {-2, -1, 3, -5}));
            Utils.DumpArray(asteroidsExp(new int[] {5, 10, -5}));
            Utils.DumpArray(asteroidsExp(new int[] {8, -8}));
            Utils.DumpArray(asteroidsExp(new int[] {10, 2, -5}));
            Utils.DumpArray(asteroidsExp(new int[] {-2, -1, 1, 2}));
        }

        private static int[] asteroidsExp(int[] asteroids)
        {
            if (asteroids == null)
            {
                return null;
            }

            if (asteroids.Length <= 1)
            {
                return asteroids;
            }

            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < asteroids.Length; i++)
            {
                stack.Push(asteroids[i]);
                while (stack.Count > 1)
                {
                    var t1 = stack.Pop();
                    var t2 = stack.Pop();
                    if (t1 < 0 && t2 > 0)
                    {
                        var merge = t1 + t2;
                        if (merge < 0)
                        {
                            stack.Push(t1);
                        }
                        else if (merge > 0)
                        {
                            stack.Push(t2);
                        }
                        else
                        {
                            break;
                        }    
                    }
                    else
                    {
                        stack.Push(t2);
                        stack.Push(t1);
                        break;
                    }
                }
            }

            int[] res = new int [stack.Count];
            var len = stack.Count;
            for (int i = len - 1; i >= 0; i--)
            {
                res[i] = stack.Pop();
            }

            return res;
        }
    }
}
