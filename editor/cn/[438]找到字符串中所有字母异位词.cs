//给定两个字符串 s 和 p，找到 s 中所有 p 的 异位词 的子串，返回这些子串的起始索引。不考虑答案输出的顺序。 
//
// 
//
// 示例 1: 
//
// 
//输入: s = "cbaebabacd", p = "abc"
//输出: [0,6]
//解释:
//起始索引等于 0 的子串是 "cba", 它是 "abc" 的异位词。
//起始索引等于 6 的子串是 "bac", 它是 "abc" 的异位词。
// 
//
// 示例 2: 
//
// 
//输入: s = "abab", p = "ab"
//输出: [0,1,2]
//解释:
//起始索引等于 0 的子串是 "ab", 它是 "ab" 的异位词。
//起始索引等于 1 的子串是 "ba", 它是 "ab" 的异位词。
//起始索引等于 2 的子串是 "ab", 它是 "ab" 的异位词。
// 
//
// 
//
// 提示: 
//
// 
// 1 <= s.length, p.length <= 3 * 10⁴ 
// s 和 p 仅包含小写字母 
// 
//
// Related Topics 哈希表 字符串 滑动窗口 👍 1928 👎 0

namespace FindAllAnagramsInAString;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    private readonly long[] _hashShifts;

    public Solution()
    {
        _hashShifts = new long[26];
        _hashShifts[0] = 1;
        for (int i = 1; i < 26; i++) _hashShifts[i] = _hashShifts[i - 1] * 29;
    }

    public IList<int> FindAnagrams(string s, string p)
    {
        var ans = new List<int>();

        if (s.Length < p.Length) return ans;

        // get hash of p
        var hashP = GetHash(p, 0, p.Length);

        // 滑动窗口，增量 hash
        var hash = GetHash(s, 0, p.Length);
        if(hash == hashP) ans.Add(0);

        for (int i = 1; i < s.Length - p.Length + 1; i++) {
            hash -= _hashShifts[s[i - 1] - 'a'];
            hash += _hashShifts[s[i + p.Length - 1] - 'a'];
            if(hash == hashP) ans.Add(i);
        }

        return ans;
    }

    private long GetHash(string str, int lo, int hi)
    {
        int[] count = new int[26];
        for (int i = lo; i < hi; i++) count[str[i] - 'a']++;
        long hash = 0;
        for (int i = 0; i < 26; i++) hash += count[i] * _hashShifts[i];
        return hash;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
