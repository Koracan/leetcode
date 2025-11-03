//给你一个整数数组 nums ，数组中的元素 互不相同 。返回该数组所有可能的子集（幂集）。 
//
// 解集 不能 包含重复的子集。你可以按 任意顺序 返回解集。 
//
// 
//
// 示例 1： 
//
// 
//输入：nums = [1,2,3]
//输出：[[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]
// 
//
// 示例 2： 
//
// 
//输入：nums = [0]
//输出：[[],[0]]
// 
//
// 
//
// 提示： 
//
// 
// 1 <= nums.length <= 10 
// -10 <= nums[i] <= 10 
// nums 中的所有元素 互不相同 
// 
//
// Related Topics 位运算 数组 回溯 👍 2486 👎 0

namespace Subsets;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        var result = new IList<int>[1 << nums.Length];

        var buffer = new List<int>(nums.Length);
        for (var i = 0; i < result.Length; i++) {
            buffer.Clear();
            for (var j = 0; j < nums.Length; j++)
                if ((i & 1 << j) != 0)
                    buffer.Add(nums[j]);

            result[i] = buffer.ToArray();
        }

        return result;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
