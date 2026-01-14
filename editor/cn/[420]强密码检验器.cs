//满足以下条件的密码被认为是强密码： 
//
// 
// 由至少 6 个，至多 20 个字符组成。 
// 包含至少 一个小写 字母，至少 一个大写 字母，和至少 一个数字 。 
// 不包含连续三个重复字符 (比如 "Baaabb0" 是弱密码, 但是 "Baaba0" 是强密码)。 
// 
//
// 给你一个字符串 password ，返回 将 password 修改到满足强密码条件需要的最少修改步数。如果 password 已经是强密码，则返回 0 
//。 
//
// 在一步修改操作中，你可以： 
//
// 
// 插入一个字符到 password ， 
// 从 password 中删除一个字符，或 
// 用另一个字符来替换 password 中的某个字符。 
// 
//
// 
//
// 示例 1： 
//
// 
//输入：password = "a"
//输出：5
// 
//
// 示例 2： 
//
// 
//输入：password = "aA1"
//输出：3
// 
//
// 示例 3： 
//
// 
//输入：password = "1337C0d3"
//输出：0
// 
//
// 
//
// 提示： 
//
// 
// 1 <= password.length <= 50 
// password 由字母、数字、点 '.' 或者感叹号 '!' 组成 
// 
//
// Related Topics 贪心 字符串 堆（优先队列） 👍 228 👎 0

namespace StrongPasswordChecker;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int StrongPasswordChecker(string password)
    {
        var n = password.Length;

        // check missing types and replacements
        var hasLower = false;
        var hasUpper = false;
        var hasDigit = false;
        var replacements = 0;
        var i = 0;
        while (i < n) {
            var c = password[i];
            if (char.IsLower(c)) hasLower = true;
            else if (char.IsUpper(c)) hasUpper = true;
            else if (char.IsDigit(c)) hasDigit = true;
            var length = 1;
            while (i + length < n && password[i + length] == c) length++;
            replacements += length / 3;
            i += length;
        }
        var missingTypes = (hasLower ? 0 : 1) + (hasUpper ? 0 : 1) + (hasDigit ? 0 : 1);
        if (n < 6) return Math.Max(missingTypes, 6 - n);
        if (n <= 20) return Math.Max(missingTypes, replacements);

        // n > 20
        var deletions = n - 20;
        var overLen = deletions;

        // prioritize reducing replacements by deletions
        var modCounts = new int[3];
        i = 0;
        while (i < n) {
            var c = password[i];
            var length = 1;
            while (i + length < n && password[i + length] == c) length++;
            if (length >= 3) modCounts[length % 3]++;
            i += length;
        }

        for (var mod = 0; mod < 3; mod++) {
            if (mod == 2) continue; // handle mod 2 later
            while (modCounts[mod] > 0 && overLen > mod) {
                overLen -= (mod + 1);
                modCounts[mod]--;
                replacements--;
            }
        }

        // handle mod 2 sequences
        while (modCounts[2] > 0 && overLen > 2) {
            overLen -= 3;
            modCounts[2]--;
            replacements--;
        }

        // any remaining deletions
        replacements -= overLen / 3;

        return deletions + Math.Max(missingTypes, replacements);
    }
}
//leetcode submit region end(Prohibit modification and deletion)
