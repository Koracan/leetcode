//给你一个数组 points ，其中 points[i] = [xi, yi] 表示 X-Y 平面上的一个点。求最多有多少个点在同一条直线上。 
//
// 
//
// 示例 1： 
// 
// 
//输入：points = [[1,1],[2,2],[3,3]]
//输出：3
// 
//
// 示例 2： 
// 
// 
//输入：points = [[1,1],[3,2],[5,3],[4,1],[2,3],[1,4]]
//输出：4
// 
//
// 
//
// 提示： 
//
// 
// 1 <= points.length <= 300 
// points[i].length == 2 
// -10⁴ <= xi, yi <= 10⁴ 
// points 中的所有点 互不相同 
// 
//
// Related Topics 几何 数组 哈希表 数学 👍 611 👎 0

namespace MaxPointsOnALine;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int MaxPoints(int[][] points)
    {
        int n = points.Length;
        if (n <= 2) return n;
        int max = 0;
        var dict = new Dictionary<(int, int), int>();
        for (int i = 0; i < n; i++) {
            dict.Clear();

            for (int j = 0; j < n; j++) {
                if (i == j) continue;
                int dx = points[j][0] - points[i][0];
                int dy = points[j][1] - points[i][1];
                if (dx == 0) dy = 1; // 垂直线
                else if (dy == 0) dx = 1; // 水平线
                else {
                    if (dy < 0) {
                        dx = -dx;
                        dy = -dy;
                    }
                    // 内联gcd
                    int a = Math.Abs(dx), b = Math.Abs(dy);
                    while (b != 0) {
                        int t = b;
                        b = a % b;
                        a = t;
                    }
                    int g = Math.Abs(a);
                    dx /= g;
                    dy /= g;
                }
                var key = (dx, dy);
                dict.TryAdd(key, 0);
                dict[key]++;
                if (dict[key] > max) max = dict[key];
            }
        }

        return max + 1;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
