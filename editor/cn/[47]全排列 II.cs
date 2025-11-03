//给定一个可包含重复数字的序列 nums ，按任意顺序 返回所有不重复的全排列。 
//
// 
//
// 示例 1： 
//
// 
//输入：nums = [1,1,2]
//输出：
//[[1,1,2],
// [1,2,1],
// [2,1,1]]
// 
//
// 示例 2： 
//
// 
//输入：nums = [1,2,3]
//输出：[[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
// 
//
// 
//
// 提示： 
//
// 
// 1 <= nums.length <= 8 
// -10 <= nums[i] <= 10 
// 
//
// Related Topics 数组 回溯 排序 👍 1711 👎 0

namespace PermutationsIi;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        Array.Sort(nums);

        var result = new List<IList<int>>();
        do {
            result.Add(nums.ToArray());
        } while (Next());

        return result;

        bool Next()
        {
            int start;
            for (start = nums.Length - 2; start >= 0 && nums[start] >= nums[start + 1]; start--) ;

            if (start == -1) {
                Array.Reverse(nums);
                return false;
            }

            Array.Reverse(nums, start + 1, nums.Length - start - 1);
            var minGtIndex = GetMinGtIndex(start + 1, nums.Length - 1, nums[start]);

            // for (var i = start + 1; i < nums.Length; i++)
            //     if (nums[i] > nums[start]) {
            //         minGtIndex = i;
            //         break;
            //     }


            (nums[start], nums[minGtIndex]) = (nums[minGtIndex], nums[start]);
            return true;
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
