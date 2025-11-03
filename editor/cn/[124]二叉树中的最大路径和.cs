//二叉树中的 路径 被定义为一条节点序列，序列中每对相邻节点之间都存在一条边。同一个节点在一条路径序列中 至多出现一次 。该路径 至少包含一个 节点，且不一定
//经过根节点。 
//
// 路径和 是路径中各节点值的总和。 
//
// 给你一个二叉树的根节点 root ，返回其 最大路径和 。 
//
// 
//
// 示例 1： 
// 
// 
//输入：root = [1,2,3]
//输出：6
//解释：最优路径是 2 -> 1 -> 3 ，路径和为 2 + 1 + 3 = 6 
//
// 示例 2： 
// 
// 
//输入：root = [-10,9,20,null,null,15,7]
//输出：42
//解释：最优路径是 15 -> 20 -> 7 ，路径和为 15 + 20 + 7 = 42
// 
//
// 
//
// 提示： 
//
// 
// 树中节点数目范围是 [1, 3 * 10⁴] 
// -1000 <= Node.val <= 1000 
// 
//
// Related Topics 树 深度优先搜索 动态规划 二叉树 👍 2405 👎 0

namespace BinaryTreeMaximumPathSum;

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
    public int MaxPathSum(TreeNode root)
    {
        var maxPathSum = int.MinValue;
        MaxPathSumHelper(root);

        return maxPathSum;


        int MaxPathSumHelper(TreeNode node)
        {
            // 返回以 node 作为一个端点的最大路径和
            if (node.left == null && node.right == null) {
                if (node.val > maxPathSum) maxPathSum = node.val;
                return node.val;
            }

            int max = 0, sum1 = 0, sum2 = 0;
            if (node.left != null) {
                sum1 = Math.Max(MaxPathSumHelper(node.left), 0);
                if (sum1 > max) max = sum1;
            }

            if (node.right != null) {
                sum2 = Math.Max(MaxPathSumHelper(node.right), 0);
                if (sum2 > max) max = sum2;
            }

            var pathSum = node.val + sum1 + sum2;
            if (pathSum > maxPathSum) maxPathSum = pathSum;

            return node.val + max;
        }
    }
}

//leetcode submit region end(Prohibit modification and deletion)
public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
{
    public TreeNode? left = left;
    public TreeNode? right = right;
    public int val = val;
}
