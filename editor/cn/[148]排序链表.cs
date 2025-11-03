//给你链表的头结点 head ，请将其按 升序 排列并返回 排序后的链表 。 
//
// 
// 
//
// 
//
// 示例 1： 
// 
// 
//输入：head = [4,2,1,3]
//输出：[1,2,3,4]
// 
//
// 示例 2： 
// 
// 
//输入：head = [-1,5,3,4,0]
//输出：[-1,0,3,4,5]
// 
//
// 示例 3： 
//
// 
//输入：head = []
//输出：[]
// 
//
// 
//
// 提示： 
//
// 
// 链表中节点的数目在范围 [0, 5 * 10⁴] 内 
// -10⁵ <= Node.val <= 10⁵ 
// 
//
// 
//
// 进阶：你可以在 O(n log n) 时间复杂度和常数级空间复杂度下，对链表进行排序吗？ 
//
// Related Topics 链表 双指针 分治 排序 归并排序 👍 2625 👎 0

namespace SortList;

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
    // 非递归（自底向上）归并排序，O(n log n) 时间，O(1) 额外空间，Split和Merge内联
    public ListNode? SortList(ListNode? head)
    {
        if (head?.next == null) return head;
        // 统计链表长度
        var n = 0;
        for (var p = head; p != null; p = p.next) n++;
        var dummy = new ListNode(0, head);
        for (var size = 1; size < n; size <<= 1) {
            var prev = dummy;
            var curr = dummy.next;
            while (curr != null) {
                // 内联Split: 拆分left
                var left = curr;
                var lTail = left;
                for (var i = 1; i < size && lTail.next != null; i++) lTail = lTail.next;
                var right = lTail.next;
                lTail.next = null;
                // 内联Split: 拆分right
                var rTail = right;
                for (var i = 1; rTail != null && i < size; i++) rTail = rTail.next;
                var next = rTail != null ? rTail.next : null;
                if (rTail != null) rTail.next = null;
                
                // 内联Merge: 合并left和right
                var l = left;
                var r = right;
                while (l != null && r != null) {
                    if (l.val < r.val) {
                        prev.next = l;
                        l = l.next;
                    } else {
                        prev.next = r;
                        r = r.next;
                    }
                    prev = prev.next;
                }
                prev.next = l ?? r;
                while (prev.next != null) prev = prev.next;
                curr = next;
            }
        }
        return dummy.next;
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
