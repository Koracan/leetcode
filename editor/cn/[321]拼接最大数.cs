//给你两个整数数组 nums1 和 nums2，它们的长度分别为 m 和 n。数组 nums1 和 nums2 分别代表两个数各位上的数字。同时你也会得到一个
//整数 k。 
//
// 请你利用这两个数组中的数字创建一个长度为 k <= m + n 的最大数。同一数组中数字的相对顺序必须保持不变。 
//
// 返回代表答案的长度为 k 的数组。 
//
// 
//
// 示例 1： 
//
// 
//输入：nums1 = [3,4,6,5], nums2 = [9,1,2,5,8,3], k = 5
//输出：[9,8,6,5,3]
// 
//
// 示例 2： 
//
// 
//输入：nums1 = [6,7], nums2 = [6,0,4], k = 5
//输出：[6,7,6,0,4]
// 
//
// 示例 3： 
//
// 
//输入：nums1 = [3,9], nums2 = [8,9], k = 3
//输出：[9,8,9]
// 
//
// 
//
// 提示： 
//
// 
// m == nums1.length 
// n == nums2.length 
// 1 <= m, n <= 500 
// 0 <= nums1[i], nums2[i] <= 9 
// 1 <= k <= m + n 
// nums1 和 nums2 没有前导 0。 
// 
//
// Related Topics 栈 贪心 数组 双指针 单调栈 👍 623 👎 0

namespace CreateMaximumNumber;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int[] MaxNumber(int[] nums1, int[] nums2, int k)
    {
        var result = new int[k];
        for (var i = Math.Max(0, k - nums2.Length); i <= Math.Min(k, nums1.Length); i++) {
            var subseq1 = MaxSubseq(nums1, i);
            var subseq2 = MaxSubseq(nums2, k - i);
            var merged = Merge(subseq1, subseq2);
            if (Greater(merged, 0, result, 0)) result = merged;
        }

        return result;

        int[] MaxSubseq(int[] nums, int len)
        {
            var n = nums.Length;
            var stack = new int[len];
            var top = -1;
            var canSkip = n - len; // 还可以删除的数字个数
            for (var i = 0; i < n; i++) {
                var num = nums[i];
                while (top >= 0 && stack[top] < num && canSkip > 0) {
                    top--;
                    canSkip--;
                }

                if (top < len - 1)
                    stack[++top] = num;
                else
                    canSkip--;
            }
            return stack;
        }

        int[] Merge(int[] seq1, int[] seq2)
        {
            var merged = new int[k];
            int i = 0, j = 0, r = 0;
            while (r < k)
                if (Greater(seq1, i, seq2, j))
                    merged[r++] = seq1[i++];
                else
                    merged[r++] = seq2[j++];

            return merged;
        }

        bool Greater(int[] seq1, int start1, int[] seq2, int start2)
        {
            int len1 = seq1.Length, len2 = seq2.Length;
            while (start1 < len1 && start2 < len2 && seq1[start1] == seq2[start2]) {
                start1++;
                start2++;
            }
            return start2 == len2 || start1 < len1 && seq1[start1] > seq2[start2];
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
