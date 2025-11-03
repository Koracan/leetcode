//给你一个 无重复元素 的整数数组 candidates 和一个目标整数 target ，找出 candidates 中可以使数字和为目标数 target 的
// 所有 不同组合 ，并以列表形式返回。你可以按 任意顺序 返回这些组合。 
//
// candidates 中的 同一个 数字可以 无限制重复被选取 。如果至少一个数字的被选数量不同，则两种组合是不同的。 
//
// 对于给定的输入，保证和为 target 的不同组合数少于 150 个。 
//
// 
//
// 示例 1： 
//
// 
//输入：candidates = [2,3,6,7], target = 7
//输出：[[2,2,3],[7]]
//解释：
//2 和 3 可以形成一组候选，2 + 2 + 3 = 7 。注意 2 可以使用多次。
//7 也是一个候选， 7 = 7 。
//仅有这两种组合。 
//
// 示例 2： 
//
// 
//输入: candidates = [2,3,5], target = 8
//输出: [[2,2,2,2],[2,3,3],[3,5]] 
//
// 示例 3： 
//
// 
//输入: candidates = [2], target = 1
//输出: []
// 
//
// 
//
// 提示： 
//
// 
// 1 <= candidates.length <= 30 
// 2 <= candidates[i] <= 40 
// candidates 的所有元素 互不相同 
// 1 <= target <= 40 
// 
//
// Related Topics 数组 回溯 👍 3020 👎 0

namespace CombinationSum;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        var result = new List<IList<int>>();
        var counts = new int[candidates.Length];
        CombinationSumHelper(0, target);
        return result;


        void CombinationSumHelper(int index, int sum)
        {
            if (index == candidates.Length - 1) {
                if (sum % candidates[index] != 0) return;

                counts[index] = sum / candidates[index];
                var list = new List<int>();
                for (var i = 0; i < candidates.Length; i++)
                    for (var j = 0; j < counts[i]; j++)
                        list.Add(candidates[i]);

                result.Add(list);
                return;
            }

            for (var repeat = 0; repeat <= sum / candidates[index]; repeat++) {
                counts[index] = repeat;
                CombinationSumHelper(index + 1, sum - repeat * candidates[index]);
            }
        }

        // return CombinationSumHelper(candidates.Length - 1, target);

        // IList<IList<int>> CombinationSumHelper(int end, int sum)
        // {
        //     if (end == 0) {
        //         if (sum % candidates[0] != 0) return [];
        //
        //         var list = new int[sum / candidates[0]];
        //         for (int i = 0; i < list.Length; i++) {
        //             list[i] = candidates[0];
        //         }
        //
        //         return [list];
        //     }
        //
        //     var result = new List<IList<int>>();
        //     for (int repeat = 0; repeat <= sum / candidates[end]; repeat++) {
        //         var added = new int[repeat];
        //         for (int i = 0; i < repeat; i++) {
        //             added[i] = candidates[end];
        //         }
        //
        //         result.AddRange(
        //             CombinationSumHelper(end - 1, sum - repeat * candidates[end])
        //                 .Select(list => (IList<int>) [..list, ..added])
        //         );
        //     }
        //
        //     return result;
        // }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
