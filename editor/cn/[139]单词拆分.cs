//给你一个字符串 s 和一个字符串列表 wordDict 作为字典。如果可以利用字典中出现的一个或多个单词拼接出 s 则返回 true。 
//
// 注意：不要求字典中出现的单词全部都使用，并且字典中的单词可以重复使用。 
//
// 
//
// 示例 1： 
//
// 
//输入: s = "leetcode", wordDict = ["leet", "code"]
//输出: true
//解释: 返回 true 因为 "leetcode" 可以由 "leet" 和 "code" 拼接成。
// 
//
// 示例 2： 
//
// 
//输入: s = "applepenapple", wordDict = ["apple", "pen"]
//输出: true
//解释: 返回 true 因为 "applepenapple" 可以由 "apple" "pen" "apple" 拼接成。
//     注意，你可以重复使用字典中的单词。
// 
//
// 示例 3： 
//
// 
//输入: s = "catsandog", wordDict = ["cats", "dog", "sand", "and", "cat"]
//输出: false
// 
//
// 
//
// 提示： 
//
// 
// 1 <= s.length <= 300 
// 1 <= wordDict.length <= 1000 
// 1 <= wordDict[i].length <= 20 
// s 和 wordDict[i] 仅由小写英文字母组成 
// wordDict 中的所有字符串 互不相同 
// 
//
// Related Topics 字典树 记忆化搜索 数组 哈希表 字符串 动态规划 👍 2830 👎 0

namespace WordBreak;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        var canBreak = new byte[s.Length]; // 0: 未计算, 1: false, 2: true
        var wordSet = wordDict.ToHashSet();
        
        return CanBreak(0);

        bool CanBreak(int start)
        {
            if (canBreak[start] != 0) return canBreak[start] == 2;

            for (var end = start + 1; end <= s.Length; end++)
                if (wordSet.Contains(s[start..end]) && (end == s.Length || CanBreak(end))) {
                    canBreak[start] = 2;
                    return true;
                }
            
            canBreak[start] = 1;
            return false;
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
