//请你为 最不经常使用（LFU）缓存算法设计并实现数据结构。 
//
// 实现 LFUCache 类： 
//
// 
// LFUCache(int capacity) - 用数据结构的容量 capacity 初始化对象 
// int get(int key) - 如果键 key 存在于缓存中，则获取键的值，否则返回 -1 。 
// void put(int key, int value) - 如果键 key 已存在，则变更其值；如果键不存在，请插入键值对。当缓存达到其容量 
//capacity 时，则应该在插入新项之前，移除最不经常使用的项。在此问题中，当存在平局（即两个或更多个键具有相同使用频率）时，应该去除 最久未使用 的键。 
// 
//
// 为了确定最不常使用的键，可以为缓存中的每个键维护一个 使用计数器 。使用计数最小的键是最久未使用的键。 
//
// 当一个键首次插入到缓存中时，它的使用计数器被设置为 1 (由于 put 操作)。对缓存中的键执行 get 或 put 操作，使用计数器的值将会递增。 
//
// 函数 get 和 put 必须以 O(1) 的平均时间复杂度运行。 
//
// 
//
// 示例： 
//
// 
//输入：
//["LFUCache", "put", "put", "get", "put", "get", "get", "put", "get", "get", 
//"get"]
//[[2], [1, 1], [2, 2], [1], [3, 3], [2], [3], [4, 4], [1], [3], [4]]
//输出：
//[null, null, null, 1, null, -1, 3, null, -1, 3, 4]
//
//解释：
//// cnt(x) = 键 x 的使用计数
//// cache=[] 将显示最后一次使用的顺序（最左边的元素是最近的）
//LFUCache lfu = new LFUCache(2);
//lfu.put(1, 1);   // cache=[1,_], cnt(1)=1
//lfu.put(2, 2);   // cache=[2,1], cnt(2)=1, cnt(1)=1
//lfu.get(1);      // 返回 1
//                 // cache=[1,2], cnt(2)=1, cnt(1)=2
//lfu.put(3, 3);   // 去除键 2 ，因为 cnt(2)=1 ，使用计数最小
//                 // cache=[3,1], cnt(3)=1, cnt(1)=2
//lfu.get(2);      // 返回 -1（未找到）
//lfu.get(3);      // 返回 3
//                 // cache=[3,1], cnt(3)=2, cnt(1)=2
//lfu.put(4, 4);   // 去除键 1 ，1 和 3 的 cnt 相同，但 1 最久未使用
//                 // cache=[4,3], cnt(4)=1, cnt(3)=2
//lfu.get(1);      // 返回 -1（未找到）
//lfu.get(3);      // 返回 3
//                 // cache=[3,4], cnt(4)=1, cnt(3)=3
//lfu.get(4);      // 返回 4
//                 // cache=[3,4], cnt(4)=2, cnt(3)=3 
//
// 
//
// 提示： 
//
// 
// 1 <= capacity <= 10⁴ 
// 0 <= key <= 10⁵ 
// 0 <= value <= 10⁹ 
// 最多调用 2 * 10⁵ 次 get 和 put 方法 
// 
//
// Related Topics 设计 哈希表 链表 双向链表 👍 919 👎 0

namespace LfuCache;

//leetcode submit region begin(Prohibit modification and deletion)

public class LFUCache
{
    private readonly int _capacity;
    private readonly Dictionary<int, LinkedList<int>> _countToKeys;
    private readonly Dictionary<int, int> _keyToCount;
    private readonly Dictionary<int, LinkedListNode<int>> _keyToNode;
    private readonly Dictionary<int, int> _keyToVal;
    private int _minCount;

    public LFUCache(int capacity)
    {
        _capacity = capacity;
        _minCount = 0;
        _keyToVal = new(capacity);
        _keyToCount = new(capacity);
        _countToKeys = new();
        _keyToNode = new(capacity);
    }

    public int Get(int key)
    {
        if (!_keyToVal.TryGetValue(key, out var value)) return -1;

        var count = _keyToCount[key];
        // remove from old count list
        var node = _keyToNode[key];
        var list = _countToKeys[count];
        list.Remove(node);
        if (list.Count == 0) {
            _countToKeys.Remove(count);
            if (_minCount == count) _minCount = count + 1;
        }

        // add to new count list
        var newCount = count + 1;
        _keyToCount[key] = newCount;
        if (!_countToKeys.TryGetValue(newCount, out var newList)) {
            newList = new();
            _countToKeys[newCount] = newList;
        }
        var newNode = newList.AddLast(key);
        _keyToNode[key] = newNode;

        return value;
    }

    public void Put(int key, int value)
    {
        if (_capacity == 0) return;

        if (_keyToVal.ContainsKey(key)) {
            // update value and increase frequency
            _keyToVal[key] = value;
            // reuse Get to update frequency (ignoring returned value)
            Get(key);
            return;
        }

        if (_keyToVal.Count >= _capacity)
            // evict least frequently used key (LRU within the same freq)
            if (_countToKeys.TryGetValue(_minCount, out var minList) && minList.Count > 0) {
                var node = minList.First!;
                var rmKey = node.Value;
                minList.RemoveFirst();
                if (minList.Count == 0) _countToKeys.Remove(_minCount);
                _keyToVal.Remove(rmKey);
                _keyToCount.Remove(rmKey);
                _keyToNode.Remove(rmKey);
            }

        // insert new key with count = 1
        _keyToVal[key] = value;
        _keyToCount[key] = 1;
        _minCount = 1;
        if (!_countToKeys.TryGetValue(1, out var list1)) {
            list1 = new();
            _countToKeys[1] = list1;
        }
        var added = list1.AddLast(key);
        _keyToNode[key] = added;
    }
}

/**
 * Your LFUCache object will be instantiated and called as such:
 * LFUCache obj = new LFUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
//leetcode submit region end(Prohibit modification and deletion)
