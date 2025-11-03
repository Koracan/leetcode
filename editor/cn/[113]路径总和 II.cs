//给你二叉树的根节点 root 和一个整数目标和 targetSum ，找出所有 从根节点到叶子节点 路径总和等于给定目标和的路径。 
//
// 叶子节点 是指没有子节点的节点。 
//
// 
// 
// 
// 
// 
//
// 示例 1： 
// 
// 
//输入：root = [5,4,8,11,null,13,4,7,2,null,null,5,1], targetSum = 22
//输出：[[5,4,11,2],[5,8,4,5]]
// 
//
// 示例 2： 
// 
// 
//输入：root = [1,2,3], targetSum = 5
//输出：[]
// 
//
// 示例 3： 
//
// 
//输入：root = [1,2], targetSum = 0
//输出：[]
// 
//
// 
//
// 提示： 
//
// 
// 树中节点总数在范围 [0, 5000] 内 
// -1000 <= Node.val <= 1000 
// -1000 <= targetSum <= 1000 
// 
//
// Related Topics 树 深度优先搜索 回溯 二叉树 👍 1183 👎 0

namespace PathSumIi;

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
    public IList<IList<int>> PathSum(TreeNode? root, int targetSum)
    {
        var result = new List<IList<int>>();
        var path = new List<int>();

        PathSumHelper(root, targetSum);
        return result;

        void PathSumHelper(TreeNode? node, int target)
        {
            if (node == null) return;

            path.Add(node.val);
            target -= node.val;

            if (node.left == null && node.right == null && target == 0) {
                result.Add(path.ToArray());
            } else {
                PathSumHelper(node.left, target);
                PathSumHelper(node.right, target);
            }

            path.RemoveAt(path.Count - 1);
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
