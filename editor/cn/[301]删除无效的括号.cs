//给你一个由若干括号和字母组成的字符串 s ，删除最小数量的无效括号，使得输入的字符串有效。 
//
// 返回所有可能的结果。答案可以按 任意顺序 返回。 
//
// 
//
// 示例 1： 
//
// 
//输入：s = "()())()"
//输出：["(())()","()()()"]
// 
//
// 示例 2： 
//
// 
//输入：s = "(a)())()"
//输出：["(a())()","(a)()()"]
// 
//
// 示例 3： 
//
// 
//输入：s = ")("
//输出：[""]
// 
//
// 
//
// 提示： 
//
// 
// 1 <= s.length <= 25 
// s 由小写英文字母以及括号 '(' 和 ')' 组成 
// s 中至多含 20 个括号 
// 
//
// Related Topics 广度优先搜索 字符串 回溯 👍 995 👎 0


using System.Text;

namespace RemoveInvalidParentheses;

//leetcode submit region begin(Prohibit modification and deletion)

public class Solution
{
    public IList<string> RemoveInvalidParentheses(string s)
    {
        var result = new HashSet<string>();
        int lToRemove = 0, rToRemove = 0;
        foreach (var c in s)
            if (c == '(') {
                lToRemove++;
            } else if (c == ')') {
                if (lToRemove > 0)
                    lToRemove--;
                else
                    rToRemove++;
            }

        Backtrack(0, 0, 0, lToRemove, rToRemove, new());
        return result.ToArray();

        void Backtrack(int index, int lCount, int rCount, int lToRem, int rToRem, StringBuilder path)
        {
            if (index == s.Length) {
                if (lToRem == 0 && rToRem == 0) result.Add(path.ToString());
                return;
            }

            var c = s[index];
            if (c == '(') {
                // 删除当前左括号
                if (lToRem > 0) {
                    // 优化：连续删除相同括号
                    var skip = 0;
                    do {
                        skip++;
                    } while (lToRem - skip > 0 && index + skip < s.Length && s[index + skip] == '(');
                    Backtrack(index + skip, lCount, rCount, lToRem - skip, rToRem, path);
                }

                // 保留当前左括号
                path.Append(c);
                Backtrack(index + 1, lCount + 1, rCount, lToRem, rToRem, path);
                path.Length--;
            } else if (c == ')') {
                // 删除当前右括号
                if (rToRem > 0) {
                    // 优化：连续删除相同括号
                    var skip = 0;
                    do {
                        skip++;
                    } while (rToRem - skip > 0 && index + skip < s.Length && s[index + skip] == ')');
                    Backtrack(index + skip, lCount, rCount, lToRem, rToRem - skip, path);
                }

                // 保留当前右括号
                if (rCount < lCount) {
                    path.Append(c);
                    Backtrack(index + 1, lCount, rCount + 1, lToRem, rToRem, path);
                    path.Length--;
                }
            } else {
                // 普通字符，直接保留
                path.Append(c);
                Backtrack(index + 1, lCount, rCount, lToRem, rToRem, path);
                path.Length--;
            }
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
