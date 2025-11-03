//给你一个字符串表达式 s ，请你实现一个基本计算器来计算并返回它的值。 
//
// 注意:不允许使用任何将字符串作为数学表达式计算的内置函数，比如 eval() 。 
//
// 
//
// 示例 1： 
//
// 
//输入：s = "1 + 1"
//输出：2
// 
//
// 示例 2： 
//
// 
//输入：s = " 2-1 + 2 "
//输出：3
// 
//
// 示例 3： 
//
// 
//输入：s = "(1+(4+5+2)-3)+(6+8)"
//输出：23
// 
//
// 
//
// 提示： 
//
// 
// 1 <= s.length <= 3 * 10⁵ 
// s 由数字、'+'、'-'、'('、')'、和 ' ' 组成 
// s 表示一个有效的表达式 
// '+' 不能用作一元运算(例如， "+1" 和 "+(2 + 3)" 无效) 
// '-' 可以用作一元运算(即 "-1" 和 "-(2 + 3)" 是有效的) 
// 输入中不存在两个连续的操作符 
// 每个数字和运行的计算将适合于一个有符号的 32位 整数 
// 
//
// Related Topics 栈 递归 数学 字符串 👍 1163 👎 0

using System.Collections;

namespace BasicCalculator;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int Calculate(string s)
    {
        var priorities = new char[5, 5] {
            // 当前      +    -    (    )    \0
            /*  +  */ { '>', '>', '<', '>', '>' },
            /*  -  */ { '>', '>', '<', '>', '>' },
            /*  (  */ { '<', '<', '<', '~', ' ' },
            /*  )  */ { ' ', ' ', ' ', ' ', ' ' },
            /*  \0 */ { '<', '<', '<', ' ', '~' }
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
                        operands.Push(op == '+' ? a + b : a - b);
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
                '(' => 2,
                ')' => 3,
                '\0' => 4,
                _ => throw new ArgumentException("Invalid operator")
            };
            var col = op2 switch {
                '+' => 0,
                '-' => 1,
                '(' => 2,
                ')' => 3,
                '\0' => 4,
                _ => throw new ArgumentException("Invalid operator")
            };
            return priorities[row, col];
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
