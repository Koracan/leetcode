//给你一个整数 n ，返回 和为 n 的完全平方数的最少数量 。 
//
// 完全平方数 是一个整数，其值等于另一个整数的平方；换句话说，其值等于一个整数自乘的积。例如，1、4、9 和 16 都是完全平方数，而 3 和 11 不是。
// 
//
// 
//
// 示例 1： 
//
// 
//输入：n = 12
//输出：3 
//解释：12 = 4 + 4 + 4 
//
// 示例 2： 
//
// 
//输入：n = 13
//输出：2
//解释：13 = 4 + 9 
//
// 
//
// 提示： 
//
// 
// 1 <= n <= 10⁴ 
// 
//
// Related Topics 广度优先搜索 数学 动态规划 👍 2246 👎 0

namespace PerfectSquares;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int NumSquares(int n)
    {
        // 四平方定理：result <= 4
        // 1. 判断是否为完全平方数
        var sqrt = (int)Math.Sqrt(n);
        if (n == sqrt * sqrt) return 1;
        // 2. 除掉4的幂次
        var temp = n;
        while ((temp & 0b11) == 0) temp >>= 2;

        // 2.1 判断是否为4^k(8m+7)，此时结果为 4
        if ((temp & 0b111) == 7) return 4;
        // 3. 判断是否为两个完全平方数之和
        for (var i = 1; i <= sqrt; i++) {
            var rem = n - i * i;
            var remSqrt = (int)Math.Sqrt(rem);
            if (rem == remSqrt * remSqrt) return 2;
        }
        // 4. 其他情况，结果为3
        return 3;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
