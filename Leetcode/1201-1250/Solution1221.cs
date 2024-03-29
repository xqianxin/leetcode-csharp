﻿using System;
using System.Collections.Generic;
using System.Text;

/*
Balanced strings are those who have equal quantity of 'L' and 'R' characters.

Given a balanced string s split it in the maximum amount of balanced strings.

Return the maximum amount of splitted balanced strings.

 

Example 1:

Input: s = "RLRRLLRLRL"
Output: 4
Explanation: s can be split into "RL", "RRLL", "RL", "RL", each substring contains same number of 'L' and 'R'.
Example 2:

Input: s = "RLLLLRRRLR"
Output: 3
Explanation: s can be split into "RL", "LLLRRR", "LR", each substring contains same number of 'L' and 'R'.
Example 3:

Input: s = "LLLLRRRR"
Output: 1
Explanation: s can be split into "LLLLRRRR".
 

Constraints:

1 <= s.length <= 1000
s[i] = 'L' or 'R'
 */

/*
 RLRRLLRLRL
 0


 */

namespace leetcode_csharp.leetcode._1201_1250
{
    class Solution1221
    {
        public int BalancedStringSplit(string s)
        {
            int sum = 0;
            int count = 0;
            foreach(char c in s)
            {
                if (c == 'L') {
                    sum += 1;
                } else {
                    sum -= 1;
                }
                if (sum == 0) {
                    count += 1;
                }
            }
            return count;
        }
    }
}
