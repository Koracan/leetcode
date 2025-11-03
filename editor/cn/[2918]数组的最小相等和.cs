//给你两个由正整数和 0 组成的数组 nums1 和 nums2 。 
//
// 你必须将两个数组中的 所有 0 替换为 严格 正整数，并且满足两个数组中所有元素的和 相等 。 
//
// 返回 最小 相等和 ，如果无法使两数组相等，则返回 -1 。 
//
// 
//
// 示例 1： 
//
// 
//输入：nums1 = [3,2,0,1,0], nums2 = [6,5,0]
//输出：12
//解释：可以按下述方式替换数组中的 0 ：
//- 用 2 和 4 替换 nums1 中的两个 0 。得到 nums1 = [3,2,2,1,4] 。
//- 用 1 替换 nums2 中的一个 0 。得到 nums2 = [6,5,1] 。
//两个数组的元素和相等，都等于 12 。可以证明这是可以获得的最小相等和。
// 
//
// 示例 2： 
//
// 
//输入：nums1 = [2,0,2,0], nums2 = [1,4]
//输出：-1
//解释：无法使两个数组的和相等。
// 
//
// 
//
// 提示： 
//
// 
// 1 <= nums1.length, nums2.length <= 10⁵ 
// 0 <= nums1[i], nums2[i] <= 10⁶ 
// 
//
// Related Topics 贪心 数组 👍 22 👎 0

namespace MinimumEqualSumOfTwoArraysAfterReplacingZeros;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public long MinSum(int[] nums1, int[] nums2)
    {
        long sum1 = 0, sum2 = 0;
        long count1 = 0, count2 = 0;
        foreach (var i in nums1) {
            sum1 += i;
            if (i == 0) {
                sum1++;
                count1++;
            }
        }

        foreach (var i in nums2) {
            sum2 += i;
            if (i == 0) {
                sum2++;
                count2++;
            }
        }

        if (count1 == 0 && sum2 > sum1 || count2 == 0 && sum1 > sum2) return -1;

        return Math.Max(sum1, sum2);
    }
}
//leetcode submit region end(Prohibit modification and deletion)
