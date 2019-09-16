using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IPolicy<TKey,TVal>
    {
        CacheEntry<TKey, TVal> EvictionPolicy(Queue<CacheEntry<TKey,TVal>> cacheEntries);    
    }
}
