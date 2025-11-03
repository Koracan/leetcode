//编写一个函数来查找字符串数组中的最长公共前缀。 
//
// 如果不存在公共前缀，返回空字符串 ""。 
//
// 
//
// 示例 1： 
//
// 
//输入：strs = ["flower","flow","flight"]
//输出："fl"
// 
//
// 示例 2： 
//
// 
//输入：strs = ["dog","racecar","car"]
//输出：""
//解释：输入不存在公共前缀。 
//
// 
//
// 提示： 
//
// 
// 1 <= strs.length <= 200 
// 0 <= strs[i].length <= 200 
// strs[i] 如果非空，则仅由小写英文字母组成 
// 
//
// Related Topics 字典树 字符串 👍 3330 👎 0

namespace LongestCommonPrefix;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        var pre = strs[0];
        var tail = pre.Length;

        for (var i = 1; i < strs.Length; i++) {
            var j = 0;
            while (j < tail && j < strs[i].Length && pre[j] == strs[i][j]) j++;

            tail = j;
        }

        return pre[..tail];
    }
}
//leetcode submit region end(Prohibit modification and deletion)
