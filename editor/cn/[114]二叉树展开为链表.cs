//给你二叉树的根结点 root ，请你将它展开为一个单链表： 
//
// 
// 展开后的单链表应该同样使用 TreeNode ，其中 right 子指针指向链表中下一个结点，而左子指针始终为 null 。 
// 展开后的单链表应该与二叉树 先序遍历 顺序相同。 
// 
//
// 
//
// 示例 1： 
// 
// 
//输入：root = [1,2,5,3,4,null,6]
//输出：[1,null,2,null,3,null,4,null,5,null,6]
// 
//
// 示例 2： 
//
// 
//输入：root = []
//输出：[]
// 
//
// 示例 3： 
//
// 
//输入：root = [0]
//输出：[0]
// 
//
// 
//
// 提示： 
//
// 
// 树中结点数在范围 [0, 2000] 内 
// -100 <= Node.val <= 100 
// 
//
// 
//
// 进阶：你可以使用原地算法（O(1) 额外空间）展开这棵树吗？ 
//
// Related Topics 栈 树 深度优先搜索 链表 二叉树 👍 1833 👎 0

namespace FlattenBinaryTreeToLinkedList;

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
    public void Flatten(TreeNode root)
    {
        if (root == null) return;

        FlattenHelper(root);
        return;

        TreeNode FlattenHelper(TreeNode node)
        {
            // 要求 node != null, 否则异常
            // 返回值是展平后的尾部
            while (true) {
                if (node.left == null && node.right == null) return node;
                // 如果两侧有一侧为 null, 把不为 null 调到右侧, 并进入下一层
                if (node.right == null) {
                    node.right = node.left;
                    node.left = null;
                }

                if (node.left == null) {
                    node = node.right!;
                    continue;
                }

                // 两侧都不为 null, 分别展平, 让 left 的尾部指向 right, 当前节点的 right 指向 left, left 置为 null
                var leftTail = FlattenHelper(node.left);
                var rightTail = FlattenHelper(node.right!);
                leftTail.right = node.right;

                node.right = node.left;
                node.left = null;
                // 返回整个树的尾部, 即 right 的尾部
                return rightTail;
            }
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
