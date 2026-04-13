//给你两个 非空 链表来代表两个非负整数。数字最高位位于链表开始位置。它们的每个节点只存储一位数字。将这两数相加会返回一个新的链表。 
//
// 你可以假设除了数字 0 之外，这两个数字都不会以零开头。 
//
// 
//
// 示例1： 
//
// 
//
// 
//输入：l1 = [7,2,4,3], l2 = [5,6,4]
//输出：[7,8,0,7]
// 
//
// 示例2： 
//
// 
//输入：l1 = [2,4,3], l2 = [5,6,4]
//输出：[8,0,7]
// 
//
// 示例3： 
//
// 
//输入：l1 = [0], l2 = [0]
//输出：[0]
// 
//
// 
//
// 提示： 
//
// 
// 链表的长度范围为 [1, 100] 
// 0 <= node.val <= 9 
// 输入数据保证链表代表的数字无前导 0 
// 
//
// 
//
// 进阶：如果输入链表不能翻转该如何解决？ 
//
// Related Topics 栈 链表 数学 👍 803 👎 0

// ReSharper disable InconsistentNaming

namespace AddTwoNumbersIi;

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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var stack1 = new Stack<int>();
        var stack2 = new Stack<int>();

        var here = l1;
        while (here != null) {
            stack1.Push(here.val);
            here = here.next;
        }
        here = l2;
        while (here != null) {
            stack2.Push(here.val);
            here = here.next;
        }

        var carry = 0;
        ListNode? head = null;

        while (stack1.Count > 0 || stack2.Count > 0 || carry > 0) {
            var sum = carry;

            if (stack1.Count > 0)
                sum += stack1.Pop();

            if (stack2.Count > 0)
                sum += stack2.Pop();

            var node = new ListNode(sum % 10, head);
            head = node;
            carry = sum / 10;
        }

        return head!;
    }
}
//leetcode submit region end(Prohibit modification and deletion)

// ReSharper disable once ClassNeverInstantiated.Global
public class ListNode(int val = 0, ListNode? next = null)
{
    public int val = val;
    public ListNode? next = next;
}
