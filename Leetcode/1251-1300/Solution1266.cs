
/*
On a plane there are n points with integer coordinates points[i] = [xi, yi]. Your task is to find the minimum time in seconds to visit all points.

You can move according to the next rules:

In one second always you can either move vertically, horizontally by one unit or diagonally (it means to move one unit vertically and one unit horizontally in one second).
You have to visit the points in the same order as they appear in the array.
 
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode_csharp.leetcode._1251_1300
{
    class Solution1266
    {
        public int MinTimeToVisitAllPoints(int[][] points) {
            if (null == points || points.Length <= 1) {
                return 0;
            }
            int res = 0;
            for (int i = 1; i < points.Length; i++) {
                int a = Math.Abs(points[i][0] - points[i-1][0]);
                int b = Math.Abs(points[i][1] - points[i-1][1]);
                int c = Math.Min(a, b);
                int d = Math.Abs(a - b);
                res += (c + d);
            }
            return res;
        }
    }
}
