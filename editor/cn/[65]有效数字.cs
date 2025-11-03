//给定一个字符串 s ，返回 s 是否是一个 有效数字。 
//
// 例如，下面的都是有效数字："2", "0089", "-0.1", "+3.14", "4.", "-.9", "2e10", "-90E3", "3e+
//7", "+6e-1", "53.5e93", "-123.456e789"，而接下来的不是："abc", "1a", "1e", "e3", "99e2.5
//", "--6", "-+3", "95a54e53"。 
//
// 一般的，一个 有效数字 可以用以下的规则之一定义： 
//
// 
// 一个 整数 后面跟着一个 可选指数。 
// 一个 十进制数 后面跟着一个 可选指数。 
// 
//
// 一个 整数 定义为一个 可选符号 '-' 或 '+' 后面跟着 数字。 
//
// 一个 十进制数 定义为一个 可选符号 '-' 或 '+' 后面跟着下述规则： 
//
// 
// 数字 后跟着一个 小数点 .。 
// 数字 后跟着一个 小数点 . 再跟着 数位。 
// 一个 小数点 . 后跟着 数位。 
// 
//
// 指数 定义为指数符号 'e' 或 'E'，后面跟着一个 整数。 
//
// 数字 定义为一个或多个数位。 
//
// 
//
// 示例 1： 
//
// 
// 输入：s = "0" 
// 
//
// 输出：true 
//
// 示例 2： 
//
// 
// 输入：s = "e" 
// 
//
// 输出：false 
//
// 示例 3： 
//
// 
// 输入：s = "." 
// 
//
// 输出：false 
//
// 
//
// 提示： 
//
// 
// 1 <= s.length <= 20 
// s 仅含英文字母（大写和小写），数字（0-9），加号 '+' ，减号 '-' ，或者点 '.' 。 
// 
//
// Related Topics 字符串 👍 397 👎 0

namespace ValidNumber;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public bool IsNumber(string s)
    {
        var start = 0;
        if (s[start] == '+' || s[start] == '-') start++;
        if (start >= s.Length) return false;
        if (s[start] == '.')
            return start + 1 < s.Length
                && char.IsDigit(s[start + 1])
                && IsAfterDot(s, start + 2);

        if (start >= s.Length || !char.IsDigit(s[start])) return false;

        while (start < s.Length && char.IsDigit(s[start])) start++;
        if (start == s.Length) return true;

        return s[start] switch {
            'e' or 'E' => start + 1 < s.Length && IsInteger(s, start + 1),
            '.' => IsAfterDot(s, start + 1),
            _ => false
        };
    }

    private bool IsAfterDot(string s, int start)
    {
        if (start >= s.Length) return true;
        if (s[start] is 'e' or 'E') return start + 1 < s.Length && IsInteger(s, start + 1);

        if (!char.IsDigit(s[start])) return false;

        while (start < s.Length && char.IsDigit(s[start])) start++;

        if (start == s.Length) return true;

        return s[start] switch {
            'e' or 'E' => start + 1 < s.Length && IsInteger(s, start + 1),
            _ => false
        };
    }

    private bool IsInteger(string s, int start)
    {
        if (s[start] == '+' || s[start] == '-') start++;

        if (start >= s.Length) return false;

        for (var i = start; i < s.Length; i++)
            if (!char.IsDigit(s[i]))
                return false;

        return true;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
