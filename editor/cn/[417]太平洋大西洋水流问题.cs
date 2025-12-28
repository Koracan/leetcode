//有一个 m × n 的矩形岛屿，与 太平洋 和 大西洋 相邻。 “太平洋” 处于大陆的左边界和上边界，而 “大西洋” 处于大陆的右边界和下边界。 
//
// 这个岛被分割成一个由若干方形单元格组成的网格。给定一个 m x n 的整数矩阵 heights ， heights[r][c] 表示坐标 (r, c) 上
//单元格 高于海平面的高度 。 
//
// 岛上雨水较多，如果相邻单元格的高度 小于或等于 当前单元格的高度，雨水可以直接向北、南、东、西流向相邻单元格。水可以从海洋附近的任何单元格流入海洋。 
//
// 返回网格坐标 result 的 2D 列表 ，其中 result[i] = [ri, ci] 表示雨水从单元格 (ri, ci) 流动 既可流向太平洋也可
//流向大西洋 。 
//
// 
//
// 示例 1： 
//
// 
//
// 
//输入: heights = [[1,2,2,3,5],[3,2,3,4,4],[2,4,5,3,1],[6,7,1,4,5],[5,1,1,2,4]]
//输出: [[0,4],[1,3],[1,4],[2,2],[3,0],[3,1],[4,0]]
// 
//
// 示例 2： 
//
// 
//输入: heights = [[2,1],[1,2]]
//输出: [[0,0],[0,1],[1,0],[1,1]]
// 
//
// 
//
// 提示： 
//
// 
// m == heights.length 
// n == heights[r].length 
// 1 <= m, n <= 200 
// 0 <= heights[r][c] <= 10⁵ 
// 
//
// Related Topics 深度优先搜索 广度优先搜索 数组 矩阵 👍 791 👎 0

namespace PacificAtlanticWaterFlow;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        var m = heights.Length;
        var n = heights[0].Length;

        var oceans = new byte[m, n]; // 0b01: Pacific, 0b10: Atlantic, 0b11: both
        (int dx, int dy)[] directions = [(1, 0), (-1, 0), (0, 1), (0, -1)];

        var pacificQueue = new Queue<(int, int)>();
        var atlanticQueue = new Queue<(int, int)>();

        // initialize Pacific (top row and left column) and Atlantic (bottom row and right column)
        for (var i = 0; i < m; i++) {
            oceans[i, 0] |= 0b01;
            pacificQueue.Enqueue((i, 0));
            oceans[i, n - 1] |= 0b10;
            atlanticQueue.Enqueue((i, n - 1));
        }
        for (var j = 0; j < n; j++) {
            oceans[0, j] |= 0b01;
            pacificQueue.Enqueue((0, j));
            oceans[m - 1, j] |= 0b10;
            atlanticQueue.Enqueue((m - 1, j));
        }

        Bfs(pacificQueue, 0b01);
        Bfs(atlanticQueue, 0b10);

        var result = new List<IList<int>>();
        for (var i = 0; i < m; i++)
            for (var j = 0; j < n; j++)
                if (oceans[i, j] == 0b11)
                    result.Add([i, j]);

        return result;

        void Bfs(Queue<(int, int)> q, byte oceanBit)
        {
            while (q.Count > 0) {
                var (x, y) = q.Dequeue();
                foreach (var (dx, dy) in directions) {
                    var nx = x + dx;
                    var ny = y + dy;
                    if (nx < 0 || nx >= m || ny < 0 || ny >= n) continue;
                    if ((oceans[nx, ny] & oceanBit) != 0) continue;
                    if (heights[nx][ny] < heights[x][y]) continue;
                    oceans[nx, ny] |= oceanBit;
                    q.Enqueue((nx, ny));
                }
            }
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
