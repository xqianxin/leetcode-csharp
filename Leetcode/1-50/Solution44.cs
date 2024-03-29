/*
44. Wildcard Matching

Given an input string (s) and a pattern (p), implement wildcard pattern matching with support for '?' and '*'.

'?' Matches any single character.
'*' Matches any sequence of characters (including the empty sequence).
The matching should cover the entire input string (not partial).

Note:

s could be empty and contains only lowercase letters a-z.
p could be empty and contains only lowercase letters a-z, and characters like ? or *.
Example 1:

Input:
s = "aa"
p = "a"
Output: false
Explanation: "a" does not match the entire string "aa".
Example 2:

Input:
s = "aa"
p = "*"
Output: true
Explanation: '*' matches any sequence.
Example 3:

Input:
s = "cb"
p = "?a"
Output: false
Explanation: '?' matches 'c', but the second letter is 'a', which does not match 'b'.
Example 4:

Input:
s = "adceb"
p = "*a*b"
Output: true
Explanation: The first '*' matches the empty sequence, while the second '*' matches the substring "dce".
Example 5:

Input:
s = "acdcb"
p = "a*c?b"
Output: false
*/
namespace leetcode_csharp.leetcode._1_50 {
    class Solution44 {
        public bool IsMatch(string s, string p) {
            bool[][] dp = new bool[s.Length + 1][];
            for (int i = 0; i <= s.Length; i++) {
                dp[i] = new bool[p.Length + 1];
                for (int j = 0; j <= p.Length; j++) {
                    dp[i][j] = false;
                }
            }
            dp[0][0] = true;
            for (int j = 1; j <= p.Length; j++) {
                dp[0][j] = p[j - 1] == '*' && dp[0][j-1];
            }
            for (int i = 1; i <= s.Length; i++) {
                for (int j = 1; j <= p.Length; j++) {
                    if (p[j-1] == s[i-1] || p[j-1] == '?') dp[i][j] = dp[i-1][j-1];
                    else if (p[j-1] == '*') dp[i][j] = dp[i-1][j] || dp[i][j-1] || dp[i-1][j-1];
                }
            }
            return dp[s.Length][p.Length];
        }
    }
}