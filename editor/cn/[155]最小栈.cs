//设计一个支持 push ，pop ，top 操作，并能在常数时间内检索到最小元素的栈。 
//
// 实现 MinStack 类: 
//
// 
// MinStack() 初始化堆栈对象。 
// void push(int val) 将元素val推入堆栈。 
// void pop() 删除堆栈顶部的元素。 
// int top() 获取堆栈顶部的元素。 
// int getMin() 获取堆栈中的最小元素。 
// 
//
// 
//
// 示例 1: 
//
// 
//输入：
//["MinStack","push","push","push","getMin","pop","top","getMin"]
//[[],[-2],[0],[-3],[],[],[],[]]
//
//输出：
//[null,null,null,null,-3,null,0,-2]
//
//解释：
//MinStack minStack = new MinStack();
//minStack.push(-2);
//minStack.push(0);
//minStack.push(-3);
//minStack.getMin();   --> 返回 -3.
//minStack.pop();
//minStack.top();      --> 返回 0.
//minStack.getMin();   --> 返回 -2.
// 
//
// 
//
// 提示： 
//
// 
// -2³¹ <= val <= 2³¹ - 1 
// pop、top 和 getMin 操作总是在 非空栈 上调用 
// push, pop, top, and getMin最多被调用 3 * 10⁴ 次 
// 
//
// Related Topics 栈 设计 👍 1987 👎 0

namespace MinStack;

//leetcode submit region begin(Prohibit modification and deletion)
public class MinStack
{
    public MinStack()
    {
        _stack = new(4);
        _min = int.MaxValue;
        _minCount = 0;
    }

    public void Push(int val)
    {
        if (val < _min) {
            _min = val;
            _minCount = 1;
        } else if (val == _min)
            _minCount++;
        _stack.Add(val);
    }

    public void Pop()
    {
        var popped = _stack[^1];
        _stack.RemoveAt(_stack.Count - 1);
        if (popped == _min) {
            if (_minCount > 1) _minCount--;
            else RefreshMin();
        }
    }

    public int Top()
    {
        return _stack[^1];
    }

    public int GetMin()
    {
        return _min;
    }

    private void RefreshMin()
    {
        _min = int.MaxValue;
        _minCount = 0;
        foreach (var num in _stack)
            if (num < _min) {
                _min = num;
                _minCount = 1;
            } else if (num == _min)
                _minCount++;
    }

    private readonly List<int> _stack;
    private int _min;
    private int _minCount;
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */
//leetcode submit region end(Prohibit modification and deletion)
