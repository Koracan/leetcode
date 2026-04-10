//给定两个大小分别为 m 和 n 的正序（从小到大）数组 nums1 和 nums2。请你找出并返回这两个正序数组的 中位数 。 
//
// 算法的时间复杂度应该为 O(log (m+n)) 。 
//
// 
//
// 示例 1： 
//
// 
//输入：nums1 = [1,3], nums2 = [2]
//输出：2.00000
//解释：合并数组 = [1,2,3] ，中位数 2
// 
//
// 示例 2： 
//
// 
//输入：nums1 = [1,2], nums2 = [3,4]
//输出：2.50000
//解释：合并数组 = [1,2,3,4] ，中位数 (2 + 3) / 2 = 2.5
// 
//
// 
//
// 
//
// 提示： 
//
// 
// nums1.length == m 
// nums2.length == n 
// 0 <= m <= 1000 
// 0 <= n <= 1000 
// 1 <= m + n <= 2000 
// -10⁶ <= nums1[i], nums2[i] <= 10⁶ 
// 
//
// Related Topics 数组 二分查找 分治 👍 7939 👎 0

namespace MedianOfTwoSortedArrays;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        if (nums1.Length > nums2.Length) (nums1, nums2) = (nums2, nums1);

        var m = nums1.Length;
        var n = nums2.Length;
        int lo = 0, hi = m;
        int med1 = 0, med2 = 0;
        while (lo <= hi) {
            var i = (lo + hi) / 2;
            var j = (m + n + 1) / 2 - i;

            var firstLast = i == 0 ? int.MinValue : nums1[i - 1];
            var firstHere = i == m ? int.MaxValue : nums1[i];
            var secondLast = j == 0 ? int.MinValue : nums2[j - 1];
            var secondHere = j == n ? int.MaxValue : nums2[j];

            if (firstLast < secondHere) {
                med1 = Math.Max(firstLast, secondLast);
                med2 = Math.Min(firstHere, secondHere);
                lo = i + 1;
            } else {
                hi = i - 1;
            }
        }

        return (m + n) % 2 == 0 ? (med1 + med2) / 2.0 : med1;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
