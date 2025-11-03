//给定一个大小为 n 的整数数组，找出其中所有出现超过 ⌊ n/3 ⌋ 次的元素。 
//
// 
//
// 示例 1： 
//
// 
//输入：nums = [3,2,3]
//输出：[3] 
//
// 示例 2： 
//
// 
//输入：nums = [1]
//输出：[1]
// 
//
// 示例 3： 
//
// 
//输入：nums = [1,2]
//输出：[1,2] 
//
// 
//
// 提示： 
//
// 
// 1 <= nums.length <= 5 * 10⁴ 
// -10⁹ <= nums[i] <= 10⁹ 
// 
//
// 
//
// 进阶：尝试设计时间复杂度为 O(n)、空间复杂度为 O(1)的算法解决此问题。 
//
// Related Topics 数组 哈希表 计数 排序 👍 776 👎 0

namespace MajorityElementIi;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public IList<int> MajorityElement(int[] nums)
    {
        if (nums.Length == 1) return [nums[0]];
        var x = nums[0];
        var y = nums[1];
        var voteX = 0;
        var voteY = 0;
        foreach (var num in nums)
            if (num == x) {
                voteX++;
            } else if (num == y) {
                voteY++;
            } else if (voteX == 0) {
                x = num;
                voteX = 1;
            } else if (voteY == 0) {
                y = num;
                voteY = 1;
            } else {
                voteX--;
                voteY--;
            }


        if (voteX == 0 && voteY == 0) return [];

        voteX = voteY = 0;
        foreach (var num in nums)
            if (num == x)
                voteX++;
            else if (num == y)
                voteY++;


        return (voteX - nums.Length / 3, voteY - nums.Length / 3) switch {
            (> 0, > 0) => [x, y],
            (> 0, _) => [x],
            (_, > 0) => [y],
            _ => []
        };
    }
}
//leetcode submit region end(Prohibit modification and deletion)
