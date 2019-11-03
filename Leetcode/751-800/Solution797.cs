
/* 
 * 797. All Paths From Source to Target
 * Given a directed, acyclic graph of N nodes.  Find all possible paths from node 0 to node N-1, and return them in any order.

The graph is given as follows:  the nodes are 0, 1, ..., graph.length - 1.  graph[i] is a list of all nodes j for which the edge (i, j) exists.

Example:
Input: [[1,2], [3], [3], []] 
Output: [[0,1,3],[0,2,3]] 
Explanation: The graph looks like this:
0--->1
|    |
v    v
2--->3
There are two paths: 0 -> 1 -> 3 and 0 -> 2 -> 3.
Note:

The number of nodes in the graph will be in the range [2, 15].
You can print different paths in any order, but you should keep the order of nodes inside one path.
 */

 // dfs

using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode_csharp.leetcode._751_800
{
    class Solution797
    {
        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            return helper(0, graph);
        }

        public IList<IList<int>> helper(int start, int[][] graph)
        {
            if (graph == null || start >= graph.Length)
            {
                return new int[0][];
            }
            IList<IList<int>> result = new List<IList<int>>();
            foreach(int e in graph[start])
            {
                if (e == graph.Length - 1)
                {
                    
                    result.Add(new List<int>(new int[] { start, e }));
                    continue;
                }

                IList<IList<int>> nextRes = helper(e, graph);
                foreach(List<int> res in nextRes)
                {
                    List<int> tmp = new List<int>(new int[] { start});
                    foreach(int path in res)
                    {
                        tmp.Add(path);
                    }
                    result.Add(tmp);
                }
            }
            return result;
        }
    }
}
