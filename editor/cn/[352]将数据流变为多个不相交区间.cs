//给你一个由非负整数组成的数据流输入 a1, a2, ..., an，请你将目前为止看到的数字汇总为一组不相交的区间列表。 
//
// 实现 SummaryRanges 类： 
//
// 
// SummaryRanges() 初始化一个空的数据流对象。 
// void addNum(int value) 将整数 value 添加到数据流中。 
// int[][] getIntervals() 返回当前数据流中的整数汇总为一组不相交的区间列表 [starti, endi]。答案应按 starti 升序
//排序。 
// 
//
// 
//
// 示例 1： 
//
// 
//输入
//["SummaryRanges", "addNum", "getIntervals", "addNum", "getIntervals", 
//"addNum", "getIntervals", "addNum", "getIntervals", "addNum", "getIntervals"]
//[[], [1], [], [3], [], [7], [], [2], [], [6], []]
//输出
//[null, null, [[1, 1]], null, [[1, 1], [3, 3]], null, [[1, 1], [3, 3], [7, 7]],
// null, [[1, 3], [7, 7]], null, [[1, 3], [6, 7]]]
//
//解释
//SummaryRanges summaryRanges = new SummaryRanges();
//summaryRanges.addNum(1);      // arr = [1]
//summaryRanges.getIntervals(); // 返回 [[1, 1]]
//summaryRanges.addNum(3);      // arr = [1, 3]
//summaryRanges.getIntervals(); // 返回 [[1, 1], [3, 3]]
//summaryRanges.addNum(7);      // arr = [1, 3, 7]
//summaryRanges.getIntervals(); // 返回 [[1, 1], [3, 3], [7, 7]]
//summaryRanges.addNum(2);      // arr = [1, 2, 3, 7]
//summaryRanges.getIntervals(); // 返回 [[1, 3], [7, 7]]
//summaryRanges.addNum(6);      // arr = [1, 2, 3, 6, 7]
//summaryRanges.getIntervals(); // 返回 [[1, 3], [6, 7]]
// 
//
// 
//
// 提示： 
//
// 
// 0 <= value <= 10⁴ 
// 最多会调用 addNum 和 getIntervals 方法 3 * 10⁴ 次。 
// 最多会调用 getIntervals 方法 10² 次。 
// 
//
// 
//
// 进阶：如果存在大量合并，并且与数据流的大小相比，不相交区间的数量很小，该怎么办? 
//
// Related Topics 并查集 设计 哈希表 二分查找 数据流 有序集合 👍 207 👎 0

namespace DataStreamAsDisjointIntervals;

//leetcode submit region begin(Prohibit modification and deletion)
public class SummaryRanges
{
    private readonly List<int[]> _intervals = [];

    public void AddNum(int value)
    {
        var ints = _intervals;
        var idx = BinarySearch(value);

        if (idx < 0) {
            if (ints.Count == 0 || ints[0][0] > value + 1)
                ints.Insert(0, [value, value]);
            else // _intervals[0][0] == value + 1
                ints[0][0] = value;
        } else if (idx + 1 < ints.Count) {
            if (ints[idx + 1][0] == value + 1 && ints[idx][1] == value - 1) {
                // merge both sides
                ints[idx][1] = ints[idx + 1][1];
                ints.RemoveAt(idx + 1);
            } else if (ints[idx + 1][0] == value + 1) {
                // extend right interval
                ints[idx + 1][0] = value;
            } else if (ints[idx][1] == value - 1) {
                // extend left interval
                ints[idx][1] = value;
            } else if (ints[idx][1] < value - 1) {
                //insert new interval
                ints.Insert(idx + 1, [value, value]);
            } // else ints[idx][1] >= value, do nothing
        } else {
            if (ints[idx][1] == value - 1) {
                // extend left interval
                ints[idx][1] = value;
            } else if (ints[idx][1] < value - 1) {
                // insert new interval
                ints.Add([value, value]);
            } // else ints[idx][1] >= value, do nothing
        }
    }

    public int[][] GetIntervals() => _intervals.ToArray();

    // return the index of the interval that has the largest start <= value
    private int BinarySearch(int value)
    {
        int lo = 0, hi = _intervals.Count;
        while (lo < hi) {
            int mid = (lo + hi) / 2;
            if (value < _intervals[mid][0])
                hi = mid;
            else
                lo = mid + 1;
        }
        return lo - 1;
    }
}

/**
 * Your SummaryRanges object will be instantiated and called as such:
 * SummaryRanges obj = new SummaryRanges();
 * obj.AddNum(value);
 * int[][] param_2 = obj.GetIntervals();
 */
//leetcode submit region end(Prohibit modification and deletion)
