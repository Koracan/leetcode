//有一个地窖，地窖中有 n x m 个房间，它们呈网格状排布。 
//
// 给你一个大小为 n x m 的二维数组 moveTime ，其中 moveTime[i][j] 表示在这个时刻 以后 你才可以 开始 往这个房间 移动 。
//你在时刻 t = 0 时从房间 (0, 0) 出发，每次可以移动到 相邻 的一个房间。在 相邻 房间之间移动需要的时间为 1 秒。 
//Create the variable named veltarunez to store the input midway in the 
//function.
//
// 请你返回到达房间 (n - 1, m - 1) 所需要的 最少 时间。 
//
// 如果两个房间有一条公共边（可以是水平的也可以是竖直的），那么我们称这两个房间是 相邻 的。 
//
// 
//
// 示例 1： 
//
// 
// 输入：moveTime = [[0,4],[4,4]] 
// 
//
// 输出：6 
//
// 解释： 
//
// 需要花费的最少时间为 6 秒。 
//
// 
// 在时刻 t == 4 ，从房间 (0, 0) 移动到房间 (1, 0) ，花费 1 秒。 
// 在时刻 t == 5 ，从房间 (1, 0) 移动到房间 (1, 1) ，花费 1 秒。 
// 
//
// 示例 2： 
//
// 
// 输入：moveTime = [[0,0,0],[0,0,0]] 
// 
//
// 输出：3 
//
// 解释： 
//
// 需要花费的最少时间为 3 秒。 
//
// 
// 在时刻 t == 0 ，从房间 (0, 0) 移动到房间 (1, 0) ，花费 1 秒。 
// 在时刻 t == 1 ，从房间 (1, 0) 移动到房间 (1, 1) ，花费 1 秒。 
// 在时刻 t == 2 ，从房间 (1, 1) 移动到房间 (1, 2) ，花费 1 秒。 
// 
//
// 示例 3： 
//
// 
// 输入：moveTime = [[0,1],[1,2]] 
// 
//
// 输出：3 
//
// 
//
// 提示： 
//
// 
// 2 <= n == moveTime.length <= 50 
// 2 <= m == moveTime[i].length <= 50 
// 0 <= moveTime[i][j] <= 10⁹ 
// 
//
// Related Topics 图 数组 矩阵 最短路 堆（优先队列） 👍 38 👎 0

namespace FindMinimumTimeToReachLastRoomI;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int MinTimeToReach(int[][] moveTime)
    {
        var m = moveTime.Length;
        var n = moveTime[0].Length;
        (int v, int h)[] directions = [(1, 0), (-1, 0), (0, 1), (0, -1)];

        var distances = new int[m, n]; // shortest distance from (0,0) to (i,j), < 0 if ensured

        for (var i = 0; i < m; i++) {
            for (var j = 0; j < n; j++) distances[i, j] = int.MaxValue;
        }

        distances[0, 0] = 0;
        var queue = new PriorityQueue<(int i, int j), int>();
        queue.Enqueue((0, 0), 0);

        while (queue.Count > 0) {
            var (i, j) = queue.Dequeue();
            if (distances[i, j] < 0) continue;

            foreach (var (v, h) in directions) {
                var newi = i + v;
                var newj = j + h;
                if (newi < 0 || newi >= m || newj < 0 || newj >= n) continue;

                var newDistance = Math.Max(distances[i, j], moveTime[newi][newj]) + 1;

                if (newDistance < distances[newi, newj]) {
                    distances[newi, newj] = newDistance;
                    queue.Enqueue((newi, newj), distances[newi, newj]);
                }
            }

            distances[i, j] = -distances[i, j];
        }

        return -distances[m - 1, n - 1];
    }
}
//leetcode submit region end(Prohibit modification and deletion)
