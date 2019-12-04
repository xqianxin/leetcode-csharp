using System.IO;
using System.Collections.Generic;
/*
37. Sudoku Solver

Write a program to solve a Sudoku puzzle by filling the empty cells.

A sudoku solution must satisfy all of the following rules:

Each of the digits 1-9 must occur exactly once in each row.
Each of the digits 1-9 must occur exactly once in each column.
Each of the the digits 1-9 must occur exactly once in each of the 9 3x3 sub-boxes of the grid.
*/

namespace leetcode_csharp.leetcode._1_50 {
    class Solution37
    {
        private Dictionary<int, HashSet<char>> rmap;
        private Dictionary<int, HashSet<char>> cmap;
        private Dictionary<int, HashSet<char>> bmap;
        public void SolveSudoku(char[][] board) {
            rmap = new Dictionary<int, HashSet<char>>();
            cmap = new Dictionary<int, HashSet<char>>();
            bmap = new Dictionary<int, HashSet<char>>();
            for (int i = 0; i < 9; i++) {
                for (int j = 0; j < 9; j++) {
                    if (!rmap.ContainsKey(i)) {
                        rmap[i] = new HashSet<char>();
                    }
                    rmap[i].Add(board[i][j]);
                    if (!cmap.ContainsKey(j)) {
                        cmap[j] = new HashSet<char>();
                    }
                    cmap[j].Add(board[i][j]);
                    int bidx = (i - i % 3) + (j - j%3) / 3;
                    if(!bmap.ContainsKey(bidx)) {
                        bmap[bidx] = new HashSet<char>();
                    }
                    bmap[bidx].Add(board[i][j]);
                }
            }
            bool res = SolveSudoku2(board, 0, 0);
            return;
        }

        public bool SolveSudoku2(char[][] board, int i, int j) {
            if (i == 9 || j == 9) {
                return true;
            }
            int ni = i;
            int nj = j;
            if (nj == 8) {ni++;nj = 0;} 
            else nj++;
            if (board[i][j] == '.') {
                for (char x = '1'; x <= '9'; x++) {
                    int ridx = i;
                    int cidx = j;
                    int bidx = i - (i % 3) + (j - (j % 3)) / 3;
                    if (!cmap[cidx].Contains(x) && !rmap[ridx].Contains(x) && !bmap[bidx].Contains(x)) {
                        board[i][j] = x;
                        cmap[cidx].Add(x);
                        rmap[ridx].Add(x);
                        bmap[bidx].Add(x);
                        bool res = SolveSudoku2(board, ni, nj);
                        if (res) {
                            return true;
                        }
                        board[i][j] = '.';
                        cmap[cidx].Remove(x);
                        rmap[ridx].Remove(x);
                        bmap[bidx].Remove(x);
                    }
                }
                return false;
            } else {
                return SolveSudoku2(board, ni, nj);
            }
        }
    }
}