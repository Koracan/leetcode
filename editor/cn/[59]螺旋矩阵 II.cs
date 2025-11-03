//给你一个正整数 n ，生成一个包含 1 到 n² 所有元素，且元素按顺时针顺序螺旋排列的 n x n 正方形矩阵 matrix 。 
//
// 
//
// 示例 1： 
// 
// 
//输入：n = 3
//输出：[[1,2,3],[8,9,4],[7,6,5]]
// 
//
// 示例 2： 
//
// 
//输入：n = 1
//输出：[[1]]
// 
//
// 
//
// 提示： 
//
// 
// 1 <= n <= 20 
// 
//
// Related Topics 数组 矩阵 模拟 👍 1452 👎 0

namespace SpiralMatrixIi;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int[][] GenerateMatrix(int n)
    {
        var result = new int[n][];
        for (var i = 0; i < n; i++) result[i] = new int[n];
        int horizontal = 1, vertical = 0;

        int row = 0, col = 0;
        for (var i = 1; i <= n * n; i++) {
            result[row][col] = i;
            int newRow = row + vertical, newCol = col + horizontal;
            if (newRow >= n || newRow < 0 || newCol >= n || newCol < 0 || result[newRow][newCol] != 0)
                (horizontal, vertical) = (horizontal, vertical) switch {
                    (1, 0) => (0, 1),
                    (0, 1) => (-1, 0),
                    (-1, 0) => (0, -1),
                    (0, -1) => (1, 0),
                    _ => throw new() // should never happen
                };

            row += vertical;
            col += horizontal;
        }

        return result;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
