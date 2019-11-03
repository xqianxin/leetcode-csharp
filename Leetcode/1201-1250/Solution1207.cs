
/*
 * Given an array of integers arr, write a function that returns true if and only if the number of occurrences of each 
 * value in the array is unique.

 

Example 1:

Input: arr = [1,2,2,1,1,3]
Output: true
Explanation: The value 1 has 3 occurrences, 2 has 2 and 3 has 1. No two values have the same number of occurrences.
Example 2:

Input: arr = [1,2]
Output: false
Example 3:

Input: arr = [-3,0,1,-3,1,1,1,-3,10,0]
Output: true
 

Constraints:

1 <= arr.length <= 1000
-1000 <= arr[i] <= 1000
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode_csharp.leetcode._1201_1250
{
    class Solution1207
    {
        public bool UniqueOccurrences(int[] arr)
        {
            Dictionary<int, int> keyCountMap = new Dictionary<int, int>();
            foreach(int a in arr)
            {
                if(!keyCountMap.ContainsKey(a))
                {
                    keyCountMap[a] = 0;
                }
                keyCountMap[a] += 1;
            }
            Dictionary<int, bool> countMap = new Dictionary<int, bool>();
            foreach(int key in keyCountMap.Keys)
            {
                if(countMap.ContainsKey(keyCountMap[key]))
                {
                    return false;
                }
                countMap[keyCountMap[key]] = true;
            }
            return true;
        }
    }
}
