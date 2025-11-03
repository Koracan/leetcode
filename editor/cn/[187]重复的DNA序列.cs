//DNA序列 由一系列核苷酸组成，缩写为
// 'A', 'C', 'G' 和
// 'T'.。 
//
// 
// 例如，
// "ACGAATTCCG" 是一个 DNA序列 。 
// 
//
// 在研究 DNA 时，识别 DNA 中的重复序列非常有用。 
//
// 给定一个表示 DNA序列 的字符串 s ，返回所有在 DNA 分子中出现不止一次的 长度为 10 的序列(子字符串)。你可以按 任意顺序 返回答案。 
//
// 
//
// 示例 1： 
//
// 
//输入：s = "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT"
//输出：["AAAAACCCCC","CCCCCAAAAA"]
// 
//
// 示例 2： 
//
// 
//输入：s = "AAAAAAAAAAAAA"
//输出：["AAAAAAAAAA"]
// 
//
// 
//
// 提示： 
//
// 
// 0 <= s.length <= 10⁵ 
// s[i]=='A'、'C'、'G' or 'T' 
// 
//
// Related Topics 位运算 哈希表 字符串 滑动窗口 哈希函数 滚动哈希 👍 623 👎 0

namespace RepeatedDnaSequences;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public IList<string> FindRepeatedDnaSequences(string s)
    {
        var dict = new Dictionary<int, int>();
        
        // 把 DNA 序列视为 4 进制数，A=0, C=1, G=2, T=3
        var map = new Dictionary<char, int>
        {
            {'A', 0},
            {'C', 1},
            {'G', 2},
            {'T', 3}
        };
        
        var result = new List<string>();
        var n = s.Length;
        if (n < 10) return result;
        var hash = 0;
        for (var i = 0; i < 10; i++) hash = hash << 2 | map[s[i]];
        
        dict[hash] = 1;
        const int mask = (1 << 20) - 1; // 20 = 10 * 2
        for (var i = 10; i < n; i++) {
            hash = (hash << 2 | map[s[i]]) & mask;
            
            if (!dict.TryAdd(hash, 1)) {
                dict[hash]++;
                if (dict[hash] == 2)
                    result.Add(s.Substring(i - 9, 10));
            }
        }

        return result;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
