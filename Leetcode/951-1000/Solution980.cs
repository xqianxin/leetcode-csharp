
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
            int r = 0, c = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        r = i;
                        c = j;
                        break;
                    }
                }
            }
            grid[r][c] = 0;
            Console.WriteLine(r);
            Console.WriteLine(c);
            List<List<int[]>> paths = helper(grid, r, c);
            for (int i = 0; i < paths.Count; i++)
            {
                printList(paths[i]);
            }
            return paths.Count;
        }

        private void printList(List<int[]> path)
        {
            for(int i = 0; i < path.Count; i++)
            {
                Console.Write("(");
                Console.Write(path[i][0]);
                Console.Write(path[i][1]);
                Console.Write(")");
            }
            Console.Write("\n");
        }

        private void printGrid(int[][] grid)
        {
            for(int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j< grid[0].Length; j++)
                {
                    Console.Write(grid[i][j]);
                    Console.Write(",");
                }
                Console.Write("\n");
            }
        }

        private List<List<int[]>> helper(int[][] grid, int i, int j)
        {
            List<List<int[]>> result = new List<List<int[]>>();
            if (i < 0 || j < 0 || i >= grid.Length || j >= grid[0].Length)
            {
                return result;
            }

            if(grid[i][j] == 2)
            {
                // printGrid(grid);
                bool ok = true;
                for (int r =0; r < grid.Length; r++)
                {
                    for (int c = 0; c < grid[0].Length; c++)
                    {
                        if(grid[r][c] == 0)
                        {
                            ok = false;
                        }
                    }
                }
                if (ok)
                {
                    int[] point = new int[]{i, j};
                    List<int[]> path = new List<int[]>();
                    path.Add(point);
                    result.Add(path);
                }
                return result;
            }
            if(grid[i][j] != 0)
            {
                return result;
            }
            grid[i][j] = -2;
            List<List<int[]>> resu = helper(grid, i - 1, j);
            if (resu.Count > 0)
            {
                foreach (List<int[]> pa in resu)
                {
                    List<int[]> tmpPath = new List<int[]>();
                    int[] point = new int[] { i, j };
                    tmpPath.Add(point);
                    foreach (int[] po in pa)
                    {
                        tmpPath.Add(po);
                    }
                    printList(tmpPath);
                    result.Add(tmpPath);
                }
            }
            List<List<int[]>> resd = helper(grid, i + 1, j) ;
            if (resd.Count > 0)
            {
                foreach(List<int[]> pa in resd)
                {
                    List<int[]> tmpPath = new List<int[]>();
                    int[] point = new int[] { i, j };
                    tmpPath.Add(point);
                    foreach(int[] po in pa)
                    {
                        tmpPath.Add(po);
                    }
                    printList(tmpPath);
                    result.Add(tmpPath);
                }
            }
            List<List<int[]>> resl = helper(grid, i, j - 1);
            if (resl.Count > 0)
            {
                foreach (List<int[]> pa in resl)
                {
                    List<int[]> tmpPath = new List<int[]>();
                    int[] point = new int[] { i, j };
                    tmpPath.Add(point);
                    foreach (int[] po in pa)
                    {
                        tmpPath.Add(po);
                    }
                    printList(tmpPath);
                    result.Add(tmpPath);
                }
            }
            List<List<int[]>> resr = helper(grid, i, j + 1);
            if (resr.Count > 0)
            {
                foreach (List<int[]> pa in resr)
                {
                    List<int[]> tmpPath = new List<int[]>();
                    int[] point = new int[] { i, j };
                    tmpPath.Add(point);
                    foreach (int[] po in pa)
                    {
                        tmpPath.Add(po);
                    }
                    printList(tmpPath);
                    result.Add(tmpPath);
                }
            }
            grid[i][j] = 0;
            return result;
        }
    }
}
