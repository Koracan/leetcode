//给定一个二叉树的 根节点 root，想象自己站在它的右侧，按照从顶部到底部的顺序，返回从右侧所能看到的节点值。 
//
// 
//
// 示例 1： 
//
// 
// 输入：root = [1,2,3,null,5,null,4] 
// 
//
// 输出：[1,3,4] 
//
// 解释： 
//
// 
//
// 示例 2： 
//
// 
// 输入：root = [1,2,3,4,null,null,null,5] 
// 
//
// 输出：[1,3,4,5] 
//
// 解释： 
//
// 
//
// 示例 3： 
//
// 
// 输入：root = [1,null,3] 
// 
//
// 输出：[1,3] 
//
// 示例 4： 
//
// 
// 输入：root = [] 
// 
//
// 输出：[] 
//
// 
//
// 提示: 
//
// 
// 二叉树的节点个数的范围是 [0,100] 
// 
// -100 <= Node.val <= 100 
// 
//
// Related Topics 树 深度优先搜索 广度优先搜索 二叉树 👍 1245 👎 0

namespace BinaryTreeRightSideView;

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
    public IList<int> RightSideView(TreeNode? root)
    {
        if (root == null) return [];
        
        var queue = new Queue<TreeNode>();
        var result = new List<int>();
        queue.Enqueue(root);

        var current = root;
        while (queue.Count > 0) {
            var n = queue.Count;
            for (var i = 0; i < n; i++)
            {
                current = queue.Dequeue();
                if (current.left != null) queue.Enqueue(current.left);
                if (current.right != null) queue.Enqueue(current.right);
            }
            result.Add(current.val);
        }

        return result;
    }
}

//leetcode submit region end(Prohibit modification and deletion)
public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;
    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
