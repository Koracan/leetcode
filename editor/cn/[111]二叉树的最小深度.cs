//给定一个二叉树，找出其最小深度。 
//
// 最小深度是从根节点到最近叶子节点的最短路径上的节点数量。 
//
// 说明：叶子节点是指没有子节点的节点。 
//
// 
//
// 示例 1： 
// 
// 
//输入：root = [3,9,20,null,null,15,7]
//输出：2
// 
//
// 示例 2： 
//
// 
//输入：root = [2,null,3,null,4,null,5,null,6]
//输出：5
// 
//
// 
//
// 提示： 
//
// 
// 树中节点数的范围在 [0, 10⁵] 内 
// -1000 <= Node.val <= 1000 
// 
//
// Related Topics 树 深度优先搜索 广度优先搜索 二叉树 👍 1278 👎 0

namespace MinimumDepthOfBinaryTree;

//leetcode submit region begin(Prohibit modification and deletion)
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 * public int val;
 * public TreeNode left;
 * public TreeNode right;
 * public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 * this.val = val;
 * this.left = left;
 * this.right = right;
 * }
 * }
 */
public class Solution
{
    public int MinDepth(TreeNode root)
    {
        var queue = new Queue<TreeNode>();
        var result = 0;
        if (root != null) queue.Enqueue(root);
        while (queue.Count > 0) {
            result++;
            var count = queue.Count;
            for (var i = 0; i < count; i++) {
                var node = queue.Dequeue();
                if (node.left == null && node.right == null) return result;
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
        }

        return result; // should reach here only if root is null
    }
}

//leetcode submit region end(Prohibit modification and deletion)
public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
{
    public TreeNode? left = left;
    public TreeNode? right = right;
    public int val = val;
}
