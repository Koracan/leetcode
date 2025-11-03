//给你一个 m x n 的矩阵 board ，由若干字符 'X' 和 'O' 组成，捕获 所有 被围绕的区域： 
//
// 
// 连接：一个单元格与水平或垂直方向上相邻的单元格连接。 
// 区域：连接所有 'O' 的单元格来形成一个区域。 
// 围绕：如果您可以用 'X' 单元格 连接这个区域，并且区域中没有任何单元格位于 board 边缘，则该区域被 'X' 单元格围绕。 
// 
//
// 通过 原地 将输入矩阵中的所有 'O' 替换为 'X' 来 捕获被围绕的区域。你不需要返回任何值。 
//
// 
// 
// 
// 
// 
//
// 示例 1： 
//
// 
// 输入：board = [["X","X","X","X"],["X","O","O","X"],["X","X","O","X"],["X","O",
//"X","X"]] 
// 
//
// 输出：[["X","X","X","X"],["X","X","X","X"],["X","X","X","X"],["X","O","X","X"]] 
//
//
// 解释： 
// 
// 在上图中，底部的区域没有被捕获，因为它在 board 的边缘并且不能被围绕。 
//
// 示例 2： 
//
// 
// 输入：board = [["X"]] 
// 
//
// 输出：[["X"]] 
//
// 
//
// 提示： 
//
// 
// m == board.length 
// n == board[i].length 
// 1 <= m, n <= 200 
// board[i][j] 为 'X' 或 'O' 
// 
//
// Related Topics 深度优先搜索 广度优先搜索 并查集 数组 矩阵 👍 1212 👎 0

namespace SurroundedRegions;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public void Solve(char[][] board)
    {
        var m = board.Length;
        var n = board[0].Length;
        (int v, int h)[] directions = [(-1, 0), (1, 0), (0, -1), (0, 1)];
        var queue = new Queue<(int, int)>();
        for (var j = 0; j < n; j++) {
            if (board[0][j] == 'O') Expand(0, j);
            if (board[m - 1][j] == 'O') Expand(m - 1, j);
        }

        for (var i = 1; i < m - 1; i++) {
            if (board[i][0] == 'O') Expand(i, 0);
            if (board[i][n - 1] == 'O') Expand(i, n - 1);
        }

        for (var i = 0; i < m; i++)
            for (var j = 0; j < n; j++)
                board[i][j] = board[i][j] == 'A' ? 'O' : 'X';

        return;

        void Expand(int i, int j)
        {
            board[i][j] = 'A';
            queue.Enqueue((i, j));
            while (queue.Count > 0) {
                (i, j) = queue.Dequeue();
                foreach (var (v, h) in directions) {
                    var i1 = i + v;
                    var j1 = j + h;
                    if (i1 >= 0 && i1 < m && j1 >= 0 && j1 < n && board[i1][j1] == 'O') {
                        board[i1][j1] = 'A';
                        queue.Enqueue((i1, j1));
                    }
                }
            }
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
