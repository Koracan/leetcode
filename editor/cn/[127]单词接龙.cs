//字典 wordList 中从单词 beginWord 到 endWord 的 转换序列 是一个按下述规格形成的序列
// beginWord -> s1 -> s2 -> ... -> sk： 
//
// 
// 每一对相邻的单词只差一个字母。 
// 
// 对于 1 <= i <= k 时，每个
// si 都在
// wordList 中。注意， beginWord 不需要在
// wordList 中。
// 
// sk == endWord 
// 
//
// 给你两个单词 beginWord 和 endWord 和一个字典 wordList ，返回 从 beginWord 到 endWord 的 最短转换序列 
//中的 单词数目 。如果不存在这样的转换序列，返回 0 。 
//
// 示例 1： 
//
// 
//输入：beginWord = "hit", endWord = "cog", wordList = ["hot","dot","dog","lot",
//"log","cog"]
//输出：5
//解释：一个最短转换序列是 "hit" -> "hot" -> "dot" -> "dog" -> "cog", 返回它的长度 5。
// 
//
// 示例 2： 
//
// 
//输入：beginWord = "hit", endWord = "cog", wordList = ["hot","dot","dog","lot",
//"log"]
//输出：0
//解释：endWord "cog" 不在字典中，所以无法进行转换。 
//
// 
//
// 提示： 
//
// 
// 1 <= beginWord.length <= 10 
// endWord.length == beginWord.length 
// 1 <= wordList.length <= 5000 
// wordList[i].length == beginWord.length 
// beginWord、endWord 和 wordList[i] 由小写英文字母组成 
// beginWord != endWord 
// wordList 中的所有字符串 互不相同 
// 
//
// Related Topics 广度优先搜索 哈希表 字符串 👍 1464 👎 0

namespace WordLadder;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        if (!wordList.Contains(endWord)) return 0;
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

        return found ? depth : 0;

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
