//请你设计一个数据结构，支持 添加新单词 和 查找字符串是否与任何先前添加的字符串匹配 。 
//
// 实现词典类 WordDictionary ： 
//
// 
// WordDictionary() 初始化词典对象 
// void addWord(word) 将 word 添加到数据结构中，之后可以对它进行匹配 
// bool search(word) 如果数据结构中存在字符串与 word 匹配，则返回 true ；否则，返回 false 。word 中可能包含一些 
//'.' ，每个 . 都可以表示任何一个字母。 
// 
//
// 
//
// 示例： 
//
// 
//输入：
//["WordDictionary","addWord","addWord","addWord","search","search","search",
//"search"]
//[[],["bad"],["dad"],["mad"],["pad"],["bad"],[".ad"],["b.."]]
//输出：
//[null,null,null,null,false,true,true,true]
//
//解释：
//WordDictionary wordDictionary = new WordDictionary();
//wordDictionary.addWord("bad");
//wordDictionary.addWord("dad");
//wordDictionary.addWord("mad");
//wordDictionary.search("pad"); // 返回 False
//wordDictionary.search("bad"); // 返回 True
//wordDictionary.search(".ad"); // 返回 True
//wordDictionary.search("b.."); // 返回 True
// 
//
// 
//
// 提示： 
//
// 
// 1 <= word.length <= 25 
// addWord 中的 word 由小写英文字母组成 
// search 中的 word 由 '.' 或小写英文字母组成 
// 最多调用 10⁴ 次 addWord 和 search 
// 
//
// Related Topics 深度优先搜索 设计 字典树 字符串 👍 626 👎 0

namespace DesignAddAndSearchWordsDataStructure;

//leetcode submit region begin(Prohibit modification and deletion)
public class WordDictionary
{
    private readonly TrieNode _root;

    public WordDictionary()
    {
        _root = new();
    }

    public void AddWord(string word)
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

    private bool SearchHelper(string word, int start, TrieNode curr)
    {
        if (start == word.Length) return curr.IsEnd;
        var c = word[start];
        if (c == '.') {
            for (int i = 0; i < 26; i++)
                if (curr.Children[i] != null && SearchHelper(word, start + 1, curr.Children[i]!))
                    return true;
            return false;
        }
        var idx = c - 'a';
        return curr.Children[idx] != null && SearchHelper(word, start + 1, curr.Children[idx]!);
    }


    public bool Search(string word)
    {
        return SearchHelper(word, 0, _root);
    }


    private class TrieNode
    {
        public bool IsEnd;
        public readonly TrieNode?[] Children = new TrieNode?[26];
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */
//leetcode submit region end(Prohibit modification and deletion)
