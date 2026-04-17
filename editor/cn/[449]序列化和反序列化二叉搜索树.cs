//序列化是将数据结构或对象转换为一系列位的过程，以便它可以存储在文件或内存缓冲区中，或通过网络连接链路传输，以便稍后在同一个或另一个计算机环境中重建。 
//
// 设计一个算法来序列化和反序列化 二叉搜索树 。 对序列化/反序列化算法的工作方式没有限制。 您只需确保二叉搜索树可以序列化为字符串，并且可以将该字符串反序
//列化为最初的二叉搜索树。 
//
// 编码的字符串应尽可能紧凑。 
//
// 
//
// 示例 1： 
//
// 
//输入：root = [2,1,3]
//输出：[2,1,3]
// 
//
// 示例 2： 
//
// 
//输入：root = []
//输出：[]
// 
//
// 
//
// 提示： 
//
// 
// 树中节点数范围是 [0, 10⁴] 
// 0 <= Node.val <= 10⁴ 
// 题目数据 保证 输入的树是一棵二叉搜索树。 
// 
//
// Related Topics 树 深度优先搜索 广度优先搜索 设计 二叉搜索树 字符串 二叉树 👍 572 👎 0

using System.Text;

namespace SerializeAndDeserializeBst;

//leetcode submit region begin(Prohibit modification and deletion)
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec
{
    // Encodes a tree to a single string.
    public string serialize(TreeNode root)
    {
        var sb = new StringBuilder();
        var queue = new Queue<TreeNode?>();
        queue.Enqueue(root);
        while (queue.Count > 0) {
            var node = queue.Dequeue();
            if (node == null) {
                sb.Append("n,");
                continue;
            }
            queue.Enqueue(node.left);
            queue.Enqueue(node.right);

            sb.Append(node.val);
            sb.Append(',');
        }
        return sb.ToString();
    }

    // Decodes your encoded data to tree.
    public TreeNode? deserialize(string data)
    {
        if (data[0] == 'n') return null;

        var i = 0;

        var root = new TreeNode(ReadNext());
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (i < data.Length) {
            var node = queue.Dequeue();
            var l = ReadNext();

            if (l != -1) {
                node.left = new(l);
                queue.Enqueue(node.left);
            }
            var r = ReadNext();
            if (r != -1) {
                node.right = new(r);
                queue.Enqueue(node.right);
            }
        }

        return root;

        int ReadNext()
        {
            if (data[i] == 'n') {
                i += 2;
                return -1;
            }

            var val = 0;
            while (data[i] != ',') {
                val = val * 10 + (data[i] - '0');
                i++;
            }
            i++;
            return val;
        }
    }
}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// String tree = ser.serialize(root);
// TreeNode ans = deser.deserialize(tree);
// return ans;
//leetcode submit region end(Prohibit modification and deletion)

public class TreeNode(int x)
{
    public int val = x;
    public TreeNode? left;
    public TreeNode? right;
}
