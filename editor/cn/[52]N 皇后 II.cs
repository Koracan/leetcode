//n 皇后问题 研究的是如何将 n 个皇后放置在 n × n 的棋盘上，并且使皇后彼此之间不能相互攻击。 
//
// 给你一个整数 n ，返回 n 皇后问题 不同的解决方案的数量。 
//
// 
//
// 
// 
// 示例 1： 
// 
// 
//输入：n = 4
//输出：2
//解释：如上图所示，4 皇后问题存在两个不同的解法。
// 
// 
// 
//
// 示例 2： 
//
// 
//输入：n = 1
//输出：1
// 
//
// 
//
// 提示： 
//
// 
// 1 <= n <= 9 
// 
//
// Related Topics 回溯 👍 569 👎 0

namespace NQueensIi;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int TotalNQueens(int n)
    {
        var result = 0;

        for (var i = 0; i < n / 2; i++) Dfs(1, 1 << i, 1 << i + 1, 1 << i >> 1);

        result *= 2;
        if (n % 2 == 1) Dfs(1, 1 << n / 2, 1 << n / 2 + 1, 1 << n / 2 >> 1);

        return result;

        void Dfs(int row, int cols, int diag1, int diag2)
        {
            if (row == n) {
                result++;
                return;
            }

            var available = (1 << n) - 1 & ~(cols | diag1 | diag2);
            while (available != 0) {
                var pick = available & -available;
                Dfs(row + 1, cols | pick, (diag1 | pick) << 1, (diag2 | pick) >> 1);
                available &= available - 1;
            }
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
