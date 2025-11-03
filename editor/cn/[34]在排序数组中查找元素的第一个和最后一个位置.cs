//给你一个按照非递减顺序排列的整数数组 nums，和一个目标值 target。请你找出给定目标值在数组中的开始位置和结束位置。 
//
// 如果数组中不存在目标值 target，返回 [-1, -1]。 
//
// 你必须设计并实现时间复杂度为 O(log n) 的算法解决此问题。 
//
// 
//
// 示例 1： 
//
// 
//输入：nums = [5,7,7,8,8,10], target = 8
//输出：[3,4] 
//
// 示例 2： 
//
// 
//输入：nums = [5,7,7,8,8,10], target = 6
//输出：[-1,-1] 
//
// 示例 3： 
//
// 
//输入：nums = [], target = 0
//输出：[-1,-1] 
//
// 
//
// 提示： 
//
// 
// 0 <= nums.length <= 10⁵ 
// -10⁹ <= nums[i] <= 10⁹ 
// nums 是一个非递减数组 
// -10⁹ <= target <= 10⁹ 
// 
//
// Related Topics 数组 二分查找 👍 3005 👎 0

namespace FindFirstAndLastPositionOfElementInSortedArray;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int[] SearchRange(int[] nums, int target)
    {
        int start = 0, end = nums.Length - 1;
        var goal = -1;
        while (true) {
            if (start > end) break;
            var mid = (start + end) / 2;

            if (nums[mid] == target) {
                goal = mid;
                break;
            }

            if (target < nums[mid]) end = mid - 1;
            else start = mid + 1;
        }

        if (goal == -1) return [-1, -1];

        int left = goal, right = goal;

        while (left - 1 >= 0 && nums[left - 1] == target) left--;

        while (right + 1 < nums.Length && nums[right + 1] == target) right++;

        return [left, right];
    }
}
//leetcode submit region end(Prohibit modification and deletion)
