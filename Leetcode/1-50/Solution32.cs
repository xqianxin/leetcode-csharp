using System;
using System.Numerics;
using System.Collections.Generic;
/*
Given a string containing just the characters '(' and ')', find the length of the longest valid (well-formed) parentheses substring.

Example 1:

Input: "(()"
Output: 2
Explanation: The longest valid parentheses substring is "()"
Example 2:

Input: ")()())"
Output: 4
Explanation: The longest valid parentheses substring is "()()"
*/
namespace leetcode_csharp.leetcode._1_50 {
    class Solution32
    {
        public int LongestValidParentheses(string s) {
            int res =0;
            List<int> dp = new List<int>(s.Length);
            for(int i = 0; i < s.Length; i++) {
                dp.Add(0);
            }
            s = ")" + s;
            for (int i = 1; i < s.Length; i++) {
                if(s[i] == ')') {
                    if (s[i-1-dp[i-1]] == '(') {
                        dp[i] = dp[i-1] + 2;
                    }
                    dp[i] += dp[i-dp[i]];
                }
                res = Math.Max(dp[i], res);
            }
            return res;
        }
    }
}