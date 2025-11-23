//给你一个数组 rectangles ，其中 rectangles[i] = [xi, yi, ai, bi] 表示一个坐标轴平行的矩形。这个矩形的左下顶点是
// (xi, yi) ，右上顶点是 (ai, bi) 。 
//
// 如果所有矩形一起精确覆盖了某个矩形区域，则返回 true ；否则，返回 false 。 
//
// 示例 1： 
// 
// 
//输入：rectangles = [[1,1,3,3],[3,1,4,2],[3,2,4,4],[1,3,2,4],[2,3,3,4]]
//输出：true
//解释：5 个矩形一起可以精确地覆盖一个矩形区域。 
// 
//
// 示例 2： 
// 
// 
//输入：rectangles = [[1,1,2,3],[1,3,2,4],[3,1,4,2],[3,2,4,4]]
//输出：false
//解释：两个矩形之间有间隔，无法覆盖成一个矩形。 
//
// 示例 3： 
// 
// 
//输入：rectangles = [[1,1,3,3],[3,1,4,2],[1,3,2,4],[2,2,4,4]]
//输出：false
//解释：因为中间有相交区域，虽然形成了矩形，但不是精确覆盖。 
//
// 
//
// 提示： 
//
// 
// 1 <= rectangles.length <= 2 * 10⁴ 
// rectangles[i].length == 4 
// -10⁵ <= xi < ai <= 10⁵ 
// -10⁵ <= yi < bi <= 10⁵ 
// 
//
// Related Topics 几何 数组 哈希表 数学 扫描线 👍 282 👎 0

namespace PerfectRectangle;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public bool IsRectangleCover(int[][] rectangles)
    {
        var left = int.MaxValue;
        var right = int.MinValue;
        var bottom = int.MaxValue;
        var top = int.MinValue;
        var area = 0;
        var points = new HashSet<(int x, int y)>();
        foreach (var rectangle in rectangles) {
            var x1 = rectangle[0];
            var y1 = rectangle[1];
            var x2 = rectangle[2];
            var y2 = rectangle[3];

            left = Math.Min(left, x1);
            right = Math.Max(right, x2);
            bottom = Math.Min(bottom, y1);
            top = Math.Max(top, y2);

            area += (x2 - x1) * (y2 - y1);

            var p1 = (x1, y1);
            var p2 = (x1, y2);
            var p3 = (x2, y1);
            var p4 = (x2, y2);

            if (!points.Add(p1)) points.Remove(p1);
            if (!points.Add(p2)) points.Remove(p2);
            if (!points.Add(p3)) points.Remove(p3);
            if (!points.Add(p4)) points.Remove(p4);
        }

        return area == (right - left) * (top - bottom)
            && points.Count == 4
            && points.Contains((left, bottom))
            && points.Contains((left, top))
            && points.Contains((right, bottom))
            && points.Contains((right, top));
    }
}
//leetcode submit region end(Prohibit modification and deletion)
