/*
 * Given the root of a binary search tree with distinct values, modify it so that every node has a new value equal to the sum of the values of the original tree that are greater than or equal to node.val.

As a reminder, a binary search tree is a tree that satisfies these constraints:

The left subtree of a node contains only nodes with keys less than the node's key.
The right subtree of a node contains only nodes with keys greater than the node's key.
Both the left and right subtrees must also be binary search trees.
 
 */



using System;
using System.Collections.Generic;
using System.Text;
using leetcode_csharp.leetcode.structs;

namespace leetcode_csharp.leetcode._1001_1050
{
    class Soluton1038
    {
        public TreeNode BstToGst(TreeNode root)
        {
            helper(root, 0);
            return root;
        }

        private int helper(TreeNode node, int add)
        {
            if (null == node)
            {
                return add;
            }

            int rightMax = helper(node.right, add);
            node.val += rightMax;
            return helper(node.left, node.val);
        }
    }
}
