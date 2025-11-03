//给你一个整数数组 nums，有一个大小为 k 的滑动窗口从数组的最左侧移动到数组的最右侧。你只可以看到在滑动窗口内的 k 个数字。滑动窗口每次只向右移动一位
//。 
//
// 返回 滑动窗口中的最大值 。 
//
// 
//
// 示例 1： 
//
// 
//输入：nums = [1,3,-1,-3,5,3,6,7], k = 3
//输出：[3,3,5,5,6,7]
//解释：
//滑动窗口的位置                最大值
//---------------               -----
//[1  3  -1] -3  5  3  6  7       3
// 1 [3  -1  -3] 5  3  6  7       3
// 1  3 [-1  -3  5] 3  6  7       5
// 1  3  -1 [-3  5  3] 6  7       5
// 1  3  -1  -3 [5  3  6] 7       6
// 1  3  -1  -3  5 [3  6  7]      7
// 
//
// 示例 2： 
//
// 
//输入：nums = [1], k = 1
//输出：[1]
// 
//
// 
//
// 提示： 
//
// 
// 1 <= nums.length <= 10⁵ 
// -10⁴ <= nums[i] <= 10⁴ 
// 1 <= k <= nums.length 
// 
//
// Related Topics 队列 数组 滑动窗口 单调队列 堆（优先队列） 👍 3297 👎 0

namespace SlidingWindowMaximum;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        var n = nums.Length;
        var result = new int[n - k + 1];
        var deque = new LinkedList<int>(); // 存储索引，队首为当前最大值索引
        var ri = 0;

        for (var i = 0; i < n; i++) {
            // 移除队首中过期的索引
            if (deque.Count > 0 && deque.First!.Value <= i - k)
                deque.RemoveFirst();

            // 保持单调递减：移除所有比当前值小的索引
            while (deque.Count > 0 && nums[deque.Last!.Value] < nums[i])
                deque.RemoveLast();

            deque.AddLast(i);

            if (i >= k - 1)
                result[ri++] = nums[deque.First!.Value];
        }

        return result;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
