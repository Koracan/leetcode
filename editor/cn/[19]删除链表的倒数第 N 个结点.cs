//给你一个链表，删除链表的倒数第 n 个结点，并且返回链表的头结点。 
//
// 
//
// 示例 1： 
// 
// 
//输入：head = [1,2,3,4,5], n = 2
//输出：[1,2,3,5]
// 
//
// 示例 2： 
//
// 
//输入：head = [1], n = 1
//输出：[]
// 
//
// 示例 3： 
//
// 
//输入：head = [1,2], n = 1
//输出：[1]
// 
//
// 
//
// 提示： 
//
// 
// 链表中结点的数目为 sz 
// 1 <= sz <= 30 
// 0 <= Node.val <= 100 
// 1 <= n <= sz 
// 
//
// 
//
// 进阶：你能尝试使用一趟扫描实现吗？ 
//
// Related Topics 链表 双指针 👍 3100 👎 0

namespace RemoveNthNodeFromEndOfList;

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
    public ListNode? RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode current = head, tail = head;
        for (var i = 0; i < n - 1; i++) tail = tail.next;

        if (tail!.next is null) return head.next;

        tail = tail.next;

        while (tail.next is not null) {
            current = current.next!;
            tail = tail.next;
        }

        current.next = current.next!.next;

        return head;
    }
}
//leetcode submit region end(Prohibit modification and deletion)

public class ListNode
{
    public ListNode? next;
    public int val;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}
