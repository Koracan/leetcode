//给你一个整数数组 nums 以及两个整数 lower 和 upper 。求数组中，值位于范围 [lower, upper] （包含 lower 和 
//upper）之内的 区间和的个数 。 
//
// 区间和 S(i, j) 表示在 nums 中，位置从 i 到 j 的元素之和，包含 i 和 j (i ≤ j)。 
//
// 
//示例 1：
//
// 
//输入：nums = [-2,5,-1], lower = -2, upper = 2
//输出：3
//解释：存在三个区间：[0,0]、[2,2] 和 [0,2] ，对应的区间和分别是：-2 、-1 、2 。
// 
//
// 示例 2： 
//
// 
//输入：nums = [0], lower = 0, upper = 0
//输出：1
// 
//
// 
//
// 提示： 
//
// 
// 1 <= nums.length <= 10⁵ 
// -2³¹ <= nums[i] <= 2³¹ - 1 
// -10⁵ <= lower <= upper <= 10⁵ 
// 题目数据保证答案是一个 32 位 的整数 
// 
//
// Related Topics 树状数组 线段树 数组 二分查找 分治 有序集合 归并排序 👍 613 👎 0

namespace CountOfRangeSum;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int CountRangeSum(int[] nums, int lower, int upper)
    {
        var prefixSums = new long[nums.Length + 1];
        for (var i = 0; i < nums.Length; i++)
            prefixSums[i + 1] = prefixSums[i] + nums[i];

        var count = 0;
        MergeSort(0, prefixSums.Length);
        return count;

        void MergeSort(int lo, int hi) // 左闭右开
        {
            if (hi - lo <= 1) return;
            var mid = (lo + hi) / 2;
            MergeSort(lo, mid);
            MergeSort(mid, hi);


            // CountRange(lo, mid, hi);
            int l = lo, r = lo;
            for (var i = mid; i < hi; i++) {
                var min = prefixSums[i] - upper;
                var max = prefixSums[i] - lower;
                while (l < mid && prefixSums[l] < min) l++;
                while (r < mid && prefixSums[r] <= max) r++;
                count += r - l;
            }

            // Merge(lo, mid, hi);
            var leftLen = mid - lo;
            var temp = new long[leftLen];
            Array.Copy(prefixSums, lo, temp, 0, leftLen);
            int p1 = 0, p2 = mid, k = lo;
            while (p1 < leftLen && p2 < hi)
                if (temp[p1] <= prefixSums[p2])
                    prefixSums[k++] = temp[p1++];
                else
                    prefixSums[k++] = prefixSums[p2++];
            if (p1 < temp.Length)
                Array.Copy(temp, p1, prefixSums, k, temp.Length - p1);
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
