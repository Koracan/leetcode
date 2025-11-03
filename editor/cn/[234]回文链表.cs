//给你一个单链表的头节点 head ，请你判断该链表是否为回文链表。如果是，返回 true ；否则，返回 false 。 
//
// 
//
// 示例 1： 
// 
// 
//输入：head = [1,2,2,1]
//输出：true
// 
//
// 示例 2： 
// 
// 
//输入：head = [1,2]
//输出：false
// 
//
// 
//
// 提示： 
//
// 
// 链表中节点数目在范围[1, 10⁵] 内 
// 0 <= Node.val <= 9 
// 
//
// 
//
// 进阶：你能否用 O(n) 时间复杂度和 O(1) 空间复杂度解决此题？ 
//
// Related Topics 栈 递归 链表 双指针 👍 2148 👎 0

namespace PalindromeLinkedList;

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
 */
public class Solution
{
    public bool IsPalindrome(ListNode head)
    {
        var list = new List<int>();
        while (head != null) {
            list.Add(head.val);
            head = head.next;
        }

        for (int left = 0, right = list.Count - 1; left < right; left++, right--)
            if (list[left] != list[right])
                return false;

        return true;
    }
}

//leetcode submit region end(Prohibit modification and deletion)
public class ListNode(int val = 0, ListNode? next = null)
{
    public ListNode? next = next;
    public int val = val;
}
