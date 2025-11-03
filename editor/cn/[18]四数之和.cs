//给你一个由 n 个整数组成的数组 nums ，和一个目标值 target 。请你找出并返回满足下述全部条件且不重复的四元组 [nums[a], nums[
//b], nums[c], nums[d]] （若两个四元组元素一一对应，则认为两个四元组重复）： 
//
// 
// 0 <= a, b, c, d < n 
// a、b、c 和 d 互不相同 
// nums[a] + nums[b] + nums[c] + nums[d] == target 
// 
//
// 你可以按 任意顺序 返回答案 。 
//
// 
//
// 示例 1： 
//
// 
//输入：nums = [1,0,-1,0,-2,2], target = 0
//输出：[[-2,-1,1,2],[-2,0,0,2],[-1,0,0,1]]
// 
//
// 示例 2： 
//
// 
//输入：nums = [2,2,2,2,2], target = 8
//输出：[[2,2,2,2]]
// 
//
// 
//
// 提示： 
//
// 
// 1 <= nums.length <= 200 
// -10⁹ <= nums[i] <= 10⁹ 
// -10⁹ <= target <= 10⁹ 
// 
//
// Related Topics 数组 双指针 排序 👍 2052 👎 0

namespace FourSum;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        // Array.Sort(nums);
        // var result = new List<IList<int>>();
        // for (int i = 0; i < nums.Length - 3; i++)
        // {
        //     if (i > 0 && nums[i] == nums[i - 1]) continue;
        //
        //     for (int j = i + 1; j < nums.Length - 2; j++)
        //     {
        //         if (j > i + 1 && nums[j] == nums[j - 1]) continue;
        //         int left = j + 1, right = nums.Length - 1;
        //         while (left < right)
        //         {
        //             long sum = (long)nums[i] + nums[j] + nums[left] + nums[right];
        //
        //             switch (sum - target)
        //             {
        //                 case 0:
        //                     result.Add([nums[i], nums[j], nums[left], nums[right]]);
        //                     do
        //                     {
        //                         left++;
        //                     } while (left < right && nums[left - 1] == nums[left]);
        //
        //                     do
        //                     {
        //                         right--;
        //                     } while (left < right && nums[right + 1] == nums[right]);
        //
        //                     break;
        //                 case < 0:
        //                     do
        //                     {
        //                         left++;
        //                     } while (left < right && nums[left - 1] == nums[left]);
        //
        //                     break;
        //                 case > 0:
        //                     do
        //                     {
        //                         right--;
        //                     } while (left < right && nums[right + 1] == nums[right]);
        //
        //                     break;
        //             }
        //         }
        //     }
        // }
        //
        // return result;
        Array.Sort(nums);

        var twoSums = new Dictionary<long, List<(int i1, int i2)>>();

        for (var j = nums.Length - 1; j >= 0; j--) {
            if (j < nums.Length - 1 && nums[j] == nums[j + 1]) continue;
            for (var i = j - 1; i >= 0; i--) {
                if (i < j - 1 && nums[i] == nums[i + 1]) continue;
                var sum = nums[i] + nums[j];
                if (!twoSums.TryGetValue(sum, out var indexes)) {
                    indexes = [];
                    twoSums[sum] = indexes;
                }

                indexes.Add((i, j));
            }
        }

        var result = new List<IList<int>>();

        for (var i = 0; i < nums.Length - 3; i++) {
            if (i > 0 && nums[i] == nums[i - 1]) continue;
            for (var j = i + 1; j < nums.Length - 2; j++) {
                if (j > i + 1 && nums[j] == nums[j - 1]) continue;
                if (twoSums.TryGetValue((long)target - nums[i] - nums[j], out var indexes))
                    foreach (var (i1, i2) in indexes)
                        if (i1 > j)
                            result.Add([nums[i], nums[j], nums[i1], nums[i2]]);
            }
        }

        return result;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
