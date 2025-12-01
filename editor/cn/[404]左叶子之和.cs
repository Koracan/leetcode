//给定二叉树的根节点 root ，返回所有左叶子之和。 
//
// 
//
// 示例 1： 
//
// 
//
// 
//输入: root = [3,9,20,null,null,15,7] 
//输出: 24 
//解释: 在这个二叉树中，有两个左叶子，分别是 9 和 15，所以返回 24
// 
//
// 示例 2: 
//
// 
//输入: root = [1]
//输出: 0
// 
//
// 
//
// 提示: 
//
// 
// 节点数在 [1, 1000] 范围内 
// -1000 <= Node.val <= 1000 
// 
//
// 
//
// Related Topics 树 深度优先搜索 广度优先搜索 二叉树 👍 791 👎 0

namespace SumOfLeftLeaves;

//leetcode submit region begin(Prohibit modification and deletion)
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    public int SumOfLeftLeaves(TreeNode root)
    {
        var stack = new Stack<TreeNode>();
        stack.Push(root);
        var sum = 0;
        while (stack.Count > 0) {
            var node = stack.Pop();
            if (node.left != null) {
                if (IsLeaf(node.left)) sum += node.left.val;
                else stack.Push(node.left);
            }
            if (node.right != null && !IsLeaf(node.right)) stack.Push(node.right);
        }

        return sum;
    }
    static bool IsLeaf(TreeNode node) => node.left == null && node.right == null;
}

//leetcode submit region end(Prohibit modification and deletion)
public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
{
    public int val = val;
    public TreeNode? left = left;
    public TreeNode? right = right;
}
