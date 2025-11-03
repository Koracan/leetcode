//给定两个整数数组 inorder 和 postorder ，其中 inorder 是二叉树的中序遍历， postorder 是同一棵树的后序遍历，请你构造并
//返回这颗 二叉树 。 
//
// 
//
// 示例 1: 
// 
// 
//输入：inorder = [9,3,15,20,7], postorder = [9,15,7,20,3]
//输出：[3,9,20,null,null,15,7]
// 
//
// 示例 2: 
//
// 
//输入：inorder = [-1], postorder = [-1]
//输出：[-1]
// 
//
// 
//
// 提示: 
//
// 
// 1 <= inorder.length <= 3000 
// postorder.length == inorder.length 
// -3000 <= inorder[i], postorder[i] <= 3000 
// inorder 和 postorder 都由 不同 的值组成 
// postorder 中每一个值都在 inorder 中 
// inorder 保证是树的中序遍历 
// postorder 保证是树的后序遍历 
// 
//
// Related Topics 树 数组 哈希表 分治 二叉树 👍 1338 👎 0

namespace ConstructBinaryTreeFromInorderAndPostorderTraversal;

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
    public TreeNode BuildTree(int[] inorder, int[] postorder)
    {
        var indexes = new Dictionary<int, int>();
        for (var i = 0; i < inorder.Length; i++) indexes[inorder[i]] = i;

        return BuildTreeHelper(0, postorder.Length - 1, inorder.Length)!;

        TreeNode? BuildTreeHelper(int i, int j, int length)
        {
            if (length == 0) return null;

            var val = postorder[j];
            var mid = indexes[val];
            var leftLength = mid - i;
            var rightLength = length - leftLength - 1;
            return new(
                val, BuildTreeHelper(i, j - length + leftLength, leftLength),
                BuildTreeHelper(mid + 1, j - 1, rightLength)
            );
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
