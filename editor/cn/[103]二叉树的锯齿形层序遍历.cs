//给你二叉树的根节点 root ，返回其节点值的 锯齿形层序遍历 。（即先从左往右，再从右往左进行下一层遍历，以此类推，层与层之间交替进行）。 
//
// 
//
// 示例 1： 
// 
// 
//输入：root = [3,9,20,null,null,15,7]
//输出：[[3],[20,9],[15,7]]
// 
//
// 示例 2： 
//
// 
//输入：root = [1]
//输出：[[1]]
// 
//
// 示例 3： 
//
// 
//输入：root = []
//输出：[]
// 
//
// 
//
// 提示： 
//
// 
// 树中节点数目在范围 [0, 2000] 内 
// -100 <= Node.val <= 100 
// 
//
// Related Topics 树 广度优先搜索 二叉树 👍 960 👎 0

namespace BinaryTreeZigzagLevelOrderTraversal;

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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
        var stack1 = new Stack<TreeNode>();
        var stack2 = new Stack<TreeNode>();
        var reverse = false;
        var result = new List<IList<int>>();
        if (root != null) stack1.Push(root);
        while (stack1.Count > 0 || stack2.Count > 0) {
            var level = new List<int>();
            if (reverse) {
                var count = stack2.Count;
                for (var i = 0; i < count; i++) {
                    var node = stack2.Pop();
                    level.Add(node.val);
                    if (node.right != null) stack1.Push(node.right);
                    if (node.left != null) stack1.Push(node.left);
                }
            } else {
                var count = stack1.Count;
                for (var i = 0; i < count; i++) {
                    var node = stack1.Pop();
                    level.Add(node.val);
                    if (node.left != null) stack2.Push(node.left);
                    if (node.right != null) stack2.Push(node.right);
                }
            }


            result.Add(level);
            reverse = !reverse;
        }

        return result;
    }
}

//leetcode submit region end(Prohibit modification and deletion)
public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
{
    public TreeNode? left = left;
    public TreeNode? right = right;
    public int val = val;
}
