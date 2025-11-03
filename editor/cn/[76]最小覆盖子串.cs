//给你一个字符串 s 、一个字符串 t 。返回 s 中涵盖 t 所有字符的最小子串。如果 s 中不存在涵盖 t 所有字符的子串，则返回空字符串 "" 。 
//
// 
//
// 注意： 
//
// 
// 对于 t 中重复字符，我们寻找的子字符串中该字符数量必须不少于 t 中该字符数量。 
// 如果 s 中存在这样的子串，我们保证它是唯一的答案。 
// 
//
// 
//
// 示例 1： 
//
// 
//输入：s = "ADOBECODEBANC", t = "ABC"
//输出："BANC"
//解释：最小覆盖子串 "BANC" 包含来自字符串 t 的 'A'、'B' 和 'C'。
// 
//
// 示例 2： 
//
// 
//输入：s = "a", t = "a"
//输出："a"
//解释：整个字符串 s 是最小覆盖子串。
// 
//
// 示例 3: 
//
// 
//输入: s = "a", t = "aa"
//输出: ""
//解释: t 中两个字符 'a' 均应包含在 s 的子串中，
//因此没有符合条件的子字符串，返回空字符串。 
//
// 
//
// 提示： 
//
// 
// m == s.length 
// n == t.length 
// 1 <= m, n <= 10⁵ 
// s 和 t 由英文字母组成 
// 
//
// 
//进阶：你能设计一个在 
//o(m+n) 时间内解决此问题的算法吗？
//
// Related Topics 哈希表 字符串 滑动窗口 👍 3237 👎 0

namespace MinimumWindowSubstring;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public string MinWindow(string s, string t)
    {
        int ansL = -1, ansR = s.Length;
        var letterDiff = new int[58]; // letter count in substring - letter count in t
        var lessCount = 0; // count of letterDiff < 0 
        foreach (var c in t) {
            if (letterDiff[c - 'A'] == 0) lessCount++;
            letterDiff[c - 'A']--;
        }

        int left = 0, right = -1;
        while (right < s.Length - 1) {
            while (lessCount > 0 && right < s.Length - 1) {
                right++;
                letterDiff[s[right] - 'A']++;
                if (letterDiff[s[right] - 'A'] == 0) lessCount--;
            }

            while (lessCount <= 0) {
                letterDiff[s[left] - 'A']--;
                if (letterDiff[s[left] - 'A'] == -1) lessCount++;
                left++;
            }

            if (right - (left - 1) < ansR - ansL) {
                ansL = left - 1;
                ansR = right;
            }
        }

        return ansL == -1 ? "" : s[ansL..(ansR + 1)];
    }
}
//leetcode submit region end(Prohibit modification and deletion)
