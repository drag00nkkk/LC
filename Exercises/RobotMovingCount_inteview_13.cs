using System.Collections.Generic;

namespace LeetCode
{
    public class RobotMovingCount_inteview_13
    {
        public static void Test()
        {
            var obj = new RobotMovingCount_inteview_13();
            var res = obj.MovingCount(1, 2, 1);
//            var res = obj.MovingCount(2, 3, 1);
            Utils.Print($"rrr = {res}");
        }

        /*
         * 地上有一个m行n列的方格，从坐标 [0,0] 到坐标 [m-1,n-1] 。
         * 一个机器人从坐标 [0, 0] 的格子开始移动，它每次可以向左、右、上、下移动一格（不能移动到方格外），
         * 也不能进入行坐标和列坐标的数位之和大于k的格子。例如，当k为18时，机器人能够进入方格 [35, 37] ，因为3+5+3+7=18。
         * 但它不能进入方格 [35, 38]，因为3+5+3+8=19。请问该机器人能够到达多少个格子？
         
        示例 1：

        输入：m = 2, n = 3, k = 1
        输出：3
        
        示例 1：

        输入：m = 3, n = 1, k = 0
        输出：1
        
        提示：

        1 <= n,m <= 100
        0 <= k <= 20
        
         */

        private Dictionary<int, bool> stepRecord = new Dictionary<int, bool>();
        private int[] xPlan = {1, 0};
        private int[] yPlan = {0, 1};
        private int castBase = 0;
        private int maxX = 0;
        private int maxY = 0;
        private int limit = 0;
        
        public int MovingCount(int m, int n, int k)
        {
            if (k <= 0)
            {
                return 1;
            }

            castBase = m * n;
            maxX = m;
            maxY = n;
            limit = k;

            Move(0, 0);
            
            return stepRecord.Count + 1;
        }

        private void Move(int x, int y)
        {
            for (int i = 0; i < 2; i++)
            {
                var nextX = x + xPlan[i];
                var nextY = y + yPlan[i];
                if ((!IsRecord(nextX, nextY)) && IsValid(nextX, nextY))
                {
                    Utils.Print($"{nextX}, {nextY}");
                    RecordStep(nextX, nextY);
                    Move(nextX, nextY);
                }
            }
        }

        private void RecordStep(int x, int y)
        {
            var key = castBase * 10 + x * castBase + y;

            if (!stepRecord.ContainsKey(key))
            {
                stepRecord.Add(key, true);
            }
        }

        private bool IsRecord(int x, int y)
        {
            var key = castBase * 10 + x * castBase + y;
//            Utils.Print($"is record = {key}, {stepRecord.ContainsKey(key)}");
            return stepRecord.ContainsKey(key);
        }

        private bool IsValid(int x, int y)
        {
            if (x >= maxX || y >= maxY || x < 0 || y < 0)
            {
//                Utils.Print($" not valid ==  {x}, {y}, {maxX}, {maxY}");
                return false;
            }

            int calcResult(int val)
            {
                int res = 0;
                while (val > 0)
                {
                    res += val % 10;
                    val /= 10;
                }

                return res;
            }

            int result = calcResult(x);
            result += calcResult(y);

//            Utils.Print($" v = {x}, {y}, {result}");
            return result <= limit;
        }
    }
}