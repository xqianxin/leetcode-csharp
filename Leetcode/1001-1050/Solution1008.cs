
/*
 * Return the root node of a binary search tree that matches the given preorder traversal.

(Recall that a binary search tree is a binary tree where for every node, any descendant of node.left has a value < node.val, and any descendant of node.right has a value > node.val.  Also recall that a preorder traversal displays the value of the node first, then traverses node.left, then traverses node.right.)

 

Example 1:

Input: [8,5,1,7,10,12]
Output: [8,5,10,1,7,null,12]
 */

using System;
using System.Collections.Generic;
using System.Text;
using leetcode.Leetcode.structs;

namespace leetcode.Leetcode._1001_1050
{
    class Solution1008
    {
        public TreeNode BstFromPreorder(int[] preorder)
        {
            return BstFromPreorderRange(preorder, 0, preorder.Length-1);
        }

        public TreeNode BstFromPreorderRange(int[] preorder, int start, int end)
        {
            if (null == preorder || end < start || start >= preorder.Length || end >= preorder.Length)
            {
                return null;
            }

            TreeNode node = new TreeNode(preorder[start]);
            int ls = start + 1;
            int le = start + 1;
            while(le <= end && preorder[le] < preorder[start])
            {
                le++;
            }
            node.left = BstFromPreorderRange(preorder, ls, le - 1);
            node.right = BstFromPreorderRange(preorder, le, end);

            return node;
        }
    }
}
