//给你一个字符串 s，请你将 s 分割成一些 子串，使每个子串都是 回文串 。返回 s 所有可能的分割方案。 
//
// 
//
// 示例 1： 
//
// 
//输入：s = "aab"
//输出：[["a","a","b"],["aa","b"]]
// 
//
// 示例 2： 
//
// 
//输入：s = "a"
//输出：[["a"]]
// 
//
// 
//
// 提示： 
//
// 
// 1 <= s.length <= 16 
// s 仅由小写英文字母组成 
// 
//
// Related Topics 字符串 动态规划 回溯 👍 2098 👎 0

namespace PalindromePartitioning;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public IList<IList<string>> Partition(string s)
    {
        var res = new List<IList<string>>();


        Backtrack(0, []);

        return res;


        bool IsPalindrome(int lo, int hi)
        {
            while (lo < hi) {
                if (s[lo] != s[hi])
                    return false;

                lo++;
                hi--;
            }
            return true;
        }

        void Backtrack(int start, List<string> path)
        {
            if (start == s.Length) {
                res.Add(path.ToArray());
                return;
            }

            for (int end = start; end < s.Length; end++) 
                if (IsPalindrome(start, end)) {
                    path.Add(s[start..(end + 1)]);
                    Backtrack(end + 1, path);
                    path.RemoveAt(path.Count - 1);
                }
            
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
