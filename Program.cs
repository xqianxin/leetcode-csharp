using System;
using leetcode.Leetcode._751_800;
using System.Collections.Generic;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution797 s = new Solution797();
            int[][] pa = new int[][] { new int[]{ 1, 2 }, new int[]{ 3 }, new int[]{ 3 },new int[]{ } };
            IList<IList<int>> res = s.AllPathsSourceTarget(pa);
            Console.WriteLine(res);
            Console.WriteLine("Hello World!");
        }
    }
}
