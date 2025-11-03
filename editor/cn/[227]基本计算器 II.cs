//给你一个字符串表达式 s ，请你实现一个基本计算器来计算并返回它的值。 
//
// 整数除法仅保留整数部分。 
//
// 你可以假设给定的表达式总是有效的。所有中间结果将在 [-2³¹, 2³¹ - 1] 的范围内。 
//
// 注意：不允许使用任何将字符串作为数学表达式计算的内置函数，比如 eval() 。 
//
// 
//
// 示例 1： 
//
// 
//输入：s = "3+2*2"
//输出：7
// 
//
// 示例 2： 
//
// 
//输入：s = " 3/2 "
//输出：1
// 
//
// 示例 3： 
//
// 
//输入：s = " 3+5 / 2 "
//输出：5
// 
//
// 
//
// 提示： 
//
// 
// 1 <= s.length <= 3 * 10⁵ 
// s 由整数和算符 ('+', '-', '*', '/') 组成，中间由一些空格隔开 
// s 表示一个 有效表达式 
// 表达式中的所有整数都是非负整数，且在范围 [0, 2³¹ - 1] 内 
// 题目数据保证答案是一个 32-bit 整数 
// 
//
// Related Topics 栈 数学 字符串 👍 863 👎 0

namespace BasicCalculatorIi;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int Calculate(string s)
    {
        var priorities = new char[7, 7] {
            /* 当前       +    -    *    /   (     )   \0 */
            /*  +  */ { '>', '>', '<', '<', '<', '>', '>' },
            /*  -  */ { '>', '>', '<', '<', '<', '>', '>' },
            /*  *  */ { '>', '>', '>', '>', '<', '>', '>' },
            /*  /  */ { '>', '>', '>', '>', '<', '>', '>' },
            /*  (  */ { '<', '<', '<', '<', '<', '~', ' ' },
            /*  )  */ { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            /*  \0 */ { '<', '<', '<', '<', '<', ' ', '~' }
            /* 栈顶 */
        };
        var operators = new Stack<char>();
        var operands = new Stack<int>();
        operators.Push('\0');
        var exp = new List<char>();
        for (int i = 0; i < s.Length; i++) {
            if (s[i] == ' ') continue;

            if (s[i] == '-' && (i == 0 || exp[^1] == '('))
                exp.Add('0');

            exp.Add(s[i]);
        }
        exp.Add('\0');
        var j = 0;
        while (operators.Count > 0)
            if (char.IsDigit(exp[j])) {
                var num = 0;
                while (j < exp.Count && char.IsDigit(exp[j])) {
                    num = num * 10 + (exp[j] - '0');
                    j++;
                }
                operands.Push(num);
            } else
                switch (GetPriority(operators.Peek(), exp[j])) {
                    case '<':
                        operators.Push(exp[j]);
                        j++;
                        break;
                    case '>':
                        var op = operators.Pop();
                        var b = operands.Pop();
                        var a = operands.Pop();
                        operands.Push(op switch {
                            '+' => a + b,
                            '-' => a - b,
                            '*' => a * b,
                            '/' => a / b,
                            _ => throw new ArgumentException("Invalid operator")
                        });
                        break;
                    case '~':
                        operators.Pop();
                        j++;
                        break;
                }

        return operands.Pop();

        char GetPriority(char op1, char op2)
        {
            var row = op1 switch {
                '+' => 0,
                '-' => 1,
                '*' => 2,
                '/' => 3,
                '(' => 4,
                ')' => 5,
                '\0' => 6,
                _ => throw new ArgumentException("Invalid operator")
            };
            var col = op2 switch {
                '+' => 0,
                '-' => 1,
                '*' => 2,
                '/' => 3,
                '(' => 4,
                ')' => 5,
                '\0' => 6,
                _ => throw new ArgumentException("Invalid operator")
            };
            return priorities[row, col];
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
