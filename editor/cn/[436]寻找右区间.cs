//给你一个区间数组 intervals ，其中 intervals[i] = [starti, endi] ，且每个 starti 都 不同 。 
//
// 区间 i 的 右侧区间 是满足 startj >= endi，且 startj 最小 的区间 j。注意 i 可能等于 j 。 
//
// 返回一个由每个区间 i 对应的 右侧区间 下标组成的数组。如果某个区间 i 不存在对应的 右侧区间 ，则下标 i 处的值设为 -1 。 
//
// 示例 1： 
//
// 
//输入：intervals = [[1,2]]
//输出：[-1]
//解释：集合中只有一个区间，所以输出-1。
// 
//
// 示例 2： 
//
// 
//输入：intervals = [[3,4],[2,3],[1,2]]
//输出：[-1,0,1]
//解释：对于 [3,4] ，没有满足条件的“右侧”区间。
//对于 [2,3] ，区间[3,4]具有最小的“右”起点;
//对于 [1,2] ，区间[2,3]具有最小的“右”起点。
// 
//
// 示例 3： 
//
// 
//输入：intervals = [[1,4],[2,3],[3,4]]
//输出：[-1,2,-1]
//解释：对于区间 [1,4] 和 [3,4] ，没有满足条件的“右侧”区间。
//对于 [2,3] ，区间 [3,4] 有最小的“右”起点。
// 
//
// 
//
// 提示： 
//
// 
// 1 <= intervals.length <= 2 * 10⁴ 
// intervals[i].length == 2 
// -10⁶ <= starti <= endi <= 10⁶ 
// 每个间隔的起点都 不相同 
// 
//
// Related Topics 数组 二分查找 排序 👍 290 👎 0

namespace FindRightInterval;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    private record Pair(int Start, int Index);

    public int[] FindRightInterval(int[][] intervals)
    {
        var n = intervals.Length;
        var sortedIntervals = new Pair[n];
        for (int i = 0; i < n; i++) sortedIntervals[i] = new(intervals[i][0], i);
        Array.Sort(sortedIntervals, (a, b) => a.Start - b.Start);

        var res = new int[n];
        for (int i = 0; i < n; i++) {
            res[i] = BinarySearch(sortedIntervals, intervals[i][1]);
        }

        return res;
    }

    private static int BinarySearch(Pair[] intervals, int target)
    {
        int lo = 0, hi = intervals.Length;
        while (lo < hi) {
            var mid = lo + (hi - lo) / 2;
            if (target <= intervals[mid].Start) {
                hi = mid;
            } else {
                lo = mid + 1;
            }
        }

        return lo < intervals.Length ? intervals[lo].Index : -1;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
