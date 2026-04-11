//你总共有 n 枚硬币，并计划将它们按阶梯状排列。对于一个由 k 行组成的阶梯，其第 i 行必须正好有 i 枚硬币。阶梯的最后一行 可能 是不完整的。 
//
// 给你一个数字 n ，计算并返回可形成 完整阶梯行 的总行数。 
//
// 
//
// 示例 1： 
// 
// 
//输入：n = 5
//输出：2
//解释：因为第三行不完整，所以返回 2 。
// 
//
// 示例 2： 
// 
// 
//输入：n = 8
//输出：3
//解释：因为第四行不完整，所以返回 3 。
// 
//
// 
//
// 提示： 
//
// 
// 1 <= n <= 2³¹ - 1 
// 
//
// Related Topics 数学 二分查找 👍 327 👎 0

namespace ArrangingCoins;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int ArrangeCoins(int n)
    {
        int lo = 0, hi = n;
        while (lo < hi)
        {
            int mi = lo + (hi - lo) / 2;
            long sum = (long)mi * (mi + 1) / 2;

            if (n <= sum) {
                hi = mi;
            } else {
                lo = mi + 1;
            }
        }
        return (long)lo * (lo + 1) / 2 == n ? lo : lo - 1;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
