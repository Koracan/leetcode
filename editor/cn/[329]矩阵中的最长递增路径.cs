//给定一个 m x n 整数矩阵 matrix ，找出其中 最长递增路径 的长度。 
//
// 对于每个单元格，你可以往上，下，左，右四个方向移动。 你 不能 在 对角线 方向上移动或移动到 边界外（即不允许环绕）。 
//
// 
//
// 示例 1： 
// 
// 
//输入：matrix = [[9,9,4],[6,6,8],[2,1,1]]
//输出：4 
//解释：最长递增路径为 [1, 2, 6, 9]。 
//
// 示例 2： 
// 
// 
//输入：matrix = [[3,4,5],[3,2,6],[2,2,1]]
//输出：4 
//解释：最长递增路径是 [3, 4, 5, 6]。注意不允许在对角线方向上移动。
// 
//
// 示例 3： 
//
// 
//输入：matrix = [[1]]
//输出：1
// 
//
// 
//
// 提示： 
//
// 
// m == matrix.length 
// n == matrix[i].length 
// 1 <= m, n <= 200 
// 0 <= matrix[i][j] <= 2³¹ - 1 
// 
//
// Related Topics 深度优先搜索 广度优先搜索 图 拓扑排序 记忆化搜索 数组 动态规划 矩阵 👍 924 👎 0

namespace LongestIncreasingPathInAMatrix;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int LongestIncreasingPath(int[][] matrix)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;
        var dp = new int[m, n];
        var max = 0;
        (int, int)[] directions = [(0, 1), (0, -1), (1, 0), (-1, 0)];

        for (var i = 0; i < m; i++)
            for (var j = 0; j < n; j++)
                max = Math.Max(Dfs(i, j), max);

        return max;

        int Dfs(int i, int j)
        {
            if (dp[i, j] != 0) return dp[i, j];

            dp[i, j] = 1;
            foreach (var (di, dj) in directions) {
                var newi = i + di;
                var newj = j + dj;
                if (newi >= 0 && newi < m && newj >= 0 && newj < n && matrix[newi][newj] > matrix[i][j])
                    dp[i, j] = Math.Max(dp[i, j], Dfs(newi, newj) + 1);
            }
            return dp[i, j];
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
