//给定一个整数，编写一个算法将这个数转换为十六进制数。对于负整数，我们通常使用 补码运算 方法。 
//
// 答案字符串中的所有字母都应该是小写字符，并且除了 0 本身之外，答案中不应该有任何前置零。 
//
// 注意: 不允许使用任何由库提供的将数字直接转换或格式化为十六进制的方法来解决这个问题。 
//
// 
//
// 示例 1： 
//
// 
//输入：num = 26
//输出："1a"
// 
//
// 示例 2： 
//
// 
//输入：num = -1
//输出："ffffffff"
// 
//
// 
//
// 提示： 
//
// 
// -2³¹ <= num <= 2³¹ - 1 
// 
//
// Related Topics 位运算 数学 字符串 👍 322 👎 0

namespace ConvertANumberToHexadecimal;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    private static readonly char[] HexChars = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f'];
    public string ToHex(int num)
    {
        const int Mask = 0xF;
        var result = new char[8];
        var index = 7;
        do {
            var hexDigit = num & Mask;
            result[index--] = HexChars[hexDigit];
            num >>>= 4;
        } while (num != 0 && index >= 0);

        return new(result, index + 1, 8 - index - 1);
    }
}
//leetcode submit region end(Prohibit modification and deletion)
