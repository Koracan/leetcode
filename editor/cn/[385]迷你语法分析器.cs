//给定一个字符串 s 表示一个整数嵌套列表，实现一个解析它的语法分析器并返回解析的结果 NestedInteger 。 
//
// 列表中的每个元素只可能是整数或整数嵌套列表 
//
// 
//
// 示例 1： 
//
// 
//输入：s = "324",
//输出：324
//解释：你应该返回一个 NestedInteger 对象，其中只包含整数值 324。
// 
//
// 示例 2： 
//
// 
//输入：s = "[123,[456,[789]]]",
//输出：[123,[456,[789]]]
//解释：返回一个 NestedInteger 对象包含一个有两个元素的嵌套列表：
//1. 一个 integer 包含值 123
//2. 一个包含两个元素的嵌套列表：
//    i.  一个 integer 包含值 456
//    ii. 一个包含一个元素的嵌套列表
//         a. 一个 integer 包含值 789
// 
//
// 
//
// 提示： 
//
// 
// 1 <= s.length <= 5 * 10⁴ 
// s 由数字、方括号 "[]"、负号 '-' 、逗号 ','组成 
// 用例保证 s 是可解析的 NestedInteger 
// 输入中的所有值的范围是 [-10⁶, 10⁶] 
// 
//
// Related Topics 栈 深度优先搜索 字符串 👍 222 👎 0

namespace MiniParser;

//leetcode submit region begin(Prohibit modification and deletion)
/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // Constructor initializes an empty nested list.
 *     public NestedInteger();
 *
 *     // Constructor initializes a single integer.
 *     public NestedInteger(int value);
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // Set this NestedInteger to hold a single integer.
 *     public void SetInteger(int value);
 *
 *     // Set this NestedInteger to hold a nested list and adds a nested integer to it.
 *     public void Add(NestedInteger ni);
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */
public class Solution
{
    public NestedInteger Deserialize(string s)
    {
        var stack = new Stack<NestedInteger>();
        var str = s.AsSpan();
        NestedInteger? current = null;
        for (var i = 0; i < str.Length;)
            switch (str[i]) {
                case '[':
                    if (current != null) stack.Push(current);
                    current = new();
                    i++;
                    break;
                case ']':
                    if (stack.Count > 0) {
                        var parent = stack.Pop();
                        parent.Add(current!);
                        current = parent;
                    }
                    i++;
                    break;
                case ',':
                    i++;
                    break;
                default:
                    // number
                    int start = i;
                    while (i < str.Length && (char.IsDigit(str[i]) || str[i] == '-')) i++;
                    int num = int.Parse(str[start..i]);
                    var ni = new NestedInteger(num);
                    if (current != null)
                        current.Add(ni);
                    else
                        current = ni;

                    break;
            }


        return current!;
    }
}

//leetcode submit region end(Prohibit modification and deletion)
public class NestedInteger
{
    // Constructor initializes an empty nested list.
    public NestedInteger() => throw new NotSupportedException();

    // Constructor initializes a single integer.
    public NestedInteger(int value) => throw new NotSupportedException();

    // @return true if this NestedInteger holds a single integer, rather than a nested list.
    bool IsInteger() => throw new NotSupportedException();

    // @return the single integer that this NestedInteger holds, if it holds a single integer
    // Return null if this NestedInteger holds a nested list
    int GetInteger() => throw new NotSupportedException();

    // Set this NestedInteger to hold a single integer.
    public void SetInteger(int value) => throw new NotSupportedException();

    // Set this NestedInteger to hold a nested list and adds a nested integer to it.
    public void Add(NestedInteger ni) => throw new NotSupportedException();

    // @return the nested list that this NestedInteger holds, if it holds a nested list
    // Return null if this NestedInteger holds a single integer
    IList<NestedInteger> GetList() => throw new NotSupportedException();
}
