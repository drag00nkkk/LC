namespace LeetCode
{
    public class MergeTwoArraies
    {
        public static void Test()
        {

        }

        /*
         *给定两个排序后的数组 A 和 B，其中 A 的末端有足够的缓冲空间容纳 B。 编写一个方法，将 B 合并入 A 并排序。

            初始化 A 和 B 的元素数量分别为 m 和 n。

            示例:

            输入:
            A = [1,2,3,0,0,0], m = 3
            B = [2,5,6],       n = 3

            输出: [1,2,2,3,5,6]
         * 
         */
        public static void Merge(int[] A, int m, int[] B, int n)
        {
            var pa = m - 1;
            var pb = n - 1;
            var cur = m + n - 1;
            while (cur >= 0)
            {
                int val = 0;
                if (pa < 0)
                {
                    val = B[pb--];
                }
                else if (pb < 0)
                {
                    val = A[pa--];
                }
                else if (A[pa] >= B[pb])
                {
                    val = A[pa--];
                }
                else if (A[pa] < B[pb])
                {
                    val = B[pb--];
                }

                A[cur--] = val;
            }
    }

    }
}