//给你一个链表的头节点 head ，旋转链表，将链表每个节点向右移动 k 个位置。 
//
// 
//
// 示例 1： 
// 
// 
//输入：head = [1,2,3,4,5], k = 2
//输出：[4,5,1,2,3]
// 
//
// 示例 2： 
// 
// 
//输入：head = [0,1,2], k = 4
//输出：[2,0,1]
// 
//
// 
//
// 提示： 
//
// 
// 链表中节点的数目在范围 [0, 500] 内 
// -100 <= Node.val <= 100 
// 0 <= k <= 2 * 10⁹ 
// 
//
// Related Topics 链表 双指针 👍 1135 👎 0

namespace RotateList;

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
    public ListNode RotateRight(ListNode head, int k)
    {
        if (head == null) {
            return null;
        }
        var current = head;
        var length = 1;
        while (current.next != null) {
            current = current.next;
            length++;
        }
        current.next = head;
        k = -k % length + length;
        while (k != 0) {
            current = current.next;
            k--;
        }
        head = current.next;
        current.next = null;

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
