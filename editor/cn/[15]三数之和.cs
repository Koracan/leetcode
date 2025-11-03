//给你一个整数数组 nums ，判断是否存在三元组 [nums[i], nums[j], nums[k]] 满足 i != j、i != k 且 j != 
//k ，同时还满足 nums[i] + nums[j] + nums[k] == 0 。请你返回所有和为 0 且不重复的三元组。 
//
// 注意：答案中不可以包含重复的三元组。 
//
// 
//
// 
//
// 示例 1： 
//
// 
//输入：nums = [-1,0,1,2,-1,-4]
//输出：[[-1,-1,2],[-1,0,1]]
//解释：
//nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0 。
//nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0 。
//nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0 。
//不同的三元组是 [-1,0,1] 和 [-1,-1,2] 。
//注意，输出的顺序和三元组的顺序并不重要。
// 
//
// 示例 2： 
//
// 
//输入：nums = [0,1,1]
//输出：[]
//解释：唯一可能的三元组和不为 0 。
// 
//
// 示例 3： 
//
// 
//输入：nums = [0,0,0]
//输出：[[0,0,0]]
//解释：唯一可能的三元组和为 0 。
// 
//
// 
//
// 提示： 
//
// 
// 3 <= nums.length <= 3000 
// -10⁵ <= nums[i] <= 10⁵ 
// 
//
// Related Topics 数组 双指针 排序 👍 7451 👎 0

namespace ThreeSum;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);

        var result = new List<IList<int>>();

        // int l = 0, r = nums.Length - 1;
        // int a = nums[l], b = nums[r];
        //
        // while (r >= 2)
        // {
        //     while (r - l >= 2)
        //     {
        //         if (search(nums, l + 1, r - 1, -(a + b)))
        //         {
        //             result.Add([a, -(a + b), b]);
        //         }
        //
        //         do
        //         {
        //             do
        //             {
        //                 l++;
        //             } while (r - l >= 2 && nums[l] == a);
        //
        //             a = nums[l];
        //         } while (r - l >= 2 && -(a + b) > b);
        //     }
        //
        //     l = 0;
        //     a = nums[l];
        //
        //
        //     do
        //     {
        //         do
        //         {
        //             r--;
        //         } while (r >= 2 && nums[r] == b);
        //
        //         b = nums[r];
        //     } while (r >= 2 && -(a + b) < a);
        // }
        int i = 0, j = 1, k = nums.Length - 1;
        while (i < nums.Length - 2) {
            while (j < k) {
                var sum = nums[i] + nums[j] + nums[k];
                switch (sum) {
                    case 0:
                        result.Add([nums[i], nums[j], nums[k]]);
                        do { k--; } while (k > j && nums[k] == nums[k + 1]);

                        do { j++; } while (j < k && nums[j] == nums[j - 1]);

                        break;
                    case > 0:
                        do { k--; } while (k > j && nums[k] == nums[k + 1]);

                        break;
                    case < 0:
                        do { j++; } while (j < k && nums[j] == nums[j - 1]);

                        break;
                }
            }

            do { i++; } while (i < nums.Length - 2 && nums[i] == nums[i - 1]);

            j = i + 1;
            k = nums.Length - 1;
        }

        return result;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
