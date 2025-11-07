//中位数是有序整数列表中的中间值。如果列表的大小是偶数，则没有中间值，中位数是两个中间值的平均值。 
//
// 
// 例如 arr = [2,3,4] 的中位数是 3 。 
// 例如 arr = [2,3] 的中位数是 (2 + 3) / 2 = 2.5 。 
// 
//
// 实现 MedianFinder 类: 
//
// 
// MedianFinder() 初始化 MedianFinder 对象。 
// void addNum(int num) 将数据流中的整数 num 添加到数据结构中。 
// double findMedian() 返回到目前为止所有元素的中位数。与实际答案相差 10⁻⁵ 以内的答案将被接受。 
// 
//
// 示例 1： 
//
// 
//输入
//["MedianFinder", "addNum", "addNum", "findMedian", "addNum", "findMedian"]
//[[], [1], [2], [], [3], []]
//输出
//[null, null, null, 1.5, null, 2.0]
//
//解释
//MedianFinder medianFinder = new MedianFinder();
//medianFinder.addNum(1);    // arr = [1]
//medianFinder.addNum(2);    // arr = [1, 2]
//medianFinder.findMedian(); // 返回 1.5 ((1 + 2) / 2)
//medianFinder.addNum(3);    // arr[1, 2, 3]
//medianFinder.findMedian(); // return 2.0 
//
// 提示: 
//
// 
// -10⁵ <= num <= 10⁵ 
// 在调用 findMedian 之前，数据结构中至少有一个元素 
// 最多 5 * 10⁴ 次调用 addNum 和 findMedian 
// 
//
// Related Topics 设计 双指针 数据流 排序 堆（优先队列） 👍 1181 👎 0


namespace FindMedianFromDataStream;

//leetcode submit region begin(Prohibit modification and deletion)
// using System.Diagnostics.CodeAnalysis;


public class MedianFinder
{
    private readonly PriorityQueue<int, int> _left = new(); // Max-heap
    private readonly PriorityQueue<int, int> _right = new(); // Min-heap
    // left 堆中的元素都小于等于 right 堆中的元素，且 left 堆的元素个数要么等于 right 堆，要么比 right 堆多一个。
    public void AddNum(int num)
    {
        if (_left.Count == 0 || num <= _left.Peek())
            _left.Enqueue(num, -num); // Max-heap by using negative priority
        else
            _right.Enqueue(num, num); // Min-heap

        // Balance the two heaps
        if (_left.Count > _right.Count + 1)
        {
            var value = _left.Dequeue();
            _right.Enqueue(value, value);
        }
        else if (_right.Count > _left.Count)
        {
            var value = _right.Dequeue();
            _left.Enqueue(value, -value);
        }
    }

    public double FindMedian() => _left.Count > _right.Count
        ? _left.Peek()
        : (_left.Peek() + _right.Peek()) / 2.0;
}
/*
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */
//leetcode submit region end(Prohibit modification and deletion)
