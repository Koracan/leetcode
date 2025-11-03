//按照国际象棋的规则，皇后可以攻击与之处在同一行或同一列或同一斜线上的棋子。 
//
// n 皇后问题 研究的是如何将 n 个皇后放置在 n×n 的棋盘上，并且使皇后彼此之间不能相互攻击。 
//
// 给你一个整数 n ，返回所有不同的 n 皇后问题 的解决方案。 
//
// 
// 
// 每一种解法包含一个不同的 n 皇后问题 的棋子放置方案，该方案中 'Q' 和 '.' 分别代表了皇后和空位。 
// 
// 
//
// 
//
// 示例 1： 
// 
// 
//输入：n = 4
//输出：[[".Q..","...Q","Q...","..Q."],["..Q.","Q...","...Q",".Q.."]]
//解释：如上图所示，4 皇后问题存在两个不同的解法。
// 
//
// 示例 2： 
//
// 
//输入：n = 1
//输出：[["Q"]]
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
// Related Topics 数组 回溯 👍 2293 👎 0

namespace NQueens;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public IList<IList<string>> SolveNQueens(int n)
    {
        var diag1 = 0; // diag1 & (1 << (j- i + n)) == 1 means j - i + n is occupied
        var diag2 = 0; // diag2 & (1 << (i + j)) == 1 means i + j is occupied
        var cols = 0; // cols & (1 << j) == 1 means j is occupied
        var map = new char[n][];

        for (var i = 0; i < n; i++) {
            map[i] = new char[n];
            for (var j = 0; j < n; j++) map[i][j] = '.';
        }

        var result = new List<IList<string>>();
        Next(0);
        return result;

        void Next(int i)
        {
            if (i == n) {
                var temp = new string[n];
                for (var j = 0; j < n; j++) temp[j] = new(map[j]);

                result.Add(temp);
                return;
            }

            for (var j = 0; j < n; j++) {
                if ((diag1 & 1 << j - i + n | diag2 & 1 << i + j | cols & 1 << j) != 0)
                    continue;

                diag1 |= 1 << j - i + n;
                diag2 |= 1 << i + j;
                cols |= 1 << j;
                map[i][j] = 'Q';
                Next(i + 1);
                map[i][j] = '.';
                diag1 &= ~(1 << j - i + n);
                diag2 &= ~(1 << i + j);
                cols &= ~(1 << j);
            }
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
