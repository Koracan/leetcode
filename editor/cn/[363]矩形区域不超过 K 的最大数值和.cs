//给你一个 m x n 的矩阵 matrix 和一个整数 k ，找出并返回矩阵内部矩形区域的不超过 k 的最大数值和。 
//
// 题目数据保证总会存在一个数值和不超过 k 的矩形区域。 
//
// 
//
// 示例 1： 
// 
// 
//输入：matrix = [[1,0,1],[0,-2,3]], k = 2
//输出：2
//解释：蓝色边框圈出来的矩形区域 [[0, 1], [-2, 3]] 的数值和是 2，且 2 是不超过 k 的最大数字（k = 2）。
// 
//
// 示例 2： 
//
// 
//输入：matrix = [[2,2,-1]], k = 3
//输出：3
// 
//
// 
//
// 提示： 
//
// 
// m == matrix.length 
// n == matrix[i].length 
// 1 <= m, n <= 100 
// -100 <= matrix[i][j] <= 100 
// -10⁵ <= k <= 10⁵ 
// 
//
// 
//
// 进阶：如果行数远大于列数，该如何设计解决方案？ 
//
// Related Topics 数组 二分查找 矩阵 有序集合 前缀和 👍 522 👎 0

namespace MaxSumOfRectangleNoLargerThanK;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int MaxSumSubmatrix(int[][] matrix, int k)
    {
        var result = int.MinValue;

        var m = matrix.Length;
        var n = matrix[0].Length;
        bool isRight = n > m;
        if (!isRight) (m, n) = (n, m);
        var colSums = new int[n];


        for (int ceil = 0; ceil < m; ceil++) {
            Array.Fill(colSums, 0);
            for (int floor = ceil; floor < m; floor++) {
                for (int col = 0; col < n; col++)
                    colSums[col] += isRight ? matrix[floor][col] : matrix[col][floor];

                List<int> prefixSums = [0]; // 由于 n<=100，选用常数更好的 List 而不是 SortedSet 提高速度
                var prefixSum = 0;
                foreach (var sum in colSums) {
                    prefixSum += sum;
                    var target = prefixSum - k;
                    var idx = prefixSums.BinarySearch(target);
                    if (idx < 0) idx = ~idx;

                    if (idx < prefixSums.Count) {
                        result = Math.Max(result, prefixSum - prefixSums[idx]);
                        if (result == k) return k;
                    }
                    var insertIdx = prefixSums.BinarySearch(prefixSum);
                    if (insertIdx < 0) prefixSums.Insert(~insertIdx, prefixSum);
                }
            }
        }
        return result;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
