
/*
 894. All Possible Full Binary Trees

A full binary tree is a binary tree where each node has exactly 0 or 2 children.

Return a list of all possible full binary trees with N nodes.  Each element of the answer is the root node of one possible tree.

Each node of each tree in the answer must have node.val = 0.

You may return the final list of trees in any order.

 

Example 1:

Input: 7
Output: 
[[0,0,0,null,null,0,0,null,null,0,0],
[0,0,0,null,null,0,0,0,0],
[0,0,0,0,0,0,0],
[0,0,0,0,0,null,null,null,null,0,0],
[0,0,0,0,0,null,null,0,0]]
 */

using System;
using System.Collections.Generic;
using System.Text;
using leetcode_csharp.leetcode.structs;

namespace leetcode_csharp.leetcode._851_900
{
    class Solution894
    {
        public IList<TreeNode> AllPossibleFBT(int N)
        {
            IList<TreeNode> result = new List<TreeNode>();
            if (N % 2 == 0)
            {
                return result;
            }

            if (N == 1)
            {
                result.Add(new TreeNode(0));
            }
            
            for (int i = 1; i < N; i+=2)
            {
                IList<TreeNode> lefts = AllPossibleFBT(i);
                IList<TreeNode> rights = AllPossibleFBT(N - i - 1);
                foreach (TreeNode l in lefts) 
                {
                    foreach (TreeNode r in rights)
                    {
                        TreeNode root = new TreeNode(0);
                        root.left = l;
                        root.right = r;
                        result.Add(root);
                    }
                }
            }
            return result;
        }
    }
}
