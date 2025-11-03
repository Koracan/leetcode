//给你一个 m 行 n 列的矩阵 matrix ，请按照 顺时针螺旋顺序 ，返回矩阵中的所有元素。 
//
// 
//
// 示例 1： 
// 
// 
//输入：matrix = [[1,2,3],[4,5,6],[7,8,9]]
//输出：[1,2,3,6,9,8,7,4,5]
// 
//
// 示例 2： 
// 
// 
//输入：matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]
//输出：[1,2,3,4,8,12,11,10,9,5,6,7]
// 
//
// 
//
// 提示： 
//
// 
// m == matrix.length 
// n == matrix[i].length 
// 1 <= m, n <= 10 
// -100 <= matrix[i][j] <= 100 
// 
//
// Related Topics 数组 矩阵 模拟 👍 1922 👎 0

namespace SpiralMatrix;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        int horizontal = 1, vertical = 0;
        int rows = matrix.Length, cols = matrix[0].Length;
        var result = new int[matrix.Length * matrix[0].Length];

        int row = 0, col = 0;
        for (var i = 0; i < result.Length; i++) {
            result[i] = matrix[row][col];
            matrix[row][col] = int.MinValue; // mark as visited
            int newRow = row + vertical, newCol = col + horizontal;
            if (newRow >= rows || newRow < 0 || newCol >= cols || newCol < 0 || matrix[newRow][newCol] == int.MinValue)
                (horizontal, vertical) = (horizontal, vertical) switch {
                    (1, 0) => (0, 1),
                    (0, 1) => (-1, 0),
                    (-1, 0) => (0, -1),
                    (0, -1) => (1, 0),
                    _ => throw new()
                };

            row += vertical;
            col += horizontal;
        }

        return result;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
