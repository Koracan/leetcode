//给定两个以字符串形式表示的非负整数 num1 和 num2，返回 num1 和 num2 的乘积，它们的乘积也表示为字符串形式。 
//
// 注意：不能使用任何内置的 BigInteger 库或直接将输入转换为整数。 
//
// 
//
// 示例 1: 
//
// 
//输入: num1 = "2", num2 = "3"
//输出: "6" 
//
// 示例 2: 
//
// 
//输入: num1 = "123", num2 = "456"
//输出: "56088" 
//
// 
//
// 提示： 
//
// 
// 1 <= num1.length, num2.length <= 200 
// num1 和 num2 只能由数字组成。 
// num1 和 num2 都不包含任何前导零，除了数字0本身。 
// 
//
// Related Topics 数学 字符串 模拟 👍 1425 👎 0

using System.Text;

namespace MultiplyStrings;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public string Multiply(string num1, string num2)
    {
        if (num1 == "0" || num2 == "0") return "0";

        var result = new int[num1.Length + num2.Length];
        for (var i = num1.Length - 1; i >= 0; i--) {
            for (var j = num2.Length - 1; j >= 0; j--) {
                var mul = (num1[i] - '0') * (num2[j] - '0');
                var sum = mul + result[i + j + 1];
                result[i + j + 1] = sum % 10;
                result[i + j] += sum / 10;
            }
        }

        var sb = new StringBuilder(num1.Length + num2.Length);
        if (result[0] != 0) {
            sb.Append((char)(result[0] + '0'));
        }

        for (var i = 1; i < result.Length; i++) {
            sb.Append((char)(result[i] + '0'));
        }

        return sb.ToString();
        // return new StringBuilder()
        //     .AppendJoin(
        //         "",
        //         result
        //             .Skip(result[0] == 0 ? 1 : 0)
        //             .Select(x => (char)(x + '0'))
        //     ).ToString();
    }
}
//leetcode submit region end(Prohibit modification and deletion)
