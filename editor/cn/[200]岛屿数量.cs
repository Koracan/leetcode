//给你一个由 '1'（陆地）和 '0'（水）组成的的二维网格，请你计算网格中岛屿的数量。 
//
// 岛屿总是被水包围，并且每座岛屿只能由水平方向和/或竖直方向上相邻的陆地连接形成。 
//
// 此外，你可以假设该网格的四条边均被水包围。 
//
// 
//
// 示例 1： 
//
// 
//输入：grid = [
//  ['1','1','1','1','0'],
//  ['1','1','0','1','0'],
//  ['1','1','0','0','0'],
//  ['0','0','0','0','0']
//]
//输出：1
// 
//
// 示例 2： 
//
// 
//输入：grid = [
//  ['1','1','0','0','0'],
//  ['1','1','0','0','0'],
//  ['0','0','1','0','0'],
//  ['0','0','0','1','1']
//]
//输出：3
// 
//
// 
//
// 提示： 
//
// 
// m == grid.length 
// n == grid[i].length 
// 1 <= m, n <= 300 
// grid[i][j] 的值为 '0' 或 '1' 
// 
//
// Related Topics 深度优先搜索 广度优先搜索 并查集 数组 矩阵 👍 2851 👎 0

namespace NumberOfIslands;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int NumIslands(char[][] grid)
    {
        var stack = new Stack<(int, int)>();
        var count = 0;
        var m = grid.Length;
        var n = grid[0].Length;
        for (var i = 0; i < m; i++)
            for (var j = 0; j < n; j++) {
                if (grid[i][j] == '0') continue;
                count++;
                grid[i][j] = '0';
                stack.Push((i, j));
                while (stack.Count > 0) {
                    var (x, y) = stack.Pop();

                    if (x > 0 && grid[x - 1][y] == '1') {
                        grid[x - 1][y] = '0';
                        stack.Push((x - 1, y));
                    }
                    if (x < m - 1 && grid[x + 1][y] == '1') {
                        grid[x + 1][y] = '0';
                        stack.Push((x + 1, y));
                    }
                    if (y > 0 && grid[x][y - 1] == '1') {
                        grid[x][y - 1] = '0';
                        stack.Push((x, y - 1));
                    }
                    if (y < n - 1 && grid[x][y + 1] == '1') {
                        grid[x][y + 1] = '0';
                        stack.Push((x, y + 1));
                    }
                }
            }
        return count;
    }

    // ---并查集解法---
    // public int NumIslands(char[][] grid)
    // {
    //     int m = grid.Length, n = grid[0].Length;
    //     int[] parent = new int[m * n];
    //     int[] rank = new int[m * n];
    //     int count = 0;
    //     for (int i = 0; i < m; i++)
    //         for (int j = 0; j < n; j++) {
    //             if (grid[i][j] == '1') {
    //                 int idx = i * n + j;
    //                 parent[idx] = idx;
    //                 rank[idx] = 1;
    //                 count++;
    //             }
    //         }
    //     int[] dx = [0, 1];
    //     int[] dy = [1, 0];
    //     for (int i = 0; i < m; i++)
    //         for (int j = 0; j < n; j++) {
    //             if (grid[i][j] != '1') continue;
    //             int idx = i * n + j;
    //             for (int d = 0; d < 2; d++) {
    //                 int ni = i + dx[d], nj = j + dy[d];
    //                 if (ni < m && nj < n && grid[ni][nj] == '1') {
    //                     int nidx = ni * n + nj;
    //                     if (Union(parent, rank, idx, nidx)) count--;
    //                 }
    //             }
    //         }
    //     return count;
    // }
    // private int Find(int[] parent, int x)
    // {
    //     if (parent[x] != x) parent[x] = Find(parent, parent[x]);
    //     return parent[x];
    // }
    // private bool Union(int[] parent, int[] rank, int x, int y)
    // {
    //     int px = Find(parent, x), py = Find(parent, y);
    //     if (px == py) return false;
    //     if (rank[px] < rank[py]) parent[px] = py;
    //     else if (rank[px] > rank[py]) parent[py] = px;
    //     else { parent[py] = px; rank[px]++; }
    //     return true;
    // }
}
//leetcode submit region end(Prohibit modification and deletion)
