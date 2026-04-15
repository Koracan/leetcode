//Trie（发音类似 "try"）或者说 前缀树 是一种树形数据结构，用于高效地存储和检索字符串数据集中的键。这一数据结构有相当多的应用情景，例如自动补全和拼
//写检查。 
//
// 请你实现 Trie 类： 
//
// 
// Trie() 初始化前缀树对象。 
// void insert(String word) 向前缀树中插入字符串 word 。 
// boolean search(String word) 如果字符串 word 在前缀树中，返回 true（即，在检索之前已经插入）；否则，返回 
//false 。 
// boolean startsWith(String prefix) 如果之前已经插入的字符串 word 的前缀之一为 prefix ，返回 true ；否
//则，返回 false 。 
// 
//
// 
//
// 示例： 
//
// 
//输入
//["Trie", "insert", "search", "search", "startsWith", "insert", "search"]
//[[], ["apple"], ["apple"], ["app"], ["app"], ["app"], ["app"]]
//输出
//[null, null, true, false, true, null, true]
//
//解释
//Trie trie = new Trie();
//trie.insert("apple");
//trie.search("apple");   // 返回 True
//trie.search("app");     // 返回 False
//trie.startsWith("app"); // 返回 True
//trie.insert("app");
//trie.search("app");     // 返回 True
// 
//
// 
//
// 提示： 
//
// 
// 1 <= word.length, prefix.length <= 2000 
// word 和 prefix 仅由小写英文字母组成 
// insert、search 和 startsWith 调用次数 总计 不超过 3 * 10⁴ 次 
// 
//
// Related Topics 设计 字典树 哈希表 字符串 👍 1859 👎 0

namespace ImplementTriePrefixTree;

//leetcode submit region begin(Prohibit modification and deletion)
public class Trie
{
    private readonly TrieNode _root;

    public Trie()
    {
        _root = new();
    }

    public void Insert(string word)
    {
        var curr = _root;
        for (int i = 0; i < word.Length; i++) {
            var idx = word[i] - 'a';
            if (curr!.Children[idx] != null) {
                curr = curr.Children[idx];
            } else {
                var newNode = new TrieNode();
                curr.Children[idx] = newNode;
                curr = newNode;
            }
        }
        curr!.IsEnd = true;
    }

    public bool Search(string word)
    {
        var curr = _root;
        foreach (var c in word) {
            var idx = c - 'a';
            if (curr!.Children[idx] == null) return false;

            curr = curr.Children[idx];
        }

        return curr!.IsEnd;
    }

    public bool StartsWith(string prefix)
    {
        var curr = _root;
        foreach (var c in prefix) {
            var idx = c - 'a';
            if (curr!.Children[idx] == null) return false;

            curr = curr.Children[idx];
        }

        return true;
    }

    private class TrieNode
    {
        public bool IsEnd;
        public readonly TrieNode?[] Children = new TrieNode?[26];
    }
}

// ReSharper disable once InvalidXmlDocComment
/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
//leetcode submit region end(Prohibit modification and deletion)
