//给定一个已排序的链表的头 head ， 删除原始链表中所有重复数字的节点，只留下不同的数字 。返回 已排序的链表 。 
//
// 
//
// 示例 1： 
// 
// 
//输入：head = [1,2,3,3,4,4,5]
//输出：[1,2,5]
// 
//
// 示例 2： 
// 
// 
//输入：head = [1,1,1,2,3]
//输出：[2,3]
// 
//
// 
//
// 提示： 
//
// 
// 链表中节点数目在范围 [0, 300] 内 
// -100 <= Node.val <= 100 
// 题目数据保证链表已经按升序 排列 
// 
//
// Related Topics 链表 双指针 👍 1367 👎 0

namespace RemoveDuplicatesFromSortedListIi;

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
    public ListNode DeleteDuplicates(ListNode head)
    {
        if (head == null) return head;

        var super = new ListNode();
        var previous = super;
        var current = head;
        var val = current.val;
        var valCount = 1;

        while (current.next != null) {
            if (current.next.val == val) {
                current = current.next;
                valCount++;
                continue;
            }

            if (valCount == 1) {
                previous.next = current;
                previous = current;
            }

            current = current.next;
            val = current.val;
            valCount = 1;
        }

        previous.next = valCount == 1 ? current : null;

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
