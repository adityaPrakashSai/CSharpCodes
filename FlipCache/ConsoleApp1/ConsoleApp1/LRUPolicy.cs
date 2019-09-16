using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class LRUPolicy<TKey, TVal> : IPolicy<TKey, TVal>
    {
        public CacheEntry<TKey, TVal> EvictionPolicy(Queue<CacheEntry<TKey, TVal>> entries)
        {
            var cacheEntryToEvict = entries.Dequeue();
            return cacheEntryToEvict;
        }
    }
}
