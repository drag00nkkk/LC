using System.Collections.Generic;

namespace LeetCode
{
    public class longestPalindrome5
    {
        public string LongestPalindrome(string s)
        {
            if (s.Length <= 1)
            {
                return s;
            }

            Dictionary<char, List<int>> recordMap = new Dictionary<char, List<int>>();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                var letter = s[i];
                if (!recordMap.ContainsKey(letter))
                {
                    recordMap[letter] = new List<int>();
                }

                recordMap[letter].Add(i);
            }

            int resLen = 0;
            int resStartIndex = 0;
            int startIndex = 0;
            while (startIndex < s.Length)
            {
                int endStartIndex = s.Length - 1;
                int endIndex = endStartIndex;
                int recordStartIndex = 0;
                while (endIndex >= startIndex)
                {
                    if (recordStartIndex < recordMap[s[startIndex]].Count)
                    {
                        endIndex = recordMap[s[startIndex]][recordStartIndex++];
                    }
                    else
                    {
                        endIndex--;
                    }
                    
                    bool bSuccess = true;
                    var startMoveIndex = startIndex;
                    var endMoveIndex = endIndex;
                    while (endMoveIndex >= startMoveIndex)
                    {
                        if (s[startMoveIndex] == s[endMoveIndex])
                        {
                            startMoveIndex++;
                            endMoveIndex--;
                        }
                        else
                        {
                            bSuccess = false;
                            break;
                        }
                    }
                    
                    if (bSuccess)
                    {
                        var len = endIndex - startIndex + 1;
                        if (len > resLen)
                        {
                            resStartIndex = startIndex;
                            resLen = len;
                        }

                        break;
                    }
                }

                startIndex++;
            }

            Utils.Print($"{resStartIndex}, {resLen}");
            string res = s.Substring(resStartIndex, resLen);

            return res;
        }

        /*
     给定一个字符串 s，找到 s 中最长的回文子串。你可以假设 s 的最大长度为 1000。
     
     输入: "babad"
     输出: "bab"
     注意: "aba" 也是一个有效答案。

     输入: "cbbd"
     输出: "bb"
     */
        public static void Test()
        {
            string input = "abccccdd";
            var obj = new longestPalindrome5();
            Utils.Print(obj.LongestPalindrome(input));
        }
    }
}