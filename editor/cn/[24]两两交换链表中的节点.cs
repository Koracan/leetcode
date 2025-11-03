//给你一个链表，两两交换其中相邻的节点，并返回交换后链表的头节点。你必须在不修改节点内部的值的情况下完成本题（即，只能进行节点交换）。 
//
// 
//
// 示例 1： 
// 
// 
//输入：head = [1,2,3,4]
//输出：[2,1,4,3]
// 
//
// 示例 2： 
//
// 
//输入：head = []
//输出：[]
// 
//
// 示例 3： 
//
// 
//输入：head = [1]
//输出：[1]
// 
//
// 
//
// 提示： 
//
// 
// 链表中节点的数目在范围 [0, 100] 内 
// 0 <= Node.val <= 100 
// 
//
// Related Topics 递归 链表 👍 2403 👎 0

namespace SwapNodesInPairs;

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
    public ListNode? SwapPairs(ListNode? head)
    {
        if (head is null || head.next is null) return head;

        var super = new ListNode(0, head);
        var current = super;

        while (current?.next?.next is not null) {
            var temp = current.next;
            current.next = current.next.next;
            temp.next = current.next.next;
            current.next.next = temp;

            current = temp;
        }

        return super.next;
    }
}
//leetcode submit region end(Prohibit modification and deletion)

public class ListNode
{
    public ListNode? next;
    public int val;

    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }
}
