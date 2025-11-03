//给定一个 m x n 二维字符网格 board 和一个单词（字符串）列表 words， 返回所有二维网格上的单词 。 
//
// 单词必须按照字母顺序，通过 相邻的单元格 内的字母构成，其中“相邻”单元格是那些水平相邻或垂直相邻的单元格。同一个单元格内的字母在一个单词中不允许被重复使
//用。 
//
// 
//
// 示例 1： 
// 
// 
//输入：board = [["o","a","a","n"],["e","t","a","e"],["i","h","k","r"],["i","f",
//"l","v"]], words = ["oath","pea","eat","rain"]
//输出：["eat","oath"]
// 
//
// 示例 2： 
// 
// 
//输入：board = [["a","b"],["c","d"]], words = ["abcb"]
//输出：[]
// 
//
// 
//
// 提示： 
//
// 
// m == board.length 
// n == board[i].length 
// 1 <= m, n <= 12 
// board[i][j] 是一个小写英文字母 
// 1 <= words.length <= 3 * 10⁴ 
// 1 <= words[i].length <= 10 
// words[i] 由小写英文字母组成 
// words 中的所有字符串互不相同 
// 
//
// Related Topics 字典树 数组 字符串 回溯 矩阵 👍 959 👎 0

namespace WordSearchIi;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public IList<string> FindWords(char[][] board, string[] words)
    {
        int m = board.Length, n = board[0].Length;
        var trie = new Trie();
        foreach (var word in words) trie.Insert(word);
        var result = new List<string>();
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                trie.Dfs(board, i, j, result);
        return result;
    }
}
public class Trie {
    private class TrieNode {
        public readonly TrieNode?[] Children = new TrieNode[26];
        public string? Word;
    }

    private readonly TrieNode _root = new();
    public void Insert(string word) {
        var node = _root;
        foreach (var c in word) {
            int idx = c - 'a';
            if (node!.Children[idx] == null) node.Children[idx] = new();
            node = node.Children[idx];
        }
        node!.Word = word;
    }

    public void Dfs(char[][] board, int i, int j, List<string> result)
    {
        DfsHelper(board, i, j, _root ,result);
    }

    private static void DfsHelper(char[][] board, int i, int j, TrieNode node, List<string> result)
    {
        char c = board[i][j];
        if (c == '#' || node.Children[c - 'a'] == null) return;
        node = node.Children[c - 'a']!;
        if (node.Word != null) {
            result.Add(node.Word);
            node.Word = null; // 防止重复加入
        }
        board[i][j] = '#'; // 标记为访问过
        if (i > 0) DfsHelper(board, i - 1, j, node, result);
        if (i < board.Length - 1) DfsHelper(board, i + 1, j, node, result);
        if (j > 0) DfsHelper(board, i, j - 1, node, result);
        if (j < board[0].Length - 1) DfsHelper(board, i, j + 1, node, result);
        board[i][j] = c;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
