//给定两个整数，分别表示分数的分子 numerator 和分母 denominator，以 字符串形式返回小数 。 
//
// 如果小数部分为循环小数，则将循环的部分括在括号内。 
//
// 如果存在多个答案，只需返回 任意一个 。 
//
// 对于所有给定的输入，保证 答案字符串的长度小于 10⁴ 。 
//
// 
//
// 示例 1： 
//
// 
//输入：numerator = 1, denominator = 2
//输出："0.5"
// 
//
// 示例 2： 
//
// 
//输入：numerator = 2, denominator = 1
//输出："2"
// 
//
// 示例 3： 
//
// 
//输入：numerator = 4, denominator = 333
//输出："0.(012)"
// 
//
// 
//
// 提示： 
//
// 
// -2³¹ <= numerator, denominator <= 2³¹ - 1 
// denominator != 0 
// 
//
// Related Topics 哈希表 数学 字符串 👍 548 👎 0

using System.Text;

namespace FractionToRecurringDecimal;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public string FractionToDecimal(int numerator, int denominator)
    {
        
        long numeratorPos;
        long denominatorPos;
        if (denominator < 0) {
            numeratorPos = -(long)numerator;
            denominatorPos = -(long)denominator;
        } else {
            numeratorPos = numerator;
            denominatorPos = denominator;
        }
        
        var integerPart = numeratorPos / denominatorPos;
        var remainder = Math.Abs(numeratorPos % denominatorPos);
        if (remainder == 0) return integerPart.ToString();

        var sb = new StringBuilder();
        if (numeratorPos < 0 && integerPart == 0) sb.Append('-');
        sb.Append(integerPart);
        sb.Append('.');
        var map = new Dictionary<long, int>();
        
        while (remainder != 0) {
            if (map.TryGetValue(remainder, out var idx)) {
                sb.Insert(idx, "(");
                sb.Append(')');
                return sb.ToString();
            }
            
            map[remainder] = sb.Length;
            remainder *= 10;
            sb.Append(remainder / denominatorPos);
            remainder %= denominatorPos;
        }

        return sb.ToString();
    }
}
//leetcode submit region end(Prohibit modification and deletion)
