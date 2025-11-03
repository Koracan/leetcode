//给你一个长度为 n 的整数数组 nums 和 一个目标值 target。请你从 nums 中选出三个整数，使它们的和与 target 最接近。 
//
// 返回这三个数的和。 
//
// 假定每组输入只存在恰好一个解。 
//
// 
//
// 示例 1： 
//
// 
//输入：nums = [-1,2,1,-4], target = 1
//输出：2
//解释：与 target 最接近的和是 2 (-1 + 2 + 1 = 2)。
// 
//
// 示例 2： 
//
// 
//输入：nums = [0,0,0], target = 1
//输出：0
//解释：与 target 最接近的和是 0（0 + 0 + 0 = 0）。 
//
// 
//
// 提示： 
//
// 
// 3 <= nums.length <= 1000 
// -1000 <= nums[i] <= 1000 
// -10⁴ <= target <= 10⁴ 
// 
//
// Related Topics 数组 双指针 排序 👍 1725 👎 0

namespace ThreeSumClosest;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int ThreeSumClosest(int[] nums, int target)
    {
        Array.Sort(nums);

        int i = 0, j = 1, k = nums.Length - 1;
        var closestSum = nums[0] + nums[1] + nums[2];
        while (i < nums.Length - 2) {
            while (j < k) {
                var sum = nums[i] + nums[j] + nums[k];
                if (Math.Abs(sum - target) < Math.Abs(closestSum - target)) closestSum = sum;

                switch (sum - target) {
                    case 0: return sum;
                    case > 0: k--; break;
                    case < 0: j++; break;
                }
            }

            i++;
            j = i + 1;
            k = nums.Length - 1;
        }

        return closestSum;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
