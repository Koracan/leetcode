//给你一个长度为 n 的链表，每个节点包含一个额外增加的随机指针 random ，该指针可以指向链表中的任何节点或空节点。 
//
// 构造这个链表的 深拷贝。 深拷贝应该正好由 n 个 全新 节点组成，其中每个新节点的值都设为其对应的原节点的值。新节点的 next 指针和 random 
//指针也都应指向复制链表中的新节点，并使原链表和复制链表中的这些指针能够表示相同的链表状态。复制链表中的指针都不应指向原链表中的节点 。 
//
// 例如，如果原链表中有 X 和 Y 两个节点，其中 X.random --> Y 。那么在复制链表中对应的两个节点 x 和 y ，同样有 x.random 
//--> y 。 
//
// 返回复制链表的头节点。 
//
// 用一个由 n 个节点组成的链表来表示输入/输出中的链表。每个节点用一个 [val, random_index] 表示： 
//
// 
// val：一个表示 Node.val 的整数。 
// random_index：随机指针指向的节点索引（范围从 0 到 n-1）；如果不指向任何节点，则为 null 。 
// 
//
// 你的代码 只 接受原链表的头节点 head 作为传入参数。 
//
// 
//
// 示例 1： 
//
// 
//
// 
//输入：head = [[7,null],[13,0],[11,4],[10,2],[1,0]]
//输出：[[7,null],[13,0],[11,4],[10,2],[1,0]]
// 
//
// 示例 2： 
//
// 
//
// 
//输入：head = [[1,1],[2,1]]
//输出：[[1,1],[2,1]]
// 
//
// 示例 3： 
//
// 
//
// 
//输入：head = [[3,null],[3,0],[3,null]]
//输出：[[3,null],[3,0],[3,null]]
// 
//
// 
//
// 提示： 
//
// 
// 0 <= n <= 1000
// 
// -10⁴ <= Node.val <= 10⁴ 
// Node.random 为 null 或指向链表中的节点。 
// 
//
// 
//
// Related Topics 哈希表 链表 👍 1672 👎 0

namespace CopyListWithRandomPointer;
//leetcode submit region begin(Prohibit modification and deletion)
/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;

    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution
{
    public Node? CopyRandomList(Node? head)
    {
        if (head == null) return null;

        // var dict = new Dictionary<Node,Node>();
        // var root = new Node(head.val);
        // dict[head] = root;
        // var current = root;
        // while (head != null) {
        //     if (head.next != null) {
        //         if (!dict.ContainsKey(head.next))
        //             dict[head.next] = new(head.next.val);
        //         
        //         current.next = dict[head.next];
        //     }
        //
        //     if (head.random != null) {
        //         if (!dict.ContainsKey(head.random))
        //             dict[head.random] = new(head.random.val);
        //         
        //         current.random = dict[head.random];
        //     }
        //     
        //     
        //     head = head.next;
        //     current = current.next;
        // }
        
        var current = head;
        // 1. 复制节点，插入到每个节点的后面
        while (current != null) {
            var copyNode = new Node(current.val);
            copyNode.next = current.next;
            current.next = copyNode;
            current = copyNode.next;
        }
        
        // 2. 复制 random 指针
        current = head;
        while (current != null) {
            if (current.random != null)
                current.next!.random = current.random.next;
            current = current.next!.next;
        }
        // 3. 拆分链表
        current = head;
        var root = head.next;
        while (current != null) {
            var copyNode = current.next!;
            current.next = copyNode.next;
            if (copyNode.next != null)
                copyNode.next = copyNode.next.next;
            current = current.next;
        }
        
        

        return root;
    }
}

//leetcode submit region end(Prohibit modification and deletion)
public class Node
{
    public int val;
    public Node? next;
    public Node? random;

    public Node(int _val)
    {
        val = _val;
        next = null;
        random = null;
    }
}
