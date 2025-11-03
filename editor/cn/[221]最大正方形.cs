//在一个由 '0' 和 '1' 组成的二维矩阵内，找到只包含 '1' 的最大正方形，并返回其面积。 
//
// 
//
// 示例 1： 
// 
// 
//输入：matrix = [["1","0","1","0","0"],["1","0","1","1","1"],["1","1","1","1","1"]
//,["1","0","0","1","0"]]
//输出：4
// 
//
// 示例 2： 
// 
// 
//输入：matrix = [["0","1"],["1","0"]]
//输出：1
// 
//
// 示例 3： 
//
// 
//输入：matrix = [["0"]]
//输出：0
// 
//
// 
//
// 提示： 
//
// 
// m == matrix.length 
// n == matrix[i].length 
// 1 <= m, n <= 300 
// matrix[i][j] 为 '0' 或 '1' 
// 
//
// Related Topics 数组 动态规划 矩阵 👍 1844 👎 0

namespace MaximalSquare;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int MaximalSquare(char[][] matrix)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;
        var map = new int[n + 1]; // 每连续1的高度
        map[n] = -1; // 哨兵
        var max = 0;
        var stack = new Stack<int>(); // 单调栈，存储下标
        stack.Push(-1);
        for (int i = 0; i < m; i++) {
            for (int j = 0; j <= n; j++) {
                if (j < n) map[j] = matrix[i][j] == '1' ? map[j] + 1 : 0;
                while (stack.Peek() >= 0 && map[stack.Peek()] >= map[j]) {
                    var height = map[stack.Pop()];
                    var width = j - stack.Peek() - 1;
                    var side = Math.Min(height, width);
                    max = Math.Max(max, side * side);
                }
                if (j < n) stack.Push(j);
            }
        }

        return max;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
