//给你一个二叉树的根节点 root ， 检查它是否轴对称。 
//
// 
//
// 示例 1： 
// 
// 
//输入：root = [1,2,2,3,4,4,3]
//输出：true
// 
//
// 示例 2： 
// 
// 
//输入：root = [1,2,2,null,3,null,3]
//输出：false
// 
//
// 
//
// 提示： 
//
// 
// 树中节点数目在范围 [1, 1000] 内 
// -100 <= Node.val <= 100 
// 
//
// 
//
// 进阶：你可以运用递归和迭代两种方法解决这个问题吗？ 
//
// Related Topics 树 深度优先搜索 广度优先搜索 二叉树 👍 2947 👎 0

namespace SymmetricTree;

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
    public bool IsSymmetric(TreeNode root)
    {
        var stack1 = new Stack<TreeNode>();
        var stack2 = new Stack<TreeNode>();
        var root1 = root.left;
        var root2 = root.right;
        while (stack1.Count > 0 || root1 != null) {
            while (root1 != null && root2 != null) {
                stack1.Push(root1);
                root1 = root1.left;
                stack2.Push(root2);
                root2 = root2.right;
            }

            if (root1 != null || root2 != null) return false;
            root1 = stack1.Pop();
            root2 = stack2.Pop();
            if (root1.val != root2.val) return false;
            root1 = root1.right;
            root2 = root2.left;
        }

        return stack2.Count == 0 && root2 == null;
    }
}

//leetcode submit region end(Prohibit modification and deletion)
public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
{
    public TreeNode? left = left;
    public TreeNode? right = right;
    public int val = val;
}
