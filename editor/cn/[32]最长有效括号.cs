//给你一个只包含 '(' 和 ')' 的字符串，找出最长有效（格式正确且连续）括号子串的长度。 
//
// 
//
// 
// 
// 示例 1： 
// 
// 
//
// 
//输入：s = "(()"
//输出：2
//解释：最长有效括号子串是 "()"
// 
//
// 示例 2： 
//
// 
//输入：s = ")()())"
//输出：4
//解释：最长有效括号子串是 "()()"
// 
//
// 示例 3： 
//
// 
//输入：s = ""
//输出：0
// 
//
// 
//
// 提示： 
//
// 
// 0 <= s.length <= 3 * 10⁴ 
// s[i] 为 '(' 或 ')' 
// 
//
// Related Topics 栈 字符串 动态规划 👍 2693 👎 0

namespace LongestValidParentheses;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int LongestValidParentheses(string s)
    {
        if (s.Length == 0) return 0;

        var left = new int[s.Length];
        // 存储使得 i 到 j 为有效字串的最小 i. 若 s[j]=='(', 值为 -1, 若 s[j]==')' 但 i 不存在, 值为 -2.
        left[0] = s[0] == '(' ? -1 : -2;
        var max = 0;
        for (var j = 1; j < s.Length; j++) {
            if (s[j] == '(') {
                left[j] = -1;
                continue;
            }

            switch (left[j - 1]) {
                case -1: left[j] = j - 2 >= 0 && left[j - 2] >= 0 ? left[j - 2] : j - 1; break;
                case -2: left[j] = -2; break;
                default:
                    if (left[j - 1] - 1 >= 0 && left[left[j - 1] - 1] == -1)
                        left[j] = left[j - 1] - 2 >= 0 && left[left[j - 1] - 2] >= 0
                            ? left[left[j - 1] - 2]
                            : left[j - 1] - 1;
                    else left[j] = -2;

                    break;
            }

            if (left[j] >= 0 && j - left[j] + 1 > max) max = j - left[j] + 1;
        }

        return max;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
