//给定一个包含非负整数的数组 nums ，返回其中可以组成三角形三条边的三元组个数。 
//
// 
//
// 示例 1: 
//
// 
//输入: nums = [2,2,3,4]
//输出: 3
//解释:有效的组合是: 
//2,3,4 (使用第一个 2)
//2,3,4 (使用第二个 2)
//2,2,3
// 
//
// 示例 2: 
//
// 
//输入: nums = [4,2,3,4]
//输出: 4 
//
// 
//
// 提示: 
//
// 
// 1 <= nums.length <= 1000 
// 0 <= nums[i] <= 1000 
// 
//
// Related Topics 贪心 数组 双指针 二分查找 排序 👍 666 👎 0

namespace ValidTriangleNumber;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int TriangleNumber(int[] nums)
    {
        Array.Sort(nums);
        int n = nums.Length, res = 0;
        for (var k = n - 1; k >= 2; k--) {
            if (nums[k] == 0) continue;
            int i = 0, j = k - 1;
            while (i < j)
                if (nums[i] + nums[j] > nums[k]) {
                    res += j - i;
                    j--;
                } else 
                    i++;
        }
        return res;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
