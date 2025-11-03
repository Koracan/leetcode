//给定一个单链表的头节点 head ，其中的元素 按升序排序 ，将其转换为 平衡 二叉搜索树。 
//
// 
//
// 示例 1: 
//
// 
//
// 
//输入: head = [-10,-3,0,5,9]
//输出: [0,-3,9,-10,null,5]
//解释: 一个可能的答案是[0，-3,9，-10,null,5]，它表示所示的高度平衡的二叉搜索树。
// 
//
// 示例 2: 
//
// 
//输入: head = []
//输出: []
// 
//
// 
//
// 提示: 
//
// 
// head 中的节点数在[0, 2 * 10⁴] 范围内 
// -10⁵ <= Node.val <= 10⁵ 
// 
//
// Related Topics 树 二叉搜索树 链表 分治 二叉树 👍 942 👎 0

namespace ConvertSortedListToBinarySearchTree;

//leetcode submit region begin(Prohibit modification and deletion)
/**
 * Definition for singly-linked list.
 * public class ListNode {
 * public int val;
 * public ListNode next;
 * public ListNode(int val=0, ListNode next=null) {
 * this.val = val;
 * this.next = next;
 * }
 * }
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
    public TreeNode SortedListToBST(ListNode head)
    {
        var nums = new List<int>();
        while (head != null) {
            nums.Add(head.val);
            head = head.next;
        }

        return SortedArrayToBSTHelper(0, nums.Count - 1)!;

        TreeNode? SortedArrayToBSTHelper(int start, int end)
        {
            if (start > end) return null;
            var mid = (start + end + 1) / 2;
            return new(
                nums[mid],
                SortedArrayToBSTHelper(start, mid - 1),
                SortedArrayToBSTHelper(mid + 1, end)
            );
        }
    }
}

//leetcode submit region end(Prohibit modification and deletion)
public class ListNode(int val = 0, ListNode? next = null)
{
    public ListNode? next = next;
    public int val = val;
}

public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
{
    public TreeNode? left = left;
    public TreeNode? right = right;
    public int val = val;
}
