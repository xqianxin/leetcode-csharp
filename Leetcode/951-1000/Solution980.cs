﻿
/*
 980. Unique Paths III

On a 2-dimensional grid, there are 4 types of squares:

1 represents the starting square.  There is exactly one starting square.
2 represents the ending square.  There is exactly one ending square.
0 represents empty squares we can walk over.
-1 represents obstacles that we cannot walk over.
Return the number of 4-directional walks from the starting square to the ending square, that walk over every non-obstacle square exactly once.

 

Example 1:

Input: [[1,0,0,0],[0,0,0,0],[0,0,2,-1]]
Output: 2
Explanation: We have the following two paths: 
1. (0,0),(0,1),(0,2),(0,3),(1,3),(1,2),(1,1),(1,0),(2,0),(2,1),(2,2)
2. (0,0),(1,0),(2,0),(2,1),(1,1),(0,1),(0,2),(0,3),(1,3),(1,2),(2,2)
Example 2:

Input: [[1,0,0,0],[0,0,0,0],[0,0,0,2]]
Output: 4
Explanation: We have the following four paths: 
1. (0,0),(0,1),(0,2),(0,3),(1,3),(1,2),(1,1),(1,0),(2,0),(2,1),(2,2),(2,3)
2. (0,0),(0,1),(1,1),(1,0),(2,0),(2,1),(2,2),(1,2),(0,2),(0,3),(1,3),(2,3)
3. (0,0),(1,0),(2,0),(2,1),(2,2),(1,2),(1,1),(0,1),(0,2),(0,3),(1,3),(2,3)
4. (0,0),(1,0),(2,0),(2,1),(1,1),(0,1),(0,2),(0,3),(1,3),(1,2),(2,2),(2,3)
Example 3:

Input: [[0,1],[2,0]]
Output: 0
Explanation: 
There is no path that walks over every empty square exactly once.
Note that the starting and ending square can be anywhere in the grid.
 

Note:

1 <= grid.length * grid[0].length <= 20
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode_csharp.leetcode._951_1000
{
    class Solution980
    {
        public int UniquePathsIII(int[][] grid)
        {
            return helper(grid, 0, 0);
        }

        private int helper(int[][] grid, int i, int j)
        {
            if (i >= grid.Length || j >= grid[0].Length)
            {
                return 0;
            }

            if(grid[i][j] == 2)
            {
                return 1;
            }
            int count = 0;
            if (i - 1 >= 0 && grid[i-1][j] == 0)
            {
                grid[i - 1][j] = -2;
                count += helper(grid, i - 1, j);
                grid[i - 1][j] = 0;
            }
            if(i + 1 < grid.Length && grid[i+1][j] == 0)
            {
                grid[i + 1][j] = -2;
                count += helper(grid, i + 1, j) ;
                grid[i + 1][j] = 0;
            }
            if(j - 1 >=0 && grid[i][j-1] == 0)
            {
                grid[i][j - 1] = -2;
                count += helper(grid, i, j - 1);
                grid[i][j - 1] = 0;
            }
            if(j + 1 < grid[0].Length && grid[i][j+1] == 0)
            {
                grid[i][j + 1] = -2;
                count += helper(grid, i, j + 1);
                grid[i][j + 1] = 0;
            }
            return count;
        }
    }
}
