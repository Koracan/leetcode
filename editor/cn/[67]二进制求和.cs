//给你两个二进制字符串 a 和 b ，以二进制字符串的形式返回它们的和。 
//
// 
//
// 示例 1： 
//
// 
//输入:a = "11", b = "1"
//输出："100" 
//
// 示例 2： 
//
// 
//输入：a = "1010", b = "1011"
//输出："10101" 
//
// 
//
// 提示： 
//
// 
// 1 <= a.length, b.length <= 10⁴ 
// a 和 b 仅由字符 '0' 或 '1' 组成 
// 字符串如果不是 "0" ，就不含前导零 
// 
//
// Related Topics 位运算 数学 字符串 模拟 👍 1294 👎 0

namespace AddBinary;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public string AddBinary(string a, string b)
    {
        if (a.Length < b.Length) (a, b) = (b, a);

        var result = new char[a.Length];
        var carry = 0;
        for (var i = 1; i <= b.Length; i++) {
            var x = a[^i] - '0' + b[^i] - '0' + carry;
            result[^i] = (char)((x & 1) + '0');
            carry = x >> 1;
        }

        for (var i = b.Length + 1; i <= a.Length; i++) {
            var x = a[^i] - '0' + carry;
            result[^i] = (char)((x & 1) + '0');
            carry = x >> 1;
        }

        return carry == 0 ? new(result) : new(['1', ..result]);
    }
}
//leetcode submit region end(Prohibit modification and deletion)
