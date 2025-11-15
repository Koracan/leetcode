//给你一个整数数组 nums ，判断这个数组中是否存在长度为 3 的递增子序列。 
//
// 如果存在这样的三元组下标 (i, j, k) 且满足 i < j < k ，使得 nums[i] < nums[j] < nums[k] ，返回 
//true ；否则，返回 false 。 
//
// 
//
// 示例 1： 
//
// 
//输入：nums = [1,2,3,4,5]
//输出：true
//解释：任何 i < j < k 的三元组都满足题意
// 
//
// 示例 2： 
//
// 
//输入：nums = [5,4,3,2,1]
//输出：false
//解释：不存在满足题意的三元组 
//
// 示例 3： 
//
// 
//输入：nums = [2,1,5,0,4,6]
//输出：true
//解释：其中一个满足题意的三元组是 (3, 4, 5)，因为 nums[3] == 0 < nums[4] == 4 < nums[5] == 6
// 
//
// 
//
// 提示： 
//
// 
// 1 <= nums.length <= 5 * 10⁵ 
// -2³¹ <= nums[i] <= 2³¹ - 1 
// 
//
// 
//
// 进阶：你能实现时间复杂度为 O(n) ，空间复杂度为 O(1) 的解决方案吗？ 
//
// Related Topics 贪心 数组 👍 903 👎 0

namespace IncreasingTripletSubsequence;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public bool IncreasingTriplet(int[] nums)
    {
        var min = int.MaxValue;
        var mid = int.MaxValue;
        foreach (var num in nums)
            if (num <= min)
                // 虽然 min 可能不是最终结果的第一个数，但更新 min 是安全的：分为三种情况
                // 1. 之后有一步更新 mid，又找到了比 mid 更大的数，此时 min 正是结果的第一个数
                // 2. 之后没有更新 mid，但找到了比 mid 更大的数，此时 min 不是结果的第一个数，但是 old_min < mid < 该数，结果依然成立
                // 3. 之后没有找到比 mid 更大的数，此时结果不存在，min 的值无关紧要
                min = num;
            else if (num <= mid)
                mid = num;
            else
                return true;


        return false;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
