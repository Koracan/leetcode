//编写一个高效的算法来搜索 m x n 矩阵 matrix 中的一个目标值 target 。该矩阵具有以下特性： 
//
// 
// 每行的元素从左到右升序排列。 
// 每列的元素从上到下升序排列。 
// 
//
// 
//
// 示例 1： 
// 
// 
//输入：matrix = [[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21
//,23,26,30]], target = 5
//输出：true
// 
//
// 示例 2： 
// 
// 
//输入：matrix = [[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21
//,23,26,30]], target = 20
//输出：false
// 
//
// 
//
// 提示： 
//
// 
// m == matrix.length 
// n == matrix[i].length 
// 1 <= n, m <= 300 
// -10⁹ <= matrix[i][j] <= 10⁹ 
// 每行的所有元素从左到右升序排列 
// 每列的所有元素从上到下升序排列 
// -10⁹ <= target <= 10⁹ 
// 
//
// Related Topics 数组 二分查找 分治 矩阵 👍 1732 👎 0

namespace SearchA2dMatrixIi;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        // // 先二分查找找到可能的行
        // var m = matrix.Length;
        // var n = matrix[0].Length;
        //
        // var maxRow = BinarySearch(0, m, target, i => matrix[i][0]);
        // var minRow = BinarySearch(0, m, target - 1, i => matrix[i][n - 1]) + 1;
        // for (var i = minRow; i <= maxRow; i++) {
        //     var row = matrix[i];
        //     var col = BinarySearch(0, n, target, j => row[j]);
        //     if (row[col] == target)
        //         return true;
        // }
        //
        //
        // return false;
        //
        // // return: the largest index i in [lo, hi) such that nums(i) <= e
        // int BinarySearch(int lo, int hi, int e, Func<int, int> nums)
        // {
        //     while (lo < hi) {
        //         var mid = (lo + hi) / 2;
        //         if (e < nums(mid))
        //             hi = mid;
        //         else
        //             lo = mid + 1;
        //     }
        //
        //     return lo - 1;
        // }

        int m = matrix.Length;
        int n = matrix[0].Length;

        int r = 0, c = n - 1;
        while (r < m && c >= 0)
        {
            var val = matrix[r][c];
            if (val == target) return true;
            if (val > target) c--;
            else r++;
        }

        return false;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
