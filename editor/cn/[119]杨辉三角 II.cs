//给定一个非负索引 rowIndex，返回「杨辉三角」的第 rowIndex 行。 
//
// 在「杨辉三角」中，每个数是它左上方和右上方的数的和。 
//
// 
//
// 
//
// 示例 1: 
//
// 
//输入: rowIndex = 3
//输出: [1,3,3,1]
// 
//
// 示例 2: 
//
// 
//输入: rowIndex = 0
//输出: [1]
// 
//
// 示例 3: 
//
// 
//输入: rowIndex = 1
//输出: [1,1]
// 
//
// 
//
// 提示: 
//
// 
// 0 <= rowIndex <= 33 
// 
//
// 
//
// 进阶： 
//
// 你可以优化你的算法到 O(rowIndex) 空间复杂度吗？ 
//
// Related Topics 数组 动态规划 👍 589 👎 0

namespace PascalsTriangleIi;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public IList<int> GetRow(int rowIndex)
    {
        // var result = new IList<int>[rowIndex];
        // for (var i = 0; i < rowIndex; i++) result[i] = new int[i + 1];
        //
        // for (var i = 0; i < rowIndex; i++) {
        //     result[i][0] = result[i][i] = 1;
        //     for (var j = 1; j < i; j++) result[i][j] = result[i - 1][j - 1] + result[i - 1][j];
        // }
        //
        // return result[rowIndex - 1];

        var row = new int[rowIndex + 1];
        row[0] = 1;
        for (var i = 1; i <= rowIndex; i++)
            for (var j = i; j >= 1; j--)
                row[j] += row[j - 1];

        return row;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
