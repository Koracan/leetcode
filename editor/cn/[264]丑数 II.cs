//给你一个整数 n ，请你找出并返回第 n 个 丑数 。 
//
// 丑数 就是质因子只包含 2、3 和 5 的正整数。 
//
// 
//
// 示例 1： 
//
// 
//输入：n = 10
//输出：12
//解释：[1, 2, 3, 4, 5, 6, 8, 9, 10, 12] 是由前 10 个丑数组成的序列。
// 
//
// 示例 2： 
//
// 
//输入：n = 1
//输出：1
//解释：1 通常被视为丑数。
// 
//
// 
//
// 提示： 
//
// 
// 1 <= n <= 1690 
// 
//
// Related Topics 哈希表 数学 动态规划 堆（优先队列） 👍 1283 👎 0

namespace UglyNumberIi;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int NthUglyNumber(int n)
    {
        var dp = new int[n];
        dp[0] = 1;
        var p2 = 0;
        var p3 = 0;
        var p5 = 0;
        for (var i = 1; i < n; i++) {
            var v2 = dp[p2] * 2;
            var v3 = dp[p3] * 3;
            var v5 = dp[p5] * 5;
            var min = Math.Min(v2, Math.Min(v3, v5));
            dp[i] = min;
            if (min == v2) p2++;
            if (min == v3) p3++;
            if (min == v5) p5++;
        }

        return dp[n - 1];
    }
}
//leetcode submit region end(Prohibit modification and deletion)
