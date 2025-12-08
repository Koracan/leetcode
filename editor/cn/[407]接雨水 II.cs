//给你一个 m x n 的矩阵，其中的值均为非负整数，代表二维高度图每个单元的高度，请计算图中形状最多能接多少体积的雨水。 
//
// 
//
// 示例 1: 
//
// 
//
// 
//输入: heightMap = [[1,4,3,1,3,2],[3,2,1,3,2,4],[2,3,3,2,3,1]]
//输出: 4
//解释: 下雨后，雨水将会被上图蓝色的方块中。总的接雨水量为1+2+1=4。
// 
//
// 示例 2: 
//
// 
//
// 
//输入: heightMap = [[3,3,3,3,3],[3,2,2,2,3],[3,2,1,2,3],[3,2,2,2,3],[3,3,3,3,3]]
//输出: 10
// 
//
// 
//
// 提示: 
//
// 
// m == heightMap.length 
// n == heightMap[i].length 
// 1 <= m, n <= 200 
// 0 <= heightMap[i][j] <= 2 * 10⁴ 
// 
//
// 
//
// Related Topics 广度优先搜索 数组 矩阵 堆（优先队列） 👍 821 👎 0

using System.Collections;

namespace TrappingRainWaterIi;

//leetcode submit region begin(Prohibit modification and deletion)

public class Solution
{
    private readonly record struct Cell(int I, int J, int H);
    public int TrapRainWater(int[][] heightMap)
    {
        var m = heightMap.Length;
        var n = heightMap[0].Length;
        (int di, int dj)[] directs = [(1, 0), (-1, 0), (0, 1), (0, -1)];
        var visited = new bool[m, n];
        var pq = new PriorityQueue<Cell, int>(); // h is the height after water filled

        // for the border cells, they cannot hold water, so h is their own height
        for (var i = 0; i < m; i++) {
            pq.Enqueue(new(i, 0, heightMap[i][0]), heightMap[i][0]);
            pq.Enqueue(new(i, n - 1, heightMap[i][n - 1]), heightMap[i][n - 1]);
            visited[i, 0] = true;
            visited[i, n - 1] = true;
        }
        for (var j = 1; j < n - 1; j++) {
            pq.Enqueue(new(0, j, heightMap[0][j]), heightMap[0][j]);
            pq.Enqueue(new(m - 1, j, heightMap[m - 1][j]), heightMap[m - 1][j]);
            visited[0, j] = true;
            visited[m - 1, j] = true;
        }

        var water = 0;
        // for other cells, h is the min height of border cells around it
        while (pq.Count > 0) {
            var (i, j, h) = pq.Dequeue();
            foreach (var (di, dj) in directs) {
                var ni = i + di;
                var nj = j + dj;
                if (ni < 0 || ni >= m || nj < 0 || nj >= n || visited[ni, nj]) continue;
                visited[ni, nj] = true;
                if (heightMap[ni][nj] < h) {
                    water += h - heightMap[ni][nj];
                    pq.Enqueue(new(ni, nj, h), h);
                } else {
                    pq.Enqueue(new(ni, nj, heightMap[ni][nj]), heightMap[ni][nj]);
                }
            }
        }
        return water;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
