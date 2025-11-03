//给定 n 个非负整数表示每个宽度为 1 的柱子的高度图，计算按此排列的柱子，下雨之后能接多少雨水。 
//
// 
//
// 示例 1： 
//
// 
//
// 
//输入：height = [0,1,0,2,1,0,1,3,2,1,2,1]
//输出：6
//解释：上面是由数组 [0,1,0,2,1,0,1,3,2,1,2,1] 表示的高度图，在这种情况下，可以接 6 个单位的雨水（蓝色部分表示雨水）。 
// 
//
// 示例 2： 
//
// 
//输入：height = [4,2,0,3,2,5]
//输出：9
// 
//
// 
//
// 提示： 
//
// 
// n == height.length 
// 1 <= n <= 2 * 10⁴ 
// 0 <= height[i] <= 10⁵ 
// 
//
// Related Topics 栈 数组 双指针 动态规划 单调栈 👍 5693 👎 0

namespace TrappingRainWater;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int Trap(int[] height)
    {
        // var stack = new Stack<int>();
        // var result = 0;
        // for (var i = 0; i < height.Length; i++) {
        //     if (stack.Count == 0) {
        //         stack.Push(i);
        //         continue;
        //     }
        //
        //     int level;
        //     while (stack.Count > 1 && (level = height[stack.Peek()]) <= height[i]) {
        //         stack.Pop();
        //         var left = stack.Peek();
        //         result += (Math.Min(height[left], height[i]) - level) * (i - left - 1);
        //     }
        //
        //
        //     if (height[stack.Peek()] <= height[i]) stack.Pop();
        //
        //     stack.Push(i);
        // }
        //
        // return result;

        var leftMaxes = new int[height.Length];
        var rightMaxes = new int[height.Length];

        var leftMax = 0;
        for (var i = 0; i < height.Length; i++) {
            if (height[i] > leftMax) leftMax = height[i];

            leftMaxes[i] = leftMax;
        }

        var rightMax = 0;
        for (var i = height.Length - 1; i >= 0; i--) {
            if (height[i] > rightMax) rightMax = height[i];

            rightMaxes[i] = rightMax;
        }


        var result = 0;

        for (var i = 0; i < height.Length; i++) result += Math.Min(leftMaxes[i], rightMaxes[i]) - height[i];

        return result;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
