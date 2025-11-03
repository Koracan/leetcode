//给定一个整数 n，计算所有小于等于 n 的非负整数中数字 1 出现的个数。 
//
// 
//
// 示例 1： 
//
// 
//输入：n = 13
//输出：6
// 
//
// 示例 2： 
//
// 
//输入：n = 0
//输出：0
// 
//
// 
//
// 提示： 
//
// 
// 0 <= n <= 10⁹ 
// 
//
// Related Topics 递归 数学 动态规划 👍 623 👎 0

namespace NumberOfDigitOne;
//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    public int CountDigitOne(int n) {
        long result = 0;
        for (long i = 1; i <= n; i *= 10) {
            var divider = i * 10;
            result += (n / divider) * i + Math.Min(Math.Max(n % divider - i + 1, 0), i);
        }
        return (int)result;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
