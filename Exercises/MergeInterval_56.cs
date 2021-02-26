using System;
using System.Collections.Generic;
namespace LeetCode
{
    public class MergeInterval
    {
        public static void Test()
        {
            int[][] a = new int[][]{
                new int[]{2,3}, 
                new int[]{4,5},
                new int[]{6,7},
                new int[]{8,9},
                new int[]{1,10},
                };

            var res = Merge(a);
            foreach (var pair in res)
            {
                Utils.Print($"{pair[0]} {pair[1]}, ");
            }
        }

        /*
        以数组 intervals 表示若干个区间的集合，其中单个区间为 intervals[i] = [starti, endi] 。
        请你合并所有重叠的区间，并返回一个不重叠的区间数组，该数组需恰好覆盖输入中的所有区间。

        示例 1：

        输入：intervals = [[1,3],[2,6],[8,10],[15,18]]
        输出：[[1,6],[8,10],[15,18]]
        解释：区间 [1,3] 和 [2,6] 重叠, 将它们合并为 [1,6].
        示例 2：

        输入：intervals = [[1,4],[4,5]]
        输出：[[1,5]]
        解释：区间 [1,4] 和 [4,5] 可被视为重叠区间。
         

        提示：

        1 <= intervals.length <= 10^4
        intervals[i].length == 2
        0 <= starti <= endi <= 10^4
        */
        private static int[][] Merge(int[][] intervals)
        {
            if (intervals.Length <= 1)
            {
                return intervals;
            }

            List<int[]> list = new List<int[]>(intervals);
            list.Sort((a, b) => { 
                if (a[0] < b[0])
                {
                    return -1;
                }
                else if (a[0] > b[0])
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
                });

            List<int[]> merged = new List<int[]>();
            for (int i = 0; i < list.Count; i++)
            {
                if (merged.Count == 0)
                {
                    merged.Add(list[i]);
                    continue;
                }
                
                var lastMerged = merged[merged.Count - 1];
                if (list[i][0] == lastMerged[0])
                {
                    if (list[i][1] > lastMerged[1])
                    {
                        lastMerged[1] = list[i][1];
                    }
                }
                else if(list[i][0] <= lastMerged[1])
                {
                    lastMerged[1] = Math.Max(lastMerged[1], list[i][1]);
                }
                else
                {
                    merged.Add(list[i]);
                }
            }

            return merged.ToArray();
        }

    }
}
