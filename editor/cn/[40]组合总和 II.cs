//给定一个候选人编号的集合 candidates 和一个目标数 target ，找出 candidates 中所有可以使数字和为 target 的组合。 
//
// candidates 中的每个数字在每个组合中只能使用 一次 。 
//
// 注意：解集不能包含重复的组合。 
//
// 
//
// 示例 1: 
//
// 
//输入: candidates = [10,1,2,7,6,1,5], target = 8,
//输出:
//[
//[1,1,6],
//[1,2,5],
//[1,7],
//[2,6]
//] 
//
// 示例 2: 
//
// 
//输入: candidates = [2,5,2,1,2], target = 5,
//输出:
//[
//[1,2,2],
//[5]
//] 
//
// 
//
// 提示: 
//
// 
// 1 <= candidates.length <= 100 
// 1 <= candidates[i] <= 50 
// 1 <= target <= 30 
// 
//
// Related Topics 数组 回溯 👍 1678 👎 0

namespace CombinationSumIi;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        Array.Sort(candidates);
        var result = new List<IList<int>>();
        CombinationSumHelper(0, 0, []);
        return result;

        void CombinationSumHelper(int index, int sum, List<int> current)
        {
            if (sum == target) {
                result.Add(current.ToArray()); // add a copy of current
                return;
            }

            for (var i = index; i < candidates.Length; i++) {
                if (i > index && candidates[i] == candidates[i - 1]) continue; // skip duplicates
                if (sum + candidates[i] > target) break;

                current.Add(candidates[i]);
                CombinationSumHelper(i + 1, sum + candidates[i], current);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
