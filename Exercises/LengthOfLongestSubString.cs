using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class LengthOfLongestSubstring_
    {
        public static void Test()
        {

        }

        /*
         *给定一个字符串，请你找出其中不含有重复字符的 最长子串 的长度。

            示例 1:

            输入: "abcabcbb"
            输出: 3 
            解释: 因为无重复字符的最长子串是 "abc"，所以其长度为 3。
            示例 2:

            输入: "bbbbb"
            输出: 1
            解释: 因为无重复字符的最长子串是 "b"，所以其长度为 1。
            示例 3:

            输入: "pwwkew"
            输出: 3
            解释: 因为无重复字符的最长子串是 "wke"，所以其长度为 3。
                 请注意，你的答案必须是 子串 的长度，"pwke" 是一个子序列，不是子串。
         * 
         */

         
       public static int LengthOfLongestSubstring(string s) {
           Dictionary<char, int> window = new Dictionary<char, int>();
           var longestLen = 0;
           var left = 0;
           for (int i = 0; i < s.Length; i++)
           {
               var word = s[i];
               if (window.ContainsKey(word))
               {
                   left = Math.Max(window[word] + 1, left);
                   window[word] = i;
               }
               else
               {
                   window.Add(word, i);    
               }

               longestLen = Math.Max(i - left + 1, longestLen);
           }

           return longestLen;
       }
    }
}