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
