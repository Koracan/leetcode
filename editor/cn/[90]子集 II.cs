//给你一个整数数组 nums ，其中可能包含重复元素，请你返回该数组所有可能的 子集（幂集）。 
//
// 解集 不能 包含重复的子集。返回的解集中，子集可以按 任意顺序 排列。 
//
// 
// 
// 
// 
// 
//
// 示例 1： 
//
// 
//输入：nums = [1,2,2]
//输出：[[],[1],[1,2],[1,2,2],[2],[2,2]]
// 
//
// 示例 2： 
//
// 
//输入：nums = [0]
//输出：[[],[0]]
// 
//
// 
//
// 提示： 
//
// 
// 1 <= nums.length <= 10 
// -10 <= nums[i] <= 10 
// 
//
// Related Topics 位运算 数组 回溯 👍 1305 👎 0

namespace SubsetsIi;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        var dict = new Dictionary<int, int>();
        foreach (var num in nums)
            if (!dict.TryAdd(num, 1))
                dict[num]++;


        var total = 1;
        foreach (var count in dict.Values) total *= count + 1;
        var result = new IList<int>[total];

        var buffer = new List<int>();
        for (var i = 0; i < total; i++) {
            buffer.Clear();

            var temp = i;

            foreach (var (num, count) in dict) {
                for (var j = 0; j < temp % (count + 1); j++) buffer.Add(num);
                temp /= count + 1;
                if (temp == 0) break;
            }

            result[i] = buffer.ToArray();
        }

        return result;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
