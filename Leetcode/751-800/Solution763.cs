
/*
 * 763. Partition Labels

A string S of lowercase letters is given. We want to partition this string into as many parts as possible so that each letter
appears in at most one part, and return a list of integers representing the size of these parts.

Example 1:
Input: S = "ababcbacadefegdehijhklij" 
Output: [9,7,8]
Explanation:
The partition is "ababcbaca", "defegde", "hijhklij".
This is a partition so that each letter appears in at most one part.
A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits S into less parts.
Note:

S will have length in range [1, 500].
S will consist of lowercase letters ('a' to 'z') only.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode.Leetcode._751_800
{
    class Solution763
    {
        public IList<int> PartitionLabels(string S)
        {
            Dictionary<int, int> lastIdxMap = new Dictionary<int, int>(26);
            for(int idx = 0; idx < S.Length; idx++)
            {
                lastIdxMap[S[idx] - 'a'] = idx;
            }

            int i = 0;
            List<int> res = new List<int>();
            while(i < S.Length)
            {
                int ilast = lastIdxMap[S[i] - 'a'];
                for (int j = i+1; j < ilast; j++)
                {
                    int jlast = lastIdxMap[S[j] - 'a'];
                    if (jlast > ilast)
                    {
                        ilast = jlast;
                    }
                }
                res.Add(ilast - i + 1);
                i = ilast + 1;
            }
            return res;
        }
    }
}
