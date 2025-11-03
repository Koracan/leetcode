//给定一个仅包含 0 和 1 、大小为 rows x cols 的二维二进制矩阵，找出只包含 1 的最大矩形，并返回其面积。 
//
// 
//
// 示例 1： 
// 
// 
//输入：matrix = [["1","0","1","0","0"],["1","0","1","1","1"],["1","1","1","1","1"]
//,["1","0","0","1","0"]]
//输出：6
//解释：最大矩形如上图所示。
// 
//
// 示例 2： 
//
// 
//输入：matrix = [["0"]]
//输出：0
// 
//
// 示例 3： 
//
// 
//输入：matrix = [["1"]]
//输出：1
// 
//
// 
//
// 提示： 
//
// 
// rows == matrix.length 
// cols == matrix[0].length 
// 1 <= row, cols <= 200 
// matrix[i][j] 为 '0' 或 '1' 
// 
//
// Related Topics 栈 数组 动态规划 矩阵 单调栈 👍 1733 👎 0

namespace MaximalRectangle;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int MaximalRectangle(char[][] matrix)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;

        for (var i = 1; i < m; i++) {
            for (var j = 0; j < n; j++)
                if (matrix[i][j] != '0')
                    matrix[i][j] += (char)(matrix[i - 1][j] - '0');
        }

        var totalMaxArea = 0;
        var stack = new Stack<int>();
        var borders = new (int l, int r)[n];

        for (var row = 0; row < m; row++) {
            // stack 在每次循环完成后都为空, 故不需要 stack.Clear()
            // borders 在每次循环中都会完全覆盖, 故不需要置零
            for (var i = 0; i < n; i++) {
                while (stack.Count > 0 && matrix[row][stack.Peek()] >= matrix[row][i]) borders[stack.Pop()].r = i;
                borders[i].l = stack.Count == 0 ? -1 : stack.Peek();
                stack.Push(i);
            }

            while (stack.Count > 0) borders[stack.Pop()].r = n;

            var maxArea = 0;
            for (var i = 0; i < n; i++) {
                var area = (matrix[row][i] - '0') * (borders[i].r - borders[i].l - 1);
                if (area > maxArea) maxArea = area;
            }

            if (totalMaxArea < maxArea) totalMaxArea = maxArea;
        }

        return totalMaxArea;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
