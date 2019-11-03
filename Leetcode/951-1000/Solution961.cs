/*
 * 961. N-Repeated Element in Size 2N Array

In a array A of size 2N, there are N+1 unique elements, and exactly one of these elements is repeated N times.

Return the element repeated N times.


Example 1:

Input: [1,2,3,3]
Output: 3
Example 2:

Input: [2,1,2,5,3,2]
Output: 2
Example 3:

Input: [5,1,5,2,5,3,5,4]
Output: 5
 

Note:

4 <= A.length <= 10000
0 <= A[i] < 10000
A.length is even
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode_csharp.leetcode._951_1000
{
    class Solution961
    {
        public int RepeatedNTimes(int[] A)
        {
            for(int i = 0; i < A.Length - 1; i++)
            {
                if(A[i] == A[i+1])
                {
                    return A[i];
                }
                if(i+2 < A.Length && A[i] == A[i+2])
                {
                    return A[i];
                }
            }
            return 0;
        }

        public int RepeatedNtimes2(int[] A)
        {
            HashSet<int> set = new HashSet<int>();
            foreach(int a in A)
            {
                int tmp = set.Count;
                set.Add(a);
                if (set.Count == tmp)
                {
                    return a;
                }
            }
            return 0;
        }
    }
}
