public class LRUCache {
    
    private LinkedList<int> queue = new LinkedList<int>();
    private Dictionary<int, int> cache = new Dictionary<int, int>();
    private int cacheSize = 0;
    private readonly int cacheCapacity;

    public LRUCache(int capacity) {
        this.cacheCapacity = capacity;
    }
    
    public int Get(int key) {
        int valueToReturn = 0;
        Console.Write($"[Get](key {key}. ");
        if (cache.ContainsKey(key))
        {
            Console.WriteLine(" Key exists.");
            queue.RemoveLast();
            queue.AddFirst(key);
            
            valueToReturn = cache[key];
        }
        else
        {
            Console.WriteLine(" Does not exist.");
            valueToReturn = -1;
        }

        return valueToReturn;
    }
    
    public void Put(int key, int value) {
        
        Console.Write($"[Put](key {key}, value {value}) ");
        if (cache.ContainsKey(key))
        {
            Console.WriteLine(" key exists");
            cache[key] = value;
        }
        else
        {
            if (cacheSize >= cacheCapacity)
            {                
                int keyToRemove = queue.Last();
                queue.RemoveLast();
                cache.Remove(keyToRemove);
                cacheSize--;
                Console.Write($" Cache capacity {cacheCapacity} exceeds. Remove key {keyToRemove}");
            }

            Console.WriteLine($" Add key {key}.");
            cacheSize++;
            queue.AddFirst(key);            
            cache.Add(key, value);
        }        
    }
}


/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */