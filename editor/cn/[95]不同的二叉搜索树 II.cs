//给你一个整数 n ，请你生成并返回所有由 n 个节点组成且节点值从 1 到 n 互不相同的不同 二叉搜索树 。可以按 任意顺序 返回答案。 
//
// 
//
// 
// 
// 示例 1： 
// 
// 
//输入：n = 3
//输出：[[1,null,2,null,3],[1,null,3,2],[2,1,3],[3,1,null,null,2],[3,2,null,1]]
// 
// 
// 
//
// 示例 2： 
//
// 
//输入：n = 1
//输出：[[1]]
// 
//
// 
//
// 提示： 
//
// 
// 1 <= n <= 8 
// 
//
// Related Topics 树 二叉搜索树 动态规划 回溯 二叉树 👍 1615 👎 0

namespace UniqueBinarySearchTreesIi;

//leetcode submit region begin(Prohibit modification and deletion)
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 * public int val;
 * public TreeNode left;
 * public TreeNode right;
 * public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 * this.val = val;
 * this.left = left;
 * this.right = right;
 * }
 * }
 */
public class Solution
{
    public IList<TreeNode> GenerateTrees(int n)
    {
        var memory = new List<TreeNode?>?[n + 1, n + 1];
        return Generate(1, n)!;

        List<TreeNode?> Generate(int start, int end)
        {
            if (start > end) return [null];
            if (memory[start, end] != null) return memory[start, end]!;
            if (start == end) {
                memory[start, end] = [new(start)];
                return memory[start, end]!;
            }

            var result = new List<TreeNode?>();
            for (var mid = start; mid <= end; mid++)
                foreach (var left in Generate(start, mid - 1))
                    foreach (var right in Generate(mid + 1, end))
                        result.Add(new(mid, left, right));


            memory[start, end] = result;
            return result;
        }
    }
}

//leetcode submit region end(Prohibit modification and deletion)
public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
{
    public TreeNode? left = left;
    public TreeNode? right = right;
    public int val = val;
}
