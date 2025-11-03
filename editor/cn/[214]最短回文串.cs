//给定一个字符串 s，你可以通过在字符串前面添加字符将其转换为回文串。找到并返回可以用这种方式转换的最短回文串。 
//
// 
//
// 示例 1： 
//
// 
//输入：s = "aacecaaa"
//输出："aaacecaaa"
// 
//
// 示例 2： 
//
// 
//输入：s = "abcd"
//输出："dcbabcd"
// 
//
// 
//
// 提示： 
//
// 
// 0 <= s.length <= 5 * 10⁴ 
// s 仅由小写英文字母组成 
// 
//
// Related Topics 字符串 字符串匹配 哈希函数 滚动哈希 👍 633 👎 0

using System.Text;

namespace ShortestPalindrome;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public string ShortestPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s) || s.Length == 1) return s;
        var n = s.Length;
        // KMP-based: Find longest palindromic prefix
        var reverse = new char[n];
        for (int i = 0; i < n; ++i) reverse[i] = s[n - 1 - i];

        var t = s + '#' + new string(reverse);
        var next = new int[t.Length];
        for (int i = 1, j = 0; i < t.Length; ++i) {
            while (j > 0 && t[i] != t[j]) j = next[j - 1];
            if (t[i] == t[j]) ++j;
            next[i] = j;
        }
        int longest = next[t.Length - 1];
        // Build result
        var sb = new StringBuilder();
        for (int i = n - 1; i >= longest; --i) sb.Append(s[i]);
        sb.Append(s);
        return sb.ToString();
    }
}
//leetcode submit region end(Prohibit modification and deletion)
