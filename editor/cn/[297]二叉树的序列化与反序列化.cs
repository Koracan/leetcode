//序列化是将一个数据结构或者对象转换为连续的比特位的操作，进而可以将转换后的数据存储在一个文件或者内存中，同时也可以通过网络传输到另一个计算机环境，采取相反方
//式重构得到原数据。 
//
// 请设计一个算法来实现二叉树的序列化与反序列化。这里不限定你的序列 / 反序列化算法执行逻辑，你只需要保证一个二叉树可以被序列化为一个字符串并且将这个字符串
//反序列化为原始的树结构。 
//
// 提示: 输入输出格式与 LeetCode 目前使用的方式一致，详情请参阅 LeetCode 序列化二叉树的格式。你并非必须采取这种方式，你也可以采用其他的
//方法解决这个问题。 
//
// 
//
// 示例 1： 
// 
// 
//输入：root = [1,2,3,null,null,4,5]
//输出：[1,2,3,null,null,4,5]
// 
//
// 示例 2： 
//
// 
//输入：root = []
//输出：[]
// 
//
// 示例 3： 
//
// 
//输入：root = [1]
//输出：[1]
// 
//
// 示例 4： 
//
// 
//输入：root = [1,2]
//输出：[1,2]
// 
//
// 
//
// 提示： 
//
// 
// 树中结点数在范围 [0, 10⁴] 内 
// -1000 <= Node.val <= 1000 
// 
//
// Related Topics 树 深度优先搜索 广度优先搜索 设计 字符串 二叉树 👍 1302 👎 0

using System.Text;

namespace SerializeAndDeserializeBinaryTree;

//leetcode submit region begin(Prohibit modification and deletion)
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 * public int val;
 * public TreeNode left;
 * public TreeNode right;
 * public TreeNode(int x) { val = x; }
 * }
 */
public class Codec
{
    // Encodes a tree to a single string.
    public string serialize(TreeNode? root)
    {
        var queue = new Queue<TreeNode?>();
        var sb = new StringBuilder();
        queue.Enqueue(root);
        sb.Append('[');
        while (queue.Count > 0) {
            var node = queue.Dequeue();
            if (node == null) {
                sb.Append("null,");
                continue;
            }
            sb.Append(node.val);
            sb.Append(',');
            queue.Enqueue(node.left);
            queue.Enqueue(node.right);
        }
        var j = sb.Length - 1;
        for (; j - 4 >= 0 && sb[j - 4] == 'n'; j -= 5) ;
        if (sb[j] == '[') j++;
        sb.Remove(j, sb.Length - j);
        sb.Append(']');
        return sb.ToString();
    }

    // Decodes your encoded data to tree.
    public TreeNode? deserialize(string data)
    {
        if (data.Length == 2) return null;
        var i = 1;
        var root = new TreeNode(ReadNext());
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (data[i] != ']' && queue.Count > 0) {

            var node = queue.Dequeue();
            SetNode(ref node.left);
            if (data[i] == ']') break;
            SetNode(ref node.right);
        }

        return root;

        void SetNode(ref TreeNode? child)
        {
            i++;
            if (data[i] == 'n')
                ReadNext();
            else
                child = new(ReadNext());

            if (child != null) queue.Enqueue(child);
        }

        int ReadNext()
        {
            if (data[i] == 'n') {
                i += 4;
                return int.MinValue;
            }
            var isNegative = false;
            if (data[i] == '-') {
                isNegative = true;
                i++;
            }
            var val = 0;
            // Read digits as negative number to avoid overflow
            while (char.IsDigit(data[i])) {
                val = val * 10 - (data[i] - '0');
                i++;
            }
            return isNegative ? val : -val;
        }
    }
}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));
//leetcode submit region end(Prohibit modification and deletion)
public class TreeNode(int x)
{
    public TreeNode? left;
    public TreeNode? right;
    public int val = x;
}
