//给你单链表的头指针 head 和两个整数 left 和 right ，其中 left <= right 。请你反转从位置 left 到位置 right 的链
//表节点，返回 反转后的链表 。
//
// 
//
// 示例 1： 
// 
// 
//输入：head = [1,2,3,4,5], left = 2, right = 4
//输出：[1,4,3,2,5]
// 
//
// 示例 2： 
//
// 
//输入：head = [5], left = 1, right = 1
//输出：[5]
// 
//
// 
//
// 提示： 
//
// 
// 链表中节点数目为 n 
// 1 <= n <= 500 
// -500 <= Node.val <= 500 
// 1 <= left <= right <= n 
// 
//
// 
//
// 进阶： 你可以使用一趟扫描完成反转吗？ 
//
// Related Topics 链表 👍 1963 👎 0

namespace ReverseLinkedListIi;

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
    public ListNode ReverseBetween(ListNode head, int left, int right)
    {
        var super = new ListNode(0, head);
        var leader = super;
        while (left > 1) {
            leader = leader!.next;
            left--;
            right--;
        }
        var l = leader!.next;
        var r = l!.next;
        ListNode temp;
        for (var i = 0; i < right - 1; i++) {
            temp = r!.next!;
            r.next = l;
            l = r;
            r = temp;
        }

        leader.next!.next = r;
        temp = leader.next;
        leader.next = l;
        leader = temp;

        return super.next!;
    }
}

//leetcode submit region end(Prohibit modification and deletion)
public class ListNode(int val = 0, ListNode? next = null)
{
    public ListNode? next = next;
    public int val = val;
}
