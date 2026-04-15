//按字典 wordList 完成从单词 beginWord 到单词 endWord 转化，一个表示此过程的 转换序列 是形式上像 beginWord -> 
//s1 -> s2 -> ... -> sk 这样的单词序列，并满足： 
//
// 
// 
// 
// 每对相邻的单词之间仅有单个字母不同。 
// 转换过程中的每个单词 si（1 <= i <= k）必须是字典 wordList 中的单词。注意，beginWord 不必是字典 wordList 中的单
//词。 
// sk == endWord 
// 
// 
// 
//
// 给你两个单词 beginWord 和 endWord ，以及一个字典 wordList 。请你找出并返回所有从 beginWord 到 endWord 的
// 最短转换序列 ，如果不存在这样的转换序列，返回一个空列表。每个序列都应该以单词列表 [beginWord, s1, s2, ..., sk] 的形式返回。 
//
// 
//
// 示例 1： 
//
// 
//输入：beginWord = "hit", endWord = "cog", wordList = ["hot","dot","dog","lot",
//"log","cog"]
//输出：[["hit","hot","dot","dog","cog"],["hit","hot","lot","log","cog"]]
//解释：存在 2 种最短的转换序列：
//"hit" -> "hot" -> "dot" -> "dog" -> "cog"
//"hit" -> "hot" -> "lot" -> "log" -> "cog"
// 
//
// 示例 2： 
//
// 
//输入：beginWord = "hit", endWord = "cog", wordList = ["hot","dot","dog","lot",
//"log"]
//输出：[]
//解释：endWord "cog" 不在字典 wordList 中，所以不存在符合要求的转换序列。
// 
//
// 
//
// 提示： 
//
// 
// 1 <= beginWord.length <= 5 
// endWord.length == beginWord.length 
// 1 <= wordList.length <= 500 
// wordList[i].length == beginWord.length 
// beginWord、endWord 和 wordList[i] 由小写英文字母组成 
// beginWord != endWord 
// wordList 中的所有单词 互不相同 
// 
//
// Related Topics 广度优先搜索 哈希表 字符串 回溯 👍 751 👎 0

namespace WordLadderIi;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
    {
        if (!wordList.Contains(endWord)) return [];
        var wordLength = beginWord.Length;

        var graph = new Dictionary<string, string[]>();
        var queue = new Queue<string>();
        queue.Enqueue(beginWord);
        var visited = new HashSet<string> { beginWord };
        var found = false;
        var depth = 1;

        List<string> buffer = [];

        while (queue.Count > 0 && !found) {
            depth++;
            var count = queue.Count;

            for (var i = 0; i < count; i++) {
                var word = queue.Dequeue();
                foreach (var next in GetNextWords(word))
                    if (visited.Add(next)) {
                        if (next == endWord) {
                            found = true;
                            break;
                        }

                        queue.Enqueue(next);
                    }
            }
        }

        if (!found) return [];

        var result = new List<IList<string>>();
        var beginNeighbor = new HashSet<string>(GetNextWords(beginWord));
        List<string> list = [endWord];
        visited.Clear();
        visited.Add(endWord);
        Dfs();
        return result;

        void Dfs()
        {
            if (list.Count == depth - 1) {
                if (!beginNeighbor.Contains(list[^1])) return;
                list.Add(beginWord);
                var temp = list.ToArray();
                Array.Reverse(temp);
                result.Add(temp);
                list.RemoveAt(list.Count - 1);
                return;
            }

            foreach (var next in GetNextWords(list[^1])) {
                if (visited.Add(next)) {
                    list.Add(next);
                    Dfs();
                    list.RemoveAt(list.Count - 1);
                    visited.Remove(next);
                }
            }
        }

        string[] GetNextWords(string word)
        {
            if (graph.TryGetValue(word, out var nextWords)) return nextWords;

            buffer.Clear();
            foreach (var next in wordList) {
                var diff = 0;
                for (var i = 0; i < wordLength; i++)
                    if (word[i] != next[i])
                        diff++;

                if (diff == 1) buffer.Add(next);
            }

            graph[word] = buffer.ToArray();
            return graph[word];
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
