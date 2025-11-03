//
// 请你设计并实现一个满足 
// LRU (最近最少使用) 缓存 约束的数据结构。
// 
//
// 
// 实现 
// LRUCache 类：
// 
//
// 
// 
// 
// LRUCache(int capacity) 以 正整数 作为容量 capacity 初始化 LRU 缓存 
// int get(int key) 如果关键字 key 存在于缓存中，则返回关键字的值，否则返回 -1 。 
// void put(int key, int value) 如果关键字 key 已经存在，则变更其数据值 value ；如果不存在，则向缓存中插入该组 
//key-value 。如果插入操作导致关键字数量超过 capacity ，则应该 逐出 最久未使用的关键字。 
// 
// 
// 
//
// 函数 get 和 put 必须以 O(1) 的平均时间复杂度运行。 
//
// 
//
// 示例： 
//
// 
//输入
//["LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get"]
//[[2], [1, 1], [2, 2], [1], [3, 3], [2], [4, 4], [1], [3], [4]]
//输出
//[null, null, null, 1, null, -1, null, -1, 3, 4]
//
//解释
//LRUCache lRUCache = new LRUCache(2);
//lRUCache.put(1, 1); // 缓存是 {1=1}
//lRUCache.put(2, 2); // 缓存是 {1=1, 2=2}
//lRUCache.get(1);    // 返回 1
//lRUCache.put(3, 3); // 该操作会使得关键字 2 作废，缓存是 {1=1, 3=3}
//lRUCache.get(2);    // 返回 -1 (未找到)
//lRUCache.put(4, 4); // 该操作会使得关键字 1 作废，缓存是 {4=4, 3=3}
//lRUCache.get(1);    // 返回 -1 (未找到)
//lRUCache.get(3);    // 返回 3
//lRUCache.get(4);    // 返回 4
// 
//
// 
//
// 提示： 
//
// 
// 1 <= capacity <= 3000 
// 0 <= key <= 10000 
// 0 <= value <= 10⁵ 
// 最多调用 2 * 10⁵ 次 get 和 put 
// 
//
// Related Topics 设计 哈希表 链表 双向链表 👍 3602 👎 0

namespace LruCache;

//leetcode submit region begin(Prohibit modification and deletion)
public class LRUCache
{
    public LRUCache(int capacity)
    {
        _dict = new(capacity);
        _capacity = capacity;
        _oldest = null;
        _latest = null;
    }

    public int Get(int key)
    {
        if (_dict.TryGetValue(key, out var node)) {
            MoveToLatest(node);
            return node.val;
        }
        return -1;
    }

    public void Put(int key, int value)
    {
        // if key exists, update value and move to latest
        if (_dict.TryGetValue(key, out var node)) {
            node.val = value;
            MoveToLatest(node);
            return;
        }

        // if no node has been added, add new node and set as oldest and latest
        if (_oldest == null) {
            _oldest = new(value, key);
            _latest = _oldest;
            
        } else {  // else, add new node to latest
            var newNode = new ListNode(value, key);
            _latest.next = newNode;
            newNode.prev = _latest;
            _latest = newNode;
        }
        // if capacity exceeded, remove the oldest node
        if (_dict.Count == _capacity) {
            _dict.Remove(_oldest.key);
            _oldest = _oldest.next;
            if (_oldest != null) _oldest.prev = null;
        }
        
        _dict[key] = _latest;
    }
    
    private void MoveToLatest(ListNode node)
    {
        if (node == _latest) return;

        if (node == _oldest) {
            _oldest = node.next;
            node.next = null;
            _latest.next = node;
            node.prev = _latest;
            _latest = node;
            return;
        }
            
        node.prev.next = node.next;
        node.next.prev = node.prev;
        _latest.next = node;
        node.prev = _latest;
        _latest = node;
    }

    private int _capacity;
    private Dictionary<int, ListNode> _dict;
    private ListNode _oldest;
    private ListNode _latest;
}

public class ListNode
{
    public int val;
    public int key;
    public ListNode? next;
    public ListNode? prev;
    public ListNode(int x, int key)
    {
        val = x;
        this.key = key;
        prev = null;
        next = null;
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
//leetcode submit region end(Prohibit modification and deletion)
