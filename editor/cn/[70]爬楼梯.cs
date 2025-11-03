//假设你正在爬楼梯。需要 n 阶你才能到达楼顶。 
//
// 每次你可以爬 1 或 2 个台阶。你有多少种不同的方法可以爬到楼顶呢？ 
//
// 
//
// 示例 1： 
//
// 
//输入：n = 2
//输出：2
//解释：有两种方法可以爬到楼顶。
//1. 1 阶 + 1 阶
//2. 2 阶 
//
// 示例 2： 
//
// 
//输入：n = 3
//输出：3
//解释：有三种方法可以爬到楼顶。
//1. 1 阶 + 1 阶 + 1 阶
//2. 1 阶 + 2 阶
//3. 2 阶 + 1 阶
// 
//
// 
//
// 提示： 
//
// 
// 1 <= n <= 45 
// 
//
// Related Topics 记忆化搜索 数学 动态规划 👍 3815 👎 0

namespace ClimbingStairs;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int ClimbStairs(int n)
    {
        var result = 0;
        for (var i = 0; i <= n / 2; i++)
            result += Choose(n - i, Math.Min(i, n - 2 * i));
        // i 次 2 阶，n - 2 * i 次 1 阶, 总共走 n - i 步.


        return result;

        int Choose(int n, int k)
        {
            long result = 1;
            for (var i = 1; i <= k; i++) {
                result *= n;
                result /= i;
                n--;
            }

            return (int)result;
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
