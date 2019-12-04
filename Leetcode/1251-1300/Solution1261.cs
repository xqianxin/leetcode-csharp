using System.Collections.Generic;
/*
1261. Find Elements in a Contaminated Binary Tree

Given a binary tree with the following rules:

root.val == 0
If treeNode.val == x and treeNode.left != null, then treeNode.left.val == 2 * x + 1
If treeNode.val == x and treeNode.right != null, then treeNode.right.val == 2 * x + 2
Now the binary tree is contaminated, which means all treeNode.val have been changed to -1.

You need to first recover the binary tree and then implement the FindElements class:

FindElements(TreeNode* root) Initializes the object with a contamined binary tree, you need to recover it first.
bool find(int target) Return if the target value exists in the recovered binary tree.
 

Example 1:
Input
["FindElements","find","find"]
[[[-1,null,-1]],[1],[2]]
Output
[null,false,true]
Explanation
FindElements findElements = new FindElements([-1,null,-1]); 
findElements.find(1); // return False 
findElements.find(2); // return True 

Example 2:
Input
["FindElements","find","find","find"]
[[[-1,-1,-1,-1,-1]],[1],[3],[5]]
Output
[null,true,true,false]
Explanation
FindElements findElements = new FindElements([-1,-1,-1,-1,-1]);
findElements.find(1); // return True
findElements.find(3); // return True
findElements.find(5); // return False

Example 3:
Input
["FindElements","find","find","find","find"]
[[[-1,null,-1,-1,null,-1]],[2],[3],[4],[5]]
Output
[null,true,false,false,true]
Explanation
FindElements findElements = new FindElements([-1,null,-1,-1,null,-1]);
findElements.find(2); // return True
findElements.find(3); // return False
findElements.find(4); // return False
findElements.find(5); // return True
 

Constraints:

TreeNode.val == -1
The height of the binary tree is less than or equal to 20
The total number of nodes is between [1, 10^4]
Total calls of find() is between [1, 10^4]
0 <= target <= 10^6
*/

using leetcode_csharp.leetcode.structs;

namespace leetcode_csharp.leetcode._1251_1300 {
    class Solution1261 {
        private TreeNode root;
        private void construct_tree(TreeNode node, int father, int bias) {
            if (null == node) {
                return;
            }
            node.val = 2 * father + bias;
            construct_tree(node.left, node.val, 1);
            construct_tree(node.right, node.val, 2);
        }
        public Solution1261(TreeNode root) {
            if (null == root) {
                return;
            }
            construct_tree(root, -1, 2);
            this.root = root;
        }
        public bool Find(int target) {
            if (target == 0) {
                return this.root != null;
            }
            List<int> targets = new List<int>();
            while (target != 0) {
                targets.Add(target);
                if (target % 2 == 0) {
                    target = (target - 2) / 2;
                } else {
                    target = (target - 1) / 2;
                }
            }
            TreeNode cur = this.root;
            for(int i = targets.Count - 1; i >= 0; i--) {
                int e = targets[i];
                if(e % 2 == 1) {
                    cur = cur.left;
                } else {
                    cur = cur.right;
                }
                if (cur == null) {
                    return false;
                }
            }
            return true;
        }
    }
}