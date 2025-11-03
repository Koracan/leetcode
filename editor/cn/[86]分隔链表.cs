//给你一个链表的头节点 head 和一个特定值 x ，请你对链表进行分隔，使得所有 小于 x 的节点都出现在 大于或等于 x 的节点之前。 
//
// 你应当 保留 两个分区中每个节点的初始相对位置。 
//
// 
//
// 示例 1： 
// 
// 
//输入：head = [1,4,3,2,5,2], x = 3
//输出：[1,2,2,4,3,5]
// 
//
// 示例 2： 
//
// 
//输入：head = [2,1], x = 2
//输出：[1,2]
// 
//
// 
//
// 提示： 
//
// 
// 链表中节点的数目在范围 [0, 200] 内 
// -100 <= Node.val <= 100 
// -200 <= x <= 200 
// 
//
// Related Topics 链表 双指针 👍 902 👎 0

namespace PartitionList;

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
    public ListNode Partition(ListNode head, int x)
    {
        if (head == null) return null;

        var super = new ListNode(0, head);
        var split = super;
        var current = super;
        while (current.next?.val < x) {
            split = split.next;
            current = current.next;
        }

        while (current.next != null)
            if (current.next.val < x) {
                // current 指向 current.next.next;
                // current.next 插入 split 与 split.next 之间
                var temp = current.next;
                current.next = current.next.next;
                temp.next = split.next;
                split.next = temp;
                split = temp;
            } else {
                current = current.next;
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
