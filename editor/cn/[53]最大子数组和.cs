//给你一个整数数组 nums ，请你找出一个具有最大和的连续子数组（子数组最少包含一个元素），返回其最大和。 
//
// 子数组 是数组中的一个连续部分。 
//
// 
//
// 示例 1： 
//
// 
//输入：nums = [-2,1,-3,4,-1,2,1,-5,4]
//输出：6
//解释：连续子数组 [4,-1,2,1] 的和最大，为 6 。
// 
//
// 示例 2： 
//
// 
//输入：nums = [1]
//输出：1
// 
//
// 示例 3： 
//
// 
//输入：nums = [5,4,-1,7,8]
//输出：23
// 
//
// 
//
// 提示： 
//
// 
// 1 <= nums.length <= 10⁵ 
// -10⁴ <= nums[i] <= 10⁴ 
// 
//
// 
//
// 进阶：如果你已经实现复杂度为 O(n) 的解法，尝试使用更为精妙的 分治法 求解。 
//
// Related Topics 数组 分治 动态规划 👍 7022 👎 0

namespace MaximumSubarray;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        // var dp = new int[nums.Length]; // the maximum sum of subarray ending at i
        // dp[0] = nums[0];
        var current = nums[0];
        var max = current;
        for (var i = 1; i < nums.Length; i++) {
            current = nums[i] + Math.Max(current, 0);
            if (current > max) max = current;
        }

        return max;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
