//给定一个正整数 n ，你可以做如下操作： 
//
// 
// 如果 n 是偶数，则用 n / 2替换 n 。 
// 如果 n 是奇数，则可以用 n + 1或n - 1替换 n 。 
// 
//
// 返回 n 变为 1 所需的 最小替换次数 。 
//
// 
//
// 示例 1： 
//
// 
//输入：n = 8
//输出：3
//解释：8 -> 4 -> 2 -> 1
// 
//
// 示例 2： 
//
// 
//输入：n = 7
//输出：4
//解释：7 -> 8 -> 4 -> 2 -> 1
//或 7 -> 6 -> 3 -> 2 -> 1
// 
//
// 示例 3： 
//
// 
//输入：n = 4
//输出：2
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
// Related Topics 贪心 位运算 记忆化搜索 动态规划 👍 329 👎 0

namespace IntegerReplacement;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int IntegerReplacement(int n)
    {
        // 111 -> 1000 -> 1, 4 steps
        // 111 -> 110 -> 11 -> 10 -> 1, 4 steps
        // 11 -> 100 -> 1, 3 steps
        // 11 -> 10 -> 1, 2 steps
        // 1011 -> 1100 -> 11 -> 10 -> 1, 4 steps
        // 1011 -> 1010 -> 101 -> 100 -> 1, 5 steps
        // so we prefer +1 when we have tail 11, except for 11 itself
        int steps = 0;
        for (var nu = (uint)n; nu > 1; steps++)
            if ((nu & 0b11) == 0b11 && nu != 0b11)
                nu += 1;
            else if ((nu & 1) == 1) // odd
                nu -= 1;
            else // even
                nu >>= 1;

        return steps;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
