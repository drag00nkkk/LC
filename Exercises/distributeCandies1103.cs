using System;

namespace LeetCode
{
    public class distributeCandies1103
    {
        public int[] DistributeCandies(int candies, int num_people)
        {
            int[] res = new int [num_people];
            int lastSendFullIndex = (int) Math.Floor(Math.Sqrt(2 * candies + 0.25) - 0.5) - 1; // 注意超过最大长度
            Console.WriteLine($"{lastSendFullIndex}");
            var lastFullChildIndex = lastSendFullIndex % num_people;
            int lastLineIndex = lastSendFullIndex / num_people;
            int notFullCandies = candies - (1 + lastSendFullIndex + 1) * (lastSendFullIndex + 1) / 2;
            for (int i = 0; i < num_people; i++)
            {
                res[i] = (i + 1 + i + 1 + (lastLineIndex - 1) * num_people) * lastLineIndex / 2;
                if (i <= lastFullChildIndex)
                {
                    res[i] += i + 1 + lastLineIndex * num_people;
                }

                if (lastFullChildIndex + 1 == num_people ? i == 0 : i == lastFullChildIndex + 1)
                {
                    res[i] += notFullCandies;
                }
            }

            return res;
        }

        /*
            输入：candies = 10, num_people = 3
            输出：[5,2,3]
            解释：
            第一次，ans[0] += 1，数组变为 [1,0,0]。
            第二次，ans[1] += 2，数组变为 [1,2,0]。
            第三次，ans[2] += 3，数组变为 [1,2,3]。
            第四次，ans[0] += 4，最终数组变为 [5,2,3]。
            
            60,4
            15,18,15,12
            
            1000000000,1000
            [990045,990090,990135,990180,990225,990270,990315,990360,990405,990450,990495,990540,990585,990630,990675,990720,990765,990810,990855,990900,990945,990990,991035,991080,991125,991170,991215,991260,991305,991350,991395,991440,991485,991530,991575,991620,991665,991710,991755,991800,991845,991890,991935,991980,992025,992070,992115,992160,992205,992250,992295,992340,992385,992430,992475,992520,992565,992610,992655,992700,992745,992790,992835,992880,992925,992970,993015,993060,993105,993150,993195,993240,993285,993330,993375,993420,993465,993510,993555,993600,993645,993690,993735,993780,993825,993870,993915,993960,994005,994050,994095,994140,994185,994230,994275,994320,994365,994410,994455,994500,994545,994590,994635,994680,994725,994770,994815,994860,994905,994950,994995,995040,995085,995130,995175,995220,995265,995310,995355,995400,995445,995490,995535,995580,995625,995670,995715,995760,995805,995850,995895,995940,995985,996030,996075,996120,996165,996210,996255,996300,996345,996390,99643...
            1 <= candies <= 10^9
            1 <= num_people <= 1000
         */
        public static void Test()
        {
            var obj = new distributeCandies1103();
            Utils.DumpArray(obj.DistributeCandies(1000000000, 1000));
        }
    }
}