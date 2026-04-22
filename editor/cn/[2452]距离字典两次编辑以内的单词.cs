//给你两个字符串数组 queries 和 dictionary 。数组中所有单词都只包含小写英文字母，且长度都相同。 
//
// 一次 编辑 中，你可以从 queries 中选择一个单词，将任意一个字母修改成任何其他字母。从 queries 中找到所有满足以下条件的字符串：不超过 两
//次编辑内，字符串与 dictionary 中某个字符串相同。 
//
// 请你返回 queries 中的单词列表，这些单词距离 dictionary 中的单词 编辑次数 不超过 两次 。单词返回的顺序需要与 queries 中原
//本顺序相同。 
//
// 
//
// 示例 1： 
//
// 输入：queries = ["word","note","ants","wood"], dictionary = ["wood","joke",
//"moat"]
//输出：["word","note","wood"]
//解释：
//- 将 "word" 中的 'r' 换成 'o' ，得到 dictionary 中的单词 "wood" 。
//- 将 "note" 中的 'n' 换成 'j' 且将 't' 换成 'k' ，得到 "joke" 。
//- "ants" 需要超过 2 次编辑才能得到 dictionary 中的单词。
//- "wood" 不需要修改（0 次编辑），就得到 dictionary 中相同的单词。
//所以我们返回 ["word","note","wood"] 。
// 
//
// 示例 2： 
//
// 输入：queries = ["yes"], dictionary = ["not"]
//输出：[]
//解释：
//"yes" 需要超过 2 次编辑才能得到 "not" 。
//所以我们返回空数组。
// 
//
// 
//
// 提示： 
//
// 
// 1 <= queries.length, dictionary.length <= 100 
// n == queries[i].length == dictionary[j].length 
// 1 <= n <= 100 
// 所有 queries[i] 和 dictionary[j] 都只包含小写英文字母。 
// 
//
// Related Topics 字典树 数组 字符串 👍 21 👎 0

namespace WordsWithinTwoEditsOfDictionary;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    private class TrieNode
    {
        private readonly TrieNode?[] _children = new TrieNode[26];

        private bool IsEnd { get; set; }

        private TrieNode? this[char c]
        {
            get => _children[c - 'a'];
            set => _children[c - 'a'] = value;
        }

        public void Insert(string word)
        {
            var node = this;
            for (int i = 0; i < word.Length - 1; i++) {
                var c = word[i];
                node[c] ??= new();
                node = node[c]!;
            }
            node[word[^1]] ??= new();
            node[word[^1]]!.IsEnd = true;
        }

        public bool Search(ReadOnlySpan<char> word, int allowEdits)
        {
            if (word.Length == 0) return IsEnd;

            var c = word[0];

            // 1. 优先尝试直接匹配（不消耗编辑次数）
            if (this[c] != null && this[c]!.Search(word[1..], allowEdits))
                return true;

            // 2. 如果还有编辑名额，尝试替换成其他 25 个字母
            if (allowEdits > 0) {
                for (char i = 'a'; i <= 'z'; i++) {
                    if (i == c) continue; // 已经试过了
                    if (this[i] != null && this[i]!.Search(word[1..], allowEdits - 1))
                        return true;
                }
            }

            return false;
        }
    }

    public IList<string> TwoEditWords(string[] queries, string[] dictionary)
    {
        var root = new TrieNode();

        foreach (var word in dictionary)
            root.Insert(word);

        var result = new List<string>();
        foreach (var word in queries)
            if (root.Search(word, 2))
                result.Add(word);

        return result;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
