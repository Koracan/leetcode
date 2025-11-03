//给定 n 个非负整数，用来表示柱状图中各个柱子的高度。每个柱子彼此相邻，且宽度为 1 。 
//
// 求在该柱状图中，能够勾勒出来的矩形的最大面积。 
//
// 
//
// 示例 1: 
//
// 
//
// 
//输入：heights = [2,1,5,6,2,3]
//输出：10
//解释：最大的矩形为图中红色区域，面积为 10
// 
//
// 示例 2： 
//
// 
//
// 
//输入： heights = [2,4]
//输出： 4 
//
// 
//
// 提示： 
//
// 
// 1 <= heights.length <=10⁵ 
// 0 <= heights[i] <= 10⁴ 
// 
//
// Related Topics 栈 数组 单调栈 👍 2921 👎 0

namespace LargestRectangleInHistogram;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int LargestRectangleArea(int[] heights)
    {
        var stack = new Stack<int>();
        var borders = new (int l, int r)[heights.Length];
        for (var i = 0; i < heights.Length; i++) {
            while (stack.Count > 0 && heights[stack.Peek()] >= heights[i]) borders[stack.Pop()].r = i;
            borders[i].l = stack.Count == 0 ? -1 : stack.Peek();
            stack.Push(i);
        }

        while (stack.Count > 0) borders[stack.Pop()].r = heights.Length;

        var maxArea = 0;
        for (var i = 0; i < heights.Length; i++) {
            var area = heights[i] * (borders[i].r - borders[i].l - 1);
            if (area > maxArea) maxArea = area;
        }

        return maxArea;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
