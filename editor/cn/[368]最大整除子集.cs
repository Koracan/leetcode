//给你一个由 无重复 正整数组成的集合 nums ，请你找出并返回其中最大的整除子集 answer ，子集中每一元素对 (answer[i], answer[
//j]) 都应当满足：
//
// 
// answer[i] % answer[j] == 0 ，或 
// answer[j] % answer[i] == 0 
// 
//
// 如果存在多个有效解子集，返回其中任何一个均可。 
//
// 
//
// 示例 1： 
//
// 
//输入：nums = [1,2,3]
//输出：[1,2]
//解释：[1,3] 也会被视为正确答案。
// 
//
// 示例 2： 
//
// 
//输入：nums = [1,2,4,8]
//输出：[1,2,4,8]
// 
//
// 
//
// 提示： 
//
// 
// 1 <= nums.length <= 1000 
// 1 <= nums[i] <= 2 * 10⁹ 
// nums 中的所有整数 互不相同 
// 
//
// Related Topics 数组 数学 动态规划 排序 👍 645 👎 0

namespace LargestDivisibleSubset;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public IList<int> LargestDivisibleSubset(int[] nums)
    {
        Array.Sort(nums);
        int n = nums.Length;
        int[] dp = new int[n]; // dp[i] 表示以 nums[i] 结尾的最大整除子集的大小
        int[] prev = new int[n]; // prev[i] 表示在最大整除子集中，nums[i] 前一个元素的索引
        Array.Fill(dp, 1);
        int maxSize = 1;
        int maxIndex = 0;
        for (int i = 1; i < n; i++) {
            for (int j = 0; j < i; j++)
                if (dp[j] + 1 > dp[i] && nums[i] % nums[j] == 0) {
                    dp[i] = dp[j] + 1;
                    prev[i] = j;
                }

            if (dp[i] > maxSize) {
                maxSize = dp[i];
                maxIndex = i;
            }
        }
        var result = new int[maxSize];
        for (int i = maxSize - 1; i >= 0; i--, maxIndex = prev[maxIndex])
            result[i] = nums[maxIndex];

        return result;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
