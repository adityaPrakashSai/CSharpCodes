using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CacheEntry<TKey, TVal>
    {
        public TKey Key;
        public TVal Value;

        public CacheEntry(TKey key, TVal val)
        {
            this.Key = key;
            this.Value = val;
        }
    }
}
