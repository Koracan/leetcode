//给定一个不含重复数字的数组 nums ，返回其 所有可能的全排列 。你可以 按任意顺序 返回答案。 
//
// 
//
// 示例 1： 
//
// 
//输入：nums = [1,2,3]
//输出：[[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
// 
//
// 示例 2： 
//
// 
//输入：nums = [0,1]
//输出：[[0,1],[1,0]]
// 
//
// 示例 3： 
//
// 
//输入：nums = [1]
//输出：[[1]]
// 
//
// 
//
// 提示： 
//
// 
// 1 <= nums.length <= 6 
// -10 <= nums[i] <= 10 
// nums 中的所有整数 互不相同 
// 
//
// Related Topics 数组 回溯 👍 3103 👎 0

namespace Permutations;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public IList<IList<int>> Permute(int[] nums)
    {
        var size = 1;
        for (var i = 1; i <= nums.Length; i++) {
            size *= i;
        }
        var result = new List<IList<int>>(size);

        for (var i = 0; i < size; i++) {
            result.Add(Next());
        }
        return result;

        int[] Next()
        {
            int start;
            for (start = nums.Length - 2; start >= 0 && nums[start] >= nums[start + 1]; start--) ;

            if (start == -1) {
                Array.Reverse(nums);
                return nums.ToArray();
            }

            Array.Reverse(nums, start + 1, nums.Length - start - 1);
            // var minGtIndex = 0;
            // for (var i = start + 1; i < nums.Length; i++)
            //     if (nums[i] > nums[start]) {
            //         minGtIndex = i;
            //         break;
            //     }

            var minGtIndex = GetMinGtIndex(start + 1, nums.Length - 1, nums[start]);

            (nums[start], nums[minGtIndex]) = (nums[minGtIndex], nums[start]);
            return nums.ToArray();
        }

        int GetMinGtIndex(int start, int end, int target)
        {
            // assert minGtIndex exists 
            while (start < end) {
                var mid = (start + end) / 2;
                if (nums[mid] <= target) start = mid + 1;
                else end = mid;
            }

            // start == end
            return start;
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
