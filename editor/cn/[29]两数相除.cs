//给你两个整数，被除数 dividend 和除数 divisor。将两数相除，要求 不使用 乘法、除法和取余运算。 
//
// 整数除法应该向零截断，也就是截去（truncate）其小数部分。例如，8.345 将被截断为 8 ，-2.7335 将被截断至 -2 。 
//
// 返回被除数 dividend 除以除数 divisor 得到的 商 。 
//
// 注意：假设我们的环境只能存储 32 位 有符号整数，其数值范围是 [−2³¹, 231 − 1] 。本题中，如果商 严格大于 231 − 1 ，则返回 2
//31 − 1 ；如果商 严格小于 -2³¹ ，则返回 -2³¹ 。 
//
// 
//
// 示例 1: 
//
// 
//输入: dividend = 10, divisor = 3
//输出: 3
//解释: 10/3 = 3.33333.. ，向零截断后得到 3 。 
//
// 示例 2: 
//
// 
//输入: dividend = 7, divisor = -3
//输出: -2
//解释: 7/-3 = -2.33333.. ，向零截断后得到 -2 。 
//
// 
//
// 提示： 
//
// 
// -2³¹ <= dividend, divisor <= 2³¹ - 1 
// divisor != 0 
// 
//
// Related Topics 位运算 数学 👍 1289 👎 0

namespace DivideTwoIntegers;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int Divide(int dividend, int divisor)
    {
        if (dividend == int.MinValue) return divisor switch { -1 => int.MaxValue, < -1 => 1 + Divide(int.MinValue - divisor, divisor), _ => -1 + Divide(int.MinValue + divisor, divisor) };

        if (divisor == int.MinValue) return 0;

        var sign = (dividend, divisor) switch { (> 0, > 0) or (< 0, < 0) => 1, _ => -1 };

        dividend = Math.Abs(dividend);
        divisor = Math.Abs(divisor);


        var result = 0;

        for (var i = 32 - 1; dividend != 0 && i >= 0; i--)
            if (divisor > 0 && dividend >> i >= divisor) {
                dividend -= divisor << i;
                result += 1 << i;
            }

        return sign * result;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
