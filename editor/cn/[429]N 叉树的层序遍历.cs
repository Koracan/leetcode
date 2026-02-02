//给定一个 N 叉树，返回其节点值的层序遍历。（即从左到右，逐层遍历）。 
//
// 树的序列化输入是用层序遍历，每组子节点都由 null 值分隔（参见示例）。 
//
// 
//
// 示例 1： 
//
// 
//
// 
//输入：root = [1,null,3,2,4,null,5,6]
//输出：[[1],[3,2,4],[5,6]]
// 
//
// 示例 2： 
//
// 
//
// 
//输入：root = [1,null,2,3,4,5,null,null,6,7,null,8,null,9,10,null,null,11,null,12,
//null,13,null,null,14]
//输出：[[1],[2,3,4,5],[6,7,8,9,10],[11,12,13],[14]]
// 
//
// 
//
// 提示： 
//
// 
// 树的高度不会超过 1000 
// 树的节点总数在 [0, 10⁴] 之间 
// 
//
// Related Topics 树 广度优先搜索 👍 517 👎 0

// ReSharper disable InconsistentNaming

namespace NAryTreeLevelOrderTraversal;
//leetcode submit region begin(Prohibit modification and deletion)
/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution
{
    public IList<IList<int>> LevelOrder(Node? root)
    {
        if (root == null) return [];

        var queue = new Queue<Node?>();
        var result = new List<IList<int>>();
        queue.Enqueue(null); // Marker for start of level
        queue.Enqueue(root);
        while (queue.Count > 0) {
            var node = queue.Dequeue();
            if (node == null) {
                // Start of next level
                if (queue.Count > 0) {
                    queue.Enqueue(null); // Marker for next level
                    result.Add([]);
                }
                continue;
            }

            result[^1].Add(node.val);

            foreach (var child in node.children)
                if (child != null)
                    queue.Enqueue(child);
        }

        return result;
    }
}

//leetcode submit region end(Prohibit modification and deletion)
public class Node
{
    public required IList<Node?> children;
    public int val;

    public Node() { }

    public Node(int val)
    {
        this.val = val;
    }

    public Node(int val, IList<Node?> children)
    {
        this.val = val;
        this.children = children;
    }
}
