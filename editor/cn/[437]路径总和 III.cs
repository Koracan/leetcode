//给定一个二叉树的根节点 root ，和一个整数 targetSum ，求该二叉树里节点值之和等于 targetSum 的 路径 的数目。 
//
// 路径 不需要从根节点开始，也不需要在叶子节点结束，但是路径方向必须是向下的（只能从父节点到子节点）。 
//
// 
//
// 示例 1： 
//
// 
//
// 
//输入：root = [10,5,-3,3,2,null,11,3,-2,null,1], targetSum = 8
//输出：3
//解释：和等于 8 的路径有 3 条，如图所示。
// 
//
// 示例 2： 
//
// 
//输入：root = [5,4,8,11,null,13,4,7,2,null,null,5,1], targetSum = 22
//输出：3
// 
//
// 
//
// 提示: 
//
// 
// 二叉树的节点个数的范围是 [0,1000] 
// 
// -10⁹ <= Node.val <= 10⁹ 
// -1000 <= targetSum <= 1000 
// 
//
// Related Topics 树 深度优先搜索 二叉树 👍 2276 👎 0

// ReSharper disable InconsistentNaming

namespace PathSumIii;

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
    public int PathSum(TreeNode? root, int targetSum)
    {
        if (root == null) return 0;

        var num = PathSumFromNode(root, targetSum);
        num += PathSum(root.left, targetSum);
        num += PathSum(root.right, targetSum);

        return num;
    }

    private int PathSumFromNode(TreeNode node, long targetSum)
    {
        var num = 0;
        if (targetSum == node.val) {
            num++;
        }
        if (node.left != null) {
            num += PathSumFromNode(node.left, targetSum - node.val);
        }
        if (node.right != null) {
            num += PathSumFromNode(node.right, targetSum - node.val);
        }

        return num;
    }
}
//leetcode submit region end(Prohibit modification and deletion)

// ReSharper disable once ClassNeverInstantiated.Global
public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
{
    public int val = val;
    public TreeNode? left = left;
    public TreeNode? right = right;
}