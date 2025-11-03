//已知存在一个按非降序排列的整数数组 nums ，数组中的值不必互不相同。 
//
// 在传递给函数之前，nums 在预先未知的某个下标 k（0 <= k < nums.length）上进行了 旋转 ，使数组变为 [nums[k], 
//nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]]（下标 从 0 开始 计数）。例如， [0,1,
//2,4,4,4,5,6,6,7] 在下标 5 处经旋转后可能变为 [4,5,6,6,7,0,1,2,4,4] 。 
//
// 给你 旋转后 的数组 nums 和一个整数 target ，请你编写一个函数来判断给定的目标值是否存在于数组中。如果 nums 中存在这个目标值 
//target ，则返回 true ，否则返回 false 。 
//
// 你必须尽可能减少整个操作步骤。 
//
// 
//
// 示例 1： 
//
// 
//输入：nums = [2,5,6,0,0,1,2], target = 0
//输出：true
// 
//
// 示例 2： 
//
// 
//输入：nums = [2,5,6,0,0,1,2], target = 3
//输出：false 
//
// 
//
// 提示： 
//
// 
// 1 <= nums.length <= 5000 
// -10⁴ <= nums[i] <= 10⁴ 
// 题目数据保证 nums 在预先未知的某个下标上进行了旋转 
// -10⁴ <= target <= 10⁴ 
// 
//
// 
//
// 进阶： 
//
// 
// 此题与 搜索旋转排序数组 相似，但本题中的 nums 可能包含 重复 元素。这会影响到程序的时间复杂度吗？会有怎样的影响，为什么？ 
// 
//
// 
//
// Related Topics 数组 二分查找 👍 840 👎 0

namespace SearchInRotatedSortedArrayIi;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public bool Search(int[] nums, int target)
    {
        int start = 0, end = nums.Length - 1;

        while (true) {
            if (start > end) return false;

            var mid = (start + end) / 2;
            if (nums[mid] == target) return true;

            if (nums[start] < nums[mid]) // 下降点在 mid 后
            {
                if (nums[start] <= target && target < nums[mid]) end = mid - 1;
                else start = mid + 1;

                continue;
            }

            if (nums[start] == nums[mid]) {
                // 下降点可能在 mid 后, 也可能在 mid 前, 直接遍历
                for (var i = start; i <= end; i++)
                    if (target == nums[i])
                        return true;

                return false;
            }

            // 否则 nums[start] > nums[mid], 下降点在 mid 前
            if (nums[mid] < target && target <= nums[end]) start = mid + 1;
            else end = mid - 1;
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
