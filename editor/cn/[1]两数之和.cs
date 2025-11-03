//给定一个整数数组 nums 和一个整数目标值 target，请你在该数组中找出 和为目标值 target 的那 两个 整数，并返回它们的数组下标。 
//
// 你可以假设每种输入只会对应一个答案，并且你不能使用两次相同的元素。 
//
// 你可以按任意顺序返回答案。 
//
// 
//
// 示例 1： 
//
// 
//输入：nums = [2,7,11,15], target = 9
//输出：[0,1]
//解释：因为 nums[0] + nums[1] == 9 ，返回 [0, 1] 。
// 
//
// 示例 2： 
//
// 
//输入：nums = [3,2,4], target = 6
//输出：[1,2]
// 
//
// 示例 3： 
//
// 
//输入：nums = [3,3], target = 6
//输出：[0,1]
// 
//
// 
//
// 提示： 
//
// 
// 2 <= nums.length <= 10⁴ 
// -10⁹ <= nums[i] <= 10⁹ 
// -10⁹ <= target <= 10⁹ 
// 只会存在一个有效答案 
// 
//
// 
//
// 进阶：你可以想出一个时间复杂度小于 O(n²) 的算法吗？ 
//
// Related Topics 数组 哈希表 👍 19665 👎 0

namespace TwoSum;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        // var table = new (int num, int index)[nums.Length];
        // for (int i = 0; i < nums.Length; i++)
        // {
        //     table[i] = (nums[i], i);
        // }
        //
        // Array.Sort(table, (a, b) => a.num - b.num);
        // int l = 0, r = table.Length - 1;
        //
        // while (l < r)
        // {
        //     int sum = table[l].num + table[r].num;
        //     switch (sum - target)
        //     {
        //         case 0:
        //             return [table[l].index, table[r].index];
        //         case < 0:
        //             l++;
        //             break;
        //         case > 0:
        //             r--;
        //             break;
        //     }
        // }
        //
        // return [0, 0];

        var table = new Dictionary<int, int>(nums.Length);
        for (var i = 0; i < nums.Length; i++) {
            if (table.TryGetValue(target - nums[i], out var index)) return [index, i];

            table[nums[i]] = i;
        }

        return [-1, -1]; // should never reach here
    }
}
//leetcode submit region end(Prohibit modification and deletion)
