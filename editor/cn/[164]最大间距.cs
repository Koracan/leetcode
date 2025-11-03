//给定一个无序的数组 nums，返回 数组在排序之后，相邻元素之间最大的差值 。如果数组元素个数小于 2，则返回 0 。 
//
// 您必须编写一个在「线性时间」内运行并使用「线性额外空间」的算法。 
//
// 
//
// 示例 1: 
//
// 
//输入: nums = [3,6,9,1]
//输出: 3
//解释: 排序后的数组是 [1,3,6,9], 其中相邻元素 (3,6) 和 (6,9) 之间都存在最大差值 3。 
//
// 示例 2: 
//
// 
//输入: nums = [10]
//输出: 0
//解释: 数组元素个数小于 2，因此返回 0。 
//
// 
//
// 提示: 
//
// 
// 1 <= nums.length <= 10⁵ 
// 0 <= nums[i] <= 10⁹ 
// 
//
// Related Topics 数组 桶排序 基数排序 排序 👍 653 👎 0

namespace MaximumGap;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int MaximumGap(int[] nums)
    {
        if (nums.Length == 0) return 0;

        var min = nums.Min();
        var max = nums.Max();
        if (min == max) return 0;
        var n = nums.Length;
        var bucketSize = Math.Max(1, (max - min) / (n - 1));
        var bucketCount = (max - min) / bucketSize + 1;
        var buckets = new (int min, int max)?[bucketCount];
        foreach (var num in nums) {
            var index = (num - min) / bucketSize;
            if (buckets[index] == null) 
                buckets[index] = (num, num);
            else {
                var (bMin, bMax) = buckets[index]!.Value;
                buckets[index] = (Math.Min(bMin, num), Math.Max(bMax, num));
            }
        }

        var prevMax = min;
        var maxGap = 0;
        foreach (var bucket in buckets) {
            if (bucket == null) continue;
            var (bMin, bMax) = bucket.Value;
            maxGap = Math.Max(maxGap, bMin - prevMax);
            prevMax = bMax;
        }

        return maxGap;
    }
}

//leetcode submit region end(Prohibit modification and deletion)
