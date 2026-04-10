//给你一个整数数组 nums。 
//
// 如果满足 nums[i] == nums[j] == nums[k]，且 (i, j, k) 是 3 个 不同 下标，那么三元组 (i, j, k) 被称
//为 有效三元组 。 
//
// 有效三元组 的 距离 被定义为 abs(i - j) + abs(j - k) + abs(k - i)，其中 abs(x) 表示 x 的 绝对值 。 
//
// 返回一个整数，表示 有效三元组 的 最小 可能距离。如果不存在 有效三元组 ，返回 -1。 
//
// 
//
// 示例 1： 
//
// 
// 输入： nums = [1,2,1,1,3] 
// 
//
// 输出： 6 
//
// 解释： 
//
// 最小距离对应的有效三元组是 (0, 2, 3) 。 
//
// (0, 2, 3) 是一个有效三元组，因为 nums[0] == nums[2] == nums[3] == 1。它的距离为 abs(0 - 2) + 
//abs(2 - 3) + abs(3 - 0) = 2 + 1 + 3 = 6。 
//
// 示例 2： 
//
// 
// 输入： nums = [1,1,2,3,2,1,2] 
// 
//
// 输出： 8 
//
// 解释： 
//
// 最小距离对应的有效三元组是 (2, 4, 6) 。 
//
// (2, 4, 6) 是一个有效三元组，因为 nums[2] == nums[4] == nums[6] == 2。它的距离为 abs(2 - 4) + 
//abs(4 - 6) + abs(6 - 2) = 2 + 2 + 4 = 8。 
//
// 示例 3： 
//
// 
// 输入： nums = [1] 
// 
//
// 输出： -1 
//
// 解释： 
//
// 不存在有效三元组，因此答案为 -1。 
//
// 
//
// 提示： 
//
// 
// 1 <= n == nums.length <= 100 
// 1 <= nums[i] <= n 
// 
//
// Related Topics 数组 哈希表 👍 7 👎 0

namespace MinimumDistanceBetweenThreeEqualElementsI;

//leetcode submit region begin(Prohibit modification and deletion)
using Last = (int i1, int i2);

public class Solution
{
    public int MinimumDistance(int[] nums)
    {
        // 三元组距离是三个元中距离最远两者距离的 2 倍，与中间元位置无关
        // 用一个字典保存数字 num 前两次出现的下标

        var n = nums.Length;
        var dict = new Last[n + 1];
        Array.Fill(dict, (-1, -1));
        var minDist = int.MaxValue;
        for (int i = 0; i < n; i++) {
            var num = nums[i];
            if (dict[num].i1 >= 0)
                minDist = Math.Min(minDist, i - dict[num].i1);

            dict[num].i1 = dict[num].i2;
            dict[num].i2 = i;
        }

        return minDist == int.MaxValue ? -1 : minDist * 2;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
