//给定一个由非重叠的轴对齐矩形的数组 rects ，其中 rects[i] = [ai, bi, xi, yi] 表示 (ai, bi) 是第 i 个矩形的左
//下角点，(xi, yi) 是第 i 个矩形的右上角点。设计一个算法来随机挑选一个被某一矩形覆盖的整数点。矩形周长上的点也算做是被矩形覆盖。所有满足要求的点必须等
//概率被返回。 
//
// 在给定的矩形覆盖的空间内的任何整数点都有可能被返回。 
//
// 请注意 ，整数点是具有整数坐标的点。 
//
// 实现 Solution 类: 
//
// 
// Solution(int[][] rects) 用给定的矩形数组 rects 初始化对象。 
// int[] pick() 返回一个随机的整数点 [u, v] 在给定的矩形所覆盖的空间内。 
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
//
// 
//输入: 
//["Solution", "pick", "pick", "pick", "pick", "pick"]
//[[[[-2, -2, 1, 1], [2, 2, 4, 6]]], [], [], [], [], []]
//输出: 
//[null, [1, -2], [1, -1], [-1, -2], [-2, -2], [0, 0]]
//
//解释：
//Solution solution = new Solution([[-2, -2, 1, 1], [2, 2, 4, 6]]);
//solution.pick(); // 返回 [1, -2]
//solution.pick(); // 返回 [1, -1]
//solution.pick(); // 返回 [-1, -2]
//solution.pick(); // 返回 [-2, -2]
//solution.pick(); // 返回 [0, 0] 
//
// 
//
// 提示： 
//
// 
// 1 <= rects.length <= 100 
// rects[i].length == 4 
// -10⁹ <= ai < xi <= 10⁹ 
// -10⁹ <= bi < yi <= 10⁹ 
// xi - ai <= 2000 
// yi - bi <= 2000 
// 所有的矩形不重叠。 
// pick 最多被调用 10⁴ 次。 
// 
//
// Related Topics 水塘抽样 数组 数学 二分查找 有序集合 前缀和 随机化 👍 158 👎 0

namespace RandomPointInNonOverlappingRectangles;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    private readonly int[][] _rects;
    private readonly Random _rand = Random.Shared;
    private readonly int[] _areas; // 前缀和数组，_areas[i] 是前 i 个矩形的面积之和
    public Solution(int[][] rects)
    {
        _rects = rects;
        var n = rects.Length;
        _areas = new int[n];
        for (int i = 0; i < n; i++) {
            var dx = rects[i][2] - rects[i][0] + 1;
            var dy = rects[i][3] - rects[i][1] + 1;
            _areas[i] = dx * dy;
        }
        for (int i = 1; i < n; i++) {
            _areas[i] += _areas[i - 1];
        }
    }

    public int[] Pick()
    {
        var target = _rand.Next(_areas[^1]);
        var index = Array.BinarySearch(_areas, target);
        if (index < 0) {
            index = ~index;
        } else {
            // 精确匹配时，该点实际属于下一个矩形
            index++;
        }
        var rect = _rects[index];
        var dx = rect[2] - rect[0] + 1;
        var offset = target - (index == 0 ? 0 : _areas[index - 1]);
        return [rect[0] + offset % dx, rect[1] + offset / dx];
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(rects);
 * int[] param_1 = obj.Pick();
 */
//leetcode submit region end(Prohibit modification and deletion)
