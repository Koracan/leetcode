//给定一个正整数 n ，将其拆分为 k 个 正整数 的和（ k >= 2 ），并使这些整数的乘积最大化。 
//
// 返回 你可以获得的最大乘积 。 
//
// 
//
// 示例 1: 
//
// 
//输入: n = 2
//输出: 1
//解释: 2 = 1 + 1, 1 × 1 = 1。 
//
// 示例 2: 
//
// 
//输入: n = 10
//输出: 36
//解释: 10 = 3 + 3 + 4, 3 × 3 × 4 = 36。 
//
// 
//
// 提示: 
//
// 
// 2 <= n <= 58 
// 
//
// Related Topics 数学 动态规划 👍 1511 👎 0

namespace IntegerBreak;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int IntegerBreak(int n)
    {
        if (n == 2) return 1;

        var ideal = n / Math.E;
        var k1 = (int)ideal;
        var max = 0;

        for (int k = Math.Max(2, k1 - 1); k <= k1 + 1; k++) {
            var quot = n / k;
            var rem = n % k;
            var product = Pow(quot, k - rem) * Pow(quot + 1, rem);
            max = Math.Max(max, product);
        }

        return max;

        int Pow(int baseNum, int exp)
        {
            // fast power
            var result = 1;
            while (exp > 0) {
                if ((exp & 1) == 1) result *= baseNum;
                baseNum *= baseNum;
                exp >>= 1;
            }
            return result;
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
