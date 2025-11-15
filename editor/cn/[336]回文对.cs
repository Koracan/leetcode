//给定一个由唯一字符串构成的 0 索引 数组 words 。 
//
// 回文对 是一对整数 (i, j) ，满足以下条件： 
//
// 
// 0 <= i, j < words.length， 
// i != j ，并且 
// words[i] + words[j]（两个字符串的连接）是一个回文串。 
// 
//
// 返回一个数组，它包含 words 中所有满足 回文对 条件的字符串。 
//
// 你必须设计一个时间复杂度为 O(sum of words[i].length) 的算法。 
//
// 
//
// 示例 1： 
//
// 
//输入：words = ["abcd","dcba","lls","s","sssll"]
//输出：[[0,1],[1,0],[3,2],[2,4]] 
//解释：可拼接成的回文串为 ["dcbaabcd","abcddcba","slls","llssssll"]
// 
//
// 示例 2： 
//
// 
//输入：words = ["bat","tab","cat"]
//输出：[[0,1],[1,0]] 
//解释：可拼接成的回文串为 ["battab","tabbat"] 
//
// 示例 3： 
//
// 
//输入：words = ["a",""]
//输出：[[0,1],[1,0]]
// 
//
// 
//
// 提示： 
//
// 
// 1 <= words.length <= 5000 
// 0 <= words[i].length <= 300 
// words[i] 由小写英文字母组成 
// 
//
// Related Topics 字典树 数组 哈希表 字符串 👍 426 👎 0

namespace PalindromePairs;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public IList<IList<int>> PalindromePairs(string[] words)
    {
        var root = new Node();
        var n = words.Length;
        for (var i = 0; i < n; i++) {
            var word = words[i].AsSpan();
            var node = root;

            if (IsPalindrome(word)) node.Suffixes.Add(i);
            for (var j = word.Length - 1; j >= 0; j--) {
                var index = word[j] - 'a';
                node.Children[index] ??= new();
                node = node.Children[index]!;
                if (IsPalindrome(word[..j])) node.Suffixes.Add(i);
            }
            node.Words.Add(i);
        }
        var result = new List<IList<int>>();
        for (var i = 0; i < n; i++) {
            var word = words[i].AsSpan();
            var node = root;
            var j = 0;
            for (; j < word.Length; j++) {
                if (node.Words.Count > 0 && IsPalindrome(word[j..]))
                    foreach (var index in node.Words)
                        if (index != i) result.Add([i, index]);

                var next = node.Children[word[j] - 'a'];
                if (next == null) break;
                node = next;
            }

            if (j == word.Length)
                foreach (var index in node.Suffixes)
                    if (index != i) result.Add([i, index]);
        }

        return result;
    }

    private static bool IsPalindrome(ReadOnlySpan<char> word)
    {
        var left = 0;
        var right = word.Length - 1;
        while (left < right) {
            if (word[left] != word[right]) return false;
            left++;
            right--;
        }
        return true;
    }

    private class Node
    {
        public Node?[] Children { get; } = new Node?[26];
        public List<int> Words { get; } = [];
        public List<int> Suffixes { get; } = [];
    }
}
//leetcode submit region end(Prohibit modification and deletion)
