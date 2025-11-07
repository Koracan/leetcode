//给你一个整数数组 nums ，找到其中最长严格递增子序列的长度。 
//
// 子序列 是由数组派生而来的序列，删除（或不删除）数组中的元素而不改变其余元素的顺序。例如，[3,6,2,7] 是数组 [0,3,1,6,2,2,7] 的子
//序列。 
//
// 示例 1： 
//
// 
//输入：nums = [10,9,2,5,3,7,101,18]
//输出：4
//解释：最长递增子序列是 [2,3,7,101]，因此长度为 4 。
// 
//
// 示例 2： 
//
// 
//输入：nums = [0,1,0,3,2,3]
//输出：4
// 
//
// 示例 3： 
//
// 
//输入：nums = [7,7,7,7,7,7,7]
//输出：1
// 
//
// 
//
// 提示： 
//
// 
// 1 <= nums.length <= 2500 
// -10⁴ <= nums[i] <= 10⁴ 
// 
//
// 
//
// 进阶： 
//
// 
// 你能将算法的时间复杂度降低到 O(n log(n)) 吗? 
// 
//
// Related Topics 数组 二分查找 动态规划 👍 4105 👎 0

namespace LongestIncreasingSubsequence;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int LengthOfLIS(int[] nums)
    {
        var subSeq = new List<int>(nums.Length) {
            nums[0]
        };
        foreach (var num in nums)
            if (num > subSeq[^1])
                subSeq.Add(num);
            else
                subSeq[BinarySearch(num)] = num;

        return subSeq.Count;

        int BinarySearch(int e)
        {
            int lo = 0, hi = subSeq.Count;
            while (lo < hi) {
                int mid = lo + (hi - lo) / 2;
                if (e <= subSeq[mid])
                    hi = mid;
                else
                    lo = mid + 1;
            }

            return lo;
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
