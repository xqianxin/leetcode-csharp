using System;
using leetcode_csharp.leetcode._951_1000;

namespace leetcode_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution980 s = new Solution980();
            int[][] p = { new int[] { 1, 0, 0, 0 }, new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 2, -1 } };
            Console.WriteLine(s.UniquePathsIII(p));
            Console.WriteLine("Hello World!");
        }
    }
}
