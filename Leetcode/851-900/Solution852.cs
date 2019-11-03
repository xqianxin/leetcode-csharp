
/*
 * 852. Peak Index in a Mountain Array
 * 
 * Let's call an array A a mountain if the following properties hold:

A.length >= 3
There exists some 0 < i < A.length - 1 such that A[0] < A[1] < ... A[i-1] < A[i] > A[i+1] > ... > A[A.length - 1]
Given an array that is definitely a mountain, return any i such that A[0] < A[1] < ... A[i-1] < A[i] > A[i+1] > ... > A[A.length - 1].

Example 1:

Input: [0,1,0]
Output: 1
Example 2:

Input: [0,2,1,0]
Output: 1
Note:

3 <= A.length <= 10000
0 <= A[i] <= 10^6
A is a mountain, as defined above.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode.Leetcode._851_900
{
    class Solution852
    {
        public int PeakIndexInMountainArray(int[] A)
        {
            /* 暴力法
            if (A.Length < 3)
            {
                return 0;
            }

            for (int i = 1; i < A.Length - 1; i++)
            {
                if (A[i] > A[i - 1] && A[i] < A[i + 1])
                {
                    return i;
                }
            }

            return 0;
            */
            /* 二分法 */

            if (A.Length < 3) { return 0; }

            int start = 0;
            int end = A.Length - 1;

            while(start <= end)
            {
                if (start == end)
                {
                    return start;
                }
                int mid = (start + end) / 2;
                if (A[mid] > A[mid - 1] && A[mid] > A[mid + 1])
                {
                    return mid;
                }
                if (A[mid] > A[mid - 1] && A[mid] < A[mid + 1])
                {
                    start = mid + 1;
                } else
                {
                    end = mid - 1;
                }
            }
            return 0;
        }
    }
}
