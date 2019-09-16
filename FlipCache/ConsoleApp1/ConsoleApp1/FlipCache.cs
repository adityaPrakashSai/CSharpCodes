using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class FlipCache<TKey,TVal>
    {
        private Queue<CacheEntry<TKey,TVal>> entries;
        private int cacheSize;
        private Dictionary<TKey, TVal> keyValues;
        int hitCount;
        int memoryReferences;
        private IPolicy<TKey, TVal> Policy;

        public FlipCache(int size, IPolicy<TKey,TVal> policy)
        {
            this.entries = new Queue<CacheEntry<TKey, TVal>>();
            this.keyValues = new Dictionary<TKey, TVal>();
            this.cacheSize = size;
            this.Policy = policy;
            this.hitCount = 0;
            this.memoryReferences = 0;
        }

        public bool Put(TKey entryKey, TVal entryVal)
        {
            bool success = false;
            if(keyValues.ContainsKey(entryKey))
            {
                keyValues.Remove(entryKey);
            }

            if(entries.Count >= this.cacheSize)
            {
                CacheEntry<TKey, TVal> cacheEntryToEvict = Policy.EvictionPolicy(this.entries);
                keyValues.Remove(cacheEntryToEvict.Key);
            }

            CacheEntry<TKey, TVal> cacheEntry = new CacheEntry<TKey, TVal>(entryKey, entryVal);
            entries.Enqueue(cacheEntry);
            keyValues.Add(entryKey, entryVal);
            success = true;

            return success;
        }

        public TVal Get(TKey entryKey)
        {
            TVal val = default(TVal);
            this.memoryReferences++;
            if(keyValues.ContainsKey(entryKey))
            {
                val = keyValues[entryKey];
                this.hitCount++;
            }
            return val;
        }

        public double GetHitRatio()
        {
            if(memoryReferences > 0)
            {
                return this.hitCount;
            }

            else
            {
                return 1.0;
            }
        }
    }
}
