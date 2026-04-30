//给你两个字符串 haystack 和 needle ，请你在 haystack 字符串中找出 needle 字符串的第一个匹配项的下标（下标从 0 开始）。
//如果 needle 不是 haystack 的一部分，则返回 -1 。 
//
// 
//
// 示例 1： 
//
// 
//输入：haystack = "sadbutsad", needle = "sad"
//输出：0
//解释："sad" 在下标 0 和 6 处匹配。
//第一个匹配项的下标是 0 ，所以返回 0 。
// 
//
// 示例 2： 
//
// 
//输入：haystack = "leetcode", needle = "leeto"
//输出：-1
//解释："leeto" 没有在 "leetcode" 中出现，所以返回 -1 。
// 
//
// 
//
// 提示： 
//
// 
// 1 <= haystack.length, needle.length <= 10⁴ 
// haystack 和 needle 仅由小写英文字符组成 
// 
//
// Related Topics 双指针 字符串 字符串匹配 👍 2409 👎 0

namespace FindTheIndexOfTheFirstOccurrenceInAString;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int StrStr(string haystack, string needle)
    {
        return haystack.IndexOf(needle, StringComparison.Ordinal);
        
        // // kmp
        // var next = new int[needle.Length]; // next[i] = j 表示 needle[0..(i+1)] 的最长相等前后缀长度为 j
        // var j = 0;
        // for (var i = 1; i < needle.Length; i++) {
        //     while (j > 0 && needle[i] != needle[j]) j = next[j - 1];
        //     if (needle[i] == needle[j]) j++;
        //     next[i] = j;
        // }
        // j = 0;
        // for (var i = 0; i < haystack.Length; i++) {
        //     while (j > 0 && haystack[i] != needle[j]) j = next[j - 1]; // 不匹配时，回退 j 到 needle[0..j] 的最长相等前后缀长度处
        //     if (haystack[i] == needle[j]) j++;
        //     if (j == needle.Length) return i - needle.Length + 1;
        // }
        // return -1;

        // sunday 算法
        // var shift = new int[26];
        // for (var i = 0; i < shift.Length; i++) shift[i] = needle.Length + 1;
        // for (var i = 0; i < needle.Length; i++) shift[needle[i] - 'a'] = needle.Length - i;
        // for (var i = 0; i <= haystack.Length - needle.Length;) {
        //     var j = 0;
        //     while (j < needle.Length && haystack[i + j] == needle[j]) j++;
        //     if (j == needle.Length) return i;
        //     if (i + needle.Length >= haystack.Length) break;
        //     i += shift[haystack[i + needle.Length] - 'a'];
        // }
        // return -1;

        // // BM 算法，BC + GS 策略
        // if (needle.Length == 0) return 0;
        // if (needle.Length > haystack.Length) return -1;
        //
        // var n = haystack.Length;
        // var m = needle.Length;
        //
        // // BC: 记录字符在模式串中最后一次出现的位置
        // var bc = new int[26];
        // for (var i = 0; i < bc.Length; i++) bc[i] = -1;
        // for (var i = 0; i < m; i++) bc[needle[i] - 'a'] = i;
        //
        // // GS: suffix[k] 表示长度为 k 的好后缀在模式串中的起始下标，prefix[k] 表示长度为 k 的后缀是否也是前缀
        // var suffix = new int[m + 1];
        // var prefix = new bool[m + 1];
        // for (var i = 0; i < suffix.Length; i++) suffix[i] = -1;
        //
        // for (var i = 0; i < m - 1; i++) {
        //     var j = i;
        //     var k = 0;
        //     while (j >= 0 && needle[j] == needle[m - 1 - k]) {
        //         j--;
        //         k++;
        //         suffix[k] = j + 1;
        //     }
        //
        //     if (j == -1) prefix[k] = true;
        // }
        //
        // for (var i = 0; i <= n - m;) {
        //     var j = m - 1;
        //     while (j >= 0 && haystack[i + j] == needle[j]) j--;
        //     if (j < 0) return i;
        //
        //     var x = j - bc[haystack[i + j] - 'a'];
        //     var y = 0;
        //     if (j < m - 1) y = MoveByGs(j);
        //     var step = x > y ? x : y;
        //     if (step < 1) step = 1;
        //     i += step;
        // }
        //
        // return -1;
        //
        // int MoveByGs(int j)
        // {
        //     var k = m - 1 - j; // 好后缀长度
        //     if (suffix[k] != -1) return j - suffix[k] + 1;
        //     for (var r = j + 2; r <= m - 1; r++) {
        //         if (prefix[m - r]) return r;
        //     }
        //     return m;
        // }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
