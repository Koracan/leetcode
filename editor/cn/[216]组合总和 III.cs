//找出所有相加之和为 n 的 k 个数的组合，且满足下列条件： 
//
// 
// 只使用数字1到9 
// 每个数字 最多使用一次 
// 
//
// 返回 所有可能的有效组合的列表 。该列表不能包含相同的组合两次，组合可以以任何顺序返回。 
//
// 
//
// 示例 1: 
//
// 
//输入: k = 3, n = 7
//输出: [[1,2,4]]
//解释:
//1 + 2 + 4 = 7
//没有其他符合的组合了。 
//
// 示例 2: 
//
// 
//输入: k = 3, n = 9
//输出: [[1,2,6], [1,3,5], [2,3,4]]
//解释:
//1 + 2 + 6 = 9
//1 + 3 + 5 = 9
//2 + 3 + 4 = 9
//没有其他符合的组合了。 
//
// 示例 3: 
//
// 
//输入: k = 4, n = 1
//输出: []
//解释: 不存在有效的组合。
//在[1,9]范围内使用4个不同的数字，我们可以得到的最小和是1+2+3+4 = 10，因为10 > 1，没有有效的组合。
// 
//
// 
//
// 提示: 
//
// 
// 2 <= k <= 9 
// 1 <= n <= 60 
// 
//
// Related Topics 数组 回溯 👍 955 👎 0

namespace CombinationSumIii;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public IList<IList<int>> CombinationSum3(int k, int n)
    {
        var result = new List<IList<int>>();
        Backtrack(k, n, 1, [], result);
        return result;
    }

    private void Backtrack(int k, int n, int start, List<int> path, IList<IList<int>> res)
    {
        if (path.Count == k && n == 0) {
            res.Add(path.ToArray());
            return;
        }

        for (var i = start; i <= 9; i++) {
            var minSum = (i + i + k - path.Count - 1) * (k - path.Count) / 2;
            if (minSum > n) break; // i + (i+1) + ... + (i + (k - path.Count - 1)) > n
            if (path.Count + (10 - i) < k) break; // 剩余数字不够凑齐 k 个
            path.Add(i);
            Backtrack(k, n - i, i + 1, path, res);
            path.RemoveAt(path.Count - 1);
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
