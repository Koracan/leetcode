//给定一个 m x n 二维字符网格 board 和一个字符串单词 word 。如果 word 存在于网格中，返回 true ；否则，返回 false 。 
//
// 单词必须按照字母顺序，通过相邻的单元格内的字母构成，其中“相邻”单元格是那些水平相邻或垂直相邻的单元格。同一个单元格内的字母不允许被重复使用。 
//
// 
//
// 示例 1： 
// 
// 
//输入：board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = 
//"ABCCED"
//输出：true
// 
//
// 示例 2： 
// 
// 
//输入：board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = 
//"SEE"
//输出：true
// 
//
// 示例 3： 
// 
// 
//输入：board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = 
//"ABCB"
//输出：false
// 
//
// 
//
// 提示： 
//
// 
// m == board.length 
// n = board[i].length 
// 1 <= m, n <= 6 
// 1 <= word.length <= 15 
// board 和 word 仅由大小写英文字母组成 
// 
//
// 
//
// 进阶：你可以使用搜索剪枝的技术来优化解决方案，使其在 board 更大的情况下可以更快解决问题？ 
//
// Related Topics 深度优先搜索 数组 字符串 回溯 矩阵 👍 1992 👎 0

namespace WordSearch;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public bool Exist(char[][] board, string word)
    {
        var m = board.Length;
        var n = board[0].Length;
        long visited = 0; // (visited & (long)1 << (i * n + j)) > 0 means (i,j) is visited;
        for (var i = 0; i < m; i++)
            for (var j = 0; j < n; j++)
                if (Dfs(0, i, j))
                    return true;

        return false;

        bool Dfs(int index, int i, int j)
        {
            if (index == word.Length) return true;

            if (i < 0 || i >= m || j < 0 || j >= n || (visited & (long)1 << i * n + j) > 0 || board[i][j] != word[index])
                return false;

            visited |= (long)1 << i * n + j;

            var result = Dfs(index + 1, i - 1, j)
                      || Dfs(index + 1, i + 1, j)
                      || Dfs(index + 1, i, j - 1)
                      || Dfs(index + 1, i, j + 1);

            visited ^= (long)1 << i * n + j;

            return result;
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
