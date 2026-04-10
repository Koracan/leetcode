//给你一个字符串 s，找到 s 中最长的 回文 子串。 
//
// 
//
// 示例 1： 
//
// 
//输入：s = "babad"
//输出："bab"
//解释："aba" 同样是符合题意的答案。
// 
//
// 示例 2： 
//
// 
//输入：s = "cbbd"
//输出："bb"
// 
//
// 
//
// 提示： 
//
// 
// 1 <= s.length <= 1000 
// s 仅由数字和英文字母组成 
// 
//
// Related Topics 双指针 字符串 动态规划 👍 8050 👎 0

namespace LongestPalindromicSubstring;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public string LongestPalindrome(string s)
    {
        var maxLength = 0;
        var resL = -1;
        var resR = -1;
        for (int i = 0; i < s.Length; i++) {
            // expand from i
            int l = i, r = i;
            while (l >= 0 && r < s.Length && s[l] == s[r]) {
                l--;
                r++;
            }
            if (r - l - 1 > maxLength) {
                maxLength = r - l - 1;
                resL = l + 1;
                resR = r - 1;
            }
            // expand from i and i + 1
            l = i;
            r = i + 1;
            while (l >= 0 && r < s.Length && s[l] == s[r]) {
                l--;
                r++;
            }
            if (r - l - 1 > maxLength) {
                maxLength = r - l - 1;
                resL = l + 1;
                resR = r - 1;
            }
        }
        return s[resL..(resR + 1)];
    }
}
//leetcode submit region end(Prohibit modification and deletion)
