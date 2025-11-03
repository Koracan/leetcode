//给定单个链表的头
// head ，使用 插入排序 对链表进行排序，并返回 排序后链表的头 。 
//
// 插入排序 算法的步骤: 
//
// 
// 插入排序是迭代的，每次只移动一个元素，直到所有元素可以形成一个有序的输出列表。 
// 每次迭代中，插入排序只从输入数据中移除一个待排序的元素，找到它在序列中适当的位置，并将其插入。 
// 重复直到所有输入数据插入完为止。 
// 
//
// 下面是插入排序算法的一个图形示例。部分排序的列表(黑色)最初只包含列表中的第一个元素。每次迭代时，从输入数据中删除一个元素(红色)，并就地插入已排序的列表
//中。 
//
// 对链表进行插入排序。 
//
// 
//
// 
//
// 示例 1： 
//
// 
//
// 
//输入: head = [4,2,1,3]
//输出: [1,2,3,4] 
//
// 示例 2： 
//
// 
//
// 
//输入: head = [-1,5,3,4,0]
//输出: [-1,0,3,4,5] 
//
// 
//
// 提示： 
//
// 
// 
//
// 
// 列表中的节点数在 [1, 5000]范围内 
// -5000 <= Node.val <= 5000 
// 
//
// Related Topics 链表 排序 👍 718 👎 0

namespace InsertionSortList;

//leetcode submit region begin(Prohibit modification and deletion)
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    public ListNode InsertionSortList(ListNode head)
    {
        if (head.next == null) return head;
        
        var prev = head;
        var current = head.next;
        var super = new ListNode(int.MinValue, head);
        while (current != null) {
            var scan = super;
            while (scan.next!.val < current.val) scan = scan.next;
        
            // if current is already in the right place
            if (scan.next == current) {
                prev = current;
                current = current.next;
            } else {
                // else, insert current after scan
                var next = current.next;
                current.next = scan.next;
                scan.next = current;
                current = next;
                prev.next = current;
            }
        }
        
        return super.next;
        
    }
    
    // // 归并排序实现，O(n log n) 时间复杂度
    // public ListNode SortList(ListNode head)
    // {
    //     if (head == null || head.next == null) return head;
    //     // 找到中点并断开
    //     ListNode mid = FindMiddle(head);
    //     ListNode right = mid.next;
    //     mid.next = null;
    //     // 递归排序左右两部分
    //     ListNode leftSorted = SortList(head);
    //     ListNode rightSorted = SortList(right);
    //     // 合并
    //     return Merge(leftSorted, rightSorted);
    // }
    //
    // // 快慢指针找中点
    // private ListNode FindMiddle(ListNode head)
    // {
    //     ListNode slow = head, fast = head;
    //     while (fast.next != null && fast.next.next != null)
    //     {
    //         slow = slow.next;
    //         fast = fast.next.next;
    //     }
    //     return slow;
    // }
    //
    // // 合并两个有序链表
    // private ListNode Merge(ListNode l1, ListNode l2)
    // {
    //     ListNode dummy = new ListNode(0);
    //     ListNode tail = dummy;
    //     while (l1 != null && l2 != null)
    //     {
    //         if (l1.val < l2.val)
    //         {
    //             tail.next = l1;
    //             l1 = l1.next;
    //         }
    //         else
    //         {
    //             tail.next = l2;
    //             l2 = l2.next;
    //         }
    //         tail = tail.next;
    //     }
    //     tail.next = l1 ?? l2;
    //     return dummy.next;
    // }
}

//leetcode submit region end(Prohibit modification and deletion)
public class ListNode
{
    public int val;
    public ListNode? next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}
