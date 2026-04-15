//给你二叉搜索树的根节点 root ，该树中的 恰好 两个节点的值被错误地交换。请在不改变其结构的情况下，恢复这棵树 。 
//
// 
//
// 示例 1： 
// 
// 
//输入：root = [1,3,null,null,2]
//输出：[3,1,null,null,2]
//解释：3 不能是 1 的左孩子，因为 3 > 1 。交换 1 和 3 使二叉搜索树有效。
// 
//
// 示例 2： 
// 
// 
//输入：root = [3,1,4,null,null,2]
//输出：[2,1,4,null,null,3]
//解释：2 不能在 3 的右子树中，因为 2 < 3 。交换 2 和 3 使二叉搜索树有效。 
//
// 
//
// 提示： 
//
// 
// 树上节点的数目在范围 [2, 1000] 内 
// -2³¹ <= Node.val <= 2³¹ - 1 
// 
//
// 
//
// 进阶：使用 O(n) 空间复杂度的解法很容易实现。你能想出一个只使用 O(1) 空间的解决方案吗？ 
//
// Related Topics 树 深度优先搜索 二叉搜索树 二叉树 👍 1000 👎 0

namespace RecoverBinarySearchTree;

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
    public void RecoverTree(TreeNode root)
    {
        // Morris 中序遍历
        TreeNode? x = null, y = null; // 两个应该交换的节点
        var errors = 0; // 已经找到的错误节点数
        var cycles = 0; // 临时改变树结构产生的环数 
        TreeNode? prev = null; // previous
        TreeNode? pred = null; // predecessor
        while (root != null) {
            if (root.left != null) {
                // 找到前驱节点
                pred = root.left;
                while (pred.right != null && pred.right != root) pred = pred.right;

                if (pred.right == null) {
                    pred.right = root; // 建立线索
                    root = root.left;
                    cycles++;
                    continue;
                }
                // 否则, 说明左子树已经访问过, 恢复树结构, 并访问当前节点
                pred.right = null;
                cycles--;
            }

            // 访问当前节点
            if (prev != null && prev.val > root.val) {
                y = root;
                x ??= prev;
                errors++;
            }

            if (errors == 2 && cycles == 0) break;

            prev = root;
            root = root.right!;
        }



        var temp = x!.val;
        x.val = y!.val;
        y.val = temp; // 交换值
    }
}

//leetcode submit region end(Prohibit modification and deletion)
public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
{
    public TreeNode? left = left;
    public TreeNode? right = right;
    public int val = val;
}
