//有效 IP 地址 正好由四个整数（每个整数位于 0 到 255 之间组成，且不能含有前导 0），整数之间用 '.' 分隔。 
//
// 
// 例如："0.1.2.201" 和 "192.168.1.1" 是 有效 IP 地址，但是 "0.011.255.245"、"192.168.1.312" 
//和 "192.168@1.1" 是 无效 IP 地址。 
// 
//
// 给定一个只包含数字的字符串 s ，用以表示一个 IP 地址，返回所有可能的有效 IP 地址，这些地址可以通过在 s 中插入 '.' 来形成。你 不能 重新
//排序或删除 s 中的任何数字。你可以按 任何 顺序返回答案。 
//
// 
//
// 示例 1： 
//
// 
//输入：s = "25525511135"
//输出：["255.255.11.135","255.255.111.35"]
// 
//
// 示例 2： 
//
// 
//输入：s = "0000"
//输出：["0.0.0.0"]
// 
//
// 示例 3： 
//
// 
//输入：s = "101023"
//输出：["1.0.10.23","1.0.102.3","10.1.0.23","10.10.2.3","101.0.2.3"]
// 
//
// 
//
// 提示： 
//
// 
// 1 <= s.length <= 20 
// s 仅由数字组成 
// 
//
// Related Topics 字符串 回溯 👍 1511 👎 0

namespace RestoreIpAddresses;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public IList<string> RestoreIpAddresses(string s)
    {
        if (s.Length is < 4 or > 12) return [];
        var result = new List<string>();
        var buffer = new char[s.Length + 3];
        Backtrack(0, 0);
        return result;

        void Backtrack(int start, int dots)
        {
            if (dots == 3) {
                if (!IsValid(start, s.Length - 1)) return;

                for (var i = 0; i < s.Length - start; i++) buffer[start + dots + i] = s[start + i];
                result.Add(new(buffer));
                return;
            }

            for (var i = 1; i <= 3 && start + i < s.Length; i++) {
                if (!IsValid(start, start + i - 1)) break;

                for (var j = 0; j < i; j++) buffer[start + dots + j] = s[start + j];
                buffer[start + dots + i] = '.';
                Backtrack(start + i, dots + 1);
            }
        }

        bool IsValid(int start, int end)
        {
            if (end - start is < 0 or > 2) return false;

            if (s[start] == '0' && end - start > 0) return false;

            var num = 0;
            for (var i = start; i <= end; i++) num = num * 10 + s[i] - '0';

            return num <= 255;
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
