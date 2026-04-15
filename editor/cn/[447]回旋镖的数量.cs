//给定平面上 n 对 互不相同 的点 points ，其中 points[i] = [xi, yi] 。回旋镖 是由点 (i, j, k) 表示的元组 ，其中
// i 和 j 之间的欧式距离和 i 和 k 之间的欧式距离相等（需要考虑元组的顺序）。 
//
// 返回平面上所有回旋镖的数量。 
//
// 示例 1： 
//
// 
//输入：points = [[0,0],[1,0],[2,0]]
//输出：2
//解释：两个回旋镖为 [[1,0],[0,0],[2,0]] 和 [[1,0],[2,0],[0,0]]
// 
//
// 示例 2： 
//
// 
//输入：points = [[1,1],[2,2],[3,3]]
//输出：2
// 
//
// 示例 3： 
//
// 
//输入：points = [[1,1]]
//输出：0
// 
//
// 
//
// 提示： 
//
// 
// n == points.length 
// 1 <= n <= 500 
// points[i].length == 2 
// -10⁴ <= xi, yi <= 10⁴ 
// 所有点都 互不相同 
// 
//
// Related Topics 数组 哈希表 数学 👍 339 👎 0

namespace NumberOfBoomerangs;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int NumberOfBoomerangs(int[][] points)
    {
        var res = 0;
        var dict = new Dictionary<int, int>();
        for (var i = 0; i < points.Length; i++) {
            dict.Clear();
            for (var j = 0; j < points.Length; j++) {
                if (i == j) continue;
                var d = GetDistanceSquare(points[i], points[j]);
                dict.TryAdd(d, 0);
                dict[d]++;
            }

            foreach (var kv in dict)
                res += kv.Value * (kv.Value - 1);
        }

        return res;
    }

    private static int GetDistanceSquare(int[] p1, int[] p2)
    {
        var dx = p1[0] - p2[0];
        var dy = p1[1] - p2[1];
        return dx * dx + dy * dy;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
