//给你一个字符串 s，请你将 s 分割成一些子串，使每个子串都是回文串。 
//
// 返回符合要求的 最少分割次数 。 
//
// 
// 
// 
// 
// 
//
// 示例 1： 
//
// 
//输入：s = "aab"
//输出：1
//解释：只需一次分割就可将 s 分割成 ["aa","b"] 这样两个回文子串。
// 
//
// 示例 2： 
//
// 
//输入：s = "a"
//输出：0
// 
//
// 示例 3： 
//
// 
//输入：s = "ab"
//输出：1
// 
//
// 
//
// 提示： 
//
// 
// 1 <= s.length <= 2000 
// s 仅由小写英文字母组成 
// 
//
// Related Topics 字符串 动态规划 👍 841 👎 0

namespace PalindromePartitioningIi;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int MinCut(string s)
    {
        var isPalindrome = new byte[s.Length / 8 + 1, s.Length];
        var dp = new int[s.Length];

        for (var i = 0; i < s.Length; i++) {
            dp[i] = i;
            for (var j = 0; j <= i; j++)
                if (s[i] == s[j] && (i - j <= 2 || (isPalindrome[(j + 1) / 8, i - 1] & 1u << (j + 1) % 8) != 0)) {
                    isPalindrome[j / 8, i] |= (byte)(1 << j % 8);
                    dp[i] = j == 0 ? 0 : Math.Min(dp[i], dp[j - 1] + 1);
                }
        }

        return dp[s.Length - 1];
    }
}
//leetcode submit region end(Prohibit modification and deletion)
