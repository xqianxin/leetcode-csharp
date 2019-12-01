/*
1252. Cells with Odd Values in a Matrix

Given n and m which are the dimensions of a matrix initialized by zeros and given an array indices where indices[i] = [ri, ci]. For each pair of [ri, ci] you have to increment all cells in row ri and column ci by 1.

Return the number of cells with odd values in the matrix after applying the increment to all indices.

Example 1:

Input: n = 2, m = 3, indices = [[0,1],[1,1]]
Output: 6
Explanation: Initial matrix = [[0,0,0],[0,0,0]].
After applying first increment it becomes [[1,2,1],[0,1,0]].
The final matrix will be [[1,3,1],[1,3,1]] which contains 6 odd numbers.

Example 2:

Input: n = 2, m = 2, indices = [[1,1],[0,0]]
Output: 0
Explanation: Final matrix = [[2,2],[2,2]]. There is no odd number in the final matrix.
*/
using System.Collections.Generic;
namespace leetcode_csharp.leetcode._1251_1300 {
    class Solution1252 {
            public int OddCells(int n, int m, int[][] indices) {
                if (n == 0 || m == 0 || indices.Length == 0) {
                    return 0;
                }
                List<List<int>> M = new List<List<int>>();
                for (int i = 0; i < n; i++) {
                    M.Add(new List<int>());
                    for (int j = 0; j < m; j++) {
                        M[i].Add(0);
                    }
                }
                for (int i = 0; i < indices.Length; i++) {
                    int r = indices[i][0];
                    int c = indices[i][1];
                    for (int x=0; x < M[0].Count; x++) {
                        M[r][x] += 1;
                    }
                    for (int x=0; x < M.Count; x++) {
                        M[x][c] += 1;
                    }
                }
                int res = 0;
                for (int i=0; i < n; i++) {
                    for (int j=0; j < m; j++) {
                        if (M[i][j] % 2 == 1) {
                            res +=1;
                        }
                    }
                }
                return res;
            }
    }
}