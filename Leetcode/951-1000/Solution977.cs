
/*
 977. Squares of a Sorted Array

Given an array of integers A sorted in non-decreasing order, return an array of the squares of each number, 
also in sorted non-decreasing order.

Example 1:

Input: [-4,-1,0,3,10]
Output: [0,1,9,16,100]
Example 2:

Input: [-7,-3,2,3,11]
Output: [4,9,9,49,121]
 

Note:

1 <= A.length <= 10000
-10000 <= A[i] <= 10000
A is sorted in non-decreasing order.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode_csharp.leetcode._951_1000
{
    class Solution977
    {
        public int[] SortedSquares(int[] A)
        {
            int[] result = new int[A.Length];

            int i = 0;
            int j = 0;

            while (j < A.Length && A[j] < 0)
            {
                j++;
            }
            i = j - 1;

            int idx = 0;
            while (i >= 0 && j < A.Length)
            {
                int ii = A[i] * A[i];
                int jj = A[j] * A[j];
                if (ii < jj)
                {
                    result[idx] = ii;
                    i--;
                } else
                {
                    result[idx] = jj;
                    j++;
                }
                idx++;
            }
            while(i >= 0)
            {
                result[idx] = A[i] * A[i];
                i--;
                idx++;
            }
            while(j < A.Length)
            {
                result[idx] = A[j] * A[j];
                j++;
                idx++;
            }
            return result;
        }
    }
}
