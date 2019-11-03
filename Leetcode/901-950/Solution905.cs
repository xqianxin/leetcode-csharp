/*
 * 905. Sort Array By Parity

Given an array A of non-negative integers, return an array consisting of all the even elements of A, followed by all the odd 
elements of A.

You may return any answer array that satisfies this condition.

 

Example 1:

Input: [3,1,2,4]
Output: [2,4,3,1]
The outputs [4,2,3,1], [2,4,1,3], and [4,2,1,3] would also be accepted.
 

Note:

1 <= A.length <= 5000
0 <= A[i] <= 5000
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode.Leetcode._901_950
{
    class Solution905
    {
        public int[] SortArrayByParity(int[] A)
        {
            if(null == A || A.Length == 1)
            {
                return A;
            }

            int l = 0;
            int r = A.Length - 1;

            while (l < r)
            {
                while (l < r && A[l] % 2 == 0)
                {
                    l++;
                }
                while (l < r && A[r] % 2 == 1)
                {
                    r--;
                }
                if (l < r)
                {
                    A[l] = A[l] ^ A[r];
                    A[r] = A[l] ^ A[r];
                    A[l] = A[l] ^ A[r];
                }
            }
            return A;
        }
    }
}
