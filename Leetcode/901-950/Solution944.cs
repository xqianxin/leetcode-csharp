﻿
/*
 944. Delete Columns to Make Sorted

We are given an array A of N lowercase letter strings, all of the same length.

Now, we may choose any set of deletion indices, and for each string, we delete all the characters in those indices.

For example, if we have an array A = ["abcdef","uvwxyz"] and deletion indices {0, 2, 3}, then the final array after deletions is 
["bef", "vyz"], and the remaining columns of A are ["b","v"], ["e","y"], and ["f","z"].  
(Formally, the c-th column is [A[0][c], A[1][c], ..., A[A.length-1][c]].)

Suppose we chose a set of deletion indices D such that after deletions, each remaining column in A is in non-decreasing sorted order.

Return the minimum possible value of D.length.

 

Example 1:

Input: ["cba","daf","ghi"]
Output: 1
Explanation: 
After choosing D = {1}, each column ["c","d","g"] and ["a","f","i"] are in non-decreasing sorted order.
If we chose D = {}, then a column ["b","a","h"] would not be in non-decreasing sorted order.
Example 2:

Input: ["a","b"]
Output: 0
Explanation: D = {}
Example 3:

Input: ["zyx","wvu","tsr"]
Output: 3
Explanation: D = {0, 1, 2}
 

Note:

1 <= A.length <= 100
1 <= A[i].length <= 1000
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode_csharp.leetcode._901_950
{
    class Solution944
    {
        public int MinDeletionSize(string[] A)
        {
            int rows = A.Length;
            int cols = A[0].Length;
            if(rows <= 1 || cols < 1)
            {
                return 0;
            }
            int res = 0;
            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < rows - 1; row++)
                {
                    if (A[row][col] > A[row+1][col])
                    {
                        res += 1;
                        break;
                    }
                }
            }
            return res;
        }
    }
}
